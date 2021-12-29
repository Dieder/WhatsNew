using System.Runtime.CompilerServices;

namespace WhatsNew.New.Net8_10;

public class AsyncStreams
{
    
    private HttpClient httpClient;
    private CancellationTokenSource cancelateAfterASecondOfSearch = new (millisecondsDelay: 1000);

    public AsyncStreams()
    {        
            httpClient = HttpClientFactory.Create();        
    }
    
    private void Close(HttpClient client)
    {
        client.CancelPendingRequests();
        client.Dispose();
    }

    private async IAsyncEnumerable<string> GetCombinedTopResults(string term, [EnumeratorCancellation] CancellationToken ct = default)
    {
        using var ctr = ct.Register(s => Close((HttpClient)s), httpClient);
        
        yield return await httpClient.GetStringAsync($"http://www.google.com?q={term}");
        yield return await httpClient.GetStringAsync($"http://www.bing.com?q={term}");
       
    }

    public async Task<List<string>> GetResultsAsync()
    {
        string searchTerm = "dotnet";
            

        List<string> searchResults = new();
        try
        {
            await foreach (var result in GetCombinedTopResults(searchTerm, cancelateAfterASecondOfSearch.Token))
            {
                searchResults.Add(result);
            }
        }
        catch(TaskCanceledException ex)
        {
            // The time out has been passed for both calls
        }     
        catch(HttpRequestException ex)
        {
            // An open request can fail
        }
        finally
        {
            Close(httpClient);            
        }
    
        return searchResults;
    }
}


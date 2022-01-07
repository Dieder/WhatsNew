namespace JobSeekApi.Data;

public class JobDetails
{
    public string Id { get; init; } = Guid.NewGuid().ToString("n");
    public string? Name { get; set; }
    public string? Contents { get; set; }
}

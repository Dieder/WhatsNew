using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
const string jobsTag = "jobs";

//Swaagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
});

// Sql Lite
string databaseFileName = "./data/jobs.sqlite";
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite($"Data Source={databaseFileName}"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
    app.UseDeveloperExceptionPage();
    app.MapFallback(() => Results.Redirect("/swagger"));
}

app.UseHttpsRedirection();


app.MapGet("/jobs", async ( DatabaseContext db) =>
{
    return await db.JobDetails.ToListAsync();
})
    .AllowAnonymous()
    .Produces<JobDetails>(200)
    .WithTags(jobsTag);

app.MapGet("/jobs/{id}", async ( DatabaseContext db, string id) =>
{
    return await db.JobDetails.FindAsync(id) switch
    {
        JobDetails details => Results.Ok(details),
        null => Results.NotFound()
    };
})
    .Produces<JobDetails>((int)HttpStatusCode.OK)
    .Produces((int) HttpStatusCode.NotFound)
    .WithTags(jobsTag);

app.MapPost("/jobs", async (DatabaseContext db, JobDetails job) => {
    ArgumentNullException.ThrowIfNull(job);
    await db.JobDetails.AddAsync(job);
    await db.SaveChangesAsync();
    return Results.Created("/jobs/{job.Id}", job);
})
    .Produces((int)HttpStatusCode.Created)
    .WithTags(jobsTag);

app.MapPut("/jobs/{id}", async (DatabaseContext db, string id, JobDetails job) =>
{
    ArgumentNullException.ThrowIfNull(job);

    if (job.Id != id)
    {
        return Results.BadRequest();
    }

    db.JobDetails.Update(job);
    await db.SaveChangesAsync();
    return Results.Ok();
})
    .Produces((int)HttpStatusCode.OK)
    .Produces((int) HttpStatusCode.BadRequest)
    .WithTags(jobsTag);

app.MapDelete("/jobs/{id}", async (DatabaseContext db, string id) =>
{
    var job = db.JobDetails.Find(id);

    if (job == null) return Results.NotFound();

    db.JobDetails.Remove(job);
    await db.SaveChangesAsync();
    return Results.Ok();
})
    .Produces((int) HttpStatusCode.OK)
    .Produces((int) HttpStatusCode.NotFound)
    .WithTags(jobsTag);

app.Run();

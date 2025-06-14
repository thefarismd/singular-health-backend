using MiniValidation;
using ScanNotesManager.Core.DTO;
using ScanNotesManager.Core.ServiceContracts;
using ScanNotesManager.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IScanService, ScanService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Routes
app.MapGet("api/scans", (IScanService service) =>
{
    var scans = service.GetAllScans();
    return Results.Ok(scans);
});

app.MapGet("api/scans/{id}/notes", (int id, IScanService service) =>
{
    var notes = service.GetNotesByScanId(id);
    return Results.Ok(notes);
});

app.MapPost("api/scans/{id}/notes", (int id, NoteRequest request, IScanService service) =>
{
    if (!MiniValidator.TryValidate(request, out var errors))
    {
        return Results.BadRequest(errors);
    }

    try
    {
        service.AddNoteToScan(id, request);
        return Results.Ok(new { message = "Note added successfully." });
    }
    catch (ArgumentException ex)
    {
        return Results.NotFound(new { message = ex.Message });
    }
});

app.MapGet("/", () => "The Application is running!");

app.Run();

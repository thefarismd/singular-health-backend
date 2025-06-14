namespace ScanNotesManager.Core.DTO
{
    // GET /scans/{id}/notes
    public class NoteResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
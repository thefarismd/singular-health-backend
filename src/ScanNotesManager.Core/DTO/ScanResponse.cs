namespace ScanNotesManager.Core.DTO
{
    // GET /scans
    public class ScanResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string ScanType { get; set; } = string.Empty;
    }
}
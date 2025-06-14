namespace ScanNotesManager.API.Domain.Entities
{
    public class Scan
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string ScanType { get; set; } = string.Empty; 
    }
}
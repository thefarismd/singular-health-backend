namespace ScanNotesManager.API.Domain.Entities
{
    public class Note
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;   
        
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
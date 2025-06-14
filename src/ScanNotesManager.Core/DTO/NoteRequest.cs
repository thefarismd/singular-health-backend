using System.ComponentModel.DataAnnotations;

// POST /scans/{id}/notes
namespace ScanNotesManager.Core.DTO
{
    public class NoteRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
using ScanNotesManager.API.Domain.Entities;
using ScanNotesManager.Core.DTO;
using ScanNotesManager.Core.ServiceContracts;

namespace ScanNotesManager.Core.Services
{
    public class ScanService : IScanService
    {
        private readonly List<Scan> _scans = [];
        private readonly Dictionary<int, List<Note>> _notesByScanId = [];

        public ScanService()
        {
            // Seed initial scans
            _scans.AddRange(
            [
                new Scan { Id = 1001, ScanType="Head MRI", Date = new DateOnly(2024, 2, 1) },
                new Scan { Id = 1002, ScanType="Chest CT", Date = new DateOnly(2024, 5, 2) }
            ]);

            _notesByScanId[1001] =
            [
                new() { Title = "Initial Report", Content = "No abnormalities detected in Head MRI." }
            ];

            _notesByScanId[1002] =
            [
                new() { Title = "Primary Findings", Content = "Slight inflammation observed." },
                new() { Title = "Follow-up X-Ray", Content = "Mild scarring noted on left lung." }
            ];
        }

        public List<ScanResponse> GetAllScans()
        {
            var scanResponse = _scans.Select(scan => new ScanResponse
            {
                Id = scan.Id,
                Date = scan.Date,
                ScanType = scan.ScanType
            })
            .ToList();

            return scanResponse;
        }

        public List<NoteResponse> GetNotesByScanId(int scanId)
        {
            if (!_notesByScanId.ContainsKey(scanId)) return [];

            var notes = _notesByScanId[scanId];

            var noteResponse = notes.Select(note => new NoteResponse
            {
                Title = note.Title,
                Content = note.Content
            })
            .ToList();

            return noteResponse;
        }

        public void AddNoteToScan(int scanId, NoteRequest request)
        {
            if (!_notesByScanId.ContainsKey(scanId))
            {
                // Need to change this
                throw new ArgumentException($"Scan with ID {scanId} not found.");
            }

            var newNote = new Note
            {
                Title = request.Title,
                Content = request.Content
            };

            _notesByScanId[scanId].Add(newNote);
        }

    }
}
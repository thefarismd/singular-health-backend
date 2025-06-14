using ScanNotesManager.Core.DTO;

namespace ScanNotesManager.Core.ServiceContracts
{
    public interface IScanService
    {
        // Get all scans
        List<ScanResponse> GetAllScans();

        // Get notes for a specific scan
        List<NoteResponse> GetNotesByScanId(int scanId);

        // Add a note to a specific scan
        void AddNoteToScan(int scanId, NoteRequest request);

    }
}
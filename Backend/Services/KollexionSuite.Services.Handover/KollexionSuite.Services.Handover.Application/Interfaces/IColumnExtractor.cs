using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.Interfaces
{
    public interface IColumnExtractor
    {
        ImportFileType FileType { get; }

        Task<List<string>> ExtractHeadersAsync(Stream stream, CancellationToken ct);
    }
}

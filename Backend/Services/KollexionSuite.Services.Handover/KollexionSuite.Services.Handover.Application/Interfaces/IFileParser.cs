using KollexionSuite.Services.Handover.Application.FileParsing;
using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.Interfaces
{
    public interface IFileParser
    {
        ImportFileType FileType { get; }
        Task<IReadOnlyList<ParsedRow>> ParseAsync(Stream stream, CancellationToken ct);
    }
}

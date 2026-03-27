
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Domain.Utilities;
using System.Text;

namespace KollexionSuite.Services.Handover.Application.FileParsing
{
    public class CsvFileParser : IFileParser
    {
        public ImportFileType FileType => ImportFileType.Csv;

        public async Task<IReadOnlyList<ParsedRow>> ParseAsync(Stream stream, CancellationToken ct)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8, true);

            var lines = new List<string>();
            string? line;
            while ((line = await reader.ReadLineAsync(ct)) != null)
                lines.Add(line);

            if (lines.Count <= 1) return Array.Empty<ParsedRow>();

            var headerLine = lines[0];
            var headers = headerLine.Split(',').Select((h, idx) => new { Header = h.Trim(), Index = idx }).ToList();

            var result = new List<ParsedRow>();

            for (int i = 1; i < lines.Count; i++)
            {
                var values = lines[i].Split(',');
                var byIndex = new Dictionary<int, string?>();
                var byHeader = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

                foreach (var h in headers)
                {
                    var value = h.Index < values.Length ? values[h.Index] : string.Empty;
                    byIndex[h.Index] = value;
                    if (!string.IsNullOrWhiteSpace(h.Header))
                        byHeader[h.Header] = value;
                }

                result.Add(new ParsedRow
                {
                    RowIndex = i + 1,
                    ByIndex = byIndex,
                    ByHeader = byHeader
                });
            }

            return result;
        }
    }
}

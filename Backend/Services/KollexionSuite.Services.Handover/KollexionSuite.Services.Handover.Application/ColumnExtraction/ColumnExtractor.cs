using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Domain.Utilities;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace KollexionSuite.Services.Handover.Application.ColumnExtraction
{
    public class ExcelColumnExtractor : IColumnExtractor
    {
        public ImportFileType FileType => ImportFileType.Excel;

        public Task<List<string>> ExtractHeadersAsync(Stream stream, CancellationToken ct)
        {
            using var workbook = new ClosedXML.Excel.XLWorkbook(stream);
            var ws = workbook.Worksheets.First();
            var headerRow = ws.Row(1);

            var headers = headerRow.CellsUsed()
                .Select(c => c.GetString())
                .ToList();

            return Task.FromResult(headers);
        }
    }

    public class CsvColumnExtractor : IColumnExtractor
    {
        public ImportFileType FileType => ImportFileType.Csv;

        public async Task<List<string>> ExtractHeadersAsync(Stream stream, CancellationToken ct)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8, true);
            var line = await reader.ReadLineAsync(ct);
            if (line == null) return new List<string>();

            return line.Split(',').Select(h => h.Trim()).ToList();
        }
    }

    public class JsonColumnExtractor : IColumnExtractor
    {
        public ImportFileType FileType => ImportFileType.Json;

        public async Task<List<string>> ExtractHeadersAsync(Stream stream, CancellationToken ct)
        {
            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct);
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
                return new List<string>();

            var first = doc.RootElement.EnumerateArray().FirstOrDefault();
            return first.EnumerateObject().Select(p => p.Name).ToList();
        }
    }

    public class XmlColumnExtractor : IColumnExtractor
    {
        public ImportFileType FileType => ImportFileType.Xml;

        public async Task<List<string>> ExtractHeadersAsync(Stream stream, CancellationToken ct)
        {
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, ct);
            ms.Position = 0;

            var doc = XDocument.Load(ms);
            var firstRow = doc.Descendants("Row").FirstOrDefault();
            if (firstRow == null) return new List<string>();

            return firstRow.Elements().Select(e => e.Name.LocalName).ToList();
        }
    }
}

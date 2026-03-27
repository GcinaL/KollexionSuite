namespace KollexionSuite.Services.Handover.Application.FileParsing
{
    public class ParsedRow
    {
        public int RowIndex { get; set; }                   // 1-based
        public IReadOnlyDictionary<int, string?> ByIndex { get; init; } = new Dictionary<int, string?>();
        public IReadOnlyDictionary<string, string?> ByHeader { get; init; } = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
    }
}

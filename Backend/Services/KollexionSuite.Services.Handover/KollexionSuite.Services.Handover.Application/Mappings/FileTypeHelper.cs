using KollexionSuite.Services.Handover.Domain.Utilities;

namespace KollexionSuite.Services.Handover.Application.Mappings
{
    public static class FileTypeHelper
    {
        public static ImportFileType FromFileName(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            return ext switch
            {
                ".xlsx" or ".xls" => ImportFileType.Excel,
                ".csv" => ImportFileType.Csv,
                ".json" => ImportFileType.Json,
                ".xml" => ImportFileType.Xml,
                _ => throw new NotSupportedException("Unsupported file format.")
            };
        }
    }

}

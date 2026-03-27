using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KollexionSuite.Services.FileManager.Application.DTOs
{
    public class FileExportRequestDto
    {
        public string Format { get; set; } = "csv"; // csv, xlsx, pdf
        public string FileName { get; set; } = string.Empty;
        public IEnumerable<IDictionary<string, object>> Data { get; set; } = new List<IDictionary<string, object>>();
    }
}

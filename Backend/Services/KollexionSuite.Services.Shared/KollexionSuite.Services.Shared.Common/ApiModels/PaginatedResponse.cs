namespace KollexionSuite.Services.Shared.Common.ApiModels
{
    public class PaginatedResponse<T> : ApiResponse<IEnumerable<T>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public string? Search { get; set; }

        public static PaginatedResponse<T> Create(
            IEnumerable<T> data,
            int pageNumber,
            int pageSize,
            int totalRecords,
            string? search = null)
        {
            return new PaginatedResponse<T>
            {
                Success = true,
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Search = search
            };
        }
    }
}

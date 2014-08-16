
namespace AgileZenApi
{
    public class PagedResponse<T> : ApiResponse<T> where T : class
    {
        /// <summary>
        /// The current page of results
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of items per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of pages in the response
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// The total number of items returned across all pages
        /// </summary>
        public int TotalItems { get; set; }
    }
}

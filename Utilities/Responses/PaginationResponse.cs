using System;

namespace Utilities.Responses
{
    public class PaginationResponse<T> : JsonResponse<T>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string FirstPage { get; set; }
        public string LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }

        public PaginationResponse(int statusCode, T data, int pageNo, int pageSize, string firstPage, string lastPage,
            int totalPages, int totalRecords, string nextPage, string previousPage) :
            base(statusCode, data)
        {
            this.StatusCode = statusCode;
            this.PageNo = pageNo;
            this.PageSize = pageSize;
            this.Data = data;
            this.FirstPage = firstPage;
            this.LastPage = lastPage;
            this.TotalPages = totalPages;
            this.TotalRecords = totalRecords;
            this.NextPage = nextPage;
            this.PreviousPage = previousPage;
        }
    }
}
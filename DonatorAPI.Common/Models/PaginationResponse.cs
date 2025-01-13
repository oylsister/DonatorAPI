namespace DonatorAPI.Common.Models;

public class PaginationResponse<T>
{
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public IList<T> Data { get; set; }

    public PaginationResponse(IList<T> data, int totalRecords, int pageNumber)
    {
        Data = data;
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = data.Count;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
    }
}

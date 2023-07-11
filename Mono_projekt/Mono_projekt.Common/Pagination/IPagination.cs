namespace Mono_projekt.Common.Pagination
{
    public interface IPagination
    {
        int? PageNumber { get; set; }
        int? PageSize { get; set; }
    }
}
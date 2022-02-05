namespace Api.Global
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            PageIndex = pageNumber;
            TotalPages = (int) Math.Ceiling(count /(double) pageSize);
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber- 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

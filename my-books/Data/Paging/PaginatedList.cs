namespace my_books.Data.Paging
{
    // T stands for Type, and we use T when we want to create generic methods or classes
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize); // get the maximum number for example if u have 8 items and the page size 5, in this case u have 2 pages

            this.AddRange(items);
        }

        public bool HasPreviusPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }

        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // process the data
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(); // if u want the second page where the pageSize is 5 and u have 12 items.
                                                                                         // 1 * 5 -> skip the first five and take the second five
                                                                                         // so now u are in the second page.
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }

}

namespace SchoolManagement.Core.Wrappers
{
    public static class IQeurableExtention
    {
        public static async Task<PaginationResult<T>> PaginationExtinsionAsync<T>
            (this IQueryable<T> source, int pageNumber = 1, int pageSize = 10)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("List is null");
            }
            pageNumber = pageNumber >= 1 ? pageNumber : 1;
            pageSize = pageSize >= 1 ? pageSize : 10;
            int count = source.Count();
            if (count == 0)
            {
                return PaginationResult<T>.Success(new List<T>(), pageSize, pageNumber, count);
            }
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginationResult<T>.Success(items, pageSize, pageNumber, count);
        }
    }
}

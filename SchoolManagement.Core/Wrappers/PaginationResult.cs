namespace SchoolManagement.Core.Wrappers
{
    public class PaginationResult<T>
    {
        #region Fields
        public List<T> data { get; set; }

        public int pageSize { get; set; }

        public int currentPage { get; set; }

        public int totalPages { get; set; }

        public int totalCount { get; set; }

        public bool hasPreviousePage => currentPage > 1;

        public bool hasNextiousePage => totalPages > currentPage;

        public object Meta { get; set; }

        public List<string> messages { get; set; } = new();

        public bool succeded { get; set; }



        #endregion
        #region Constructors
        public PaginationResult(List<T> values)
        {
            data = values;
        }

        internal PaginationResult(bool Succeded, List<T> _data = default!, int _pageSize = 10, int _currentPage = 1,
                                  int _totalCount = 0, List<string> _messages = null!)
        {
            pageSize = _pageSize <= 0 ? 10 : _pageSize;
            totalCount = _totalCount;
            totalPages = (int)Math.Ceiling(_totalCount / (double)pageSize);
            currentPage = _currentPage <= totalPages ? _currentPage : totalPages;
            succeded = Succeded;
            messages = _messages;
            data = _data;
        }

        #endregion

        #region Methods
        public static PaginationResult<T> Success(List<T> _data, int _pageSize = 10,
                                                    int _currentPage = 1, int _totalCount = 0)
        {
            return new(true, _data, _pageSize, _currentPage, _totalCount);
        }
        #endregion


    }
}

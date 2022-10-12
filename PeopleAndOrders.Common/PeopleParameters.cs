namespace PeopleAndOrders.Common
{
    public class PeopleParameters
    {
        public PeopleParameters()
        {
            OrderBy = "orderDate";
        }
        public string OrderBy { get; set; }
        public int PageNumber { get; set; }

        const int maxPageSize = 4;
        private int _pageSize = 3;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}

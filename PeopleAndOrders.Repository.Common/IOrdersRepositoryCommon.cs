using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Repository.Common
{
    public interface IOrdersRepositoryCommon
    {
        Task<List<Orders>> FindAllOrdersAsync(Paging paging, Sorting sort, Filtering filtering);
        Task<Orders> FindOrderByIdAsync(int id);
        Task<Orders> PostOrderAsync(OrdersRest orderRest);
        Task<Orders> PutOrderAsync(int id, Orders orders);
        Task DeleteOrderAsync(Orders orders);
    }
}

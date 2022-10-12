using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service.Common
{
    public interface IOrdersServiceCommon
    {
        Task<List<Orders>> FindAllOrdersAsync(Paging paging, Sorting sort, Filtering filtering);
        Task<Orders> FindOrderByIdAsync(int id);
        Task PostOrderAsync(OrdersRest order);
        Task PutOrderAsync(int id, Orders order);
        Task DeleteOrderAsync(Orders order);
    }
}

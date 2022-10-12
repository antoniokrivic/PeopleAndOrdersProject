using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Repository;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service
{
    public class OrdersService : IOrdersServiceCommon
    {
        public OrdersService(IOrdersRepositoryCommon repository)
        {
            this.repository = repository;
        }
        public OrdersService(){}
        private IOrdersRepositoryCommon repository { get; set; }
        
        public async Task<List<Orders>> FindAllOrdersAsync(Paging paging, Sorting sort, Filtering filtering)
        {
            List<Orders> order = await repository.FindAllOrdersAsync(paging, sort, filtering);
            return order;
        }

        public async Task<Orders> FindOrderByIdAsync(int id)
        {
            Orders order = await repository.FindOrderByIdAsync(id);
            return order;
        }
        public async Task PostOrderAsync(OrdersRest order)
        {
            repository.PostOrderAsync(order);
        }
        public async Task PutOrderAsync(int id, Orders order)
        {
            repository.PutOrderAsync(id, order);
        }
        public async Task DeleteOrderAsync(Orders order)
        {
            repository.DeleteOrderAsync(order);
        }
    }
}
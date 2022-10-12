using PeopleAndOrders.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Model
{
    public class OrdersRest : IOrdersRestCommon
    {
        //without Id_User property
        public int Id_Order { get; set; }
        public string Product { get; set; }
        public int Total_Price { get; set; }
        public DateTime OrderDate { get; set; }

        public OrdersRest()
        {
            this.Id_Order = 0;
            this.Product = "";
            this.Total_Price = 0;
            this.OrderDate = new DateTime();
        }
        public OrdersRest(int id_Order, string product, int total_Price, DateTime orderDate)
        {
            Id_Order = id_Order;
            Product = product;
            Total_Price = total_Price;
            OrderDate = orderDate;
        }
    }
}

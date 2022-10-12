using PeopleAndOrders.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PeopleAndOrders.Model
{
    public class Orders : IOrdersModelCommon
    {
        private object privObj;
        public Orders(int id_Order, string product, int total_Price, object privObj,DateTime orderDate)
        {
            Id_Order = id_Order;
            Product = product;
            Total_Price = total_Price;
            this.privObj = privObj;
            OrderDate = orderDate;
            
        }

        public Orders()
        {
            Id_Order = 0;
            Id_User = 0;
            Product = "";
            Total_Price = 0;

        }


        public int Id_Order { get; set; } 
        public int Id_User { get; set; }
        public string Product { get; set; }
        public int Total_Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

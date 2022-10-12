using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Model.Common
{
    
    public interface IOrdersModelCommon
    {
        int Id_Order { get; set; }         
        string Product { get; set; }
        int Total_Price { get; set; }
    }
}

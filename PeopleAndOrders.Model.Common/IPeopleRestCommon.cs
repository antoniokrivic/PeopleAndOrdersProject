using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Model.Common
{
    public interface IPeopleRestCommon
    {
        int Id { get; set; }
        string Address { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string City { get; set; }
    }
}

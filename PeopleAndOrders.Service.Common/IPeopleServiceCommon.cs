using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service.Common
{
    public interface IPeopleServiceCommon
    {
        Task<List<People>> FindAllPeopleAsync(Paging paging, Sorting sort, Filtering filtering);
        Task<People> FindPeopleByIdAsync(int id);
        Task PostPeopleAsync(PeopleRest people);
        Task PutPeopleAsync(int id, People people);
        Task DeletePeopleAsync(People people, int id);
    }
}

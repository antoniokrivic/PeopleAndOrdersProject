using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Repository.Common
{
    public interface IPeopleRepositoryCommon
    {
        Task<List<People>> FindAllPeopleAsync(Paging paging, Sorting sort, Filtering filtering);
        Task<People> FindPeopleByIdAsync(int id);
        Task<PeopleRest> PostPeopleAsync(PeopleRest people);
        Task<People> PutPeopleAsync(int id, People people);
        Task DeletePeopleAsync(People people, int id);
    }
}

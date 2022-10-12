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
    public class PeopleService : IPeopleServiceCommon
    {
        public PeopleService(IPeopleRepositoryCommon repository)
        {
            this.repository = repository;
        }
        private IPeopleRepositoryCommon repository { get; set; }

        public async Task<List<People>> FindAllPeopleAsync(Paging paging, Sorting sort, Filtering filtering) { 
            List<People> people = await repository.FindAllPeopleAsync(paging, sort, filtering);
            return people;
        }

        public async Task<People> FindPeopleByIdAsync(int id)
        {
            People people = await repository.FindPeopleByIdAsync(id);
            return people;
        }

        public async Task PostPeopleAsync(PeopleRest people)
        {
            repository.PostPeopleAsync(people);
        }

        public async Task PutPeopleAsync(int id, People people)
        {
            repository.PutPeopleAsync(id, people);
        }

        public async Task DeletePeopleAsync(People people, int id)
        {
            repository.DeletePeopleAsync(people, id);
        }
    }
}

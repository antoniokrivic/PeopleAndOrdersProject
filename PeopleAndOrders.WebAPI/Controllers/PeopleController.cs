using AutoMapper;
using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Service;
using PeopleAndOrders.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace PeopleAndOrders.WebAPI.Controllers
{
    public class PeopleController : ApiController
    {
        public PeopleController() { }
        public IMapper Mapper { get; set; }
        private IPeopleServiceCommon service { get; set; }
        public PeopleController(IPeopleServiceCommon service)
        {
            this.service = service;
        }


        public async Task<HttpResponseMessage> FindAllPeopleAsync(int pageSize, int pageNumber, string sortBy,string sortOrder,DateTime preMade,DateTime postMade,bool goodOrderReview)
        {
            Paging paging = new Paging(pageSize, pageNumber);
            Sorting sorting = new Sorting(sortBy, sortOrder);
            Filtering filtering = new Filtering(preMade, postMade, goodOrderReview);
            List<People> people = await service.FindAllPeopleAsync(paging,sorting,filtering);

            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, people);
        }

        public async Task<HttpResponseMessage> FindPeopleByIdAsync(int id)
        {
            People people = await service.FindPeopleByIdAsync(id);
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, people);
        }
        
        public async Task<HttpResponseMessage> DeletePeopleAsync(People people, int id)
        {
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.DeletePeopleAsync(people, id);
            return Request.CreateResponse(HttpStatusCode.OK, people);
        }
        
        public async Task<HttpResponseMessage> PutPeopleAsync(int id, People people)
        {
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PutPeopleAsync(id, people);
            return Request.CreateResponse(HttpStatusCode.OK, people);
        }
      
        public async Task<HttpResponseMessage> PostPeopleAsync(PeopleRest people)
        {
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PostPeopleAsync(people);
            return Request.CreateResponse(HttpStatusCode.OK, people);
        }
    }
}



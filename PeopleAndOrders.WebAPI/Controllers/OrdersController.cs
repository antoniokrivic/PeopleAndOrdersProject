using AutoMapper;
using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Service;
using PeopleAndOrders.Service.Common;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace PeopleAndOrders.WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        public OrdersController(){}
        private IOrdersServiceCommon service { get; set; }
        private IMapper Mapper { get; set; }
        
        public OrdersController(IOrdersServiceCommon service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
      
        [HttpGet]
        public async Task<HttpResponseMessage> FindAllOrdersAsync(int pageSize, int pageNumber, string sortBy, string sortOrder, DateTime? preMade,DateTime?postMade,bool goodOrderReview)
        {
            pageSize = 4;
            pageNumber = 1;
            sortBy = "model";
            sortOrder = "ascending";                                                                                  /*Setup*/
            preMade = null;
            postMade = null;
            goodOrderReview = false;
            

            Paging paging = new Paging(pageNumber, pageSize);
            Sorting sort= new Sorting(sortBy, sortOrder);
            Filtering filtering = new Filtering(preMade, postMade, goodOrderReview);
            
            List<Orders> order = await service.FindAllOrdersAsync(paging, sort, filtering); 
            List<OrdersRest> ordersRest = MapToRest(order);
            ordersRest = Mapper.Map(order, ordersRest);

            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ordersRest);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> FindOrderByIdAsync(int id)
        {
            Orders order = await service.FindOrderByIdAsync(id);
            OrdersRest orders = Mapper.Map<OrdersRest>(order);

            if (orders == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> PutOrder(int id, Orders order)
        {
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PutOrderAsync(id, order);
            OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
            return Request.CreateResponse(HttpStatusCode.OK, _ordersRest);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostOrder(OrdersRest ordersRest)
        {
            if (ordersRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PostOrderAsync(ordersRest);
            Orders orders = Mapper.Map<Orders>(ordersRest);
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrder(Orders order)
        {
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.DeleteOrderAsync(order);
            OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
            return Request.CreateResponse(HttpStatusCode.OK, _ordersRest);
        }
        public List<OrdersRest> MapToRest(List<Orders> orders)
        {
            List<OrdersRest> ordersRest = new List<OrdersRest>();

            if (orders == null)
            {
                return null;
            }
            foreach (Orders order in orders)
            {
                OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
                ordersRest.Add(_ordersRest);
            }
            return ordersRest;
        }

    }
}

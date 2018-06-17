﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopOnline.Model.Models;
using ShopOnline.Service;
using ShopOnline.Web.Infrastructure.Core;
using ShopOnline.Web.Infrastructure.Extensions;
using ShopOnline.Web.Models;
using ShopOnline.Web.Providers;
using ShopOnline.Web.SignalR;

namespace ShopOnline.Web.Api
{
    [RoutePrefix("api/Order")]
    [Authorize]
    public class OrderController : ApiControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService, IErrorService errorService) : base(errorService)
        {
            this._orderService = orderService;
        }

        [Route("getlistpaging")]
        [HttpGet]
        [Permission(Action = "Read", Function = "ORDER")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, string startDate, string endDate,
            string customerName, string paymentStatus, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRows = 0;
                IEnumerable<Order> listOrderDb = _orderService.GetList(startDate, endDate, customerName, paymentStatus, page, pageSize, out totalRows);
                IEnumerable<OrderViewModel> listOrderVm = Mapper.Map<IEnumerable<OrderViewModel>>(listOrderDb);
                PaginationSet<OrderViewModel> pagination = new PaginationSet<OrderViewModel>()
                {
                    PageIndex = page,
                    PageSize = pageSize,
                    TotalRows = totalRows,
                    Items = listOrderVm,
                };
                return request.CreateResponse(HttpStatusCode.OK, pagination);
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        [Permission(Action = "Read", Function = "ORDER")]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                Order OrderDb = _orderService.GetDetail(id);

                if (OrderDb != null)
                {
                  OrderViewModel OrderDetailVm = Mapper.Map<OrderViewModel>(OrderDb);
                    return request.CreateResponse(HttpStatusCode.OK, OrderDetailVm);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
                }
            });
        }

        [HttpPost]
        [Route("add")]
        //[Authorize(Roles = "AddUser")]
        [Permission(Action = "Create", Function = "USER")]
        public HttpResponseMessage Create(HttpRequestMessage request, OrderViewModel orderVm)
        {
            return CreateHttpResponse(request, () =>
             {
                 if (ModelState.IsValid)
                 {
                     Order orderDb = new Order();
                     orderDb.UpdateOrder(orderVm);
                     var listOrderDetails = new List<OrderDetail>();

                     foreach (var item in orderVm.OrderDetails)
                     {
                         listOrderDetails.Add(new OrderDetail()
                         {
                             ProductID = item.ProductID,
                             Quantity = item.Quantity,
                             Price = item.Price,                          
                         });
                     }
                     orderDb.OrderDetails = listOrderDetails;
                     _orderService.Create(orderDb);
                     _orderService.Save();

                     //push notification
                     var annoucement = _orderService.GetDetail(orderDb.ID);
                     ShopOnlineHub.PushToAllUsers(Mapper.Map<OrderViewModel>(annoucement), null);
                     return request.CreateResponse(HttpStatusCode.Created, orderVm);
                 }
                 else
                     return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
             });
        }
        [Route("getalldetails/{id}")]
        [HttpGet]
        [Permission(Action = "Read", Function = "ORDER")]
        //[Authorize(Roles = "ViewUser")]
        public HttpResponseMessage GetOrderDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                IEnumerable<OrderDetail> listOrderDetailDb = _orderService.GetOrderDetails(id);
                if (listOrderDetailDb.Count() > 0)
                {
                    IEnumerable<OrderDetailViewModel> listOrderDetailVm = Mapper.Map<IEnumerable<OrderDetailViewModel>>(listOrderDetailDb);
                    return request.CreateResponse(HttpStatusCode.OK, listOrderDetailVm);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
                }
            });
        }
        [Route("delete")]
        [HttpDelete]
        [Permission(Action = "Delete", Function = "ORDER")]
        //[Authorize(Roles = "ViewUser")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                _orderService.DeleteOrder(id);
                _orderService.Save();
               return request.CreateResponse(HttpStatusCode.OK, id);
            });
        }


    }
}
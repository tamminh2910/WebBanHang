using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBanHang.Model.Entities;
using WebBanHang.Service;
using WebBanHang.Web.Infrastructure.Core;
using WebBanHang.Web.Infrastructure.Extensions;
using WebBanHang.Web.Models;

namespace WebBanHang.Web.Api
{
    [RoutePrefix("api/orderdetail")]
    [Authorize]
    public class OrderDetailController : ApiControllerBase
    {
        private IOrderDetailService _orderDetailService;
        private IProductService _productService;
        public OrderDetailController(IErrorService errorService, IOrderDetailService orderDetailService,IProductService productService) : base(errorService)
        {
            this._orderDetailService = orderDetailService;
            this._productService = productService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _orderDetailService.GetAll();
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.OrderID).Skip(page * pageSize).Take(pageSize);


               
                var responseData = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailViewModel>>(query);

                PaginationSet<OrderDetailViewModel> paginationSet = new PaginationSet<OrderDetailViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var product = _productService.GetAll();
                var model = _orderDetailService.GetOrderDetails(id).Join(product, od => od.ProductID, prod => prod.ProductID, (od, prod) => new {OrderID= od.OrderID,ProductName=prod.Name,UnitPrice=od.UnitPrice,Quantity=od.Quantity,Discount=od.Discount });
                
                

                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, OrderDetailViewModel orderDetailVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newOrderDetail = new OrderDetail();
                    newOrderDetail.UpdateOrderDetail(orderDetailVm);

                    _orderDetailService.Add(newOrderDetail);
                    _orderDetailService.Save();

                    var responseData = Mapper.Map<OrderDetail, OrderDetailViewModel>(newOrderDetail);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, OrderDetailViewModel orderDetailVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbOrderDetail = _orderDetailService.GetById(orderDetailVm.OrderID);
                    dbOrderDetail.UpdateOrderDetail(orderDetailVm);

                    _orderDetailService.Update(dbOrderDetail);
                    _orderDetailService.Save();

                    var responseData = Mapper.Map<OrderDetail, OrderDetailViewModel>(dbOrderDetail);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldOrderDetail = _orderDetailService.Delete(id);
                    _orderDetailService.Save();

                    var responseData = Mapper.Map<OrderDetail, OrderDetailViewModel>(oldOrderDetail);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

    }
}

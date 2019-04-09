using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebBanHang.Model.Entities;
using WebBanHang.Service;
using WebBanHang.Web.Infrastructure.Core;
using WebBanHang.Web.Infrastructure.Extensions;
using WebBanHang.Web.Models;

namespace WebBanHang.Web.Api
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(IErrorService errorService, ICustomerService customerService) : base(errorService)
        {
            this._customerService = customerService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _customerService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(query);

                PaginationSet<CustomerViewModel> paginationSet = new PaginationSet<CustomerViewModel>()
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

        [Route("getallcustomers")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomer(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customerService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _customerService.GetById(id);
                var responseData = Mapper.Map<Customer, CustomerViewModel>(model);


                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CustomerViewModel customerVm)
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
                    var newCustomer = new Customer();
                    newCustomer.CreatedDate = DateTime.Now;
                    newCustomer.UpdateCustomer(customerVm);

                    _customerService.Add(newCustomer);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(newCustomer);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CustomerViewModel customerVm)
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
                    var dbCustomer = _customerService.GetById(customerVm.CustomerID);
                    dbCustomer.UpdateCustomer(customerVm);

                    _customerService.Update(dbCustomer);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(dbCustomer);

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
                    var oldCustomer = _customerService.Delete(id);
                    _customerService.Save();

                    var responseData = Mapper.Map<Customer, CustomerViewModel>(oldCustomer);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("deleteMulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string listItem)
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
                    var items = new JavaScriptSerializer().Deserialize<List<int>>(listItem);
                    foreach (var item in items)
                    {
                        _customerService.Delete(item);

                    }
                    _customerService.Save();


                    response = request.CreateResponse(HttpStatusCode.OK, items.Count);
                }
                return response;
            });
        }

    }
}

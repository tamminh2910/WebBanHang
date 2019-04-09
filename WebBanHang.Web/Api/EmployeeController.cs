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
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IErrorService errorService, IEmployeeService employeeService) : base(errorService)
        {
            this._employeeService = employeeService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _employeeService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(query);

                PaginationSet<EmployeeViewModel> paginationSet = new PaginationSet<EmployeeViewModel>()
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

                var model = _employeeService.GetById(id);

                var responseData = Mapper.Map<Employee, EmployeeViewModel>(model);


                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, EmployeeViewModel employeeVm)
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
                    var newEmployee = new Employee();
                    newEmployee.UpdateEmployee(employeeVm);

                    _employeeService.Add(newEmployee);
                    _employeeService.Save();

                    var responseData = Mapper.Map<Employee, EmployeeViewModel>(newEmployee);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, EmployeeViewModel employeeVm)
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
                    var dbEmployee = _employeeService.GetById(employeeVm.EmployeeID);
                    dbEmployee.UpdateEmployee(employeeVm);

                    _employeeService.Update(dbEmployee);
                    _employeeService.Save();

                    var responseData = Mapper.Map<Employee, EmployeeViewModel>(dbEmployee);

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
                    var oldEmployee = _employeeService.Delete(id);
                    _employeeService.Save();

                    var responseData = Mapper.Map<Employee, EmployeeViewModel>(oldEmployee);

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
                        _employeeService.Delete(item);

                    }
                    _employeeService.Save();


                    response = request.CreateResponse(HttpStatusCode.OK, items.Count);
                }
                return response;
            });
        }

    }
}

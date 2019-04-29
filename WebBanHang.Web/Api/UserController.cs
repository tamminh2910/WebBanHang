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
    [RoutePrefix("api/user")]
    public class UserController : ApiControllerBase
    {
        private IUserSerivce _userService;

        public UserController(IErrorService errorService, IUserSerivce userSerivce) : base(errorService)
        {
            this._userService = userSerivce;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _userService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(query);

                PaginationSet<ApplicationUserViewModel> paginationSet = new PaginationSet<ApplicationUserViewModel>()
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

        [Route("GetAllApplicationUsers")]
        [HttpGet]
        public HttpResponseMessage GetAllApplicationUsers(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _userService.GetAll();

                var responseData = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getbyid")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _userService.GetById(id);

                var responseData = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ApplicationUserViewModel applicationUserVm)
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
                    var newApplicationUser = new ApplicationUser();
                    newApplicationUser.UpdateUser(applicationUserVm);

                    _userService.Add(newApplicationUser);
                    _userService.Save();

                    var responseData = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(newApplicationUser);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ApplicationUserViewModel applicationUserVm)
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
                    var dbApplicationUser = _userService.GetById(applicationUserVm.Id);
                    dbApplicationUser.UpdateUser(applicationUserVm);

                    _userService.Update(dbApplicationUser);
                    _userService.Save();

                    var responseData = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(dbApplicationUser);

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
                    var oldApplicationUser = _userService.Delete(id);
                    _userService.Save();

                    var responseData = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(oldApplicationUser);

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
                        _userService.Delete(item);
                    }
                    _userService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, items.Count);
                }
                return response;
            });
        }
    }
}
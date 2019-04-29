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
    [RoutePrefix("api/categorychild")]
    [Authorize]
    public class CategoryChildController : ApiControllerBase
    {
        private ICategoryChildService _categoryChildService;

        public CategoryChildController(IErrorService errorService, ICategoryChildService categoryChildService) :
            base(errorService)
        {
            this._categoryChildService = categoryChildService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _categoryChildService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CategoryChildID).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<CategoryChild>, IEnumerable<CategoryChildViewModel>>(query);

                PaginationSet<CategoryChildViewModel> paginationSet = new PaginationSet<CategoryChildViewModel>()
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

        [Route("getallchilds")]
        [HttpGet]
        public HttpResponseMessage GetAllCategoryParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _categoryChildService.GetAll();
                var responseData = Mapper.Map<IEnumerable<CategoryChild>, IEnumerable<CategoryChildViewModel>>(model);
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
                var model = _categoryChildService.GetById(id);

                var responseData = Mapper.Map<CategoryChild, CategoryChildViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CategoryChildViewModel categoryChildVm)
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
                    var newCategoryChild = new CategoryChild();
                    newCategoryChild.UpdateCategoryChild(categoryChildVm);

                    _categoryChildService.Add(newCategoryChild);
                    _categoryChildService.Save();

                    var responseData = Mapper.Map<CategoryChild, CategoryChildViewModel>(newCategoryChild);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CategoryChildViewModel categoryChildVm)
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
                    var dbCategoryChild = _categoryChildService.GetById(categoryChildVm.CategoryChildID);
                    dbCategoryChild.UpdateCategoryChild(categoryChildVm);

                    _categoryChildService.Update(dbCategoryChild);
                    _categoryChildService.Save();

                    var responseData = Mapper.Map<CategoryChild, CategoryChildViewModel>(dbCategoryChild);

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
                    var oldCategoryChild = _categoryChildService.Delete(id);
                    _categoryChildService.Save();

                    var responseData = Mapper.Map<CategoryChild, CategoryChildViewModel>(oldCategoryChild);

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
                        _categoryChildService.Delete(item);
                    }
                    _categoryChildService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, items.Count);
                }
                return response;
            });
        }
    }
}
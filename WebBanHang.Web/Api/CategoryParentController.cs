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
    [RoutePrefix("api/categoryparent")]
    public class CategoryParentController : ApiControllerBase
    {
        private ICategoryParentService _categoryParentService;

        public CategoryParentController(IErrorService errorService, ICategoryParentService categoryParentService) : base(errorService)
        {
            this._categoryParentService = categoryParentService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _categoryParentService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<CategoryParent>, IEnumerable<CategoryParentViewModel>>(query);

                PaginationSet<CategoryParentViewModel> paginationSet = new PaginationSet<CategoryParentViewModel>()
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

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllCategoryParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _categoryParentService.GetAll();
                var responseData = Mapper.Map<IEnumerable<CategoryParent>, IEnumerable<CategoryParentViewModel>>(model);
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

                var model = _categoryParentService.GetById(id);

                var responseData = Mapper.Map<CategoryParent, CategoryParentViewModel>(model);


                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CategoryParentViewModel categoryParentVm)
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
                    var newCategoryParent = new CategoryParent();
                    newCategoryParent.UpdateCategoryParent(categoryParentVm);

                    _categoryParentService.Add(newCategoryParent);
                    _categoryParentService.Save();

                    var responseData = Mapper.Map<CategoryParent, CategoryParentViewModel>(newCategoryParent);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CategoryParentViewModel categoryParentVm)
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
                    var dbCategoryParent = _categoryParentService.GetById(categoryParentVm.CategoryParentID);
                    dbCategoryParent.UpdateCategoryParent(categoryParentVm);

                    _categoryParentService.Update(dbCategoryParent);
                    _categoryParentService.Save();

                    var responseData = Mapper.Map<CategoryParent, CategoryParentViewModel>(dbCategoryParent);

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
                    var oldCategoryParent = _categoryParentService.Delete(id);
                    _categoryParentService.Save();

                    var responseData = Mapper.Map<CategoryParent, CategoryParentViewModel>(oldCategoryParent);

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
                        _categoryParentService.Delete(item);

                    }
                    _categoryParentService.Save();


                    response = request.CreateResponse(HttpStatusCode.OK, items.Count);
                }
                return response;
            });
        }
    }
}
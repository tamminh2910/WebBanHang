using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBanHang.Model.Entities;
using WebBanHang.Service;
using WebBanHang.Web.Infrastructure.Core;

namespace WebBanHang.Web.Api
{
    [RoutePrefix("api/categorychild")]
    public class CategoryChildController : ApiControllerBase
    {
        ICategoryChildService _categoryChildService;
        
        public CategoryChildController(IErrorService errorService, ICategoryChildService categoryChildService) :
            base(errorService)
        {
            this._categoryChildService = categoryChildService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _categoryChildService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, CategoryChild categoryChild)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _categoryChildService.Add(categoryChild);
                    _categoryChildService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, CategoryChild postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _categoryChildService.Update(postCategory);
                    _categoryChildService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _categoryChildService.Delete(id);
                    _categoryChildService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
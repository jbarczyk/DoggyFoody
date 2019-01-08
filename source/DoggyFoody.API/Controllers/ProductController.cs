using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services;
using DoggyFoody.Services.Filter;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace DoggyFoody.API.Controllers
{
    [RoutePrefix("api/products")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Product>))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, _productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage Get(HttpRequestMessage request, long id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                if (product != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, product);
                }

                return request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("filter")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Product>))]
        public HttpResponseMessage Filter(HttpRequestMessage request, [FromBody]FilterParams filterParams)
        {
            try
            {
                var products = _productService.GetProducts(filterParams);
                return request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch(Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addColumn")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddColumn(HttpRequestMessage request, long productId, long userId, [FromBody]Column column)
        {
            try
            {
                await _productService.AddColumnToProduct(userId, productId, column);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addRate")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddRate(HttpRequestMessage request, long productId, long userId, [FromBody]Rate rate)
        {
            try
            {
                await _productService.AddRateToProduct(userId, productId, rate);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addComment")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddComment(HttpRequestMessage request, long productId, long userId, [FromBody]Comment comment)
        {
            try
            {
                await _productService.AddCommentToProduct(userId, productId, comment);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, long id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services;
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
    [RoutePrefix("api/manufacturers")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ManufacturersController : ApiController
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Manufacturer>))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, _manufacturerService.GetAllManufacturers());
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Manufacturer))]
        public HttpResponseMessage Get(HttpRequestMessage request, long id)
        {
            try
            {
                var user = _manufacturerService.GetManufacturer(id);
                if (user != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, user);
                }

                return request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request, [FromBody]Manufacturer manufacturer)
        {
            try
            {
                await _manufacturerService.AddManufacturer(manufacturer);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addAdvertisement")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddAdvertisement(HttpRequestMessage request, long id, [FromBody]Advertisement advertisement)
        {
            try
            {
                await _manufacturerService.AddAdvertisement(id, advertisement);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addProduct")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddProduct(HttpRequestMessage request, long id, [FromBody]Product product)
        {
            try
            {
                await _manufacturerService.AddProductToManufacturer(id, product);
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
                await _manufacturerService.DeleteManufacturer(id);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

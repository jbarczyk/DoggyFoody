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
    [RoutePrefix("api/advertisements")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdvertisementController : ApiController
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Advertisement>))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, _advertisementService.GetAllAdvertisements());
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Advertisement))]
        public HttpResponseMessage Get(HttpRequestMessage request, long id)
        {
            try
            {
                var advert = _advertisementService.GetAdvertisement(id);
                if (advert != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, advert);
                }

                return request.CreateErrorResponse(HttpStatusCode.NotFound, "Advertisement not found");
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Add(HttpRequestMessage request, long id)
        {
            try
            {
                await _advertisementService.DeleteAdvertisement(id);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Advertisement>))]
        public HttpResponseMessage GetRandom(HttpRequestMessage request, int count)
        {
            try
            {
                var result = _advertisementService.GetRandomAdvertisements(count);
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

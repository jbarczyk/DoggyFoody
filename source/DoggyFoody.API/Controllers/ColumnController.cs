using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace DoggyFoody.API.Controllers
{
    [RoutePrefix("api/columns")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ColumnController : ApiController
    {
        private readonly IColumnService _columnService;

        public ColumnController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Column>))]
        public HttpResponseMessage GetRandom(HttpRequestMessage request, int count)
        {
            try
            {
                var result = _columnService.GetRandomColumns(count);
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

using DoggyFoody.Contracts.Database.Models;
using DoggyFoody.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DoggyFoody.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [ResponseType(typeof(IEnumerable<User>))]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, _userService.GetAllUsers());
            }
            catch(Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

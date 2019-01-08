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
    [RoutePrefix("api/users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                return request.CreateResponse(HttpStatusCode.OK, _userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public HttpResponseMessage Get(HttpRequestMessage request, long id)
        {
            try
            {
                var user = _userService.GetUser(id);
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

        [Route("login")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public HttpResponseMessage Login(HttpRequestMessage request, string username, string password)
        {
            try
            {
                var user = _userService.GetUser(username, password);
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

        [Route("register")]
        [HttpPost]
        public async Task<HttpResponseMessage> Register(HttpRequestMessage request, [FromBody]User user)
        {
            try
            {
                await _userService.AddUser(user);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addColumn")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddColumnToUser(HttpRequestMessage request, long id, [FromBody]Column column)
        {
            try
            {
                await _userService.AddColumnToUser(id, column);
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
                await _userService.DeleteUser(id);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

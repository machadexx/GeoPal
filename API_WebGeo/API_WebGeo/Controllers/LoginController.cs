using API_WebGeo.Models.Registo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using API_WebGeo.Models.Login;


namespace API_WebGeo.Controllers
{
    [EnableCors(origins: "http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class LoginController : ApiController
    {
        private ILoginRepository repository;

        public LoginController() { }

        public LoginController(ILoginRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(Login request)
        {
            try
            {
                
                bool isValid = repository.IsValidUser(request.Email, request.Password).Result;

                if (isValid)
                {
                    
                    return Ok();
                }
                else
                {
                    
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace desafio.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        // GET api/profile/5
        [HttpGet("profile/{id}")]
        public object Profile(Guid id)
        {
            var service = new RegisterUserService();
            
            try
            {
                return service.GetByUserId(id);
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }

        // POST api/signup
        [HttpPost("signup")]
        public object SignUp([FromBody] SignUpModel model)
        {
            var service = new RegisterUserService();
            
            try
            {
                return service.Register(model);
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }
        
        // POST api/signin
        [HttpPost]
        public void SignIn([FromBody]string value)
        {
            //return value;
        }
    }
}

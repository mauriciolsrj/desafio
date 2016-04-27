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
        // POST api/accounts/signup
        [HttpPost("signup")]
        public object SignUp([FromBody] SignUpModel model)
        {
            try
            {
                var service = new RegisterUserService();
                model.senha = CryptoUtility.GetMD5Hash(model.senha);
                return service.Register(model);
            }
            catch (ArgumentException ae)
            {
                return new ErrorModel(){
                    mensagem = ae.Message,
                    statusCode =   
                };
            }
        }
        
        // POST api/accounts/signin
        [HttpPost]
        public void SignIn([FromBody]string value)
        {
            //return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;
using desafio.app;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace desafio.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IRegisterUserService registerUserService;
        private readonly ISignInService signInService;

        public AccountsController(IRegisterUserService registerUserService, ISignInService signInService)
        {
            this.registerUserService = registerUserService;
            this.signInService = signInService;
        }
        
        // POST api/accounts/signup
        [HttpPost("signup")]
        public object SignUp([FromBody] SignUpModel model)
        {
            try
            {
                model.senha = CryptoUtility.GetMD5Hash(model.senha);
                return registerUserService.Register(model);
            }
            catch (PreConditionException ae)
            {
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = 412  
                };
            }
            catch (DuplicatedUserException ae)
            {
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = 412  
                };
            }
            catch (Exception e)
            {
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = 500  
                };
            }
        }
        
        // POST api/accounts/signin
        [HttpPost("signin")]
        public object SignIn([FromBody] SignInModel model)
        {
            try
            {
                model.senha = CryptoUtility.GetMD5Hash(model.senha);
                return signInService.SignIn(model);
            }
            catch (PreConditionException ae)
            {
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = 412  
                };
            }
            catch (InvalidUserException e)
            {
                return new ErrorModel(){
                   mensagem = e.Message,
                   statusCode = 412  
                };
            }
            catch (Exception e)
            {
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = 500  
                };
            }
        }
    }
}

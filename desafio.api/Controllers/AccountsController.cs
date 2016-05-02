using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;
using desafio.app;
using System.Net;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace desafio.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IRegisterUserService registerUserService;
        private readonly ISignInService signInService;
        private readonly IGetUserService getUserService;

        public AccountsController(IRegisterUserService registerUserService, ISignInService signInService, IGetUserService getUserService)
        {
            this.registerUserService = registerUserService;
            this.signInService = signInService;
            this.getUserService = getUserService;
        }
        
        // POST api/accounts/signup
        [HttpPost("signup")]
        public object SignUp([FromBody] SignUpModel model)
        {
            try
            {
                model.senha = CryptoUtility.GetMD5Hash(model.senha);
                
                Response.StatusCode = (int)HttpStatusCode.Created;
                
                return registerUserService.Register(model);
            }
            catch (PreConditionException ae)
            {
                Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = (int)HttpStatusCode.PreconditionFailed  
                };
            }
            catch (DuplicatedUserException ae)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = (int)HttpStatusCode.Forbidden  
                };
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = (int)HttpStatusCode.InternalServerError  
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
                
                Response.StatusCode = (int)HttpStatusCode.OK;
                
                return signInService.SignIn(model);
            }
            catch (PreConditionException ae)
            {
                Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = (int)HttpStatusCode.PreconditionFailed    
                };
            }
            catch (InvalidUserException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                
                return new ErrorModel(){
                   mensagem = e.Message,
                   statusCode = (int)HttpStatusCode.Forbidden    
                };
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = (int)HttpStatusCode.InternalServerError  
                };
            }
        }
        
         // GET api/accounts/profile
        [HttpGet("profile")]
        public object Profile()
        {
            try
            {
                var bearer = Request.Headers["Bearer"];
                
                Assertion.IsFalse(string.IsNullOrEmpty(bearer), "Chamadas para este endpoint devem conter um header na requisição de Authentication com o valor 'Bearer {token}'");
                
                return getUserService.Get(bearer[0]);
            }
            catch (ArgumentException ae){
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = (int)HttpStatusCode.ExpectationFailed    
                };
            }
            catch (PreConditionException ae)
            {
                Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                
                return new ErrorModel(){
                   mensagem = ae.Message,
                   statusCode = (int)HttpStatusCode.PreconditionFailed    
                };
            }
            
            catch (NotAuthorizedException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                
                return new ErrorModel(){
                   mensagem = e.Message,
                   statusCode = (int)HttpStatusCode.Unauthorized    
                };
            }
            catch (SessionExpiredException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                
                return new ErrorModel(){
                   mensagem = e.Message,
                   statusCode = (int)HttpStatusCode.Forbidden    
                };
            }
            catch (InvalidUserException e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                
                return new ErrorModel(){
                   mensagem = e.Message,
                   statusCode = (int)HttpStatusCode.Forbidden    
                };
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = (int)HttpStatusCode.InternalServerError  
                };
            }
        }
        
        // GET api/accounts/list
        [HttpGet("list")]
        public object List()
        {
            try
            {
                return getUserService.All();
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new ErrorModel(){
                   mensagem = string.Format("Ocorreu um erro interno não tratado: {0}", e.Message),
                   statusCode = (int)HttpStatusCode.InternalServerError  
                };
            }
        }
    }
}

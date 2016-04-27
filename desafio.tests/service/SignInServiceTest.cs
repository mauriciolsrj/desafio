using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;
using desafio.app;

namespace desafio.tests
{
    public class SignInServiceTest
    {   
        [Fact]
        public void SignInWithSuccess()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "contato.mclss@gmail.com";
            var password = "abc123";
            var prefix = 21;
            var number = "31785826";
            
            var model = new SignUpModel(){
                nome = name,
                email = email,
                senha = password,
                telefones = new List<TelphoneModel>(){
                    new TelphoneModel(){
                        ddd = prefix,
                        numero = number
                    }
                }
            };
            
            var service = new RegisterUserService();
            var user = service.Register(model);
            
            var signInService = new SignInService();
            var signInModel = new SignInModel(){
               email = email,
               senha = password  
            };
            
            var loggedInUser = signInService.SignIn(signInModel);
            
            Assert.NotNull(loggedInUser);
            Assert.NotNull(loggedInUser.telefones);
        }
        
        [Fact]
        public void SignInErrorWhenPasswordIsWrong()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj1010@gmail.com";
            var password = "abc123";
            var prefix = 21;
            var number = "31785826";
            
            var model = new SignUpModel(){
                nome = name,
                email = email,
                senha = password,
                telefones = new List<TelphoneModel>(){
                    new TelphoneModel(){
                        ddd = prefix,
                        numero = number
                    }
                }
            };
            
            var service = new RegisterUserService();
            var user = service.Register(model);
            
            var signInService = new SignInService();
            var signInModel = new SignInModel(){
               email = email,
               senha = "abc123456"  
            };
            
            Exception ex = Assert.Throws<InvalidUserException>(() => signInService.SignIn(signInModel));
            
            Assert.Equal("Usuário e/ou senha inválidos", ex.Message);
        }
        
        [Fact]
        public void SignInErrorWhenEmailNotExists()
        { 
            var email = "mauricio12345@gmail.com";
            
            var signInService = new SignInService();
            var signInModel = new SignInModel(){
               email = email,
               senha = "abc123456"  
            };
            
            Exception ex = Assert.Throws<InvalidUserException>(() => signInService.SignIn(signInModel));
            
            Assert.Equal("Usuário e/ou senha inválidos", ex.Message);
        }
        
        [Fact]
        public void SignInErrorWhenEmailIsEmpty()
        { 
            var email = "";
            
            var signInService = new SignInService();
            var signInModel = new SignInModel(){
               email = email,
               senha = "abc123456"  
            };
            
            Exception ex = Assert.Throws<PreConditionException>(() => signInService.SignIn(signInModel));
            
            Assert.Equal("Informe o e-mail do usuário.", ex.Message);
        }
        
        [Fact]
        public void SignInErrorWhenPasswordIsEmpty()
        { 
            var signInService = new SignInService();
            var signInModel = new SignInModel(){
                email = "abc@abc.com"
            };
            
            Exception ex = Assert.Throws<PreConditionException>(() => signInService.SignIn(signInModel));
            
            Assert.Equal("Informe a senha do usuário.", ex.Message);
        }
    }
}
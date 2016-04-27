using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;

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
            
            Console.WriteLine("Senha atual: " + user.senha);
            Console.WriteLine("Senha enviada: " + model.senha);
            
            var loggedInUser = signInService.SignIn(signInModel);
            Assert.NotNull(loggedInUser);
        }
    }
}
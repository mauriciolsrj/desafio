using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;
using desafio.app.repository;
using desafio.app.context;

namespace desafio.tests
{
    public class GetGetUserServiceTest : TestBase
    {   
        [Fact]
        public void GetUserWhenTokenIsEmpty()
        { 
            var token = "";
            
            var service = GetGetUserService();
            
            Exception ex = Assert.Throws<PreConditionException>(() => service.Get(token));
            
            Assert.Equal("Informe um token válido", ex.Message);
        }
        
        [Fact]
        public void GetUserWhenTokenNotFound()
        { 
            var service = GetGetUserService();
            
            Exception ex = Assert.Throws<NotAuthorizedException>(() => service.Get("0024042024012"));
            
            Assert.Equal("Não autorizado", ex.Message);
        }
        
        [Fact]
        public void GetUserWhenTokeExists()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "maur235235iciolsrj1@gmail.com";
            var password = "ab32c123";
            var prefix = "21";
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
            
            var response = GetRegisterUserService().Register(model);
            var registeredUserModel = GetGetUserService().Get(response.token);
            /*
            Assert.Equal(registeredUserModel.nome, name);
            Assert.Equal(registeredUserModel.email, email);*/
        }
    }
}
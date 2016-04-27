using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;

namespace desafio.tests
{
    public class RegisterUserServiceTest
    {   
        [Fact]
        public void RegisterUserProfileWithTelphones()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj@gmail.com";
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
            var response = service.Register(model);
            
            Assert.Equal(model.nome, response.nome);
            Assert.Equal(model.email, response.email);
        }
        
        [Fact]
        public void RegisterDuplicatedUser()
        { 
           var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj1@gmail.com";
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
            var response = service.Register(model);
            
            Exception ex = Assert.Throws<DuplicatedUserException>(() => service.Register(model));
            
            Assert.Equal("E-mail já existente", ex.Message);
        }
    }
}
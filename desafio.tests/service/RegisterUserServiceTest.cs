using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
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
            var model = new SignUpModel(){
                nome = "Maurício Luís dos Santos",
                email = "mauriciolsrj@gmail.com",
                senha = "abc123",
                telefones = new List<TelphoneModel>(){
                    new TelphoneModel(){
                        ddd = 21,
                        numero = "31785826"
                    }
                }
            };
            
            RegisteredUserModel response;
            
            var profile = new Profile();
            
            using (var service = new RegisterUserService()){
                response = service.Register(model);
                profile = service.GetByUserId();
                Console.WriteLine("Profile Obtido: " + profile.Name);
            }
            
            Console.WriteLine("Name: " + response.nome);            
            Console.WriteLine("TOKEN: " + response.token);
            Console.WriteLine("UserId: " + response.id);
            Console.WriteLine("Password: " + response.senha);
        }
    }
}
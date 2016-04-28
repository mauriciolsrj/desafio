using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app.domain;
using desafio.app.service;
using desafio.app.model;

namespace desafio.tests
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html
    public class UsersFactoryTest
    {
        [Fact]
        public void CreateObjects()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj@gmail.com";
            var password = "abc123";
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
            
            var factory = new UsersFactory(model);
            factory.Create();
            
            Assert.NotNull(factory.GetUser()); 
            Assert.NotNull(factory.GetProfile());
        }
        
        [Fact]
        public void GetProfileWithCorrectData()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj@gmail.com";
            var password = "abc123";
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
            
            var factory = new UsersFactory(model);
            factory.Create();
            
            var profile = factory.GetProfile();
            Assert.Equal(name, profile.Name);
        }
        
        [Fact]
        public void GetUserWithCorrectData()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj@gmail.com";
            var password = "abc123";
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
            
            var factory = new UsersFactory(model);
            factory.Create();
            
            var user = factory.GetUser();
            Assert.Equal(email, user.Email);
        }
        
        [Fact]
        public void GetTelphoneWithCorrectData()
        { 
            var name = "Maurício Luís dos Santos";
            var email = "mauriciolsrj@gmail.com";
            var password = "abc123";
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
            
            var factory = new UsersFactory(model);
            factory.Create();
            
            var profile = factory.GetProfile();
            Assert.Equal(prefix, profile.Telphones.First().Prefix.ToString());
            Assert.Equal(number, profile.Telphones.First().Number);
        }
    }
}
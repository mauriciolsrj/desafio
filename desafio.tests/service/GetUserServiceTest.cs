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
    public class GetUserServiceTest
    {   
        [Fact]
        public void GetUserWhenTokenIsEmpty()
        { 
            var token = "";
            
            var service = new GetUserService();
            
            Exception ex = Assert.Throws<PreConditionException>(() => service.Get(token));
            
            Assert.Equal("Informe um token válido", ex.Message);
        }
        
        [Fact]
        public void GetUserWhenTokenNotFound()
        { 
            var service = new GetUserService();
            
            Exception ex = Assert.Throws<InvalidUserException>(() => service.Get("0024042024012"));
            
            Assert.Equal("Não autorizado", ex.Message);
        }
    }
}
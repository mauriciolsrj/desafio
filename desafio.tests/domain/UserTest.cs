using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;
using desafio.app.domain;
using desafio.app.service;

namespace desafio.tests
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html
    public class UserTest
    {   
        [Fact]
        public void SetEmail()
        { 
            var user = new User();
            var email = "Maurício";
             
            user.SetEmail(email);
            
            Assert.Equal(user.Email, email);
        }
        
        [Fact]
        public void SetEmailWhenEmailIsEmpty()
        { 
            var user = new User();
            var email = "";
            
            Exception ex = Assert.Throws<PreConditionException>(() => user.SetEmail(email));
            
            Assert.Equal("Informe o e-mail do usuário.", ex.Message);
        }
        
        [Fact]
        public void SetLastLogon()
        { 
            var user = new User();
            var lastLogon = DateTime.Now;
             
            user.SetLastLogon(lastLogon);
            
            Assert.Equal(user.LastLogon, lastLogon);
        }
        
        [Fact]
        public void SetLastLogonWhenLastLogonIsEmpty()
        { 
            var user = new User();
            
            Exception ex = Assert.Throws<PreConditionException>(() => user.SetLastLogon(DateTime.MinValue));
            
            Assert.Equal("Data de último acesso inválida.", ex.Message);
        }
        
        [Fact]
        public void SetPassword()
        { 
            var user = new User();
            var password = "abc123";
             
            user.SetPassword(password);
            
            Assert.Equal(user.Password, password);
        }
        
        [Fact]
        public void SetPasswordWhenPasswordIsEmpty()
        { 
            var user = new User();
            
            Exception ex = Assert.Throws<PreConditionException>(() => user.SetPassword(""));
            
            Assert.Equal("Informe a senha do usuário.", ex.Message);
        }
        
        [Fact]
        public void SetUpdated()
        { 
            var user = new User();
            var updated = DateTime.Now;
             
            user.SetUpdated(updated);
            
            Assert.Equal(user.Updated, updated);
        }
        
        [Fact]
        public void SetUpdatedWhenUpdatedIsEmpty()
        { 
            var user = new User();
            
            Exception ex = Assert.Throws<PreConditionException>(() => user.SetUpdated(DateTime.MinValue));
            
            Assert.Equal("Data de atualização inválida.", ex.Message);
        }
        
        [Fact]
        public void GetExpirationMustBe30MinutesOverThanLastLogon(){
            var user = new User();
            
            Assert.Equal(user.GetExpiration(), user.LastLogon.AddMinutes(30));
        }
    }
}
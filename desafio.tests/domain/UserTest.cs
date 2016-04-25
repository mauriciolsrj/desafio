using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
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
            
            try
            {
                user.SetEmail(email);
            }
            catch (ArgumentException ae)
            {
                Assert.Equal(ae.GetType(), typeof(ArgumentException));
            }
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
            
            try
            {
                user.SetLastLogon(DateTime.MinValue);
            }
            catch (ArgumentException ae)
            {
                Assert.Equal(ae.GetType(), typeof(ArgumentException));
            }
        }
    }
}
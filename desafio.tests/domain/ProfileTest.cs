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
    public class ProfileTest
    {
        [Fact]
        public void SetProfileName()
        { 
            var profile = new Profile();
            var name = "Maurício";
             
            profile.SetName(name);
            
            Assert.Equal(profile.Name, name);
        }
        
        [Fact]
        public void SetNameWhenNameIsEmpty()
        { 
            var profile = new Profile();
            var name = "";
            
            Exception ex = Assert.Throws<ArgumentException>(() => profile.SetName(name));
            
            Assert.Equal("Informe o nome do perfil.", ex.Message);
        }
        
        [Fact]
        public void SetUserId()
        { 
            var profile = new Profile();
            var userId = Guid.NewGuid();
             
            profile.SetUserId(userId);
            
            Assert.Equal(profile.UserId, userId);
        }
        
        [Fact]
        public void SetUserIdWhenUserIdIsZero()
        { 
            var profile = new Profile();
            var userId = Guid.Empty;
            
            Exception ex = Assert.Throws<ArgumentException>(() => profile.SetUserId(userId));
            
            Assert.Equal("Informe o userId do perfil.", ex.Message);
        }
        
        [Fact]
        public void AddTelphone()
        { 
            var profile = new Profile();
            var telphone = new Telphone();
            telphone.SetPrefix(21);
            telphone.SetNumber("31785826");
            
            profile.AddTelphone(telphone);
            
            Assert.Equal(profile.Telphones.Count(), 1);
        }
    }
}

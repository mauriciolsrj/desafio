using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.context;
using desafio.app.repository;
using desafio.app.service;

namespace desafio.tests
{
    public class ProfileRepositoryTest
    {   
        [Fact]
        public void InsertProfile()
        { 
            var name = "Maurício";
            var userId = Guid.NewGuid();
            var tel = new Telphone();
            tel.SetPrefix(21);
            tel.SetNumber("31785826");
            
            var profile = new Profile();
            profile.SetName(name);
            profile.SetUserId(userId);
            profile.AddTelphone(tel);
            
            var context = new UsersContext();
            var repository = new ProfileRepository(context);
            repository.Insert(profile);
            
            Assert.True(profile.Id > 0);
        }
        
        [Fact]
        public void GetUserById()
        { 
            var name = "Maurício";
            var userId = Guid.NewGuid();
            var tel = new Telphone();
            tel.SetPrefix(21);
            tel.SetNumber("31785826");
            
            var profile = new Profile();
            profile.SetName(name);
            profile.SetUserId(userId);
            profile.AddTelphone(tel);
            
            var context = new UsersContext();
            var repository = new ProfileRepository(context);
            repository.Insert(profile);
            
            var response = repository.GetByUserId(profile.UserId);
            
            Assert.Equal(profile.Name, response.Name);
            Assert.Equal(profile.UserId, response.UserId);
            Assert.NotNull(profile.Telphones);
            Assert.Equal(profile.Telphones.Count, 1);
        }
        
        [Fact]
        public void GetUserByIdWhenProfileNotExists()
        { 
            var userId = Guid.NewGuid();
            
            var context = new UsersContext();
            var repository = new ProfileRepository(context);
            
            var response = repository.GetByUserId(userId);
            
            Assert.Null(response);
        }
    }
}
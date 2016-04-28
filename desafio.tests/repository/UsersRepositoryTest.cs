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
    public class UsersRepositoryTest
    {   
        [Fact]
        public void InserUser()
        { 
            var user = new User();
            var email = "mauriciolsrj123@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var context = new UsersContext();
            var repository = new UsersRepository(context);
            repository.Insert(user);
        }
        
        [Fact]
        public void GetUserByEmail()
        { 
            var user = new User();
            var email = "mauriciolsrj123@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var context = new UsersContext();
            var repository = new UsersRepository(context);
            repository.Insert(user);
            
            var response = repository.GetByEmail(email);
            
            Assert.Equal(user.Email, response.Email);
            Assert.Equal(user.Password, response.Password);
        }
        
        [Fact]
        public void GetUserByIdWhenUserNotExists()
        { 
            var userId = Guid.NewGuid();
            
            var context = new UsersContext();
            var repository = new UsersRepository(context);
            
            var response = repository.GetByEmail("aaaaa@aaa.com");
            
            Assert.Null(response);
        }
        
        [Fact]
        public void VerifyIfUserExistsByEmailWhenUserExists()
        { 
            var user = new User();
            var email = "mauriciolsrj12309101@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var context = new UsersContext();
            var repository = new UsersRepository(context);
            repository.Insert(user);
            
            var response = repository.VerifyUserExistsByEmail(email);
            
            Assert.True(response);
        }
        
        [Fact]
        public void VerifyIfUserExistsByEmailWhenUserNotExists()
        {
            var context = new UsersContext();
            var repository = new UsersRepository(context);
            
            var response = repository.VerifyUserExistsByEmail("093520983598@33235.com");
            
            Assert.False(response);
        }
    }
}
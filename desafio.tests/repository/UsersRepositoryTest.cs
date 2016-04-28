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
    public class UsersRepositoryTest : TestBase
    {   
        [Fact]
        public void InserUser()
        { 
            var user = new User();
            var email = "mauriciolsrj123@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var repository = GetUsersRepository();
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
            
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var response = repository.GetByEmail(email);
            
            Assert.Equal(user.Email, response.Email);
            Assert.Equal(user.Password, response.Password);
        }
        
        [Fact]
        public void GetUserByIdWhenUserNotExists()
        { 
            var userId = Guid.NewGuid();
            
            var repository = GetUsersRepository();
            var response = repository.GetByEmail("aaaaa@aaa.com");
            
            Assert.Null(response);
        }
        
        [Fact]
        public void GetByEmailWhenEmailExists()
        { 
            var user = new User();
            var email = "mauriciolsrj123091101@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var response = repository.GetByEmail(email);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public void VerifyIfUserExistsByEmailWhenUserNotExists()
        {
            var user = new User();
            var email = "m0932092389110424241@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var response = repository.GetByEmail("1233123121");
            
            Assert.Null(response);
        }
        
        [Fact]
        public void GetByIdWhenIdExists()
        { 
            var user = new User();
            var email = "124441241241@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var userId = user.Id;
            
            var response = repository.GetById(userId);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public void GetByIdWhenIdNotExists()
        {
            var user = new User();
            var email = "1244412532241241@gmail.com";
            var password = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var userId = user.Id;
            
            var response = repository.GetById(Guid.NewGuid());
            
            Assert.Null(response);
        }
        
        [Fact]
        public void GetByTokenWhenTokenExists()
        { 
            var user = new User();
            var email = "124441241241@gmail.com";
            var password = "abc123";
            var token = "abc123";
            user.SetEmail(email);
            user.SetPassword(password);
            user.SetToken(token);
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var response = repository.GetByToken(token);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public void GetByTokenWhenTokenNotExists()
        {
            var user = new User();
            var email = "124441241241@gmail.com";
            var password = "abc123";
            var token = "1241242";
            user.SetEmail(email);
            user.SetPassword(password);
            user.SetToken(token);
            var repository = GetUsersRepository();
            repository.Insert(user);
            
            var response = repository.GetByToken("12313132");
            
            Assert.Null(response);
        }
    }
}
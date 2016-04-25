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
    public class TelphoneTest
    {
        [Fact]
        public void SetPrefix()
        { 
            var tel = new Telphone();
            var prefix = 21;
             
            tel.SetPrefix(prefix);
            
            Assert.Equal(tel.Prefix, prefix);
        }
        
        [Fact]
        public void SetPrefixWhenPrefixIsZero()
        { 
            var tel = new Telphone();
            var prefix = 0;
            
            try
            {
                tel.SetPrefix(prefix);
            }
            catch (ArgumentException ae)
            {
                Assert.Equal(ae.GetType(), typeof(ArgumentException));
            }
        }
        
        [Fact]
        public void SetNumber()
        { 
            var tel = new Telphone();
            var number = "31785826";
             
            tel.SetNumber(number);
            
            Assert.Equal(tel.Number, number);
        }
        
        [Fact]
        public void SetNumberWhenNumberIsEmpty()
        { 
            var tel = new Telphone();
            var number = "";
            
            try
            {
                tel.SetNumber(number);
            }
            catch (ArgumentException ae)
            {
                Assert.Equal(ae.GetType(), typeof(ArgumentException));
            }
        }
    }
}

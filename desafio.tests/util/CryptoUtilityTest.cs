using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;

namespace desafio.tests
{
    public class CryptoUtilityTest
    {   
        [Fact]
        public void GetMD5Hash()
        { 
            var name = "mauricio";
            var hash = CryptoUtility.GetMD5Hash(name);
            
            Assert.Equal(hash, "2c86832c6b7c9a45a7c039e9eff08cba");
        }
    }
}
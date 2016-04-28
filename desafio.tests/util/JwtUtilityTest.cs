using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;

namespace desafio.tests
{
    public class JwtUtilityTest
    {   
        [Fact]
        public void TestJwtEncode()
        { 
            var name = "mauricio";
            
            var dt1 = DateTime.Now;
            var dt2 = DateTime.Now.AddMinutes(30);
                          
            var hash = JwtUtility.Encode(Guid.NewGuid(), UnixDateUtility.ConvertToUnixTimestamp(dt2), UnixDateUtility.ConvertToUnixTimestamp(dt1));
            
            var decode = JwtUtility.Decode(hash);
        }
    }
}
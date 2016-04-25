using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app.domain;

namespace desafio.tests
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html
    public class ProfileTest
    {
        [Fact]
        public void PassingTest()
        {
            var profile = new Profile();
            profile.setName("Maurício");
            
            Assert.Equal(profile.Name, "Maurício");
        }
    }
}

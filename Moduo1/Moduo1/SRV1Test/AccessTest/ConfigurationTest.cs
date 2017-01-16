using NUnit.Framework;
using SRV1.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV1Test.AccessTest
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new Configuration());
        }
    }
}

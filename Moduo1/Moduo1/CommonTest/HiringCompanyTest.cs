using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;

namespace CommonTest
{
    [TestFixture]
    public class HiringCompanyTest
    {
        private HiringCompany hiring;
        private string name = "hcComp1";

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.hiring = new HiringCompany();
        }

        [Test]
        public void UserStoryConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new HiringCompany());
        }

        [Test]
        public void UserStoryConstructorTestWithParameters()
        {
            Assert.DoesNotThrow(() => new HiringCompany(name));
        }

        [Test]
        public void Name()
        {
            hiring.Name = name;

            Assert.AreEqual(name, hiring.Name);
        }

    }
}

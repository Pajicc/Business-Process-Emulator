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
    public class AccessDBTest
    {
        private AccessDB accessDBtest;


        [OneTimeSetUp]
        public void SetupTest()
        {
            this.accessDBtest = new AccessDB();
        }

        [Test]
        public void UserTest()
        {
            Assert.DoesNotThrow(() => accessDBtest.Users.FirstOrDefault());
        }

        [Test]
        public void HiringCompaniesTest()
        {
            Assert.DoesNotThrow(() => accessDBtest.HiringCompanies.FirstOrDefault());
        }

        [Test]
        public void UserStoriesTest()
        {
            Assert.DoesNotThrow(() => accessDBtest.UserStories.FirstOrDefault());
        }
        [Test]
        public void ProjectTest()
        {
            Assert.DoesNotThrow(() => accessDBtest.Projects.FirstOrDefault());
        }

        [Test]
        public void PartnersTest()
        {
            Assert.DoesNotThrow(() => accessDBtest.Partners.FirstOrDefault());

        }
    }
}

using Common;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.DataTest
{
    [TestFixture]
    public class OutSourcingCompanyTest
    {
        private OutsourcingCompany oc;
        private string name = "Kompanija";
        private User ceo = new User();
        private List<Project> projects = new List<Project>();


        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.oc = new OutsourcingCompany();
        }

        [Test]
        public void OutSourcingCompanyConstructorTestBezParametra()
        {
            Assert.DoesNotThrow(() => new Project());
        }

        [Test]
        public void OutSourcingCompanyConstructorTestSaParametrima()
        {

            Assert.DoesNotThrow(() => new OutsourcingCompany(name, ceo, projects));
        }

        [Test]
        public void OutSourcingCompanyName()
        {
            oc.Name = name;

            Assert.AreEqual(name, oc.Name);
        }

        [Test]
        public void OutSourcingCompanyCEO()
        {
            oc.CEO = ceo;

            Assert.AreEqual(ceo, oc.CEO);
        }

        [Test]
        public void OutSourcingCompanyProjects()
        {
            oc.Projects = projects;

            Assert.AreEqual(projects, oc.Projects);
        }

    }
}

using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    [TestFixture]
    public class ProcentTest
    {
        private Procent procent;
        private string imeProj = "Project1";
        private double procenat = 0;

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.procent = new Procent();
        }


        [Test]
        public void ProcentConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new Procent());
        }

        [Test]
        public void UserStoryConstructorTestWithParameters()
        {
            Assert.DoesNotThrow(() => new Procent(imeProj, procenat));
        }

        [Test]
        public void Procenat()
        {
            procent.Procenat = procenat;

            Assert.AreEqual(procenat, procent.Procenat);
        }

        [Test]
        public void ImeProj()
        {
            procent.ImeProj = imeProj;

            Assert.AreEqual(imeProj, procent.ImeProj);
        }


    }
}

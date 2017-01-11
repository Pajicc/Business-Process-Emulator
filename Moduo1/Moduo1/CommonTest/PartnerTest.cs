using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CommonTest
{
    [TestFixture]
    public class PartnerTest
    {
        private Partner partner;
        private int id = 1;
        private string imeHiringKompanije = "Kompanija1";
        private string imeOutKompanije = "outComp1";

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.partner = new Partner();
        }

        [Test]
        public void UserStoryConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new Partner());
        }

        [Test]
        public void UserStoryConstructorTestWithParameters()
        {
            Assert.DoesNotThrow(() => new Partner(imeHiringKompanije, imeOutKompanije));
        }

        [Test]
        public void Id()
        {
            partner.Id = id;

            Assert.AreEqual(id, partner.Id);
        }

        [Test]
        public void ImeHiringKompanije()
        {
            partner.ImeHiringKompanije = imeHiringKompanije;

            Assert.AreEqual(imeHiringKompanije, partner.ImeHiringKompanije);
        }

        [Test]
        public void ImeOutKompanije()
        {
            partner.ImeOutKompanije = imeOutKompanije;

            Assert.AreEqual(imeOutKompanije, partner.ImeOutKompanije);
        }
    }
}

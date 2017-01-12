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
    public class ProjectTest
    {
        private Project project;
        private string name = "name";
        private string description = "description";
        private string startTime = "01/01/2001 12:12:12";
        private string endTime = "01/01/2002 12:12:12";
        private States state = States.notApproved;
        private string po = "po1";
        private string hiringCompany = "hiringCompany";

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.project = new Project();
        }

        [Test]
        public void UserStoryConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new Project());
        }

        [Test]
        public void UserStoryConstructorTestWithParameters()
        {
            Assert.DoesNotThrow(() => new Project(name, description, startTime, endTime, po));
        }

        [Test]
        public void Name()
        {
            project.Name = name;

            Assert.AreEqual(name, project.Name);
        }

        [Test]
        public void Description()
        {
            project.Description = description;

            Assert.AreEqual(description, project.Description);
        }

        [Test]
        public void StartTime()
        {
            project.StartTime = startTime;

            Assert.AreEqual(startTime, project.StartTime);
        }

        [Test]
        public void EndTime()
        {
            project.EndTime = endTime;

            Assert.AreEqual(endTime, project.EndTime);
        }

        [Test]
        public void State()
        {
            project.State = state;

            Assert.AreEqual(state, project.State);
        }

        [Test]
        public void Po()
        {
            project.Po = po;

            Assert.AreEqual(po, project.Po);
        }
        [Test]
        public void HiringCompany()
        {
            project.HiringCompany = hiringCompany;

            Assert.AreEqual(hiringCompany, project.HiringCompany);
        }
    }
}

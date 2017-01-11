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
    public class UserStoryTest
    {
        #region Declarations

        private UserStory userStory;
        private string name = "name";
        private string project = "project";
        private string criteria = "1. criteria, 2. criteria, 3. criteria";


        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.userStory = new UserStory();
        }

        #endregion setup

        #region tests

        [Test]
        public void UserStoryConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new UserStory());
        }

        [Test]
        public void UserStoryConstructorTestWithParameters()
        {
            Assert.DoesNotThrow(() => new UserStory(name, criteria));
        }

        [Test]
        public void Name()
        {
            userStory.Name = name;

            Assert.AreEqual(name, userStory.Name);
        }

        [Test]
        public void Criteria()
        {
            userStory.Criteria = criteria;

            Assert.AreEqual(criteria, userStory.Criteria);
        }

        [Test]
        public void Project()
        {
            userStory.Project = project;

            Assert.AreEqual(project, userStory.Project);
        }

        #endregion tests
    }
}

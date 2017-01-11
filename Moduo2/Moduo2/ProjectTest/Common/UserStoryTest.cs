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
    public class UserStoryTest
    {
        private UserStory us;
        private string name = "Userstory";
        private string criteria = "kriterijum";
        private double startTime = 1;
        private double endTime = 31;

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.us = new UserStory();
        }


        [Test]
        public void UserStoryConstructorTestBezParametra()
        {
            Assert.DoesNotThrow(() => new UserStory());
        }

        [Test]
       /* public void UserStoryConstructorTestSaParametrima()
        {
            
            Assert.DoesNotThrow(() => new UserStory(name,criteria,startTime,endTime));
        }

        [Test]*/
        public void UserStoryName()
        {
            
            us.Name = name;

            Assert.AreEqual(name, us.Name);
        }

        [Test]
        public void UserStoryCriteria()
        {

            us.Criteria = criteria;

            Assert.AreEqual(criteria, us.Criteria);
        }

        
      /*  public void UserStoryStartTime()
        {

            us.StartTime = startTime;

            Assert.AreEqual(startTime, us.StartTime);
        }*/

       /* [Test]
        public void UserStoryEndTime()
        {

            us.EndTime = endTime;

            Assert.AreEqual(endTime, us.EndTime);
        }*/

       }
}

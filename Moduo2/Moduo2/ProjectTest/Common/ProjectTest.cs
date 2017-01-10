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
     public  class ProjectTest
    {
       private Project projekat;
       private string name = "projekat";
       private string description = "projekat_desc";    
       private double startTime = 14;
       private double endTime = 22;
       private User po = new User();
       private List<UserStory> userStories = new List<UserStory>();

       [OneTimeSetUp]
       //[TestFixtureSetUp]
       public void SetupTest()
       {
           this.projekat = new Project();
       }

       [Test]
       public void ProjectConstructorTestBezParametra()
       {
           Assert.DoesNotThrow(() => new Project());
       }

       [Test]
       public void ProjectConstructorTestSaParametrima()
       {
          
           Assert.DoesNotThrow(() => new Project(name,description,startTime,endTime,po,userStories));
       }

       [Test]
       public void ProjectName()
       {
           projekat.Name = name;

           Assert.AreEqual(name, projekat.Name);
       }


       [Test]
       public void ProjectDescription()
       {
           projekat.Description = description;

           Assert.AreEqual(description, projekat.Description);
       }


       [Test]
       public void ProjectStartTime()
       {
           projekat.StartTime = startTime;

           Assert.AreEqual(startTime, projekat.StartTime);
       }


       [Test]
       public void ProjectEndTime()
       {
           projekat.EndTime = endTime;

           Assert.AreEqual(endTime, projekat.EndTime);
       }

       
       
      /* [Test]
       public void ProjektPo()
       {
           projekat.Po = po;

           Assert.AreEqual(po, projekat.Po);
       }*/

      /* [Test]
       public void ProjektUserStories()
       {
           projekat.UserStories = userStories;

           Assert.AreEqual(userStories, projekat.UserStories);
       }*/
    }
}

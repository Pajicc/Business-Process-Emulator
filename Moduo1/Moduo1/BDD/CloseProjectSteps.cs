using System;
using TechTalk.SpecFlow;
using Common;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class CloseProjectSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private User po = new User();
        private Project proj;
        private string projName;

        [Given(@"I am logged in as a PO")]
        public void GivenIAmLoggedInAsAPO()
        {
            binding.OpenTimeout = new TimeSpan(1, 0, 0);
            binding.CloseTimeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = new TimeSpan(1, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(1, 0, 0);

            proxy = new Client1Proxy(binding, endpoint);
            po.Username = "po1";
            po.Password = "po1";
            proxy.Login(po.Username, po.Password);
        }
        
        [Given(@"I have a form for choosing project for closing")]
        public void GivenIHaveAFormForChoosingProjectForClosing()
        {
            proj = new Project();
        }
        
        [Given(@"I have select it")]
        public void GivenIHaveSelectIt()
        {
            projName = "testProj";
        }
        
        [When(@"I press close button")]
        public void WhenIPressCloseButton()
        {
            proj.Name = projName;
            proj.Po = po.Username;
            proj.State = States.finished;
        }
        
        [Then(@"the project should be changed")]
        public void ThenTheProjectShouldBeChanged()
        {
            Assert.DoesNotThrow((() => proxy.UpdateProject(proj)));
        }
    }
}

using System;
using TechTalk.SpecFlow;
using Common;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class CreateNewProjectSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private Project proj;
        private string projectName;

        [Given(@"I have a form for creating projects")]
        public void GivenIHaveAFormForCreatingProjects()
        {
            binding.OpenTimeout = new TimeSpan(1, 0, 0);
            binding.CloseTimeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = new TimeSpan(1, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(1, 0, 0);

            proxy = new Client1Proxy(binding, endpoint);
        }
        
        [Given(@"I have fill it with data")]
        public void GivenIHaveFillItWithData()
        {
            projectName = "testbdd";
            proj = new Project();
        }
        
        [When(@"I press create button")]
        public void WhenIPressCreateButton()
        {
            proj.Name = projectName;
        }
        
        [Then(@"the project should be created")]
        public void ThenTheProjectShouldBeCreated()
        {
            Assert.DoesNotThrow((() => proxy.CreateProject(proj)));
        }
    }
}

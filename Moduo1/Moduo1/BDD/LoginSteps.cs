using System;
using TechTalk.SpecFlow;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class LoginSteps
    {
        private static string adress = "net.tcp://localhost:9999/EmployeeService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private string username;
        private string password;

        private bool result;

        [Given(@"I have form to log in")]
        public void GivenIHaveFormToLogIn()
        {
            binding.CloseTimeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = new TimeSpan(1, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(1, 0, 0);

            proxy = new Client1Proxy(binding, endpoint);
        }

        [When(@"I enter valid ""(.*)"" and ""(.*)"" as")]
        public void WhenIEnterValidAndAs(string p0, string p1)
        {
            username = p0;
            password = p1;
        }
        
        [When(@"I enter wrong ""(.*)"" or ""(.*)"" as")]
        public void WhenIEnterWrongOrAs(string p0, string p1)
        {
            username = p0;
            password = p1;
        }
        
        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.DoesNotThrow(() => proxy.Login(username, password));
        }
        
        [Then(@"I should be warned")]
        public void ThenIShouldBeWarned()
        {
            result = proxy.Login(username, password);
            Assert.AreEqual(false, result);
        }
    }
}

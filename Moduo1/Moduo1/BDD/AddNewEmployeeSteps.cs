using System;
using TechTalk.SpecFlow;
using Common;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class AddNewEmployeeSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private User employee;
        private User ceo = new User();

        [Given(@"I am logged in as a CEO")]
        public void GivenIAmLoggedInAsACEO()
        {
            binding.OpenTimeout = new TimeSpan(1, 0, 0);
            binding.CloseTimeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = new TimeSpan(1, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(1, 0, 0);

            proxy = new Client1Proxy(binding, endpoint);
            ceo.Username = "ceo1";
            ceo.Passeditime = "ceo1";
            ceo.LoggedIn = true;
            proxy.Login(ceo.Username, ceo.Password);
        }
        
        [Given(@"I have a form for filling up employee data")]
        public void GivenIHaveAFormForFillingUpEmployeeData()
        {
            employee = new User();
            employee.Role = Roles.Employee;
        }
        
        [When(@"I enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"",")]
        public void WhenIEnter(string p0, string p1, string p2, string p3, string p4)
        {
            employee.Username = p0;
            employee.Password = p1;
            employee.Name = p2;
            employee.LastName = p3;
            employee.Email = p4;
        }
        
        [Then(@"the new employee should be added")]
        public void ThenTheNewEmployeeShouldBeAdded()
        {
            Assert.DoesNotThrow(() => proxy.AddUser(employee));
        }
    }
}

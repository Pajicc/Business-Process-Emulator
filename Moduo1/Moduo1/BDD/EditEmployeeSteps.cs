using System;
using TechTalk.SpecFlow;
using Common;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class EditEmployeeSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private User employee;
        private User ceo = new User();

        [Given(@"I have form for editing data")]
        public void GivenIHaveFormForEditingData()
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
            employee = new User();
            employee.Role = Roles.Employee;
        }
        
        [When(@"I change ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"",")]
        public void WhenIChange(string p0, string p1, int p2, string p3)
        {
            employee.Name = p0;
            employee.LastName = p1;
            employee.Password = p2.ToString();
            employee.Email = p3;
        }
        
        [Then(@"the changes are updated")]
        public void ThenTheChangesAreUpdated()
        {
            Assert.DoesNotThrow(() => proxy.EditUser(employee));
        }
    }
}

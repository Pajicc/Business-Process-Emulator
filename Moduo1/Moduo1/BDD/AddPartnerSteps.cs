using System;
using TechTalk.SpecFlow;
using Common;
using System.ServiceModel;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class AddPartnerSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private string outsComp;
        private User ceo = new User();

        [Given(@"I have form for choosing company")]
        public void GivenIHaveFormForChoosingCompany()
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
        
        [When(@"I press button")]
        public void WhenIPressButton()
        {
            outsComp = "Kompanija1";
        }
        
        [Then(@"the outsorcing company should be contacted with request")]
        public void ThenTheOutsorcingCompanyShouldBeContactedWithRequest()
        {
            Assert.DoesNotThrow(() => proxy.AddPartnerCompany(ceo, outsComp));
        }
    }
}

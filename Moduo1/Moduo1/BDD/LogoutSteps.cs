﻿using System;
using TechTalk.SpecFlow;
using Client1;
using NUnit.Framework;
using System.ServiceModel;

namespace BDD
{
    [Binding]
    public class LogoutSteps
    {
        private static string adress = "net.tcp://localhost:9999/CompanyService";
        private EndpointAddress endpoint = new EndpointAddress(new Uri(adress));
        private NetTcpBinding binding = new NetTcpBinding();
        private Client1Proxy proxy;

        private string username;
        private string password;

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            binding.OpenTimeout = new TimeSpan(1, 0, 0);
            binding.CloseTimeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = new TimeSpan(1, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(1, 0, 0);

            proxy = new Client1Proxy(binding, endpoint);

            proxy.Login("test", "test");
        }
        
        [When(@"I press logout button")]
        public void WhenIPressLogoutButton()
        {
            username = "test";
        }
        
        [Then(@"I should be logged out")]
        public void ThenIShouldBeLoggedOut()
        {
            Assert.DoesNotThrow(() => proxy.LogOut(username));
        }
    }
}

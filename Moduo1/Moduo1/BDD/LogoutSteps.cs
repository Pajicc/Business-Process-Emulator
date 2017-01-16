using System;
using TechTalk.SpecFlow;
using Client1;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class LogoutSteps
    {
        private Context wrap = Context.GetInstance();

        private bool result;
        private string username;
        private string password;

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            wrap.Proxy.Open();

            wrap.Proxy.Login("test", "test");
        }
        
        [When(@"I press logout button")]
        public void WhenIPressLogoutButton()
        {
            username = "test";
        }
        
        [Then(@"I should be logged out")]
        public void ThenIShouldBeLoggedOut()
        {
            Assert.DoesNotThrow(() => wrap.Proxy.LogOut(username));
        }
    }
}

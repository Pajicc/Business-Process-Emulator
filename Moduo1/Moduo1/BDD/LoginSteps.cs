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
        private Context wrap = Context.GetInstance();

        private string username;
        private string password;

        private bool result;

        [Given(@"I have form to log in")]
        public void GivenIHaveFormToLogIn()
        {
            wrap.Proxy.Open();
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
            Assert.DoesNotThrow(() => wrap.Proxy.Login(username, password));
        }
        
        [Then(@"I should be warned")]
        public void ThenIShouldBeWarned()
        {
            result = wrap.Proxy.Login(username, password);
            Assert.AreEqual(false, result);
        }
    }
}

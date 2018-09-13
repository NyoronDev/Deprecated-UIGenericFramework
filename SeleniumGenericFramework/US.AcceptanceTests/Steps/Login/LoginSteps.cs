using System;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.Login
{
    /// <summary>
    /// The login steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class LoginSteps : StepBase
    {
        private readonly ILoginPage loginPage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSteps"/> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="loginPage">The login page.</param>
        public LoginSteps(ISetUp setUp, ILoginPage loginPage)
        {
            this.loginPage = loginPage;
            this.setUp = setUp;
        }

        /// <summary>
        /// Thes the user goes to the page.
        /// </summary>
        /// <param name="page">The page.</param>
        [Given(@"The user goes to the '(.*)' page")]
        public void TheUserGoesToThePage(string page)
        {
            setUp.GoToUrl(page);
        }

        /// <summary>
        /// Thes the user tries to login with the following user.
        /// </summary>
        /// <param name="table">The table.</param>
        [When(@"The user tries to login with the following user")]
        public void TheUserTriesToLoginWithTheFollowingUser(Table table)
        {
            var user = table.CreateInstance<UserLogin>();

            loginPage.LoginUser(user);
        }

        /// <summary>
        /// The user login to the web page.
        /// </summary>
        /// <param name="loginUser">The login user.</param>
        [When(@"The user '(.*)' login to the web page")]
        public void TheUserLoginToTheWebPage(string loginUser)
        {
            try
            {
                var user = GetLoginUser(loginUser);

                loginPage.LoginUser(user);
            }
            catch (Exception e)
            {
                throw new Exception($"User {loginUser} does not exist.", e);
            }
            
        }

        /// <summary>
        /// Thes the user cannot login and the alert appears.
        /// </summary>
        /// <param name="alertMessage">The alert message.</param>
        [Then(@"The user cannot login and the '(.*)' alert appears")]
        public void TheUserCannotLoginAndTheAlertAppears(string alertMessage)
        {
            var realMessage = loginPage.GetAlertBoxMessage();

            realMessage.Should().Be(alertMessage);
        }
    }
}
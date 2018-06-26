using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.Login
{
    /// <summary>
    /// The Login page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ILoginPage" />
    public class LoginPage : PageBase, ILoginPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Name, Using = "uid")]
        private IWebElement userIdTextBox;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.Name, Using = "btnLogin")]
        private IWebElement loginButton;

        #endregion .: Web Elements :.

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public LoginPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void LoginUser(UserLogin user)
        {
            this.WaitUntil(1);
            SendKeysElement(userIdTextBox, user.UserId);
            SendKeysElement(passwordTextBox, user.Password);

            ClickElement(loginButton);
        }

        public string GetAlertBoxMessage()
        {
            var alert = webDriver.SwitchTo().Alert();
            var alertMessage = alert.Text;

            alert.Accept();

            return alertMessage;
        }
    }
}
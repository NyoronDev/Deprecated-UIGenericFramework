using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.Login
{
    public class LoginPage : PageBase, ILoginPage
    {
        public LoginPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public void LoginUser(UserLogin user)
        {
            throw new System.NotImplementedException();
        }
    }
}
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AC.SeleniumDriver
{
    /// <summary>
    /// The page base class.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public class PageBase : IPageBase
    {
        protected IWebDriver webDriver;
        protected WebDriverWait webDriverWait;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public PageBase(ISetUp setUpWebDriver)
        {
            this.webDriver = setUpWebDriver.LaunchWebDriver();

            if (this.webDriver != null)
            {
                this.webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(15));
            }
        }

        /// <summary>
        /// Scrolls to element.
        /// </summary>
        /// <param name="element">The element.</param>
        protected void ScrollToElement(IWebElement element)
        {
            var javascriptExecutor = (IJavaScriptExecutor)this.webDriver;
            javascriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Waits the until.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        protected void WaitUntil(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// Determines whether [is element enabled] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if [is element enabled] [the specified element]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsElementEnabled(IWebElement element)
        {
            this.WaitUntil(1);

            return element.Displayed && element.Enabled;
        }
    }
}
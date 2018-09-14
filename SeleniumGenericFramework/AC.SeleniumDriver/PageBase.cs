using System;
using System.Threading;
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        /// The click element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected void ClickElement(IWebElement element)
        {
            this.WaitUntil(1);

            this.WaitUntilElementIsClickable(element);

            element.Click();
        }

        /// <summary>
        /// The send keys element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="keys">
        /// The keys.
        /// </param>
        protected void SendKeysElement(IWebElement element, string keys)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            this.WaitUntilElementIsClickable(element);

            element.SendKeys(keys);
        }

        /// <summary>
        /// The clear element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected void ClearElement(IWebElement element)
        {
            this.WaitUntil(1);
            this.WaitUntilElementIsClickable(element);

            element.Clear();
        }

        /// <summary>
        /// The is element enabled.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool IsElementEnabled(IWebElement element)
        {
            this.WaitUntil(1);

            try
            {
                return element.Displayed && element.Enabled;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The wait until element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        private void WaitUntilElementIsClickable(IWebElement element)
        {
            this.webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(15));
            this.webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
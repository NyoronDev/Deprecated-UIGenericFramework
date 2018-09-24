using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AC.AndroidNativeDriver
{
    /// <summary>
    /// The page base.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public class PageBase : IPageBase
    {
        protected AndroidDriver<AndroidElement> androidDriver;
        protected WebDriverWait webDriverWait;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        public PageBase(ISetUp setUpAndroidDriver)
        {
            this.androidDriver = (AndroidDriver<AndroidElement>)setUpAndroidDriver.LaunchDriver();
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
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch
            {
                return false;
            }
        }
    }
}
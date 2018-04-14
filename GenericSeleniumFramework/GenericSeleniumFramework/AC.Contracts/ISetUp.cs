using OpenQA.Selenium;

namespace AC.Contracts
{
    /// <summary>
    /// Set up configuration.
    /// </summary>
    public interface ISetUp
    {
        /// <summary>
        /// Launches the web driver.
        /// </summary>
        /// <returns></returns>
        IWebDriver LaunchWebDriver();

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        string MakeScreenshot(string scenario);

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        void RefreshPage();

        /// <summary>
        /// Determines whether [is driver null].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is driver null]; otherwise, <c>false</c>.
        /// </returns>
        bool IsDriverNull();

        /// <summary>
        /// Goes to URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        void GoToUrl(string url);
    }
}
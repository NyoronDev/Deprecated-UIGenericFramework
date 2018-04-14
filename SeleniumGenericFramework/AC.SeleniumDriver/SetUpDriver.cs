using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace AC.SeleniumDriver
{
    public class SetUpDriver : ISetUp
    {
        private const string DriverPath = @"\binaries\";
        private string WebSite => ConfigurationManager.AppSettings["WebSite"];
        private static IWebDriver webDriver;

        private enum WebBrowser
        {
            Chrome,
            IE11
        }

        /// <summary>
        /// Closes the driver.
        /// </summary>
        public static void CloseDriver()
        {
            webDriver?.Quit();
            webDriver?.Dispose();
            webDriver = null;
        }

        /// <summary>
        /// Launches the web driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/></returns>
        /// <exception cref="System.Exception"></exception>
        public IWebDriver LaunchWebDriver()
        {
            var appConfigValue = ConfigurationManager.AppSettings["WebBrowser"];

            if (Enum.TryParse(appConfigValue, out WebBrowser webBrowser))
            {
                switch (webBrowser)
                {
                    case WebBrowser.Chrome:
                        return SetUpChromeWebDriver();

                    case WebBrowser.IE11:
                        return SetUpInternetExplorerWebDriver();

                    default:
                        return SetUpChromeWebDriver();
                }
            }

            throw new Exception($"The web browser {appConfigValue} is undefined");
        }

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns>The <see cref="string"/></returns>
        public string MakeScreenshot(string scenario)
        {
            var binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\screenshot";
            CreateScreenShotFolder(binDirectory);

            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            var screenshotName = $"{DateTime.UtcNow.ToString("d-M-yyyy HH-mm-ss", CultureInfo.InvariantCulture)}_{scenario}.jpeg";

            var fullPathFile = binDirectory + @"\" + screenshotName;
            screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);

            return fullPathFile;
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        public void RefreshPage()
        {
            webDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Determines whether [is web driver null].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is web driver null]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDriverNull()
        {
            return webDriver == null;
        }

        /// <summary>
        /// Goes to main URL.
        /// </summary>
        public void GoToMainUrl()
        {
            webDriver.Navigate().GoToUrl(WebSite);
        }

        /// <summary>
        /// Sets up chrome web driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/>.</returns>
        private IWebDriver SetUpChromeWebDriver()
        {
            try
            {
                if (webDriver != null)
                {
                    return webDriver;
                }

                var chromeFullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath;
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArguments("disable-infobars");

                // TFS Virtual Machine option
                // chromeOptions.AddArgument("--window-size=1920,1080");

                webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(chromeFullPath), chromeOptions, TimeSpan.FromSeconds(15));
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);

                return webDriver;
            }
            catch
            {
                CloseDriver();
                throw;
            }
        }

        /// <summary>
        /// Sets up internet explorer web driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/>.</returns>
        private IWebDriver SetUpInternetExplorerWebDriver()
        {
            try
            {
                if (webDriver != null)
                {
                    return webDriver;
                }

                var internetExplorerFullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath;

                var internetExplorerOptions = new InternetExplorerOptions();
                internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                webDriver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(internetExplorerFullPath), internetExplorerOptions, TimeSpan.FromSeconds(15));
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);

                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl(this.WebSite);

                return webDriver;
            }
            catch
            {
                CloseDriver();
                throw;
            }
        }

        /// <summary>
        /// Creates the screen shot folder.
        /// </summary>
        /// <param name="path">The path.</param>
        private void CreateScreenShotFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
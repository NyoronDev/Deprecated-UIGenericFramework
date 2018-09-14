using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace AC.SeleniumDriver
{
    public class SetUpDriver : ISetUp
    {
        private static IWebDriver webDriver;

        private enum WebBrowser
        {
            Chrome,
            Android
        }

        /// <summary>
        /// Closes the driver.
        /// </summary>
        public void CloseDriver()
        {
            webDriver?.Quit();
            webDriver?.Dispose();
            webDriver = null;
        }

        /// <summary>
        /// Launches the web driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/></returns>
        public IWebDriver LaunchWebDriver()
        {
            var webBrowserAppConfigValue = ConfigurationManager.AppSettings["WebBrowser"];
            WebBrowser webBrowser;

            if (Enum.TryParse(webBrowserAppConfigValue, out webBrowser))
            {
                switch (webBrowser)
                {
                    case WebBrowser.Chrome:
                        return this.SetUpChromeWebDriver();

                    case WebBrowser.Android:
                        return this.SetUpAndroidWebDriver();

                    default:
                        return this.SetUpChromeWebDriver();
                }
            }

            throw new Exception($"The web browser {webBrowserAppConfigValue} is undefined");
        }

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns>The <see cref="string"/></returns>
        public string MakeScreenshot(string scenario)
        {
            var binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\screenshot";
            this.CreateScreenshotFolder(binDirectory);

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
        /// Goes to URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
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

                var chromeFullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
                this.CloseDriver();
                throw;
            }
        }

        /// <summary>
        /// Sets up android web driver.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        private IWebDriver SetUpAndroidWebDriver()
        {
            try
            {
                if (webDriver != null)
                {
                    return webDriver;
                }

                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("deviceName", "generic_x86");
                capabilities.SetCapability("platformVersion", "7.0");
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("fastReset", "True");
                capabilities.SetCapability("browserName", "Chrome");
                capabilities.SetCapability("unicodeKeyboard", true);
                capabilities.SetCapability("resetKeyboard", true);


                webDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(120));
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);

                return webDriver;
            }
            catch (Exception ex)
            {
                this.CloseDriver();
                throw;
            }
        }

        /// <summary>
        /// Creates the screen shot folder.
        /// </summary>
        /// <param name="path">The path.</param>
        private void CreateScreenshotFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace AC.AndroidNativeDriver
{
    /// <summary>
    /// The Set up driver class.
    /// </summary>
    /// <seealso cref="AC.Contracts.ISetUp" />
    public class SetUpAndroidDriver : ISetUp
    {
        private const string AndroidApplicationPath = @"\binaries\mylist.apk";

        private static AndroidDriver<AndroidElement> androidDriver;

        /// <summary>
        /// Closes the driver.
        /// </summary>
        public void CloseDriver()
        {
            androidDriver?.Quit();
            androidDriver?.Dispose();
            androidDriver = null;
        }

        /// <summary>
        /// Goes to URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoToUrl(string url)
        {
            throw new NotSupportedException("Only valid with web browser automation project");
        }

        public bool IsDriverNull()
        {
            return androidDriver == null;
        }

        /// <summary>
        /// Launches the android driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/></returns>
        public IWebDriver LaunchDriver()
        {
            try
            {
                if (androidDriver != null)
                {
                    return androidDriver;
                }

                var appFullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + AndroidApplicationPath;

                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability(MobileCapabilityType.DeviceName, "generic_x86");
                capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "7.0");
                capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
                capabilities.SetCapability(MobileCapabilityType.App, appFullPath);
                capabilities.SetCapability("unicodeKeyboard", true);
                capabilities.SetCapability("resetKeyboard", true);

                androidDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(120));

                return androidDriver;
            }
            catch
            {
                this.CloseDriver();
                throw;
            }
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

            var screenshot = ((ITakesScreenshot)androidDriver).GetScreenshot();
            var screenshotName = $"{DateTime.UtcNow.ToString("d-M-yyyy HH-mm-ss", CultureInfo.InvariantCulture)}_{scenario}.jpeg";

            var fullPathFile = binDirectory + @"\" + screenshotName;
            screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);

            return fullPathFile;
        }

        /// <summary>
        /// Reset the application.
        /// </summary>
        public void RefreshPage()
        {
            androidDriver.ResetApp();
        }

        private void CreateScreenshotFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
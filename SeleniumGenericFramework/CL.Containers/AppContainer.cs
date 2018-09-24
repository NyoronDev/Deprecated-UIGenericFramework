using AC.AndroidNativeDriver;
using AC.AndroidNativeDriver.Pages;
using AC.AndroidNativeDriver.Pages.AddTask;
using AC.Contracts;
using AC.Contracts.Pages;
using AC.SeleniumDriver;
using AC.SeleniumDriver.Pages.AddTask;
using AC.SeleniumDriver.Pages.Main;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;

namespace CL.Containers
{
    /// <summary>
    /// The App Container dependency injector.
    /// </summary>
    public static class AppContainer
    {
        private enum Device
        {
            Computer,
            Android
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IUnityContainer Container { get; private set; }

        /// <summary>
        /// Builds the web container.
        /// </summary>
        public static void BuildContainer()
        {
            var deviceConfigValue = ConfigurationManager.AppSettings["Device"];

            if (Enum.TryParse(deviceConfigValue, out Device device))
            {
                switch (device)
                {
                    case Device.Computer:
                        BuildWebContainer();
                        break;

                    case Device.Android:
                        BuildAndroidContainer();
                        break;

                    default:
                        BuildWebContainer();
                        break;
                }
            }
        }

        private static void BuildWebContainer()
        {
            if (Container == null)
            {
                var buildContainer = new UnityContainer();

                buildContainer.RegisterType<ISetUp, SetUpWebDriver>();
                buildContainer.RegisterType<IMainPage, MainPage>();
                buildContainer.RegisterType<IAddTaskPage, AddTaskPage>();

                Container = buildContainer;
            }
        }

        private static void BuildAndroidContainer()
        {
            if (Container == null)
            {
                var buildContainer = new UnityContainer();

                buildContainer.RegisterType<ISetUp, SetUpAndroidDriver>();
                buildContainer.RegisterType<IMainPage, AndroidMainPage>();
                buildContainer.RegisterType<IAddTaskPage, AndroidAddTaskPage>();

                Container = buildContainer;
            }
        }
    }
}
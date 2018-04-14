using AC.Contracts;
using AC.Contracts.Pages;
using AC.SeleniumDriver;
using AC.SeleniumDriver.Pages.Login;
using Unity;

namespace CL.Containers
{
    /// <summary>
    /// The App Container dependency injector.
    /// </summary>
    public static class AppContainer
    {
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
        public static void BuildWebContainer()
        {
            if (Container == null)
            {
                var buildContainer = new UnityContainer();

                buildContainer.RegisterType<ISetUp, SetUpDriver>();
                buildContainer.RegisterType<ILoginPage, LoginPage>();

                Container = buildContainer;
            }
        }
    }
}
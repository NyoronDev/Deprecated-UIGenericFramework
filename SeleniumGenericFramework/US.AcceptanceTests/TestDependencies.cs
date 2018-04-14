using CL.Containers;
using Microsoft.Practices.Unity;
using SpecFlow.Unity;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace US.AcceptanceTests
{
    /// <summary>
    /// The test dependencies.
    /// </summary>
    public static class TestDependencies
    {
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <returns></returns>
        [ScenarioDependencies]
        public static IUnityContainer CreateContainer()
        {
            AppContainer.BuildWebContainer();
            var container = AppContainer.Container;

            // Registers the build steps, this gives us dependency resolution using the container.
            // NB If you need named parameters into the steps you should override specific registrations
            container.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.ContainerControlled);

            return container;
        }
    }
}
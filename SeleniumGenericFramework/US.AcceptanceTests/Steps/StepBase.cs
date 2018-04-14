using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The step base.
    /// </summary>
    public class StepBase : TechTalk.SpecFlow.Steps
    {
    }

    [TestClass]
    public class InitializeTestContext
    {
        public static TestContext Context { get; private set; }

        /// <summary>
        /// Assemblies the initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            if (Context == null)
            {
                Context = context;
            }
        }
    }
}
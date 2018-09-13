using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.Main
{
    /// <summary>
    /// The Main Page steps.
    /// </summary>
    /// <seealso cref="TechTalk.SpecFlow.Steps" />
    [Binding]
    public class MainPageSteps : StepBase
    {
        private readonly ISetUp setUpDriver;
        private readonly IMainPage mainPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageSteps"/> class.
        /// </summary>
        /// <param name="setUpDriver">The set up driver.</param>
        /// <param name="mainPage">The main page.</param>
        public MainPageSteps(ISetUp setUpDriver, IMainPage mainPage)
        {
            this.setUpDriver = setUpDriver;
            this.mainPage = mainPage;
        }

        [Given(@"The user goes to the main page")]
        public void TheUserGoesToTheMainPage()
        {
            string url;
            try
            {
                url = this.WebSiteUrl;
            }
            catch
            {
                // We need to add the config.runsettings -> Visual Studio -> Test -> Test Settings -> Select Test Settings File
                url = "https://todoauto.azurewebsites.net";
            }

            this.setUpDriver.GoToUrl(url);
        }

        [Given(@"The user goes to create new item")]
        [When(@"The user goes to create new item")]
        public void TheUserGoesToCreateNewItem()
        {
            this.mainPage.GoToCreateNewTask();
        }

        [Then(@"The testee display the following items:")]
        public void TheTesteeDisplayTheFollowingItems(Table table)
        {
            var expectedItems = table.CreateSet<TodoItem>();
            var realItems = this.mainPage.GetTodoItems();

            realItems.Should().BeEquivalentTo(expectedItems, options => options.WithStrictOrdering());
        }

        /// <summary>
        /// The after scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (!this.setUpDriver.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
                        // Take a screenshot.
                        var screenshotPathFile = this.setUpDriver.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                }

                this.setUpDriver.CloseDriver();
            }
            catch
            {
                this.setUpDriver.CloseDriver();
            }
        }
    }
}

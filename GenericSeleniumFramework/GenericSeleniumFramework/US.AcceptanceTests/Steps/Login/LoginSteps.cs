using TechTalk.SpecFlow;

namespace US.AcceptanceTests.Steps.Login
{
    /// <summary>
    /// The Login steps base.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class LoginSteps : StepBase
    {
        [Given(@"The user goes to the '(.*)' page")]
        public void TheUserGoesToThePage(string page)
        {
        }
    }
}
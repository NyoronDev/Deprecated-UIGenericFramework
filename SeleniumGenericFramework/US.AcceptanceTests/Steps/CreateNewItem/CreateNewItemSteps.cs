using System;
using AC.Contracts.Pages;
using DF.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.CreateNewItem
{
    /// <summary>
    /// The Create new item steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class CreateNewItemSteps : StepBase
    {
        private readonly IAddTaskPage addTaskPage;
        private readonly IMainPage mainPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewItemSteps" /> class.
        /// </summary>
        /// <param name="addTaskPage">The add task page.</param>
        /// <param name="mainPage">The main page.</param>
        public CreateNewItemSteps(IAddTaskPage addTaskPage, IMainPage mainPage)
        {
            this.addTaskPage = addTaskPage;
            this.mainPage = mainPage;
        }

        [When(@"The user creates a new task with the following properties:")]
        public void TheUserCreatesANewTaskWithTheFollowingProperties(Table table)
        {
            var task = table.CreateInstance<TodoItem>();

            this.addTaskPage.CreateTask(task);
        }

        [When(@"The user creates a group of task with the following properties:")]
        public void TheUserCreatesAGroupOfTasksWithTheFollowingProperties(Table table)
        {
            var taskList = table.CreateSet<TodoItem>();

            foreach (var task in taskList)
            {
                this.mainPage.GoToCreateNewTask();
                this.addTaskPage.CreateTask(task);
            }
        }

        [When(@"The user creates the task '(.*)'")]
        public void TheUserCreatesTheTask(string title)
        {
            try
            {
                var task = this.GetTodoItem(title);

                this.addTaskPage.CreateTask(task);
            }
            catch (Exception ex)
            {
                throw new Exception($"The title {title} does not found at the json file", ex);
            }
        }
    }
}
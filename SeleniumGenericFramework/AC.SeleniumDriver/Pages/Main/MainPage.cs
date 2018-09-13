using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.Main
{
    /// <summary>
    /// The MainPage class.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IMainPage" />
    public class MainPage : PageBase, IMainPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Name, Using = "create-new")]
        private IWebElement createNewButton;

        [FindsBy(How = How.XPath, Using = "//*[@data-test-id='box-list-item']")]
        private IList<IWebElement> itemBoxList;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="setUpDriver">The set up driver.</param>
        public MainPage(ISetUp setUpDriver)
            : base(setUpDriver)
        {
            PageFactory.InitElements(this.webDriver, this);
        }

        /// <summary>
        /// Goes to create new task.
        /// </summary>
        public void GoToCreateNewTask()
        {
            this.ClickElement(this.createNewButton);
        }

        /// <summary>
        /// Gets the to do items.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/></returns>
        public IList<TodoItem> GetTodoItems()
        {
            var todoItems = new List<TodoItem>();

            foreach (var itemBox in this.itemBoxList)
            {
                var todoItem = new TodoItem();

                // Title
                todoItem.Title = itemBox.FindElement(By.Name("title")).Text;

                // Description
                todoItem.Content = itemBox.FindElement(By.Name("description")).Text;

                // Color
                todoItem.Color = itemBox.GetAttribute("style").Replace("background: ", string.Empty).Replace(";", string.Empty);

                todoItems.Add(todoItem);
            }

            return todoItems;
        }
    }
}

using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.AddTask
{
    /// <summary>
    /// The add task page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IAddTaskPage" />
    public class AddTaskPage : PageBase, IAddTaskPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "textBox-itemTitle")]
        private IWebElement taskTitleTextBox;

        [FindsBy(How = How.Id, Using = "textBox-itemDescription")]
        private IWebElement taskDescriptionTextBox;

        [FindsBy(How = How.Id, Using = "button-addItem")]
        private IWebElement taskNewItemButton;

        [FindsBy(How = How.Id, Using = "dropDown-itemColor")]
        private IWebElement colorDropDownMenu;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskPage"/> class.
        /// </summary>
        /// <param name="setUpDriver">The set up driver.</param>
        public AddTaskPage(ISetUp setUpDriver)
            : base(setUpDriver)
        {
            PageFactory.InitElements(this.webDriver, this);
        }

        /// <summary>
        /// Creates the task.
        /// </summary>
        /// <param name="todoItem">The to do item.</param>
        /// <param name="clickNewItem">if set to <c>true</c> [click new item].</param>
        public void CreateTask(TodoItem todoItem, bool clickNewItem = true)
        {
            // Title
            this.SendKeysElement(this.taskTitleTextBox, todoItem.Title);

            // Description
            this.SendKeysElement(this.taskDescriptionTextBox, todoItem.Content);

            // Color
            this.SetTaskColor(todoItem.Color);

            if (clickNewItem)
            {
                this.ClickElement(this.taskNewItemButton);
            }
        }

        private void SetTaskColor(string color)
        {
            var isClicked = false;

            foreach (var item in this.colorDropDownMenu.FindElements(By.TagName("option")))
            {
                if (color == item.Text)
                {
                    this.ClickElement(item);
                    isClicked = true;
                }
            }

            if (!isClicked)
            {
                throw new NotFoundException($"Color {color} not found.");
            }
        }
    }
}

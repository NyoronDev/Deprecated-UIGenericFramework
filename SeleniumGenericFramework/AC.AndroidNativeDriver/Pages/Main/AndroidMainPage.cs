using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace AC.AndroidNativeDriver.Pages
{
    /// <summary>
    /// The Android Main page.
    /// </summary>
    /// <seealso cref="AC.AndroidNativeDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IMainPage" />
    public class AndroidMainPage : PageBase, IMainPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.Id, Using = "douzifly.list:id/fab_add")]
        private IWebElement createNewButton;

        [FindsBy(How = How.Id, Using = "douzifly.list:id/content")]
        private IList<IWebElement> itemBoxList;

        #endregion .: Android Elements :.

        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidMainPage"/> class.
        /// </summary>
        /// <param name="setUpAndroidDriver"></param>
        public AndroidMainPage(ISetUp setUpAndroidDriver)
            : base(setUpAndroidDriver)
        {
            PageFactory.InitElements(this.androidDriver, this);
        }

        /// <summary>
        /// Gets the todo items.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/></returns>
        public IList<TodoItem> GetTodoItems()
        {
            var todoItemList = new List<TodoItem>();

            foreach (var item in this.itemBoxList)
            {
                var todoItem = new TodoItem();

                todoItem.Title = item.FindElement(By.Id("douzifly.list:id/txt_thing")).Text;

                todoItemList.Add(todoItem);
            }

            return todoItemList;
        }

        /// <summary>
        /// Goes to create new task.
        /// </summary>
        public void GoToCreateNewTask()
        {
            this.ClickElement(this.createNewButton);
        }
    }
}
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace AC.AndroidNativeDriver.Pages.AddTask
{
    public class AndroidAddTaskPage : PageBase, IAddTaskPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.Id, Using = "douzifly.list:id/edit_text")]
        private IWebElement titleTask;

        [FindsBy(How = How.Id, Using = "douzifly.list:id/edit_text_content")]
        private IWebElement contentTask;

        [FindsBy(How = How.ClassName, Using = "android.view.View")]
        private IList<IWebElement> colorPicker;

        [FindsBy(How = How.Id, Using = "douzifly.list:id/fab_add")]
        private IWebElement createTaskButton;

        #endregion .: Android Elements :.

        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidAddTaskPage"/> class.
        /// </summary>
        /// <param name="setUpAndroidDriver"></param>
        public AndroidAddTaskPage(ISetUp setUpAndroidDriver)
            : base(setUpAndroidDriver)
        {
            PageFactory.InitElements(this.androidDriver, this);
        }

        /// <summary>
        /// Creates the task.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="clickNewItem">if set to <c>true</c> [click new item].</param>
        public void CreateTask(TodoItem todoItem, bool clickNewItem = true)
        {
            // Title
            this.SendKeysElement(this.titleTask, todoItem.Title);

            // Description
            this.SendKeysElement(this.contentTask, todoItem.Content);

            if (clickNewItem)
            {
                this.ClickElement(this.createTaskButton);
            }
        }
    }
}
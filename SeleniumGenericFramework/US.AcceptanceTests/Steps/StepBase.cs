using System.Collections.Generic;
using System.IO;
using System.Linq;
using DF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The step base.
    /// </summary>
    [TestClass]
    public class StepBase : TechTalk.SpecFlow.Steps
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        private static TestContext context;

        private IEnumerable<TodoItem> todoItems;

        private string usersFile = @"TestData\Users.json";
        private string todoItemsFile = @"TestData\TodoItems.json";

        public TestContext CurrentTestContext => context;

        public string WebSiteUrl => this.CurrentTestContext?.Properties["WebSiteURL"].ToString();

        /// <summary>
        /// Gets the to do items.
        /// </summary>
        public IEnumerable<TodoItem> TodoItems
        {
            get
            {
                if (this.todoItems == null)
                {
                    this.todoItems = this.LoadTodoItems();
                }

                return this.todoItems;
            }
        }

        /// <summary>
        /// Assemblies the initialize.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            if (context == null)
            {
                context = testContext;
            }
        }

        /// <summary>
        /// Gets the to do item.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="TodoItem"/></returns>
        public TodoItem GetTodoItem(string title)
        {
            return this.TodoItems.FirstOrDefault(i => i.Title == title);
        }

        private IEnumerable<TodoItem> LoadTodoItems()
        {
            using (var file = File.OpenText(this.todoItemsFile))
            {
                var serializer = new JsonSerializer();
                return (List<TodoItem>)serializer.Deserialize(file, typeof(List<TodoItem>));
            }
        }
    }
}
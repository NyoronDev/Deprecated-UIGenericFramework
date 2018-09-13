using System.Collections.Generic;
using DF.Entities;

namespace AC.Contracts.Pages
{
    public interface IMainPage
    {
        void GoToCreateNewTask();

        IList<TodoItem> GetTodoItems();
    }
}

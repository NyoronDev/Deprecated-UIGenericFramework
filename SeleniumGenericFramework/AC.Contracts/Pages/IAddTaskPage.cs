using DF.Entities;

namespace AC.Contracts.Pages
{
    public interface IAddTaskPage
    {
        void CreateTask(TodoItem todoItem, bool clickNewItem = true);
    }
}
namespace ToDoList
{
    public interface ITodoRepository
    {
        List<TodoTask> GetTodos();
        void AddTodo(TodoTask todo);
        void CompleteTodo(int todoId);
    }
}

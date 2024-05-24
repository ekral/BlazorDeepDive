namespace ToDoList
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly List<TodoTask> todos = 
        [
            new TodoTask() { Id = 1, Description = "Item 1"},
            new TodoTask() { Id = 2, Description = "Item 2"},
            new TodoTask() { Id = 3, Description = "Item 3"}
        ];
        
        public List<TodoTask> GetTodos()
        {
            return todos;
        }

        public void AddTodo(TodoTask todo)
        {
            int max = todos.Max(task => task.Id);
            ++max;

            todo.Id = max;

            todos.Add(todo);
        }

        public void CompleteTodo(int todoId)
        {
            TodoTask? todo = todos.Find(task => task.Id == todoId);

            ArgumentNullException.ThrowIfNull(todo);

            todo.Completed = true;
            todo.CompletitionDate = DateTime.Now;
        }
    }
}

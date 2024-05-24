namespace ToDoList
{
    public class TodoTask
    {
        public int Id { get; set; }
        required public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletitionDate { get; set; }

    }
}

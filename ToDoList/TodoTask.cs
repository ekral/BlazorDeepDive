namespace ToDoList
{
    public class TodoTask
    {

        public int Id { get; set; }
        required public string Description { get; set; }

        private bool isCompleted;
        
        public bool IsCompleted 
        { 
            get => isCompleted;
            set
            { 
                isCompleted = value; 
            
                if(IsCompleted)
                {
                    CompletitionDate = DateTime.Now;
                }
            } 
        }
        public DateTime? CompletitionDate { get; private set; }

    }
}

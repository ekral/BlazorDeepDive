namespace ServerManagement.Models
{
    public class Server
    {
        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        required public string Name { get; set; }
        required public string City { get; set; }

        public Server()
        {
            int randomNumber = Random.Shared.Next(0, 2);
            IsOnline = randomNumber == 0 ? false : true;
        }
    }
}

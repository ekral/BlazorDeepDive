using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        
        [Required]
        required public string Name { get; set; }
        
        [Required]
        required public string City { get; set; }

        public int NumberOfPeople { get; set; }

        public Server()
        {
            int randomNumber = Random.Shared.Next(0, 2);
            IsOnline = randomNumber == 0 ? false : true;

            NumberOfPeople = Random.Shared.Next(0, 100);
        }
    }
}

namespace Homework_Client_Server_MVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }       //in a prod environment we would hash
    }
}

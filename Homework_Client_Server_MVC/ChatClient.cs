namespace Homework_Client_Server_MVC
{
    public interface ChatClient     //represents the interface for my client, this is a "strongly typed client", instead of sendasync we just call receive message
    {
        Task ReceiveMessage(string user, string message);     //method to receive messages from the server, passing user and message through, need to inherit from the generic hub
    }
}

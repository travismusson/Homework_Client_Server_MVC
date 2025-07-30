using Microsoft.AspNetCore.SignalR;


namespace Homework_Client_Server_MVC.Hubs

{
    public class ChatHub : Hub<ChatClient>     //inherits from the generic Hub class, passing the ChatClient interface as a type parameter
    {
        /*
        public override async Task OnConnectedAsync()     //overides the OnConnectedAsync method to handle when a client connects to the hub
        {
            await Clients.All.ReceiveMessage(Context.ConnectionId, "Has Joined"); //sends a join notification message to the clients that a new client has just connected
        }
        */
        public async Task SendMessage(string user, string message)      //passing parameters username and message
        {
            await Clients.All.ReceiveMessage(user, message);
        }
        public async Task AnnounceJoin(string user)     //new join message
        {
            await Clients.All.ReceiveMessage("System", $"{user} has joined");
        }
    }
}

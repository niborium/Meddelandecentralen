using Meddelandecentralen.Models;
using Meddelandecentralen.Services;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }
        public async Task SendMessage(string messagetype, string room, string author, string message)
        {
            if (string.IsNullOrEmpty(messagetype + room + author + message)){
                return;
            }

            if(messagetype =="Arbetsorder")
            {
            var workorder = _chatService.CreateNewMessage(messagetype,room,author,message);
            await Clients.All.SendAsync("ReceiveWorkorder", workorder);
            } else {
            var chat = _chatService.CreateNewMessage(messagetype,room,author,message);
            await Clients.All.SendAsync("ReceiveChat", chat);
            }
        }
        public async Task SendInvestigate(string id, string casemanager)
        {
            if (string.IsNullOrEmpty(id + casemanager)){
                return;
            }

            const string status = "Under utredning";
            await Clients.All.SendAsync("ReceiveInvestigate", id, casemanager, status);
        }
        public async Task SendDone(string id, string casemanager)
        {
            if (string.IsNullOrEmpty(id + casemanager)){
                return;
            }
            const string status = "Åtgärdad";
            await Clients.All.SendAsync("ReceiveDone", id, casemanager, status);
        }
    }
}
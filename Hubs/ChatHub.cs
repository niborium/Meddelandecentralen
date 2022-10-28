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
            var updatedworkorder = _chatService.UpdateWorkorder(id, casemanager, "Under utredning");
            await Clients.All.SendAsync("ReceiveInvestigate", updatedworkorder.Item1, updatedworkorder.Item2, updatedworkorder.Item3);
        }
        public async Task SendDone(string id, string casemanager)
        {
            if (string.IsNullOrEmpty(id + casemanager)){
                return;
            }
            var updatedworkorder = _chatService.UpdateWorkorder(id, casemanager, "Åtgärdad");
            await Clients.All.SendAsync("ReceiveDone", updatedworkorder.Item1, updatedworkorder.Item2, updatedworkorder.Item3);
        }
    }
}
using Meddelandecentralen.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string messagetype, string room, string author, string message)
        {
            DateTime dt = DateTime.Now;
            var swedatetime= dt.ToString("g");

            if(messagetype =="Arbetsorder")
            {
            MessageModel workorder = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Workorder,room,author,message,"Ej påbörjad","Ej tilldelad");
            await Clients.All.SendAsync("ReceiveMessage", workorder.Id, workorder.Date, messagetype, workorder.Room, workorder.Author, workorder.Message, workorder.Status, workorder.Assigned);
            } else {
            MessageModel chat = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Chat,"",author,message,"","");
            await Clients.All.SendAsync("ReceiveMessage", chat.Id, chat.Date, messagetype, chat.Room, chat.Author, chat.Message, chat.Status, chat.Assigned);
            }
        }
        public async Task SendInvestigate(string id, string casemanager)
        {
            const string status = "Under utredning";
            await Clients.All.SendAsync("ReceiveInvestigate", id, casemanager, status);
        }
        public async Task SendDone(string id, string casemanager)
        {
            const string status = "Åtgärdad";
            await Clients.All.SendAsync("ReceiveDone", id, casemanager, status);
        }
    }
}
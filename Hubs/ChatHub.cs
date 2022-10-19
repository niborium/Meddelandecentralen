using Meddelandecentralen.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string messagetype, string room, string author, string message)
        {
            const string NotUsed = "";
            const string NotStarted = "Ej påbörjad";
            const string NotAssigned = "Ej tilldelad";

            DateTime dt = DateTime.Now;
            var swedatetime= dt.ToString("g");

            if(messagetype =="Arbetsorder")
            {
            MessageModel workorder = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Arbetsorder,room,author,message,NotStarted,NotAssigned);
            await Clients.All.SendAsync("ReceiveMessage", workorder.Id, workorder.Date, nameof(MessageModel.Messagetype.Arbetsorder), workorder.Room, workorder.Author, workorder.Message, workorder.Status, workorder.Assigned);
            } else {
            MessageModel chat = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Chatt,NotUsed,author,message,NotUsed,NotUsed);
            await Clients.All.SendAsync("ReceiveMessage", chat.Id, chat.Date, nameof(MessageModel.Messagetype.Chatt), chat.Room, chat.Author, chat.Message, chat.Status, chat.Assigned);
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
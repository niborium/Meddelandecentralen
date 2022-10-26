using Meddelandecentralen.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string messagetype, string room, string author, string message)
        {
            if (string.IsNullOrEmpty(messagetype + room + author + message)){
                return;
            }

            const string NotUsed = "";
            const string NotStarted = "Ej påbörjad";
            const string NotAssigned = "Ej tilldelad";

            DateTime dt = DateTime.Now;
            var swedatetime= dt.ToString("g");

            if(messagetype =="Arbetsorder")
            {
            MessageModel workorder = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Arbetsorder,room,author,message,NotStarted,NotAssigned);
            await Clients.All.SendAsync("ReceiveWorkorder", workorder);
            } else {
            MessageModel chat = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Chatt,NotUsed,author,message,NotUsed,NotUsed);
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
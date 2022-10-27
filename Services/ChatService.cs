using Meddelandecentralen.Models;

namespace Meddelandecentralen.Services
{
  public class ChatService : IChatService
    {
    public MessageModel CreateNewMessage(string messagetype, string room, string author, string message)
    {
      const string NotUsed = "";
      const string NotStarted = "Ej påbörjad";
      const string NotAssigned = "Ej tilldelad";

      DateTime dt = DateTime.Now;
      var swedatetime = dt.ToString("g");

      if (messagetype == "Arbetsorder")
      {
        MessageModel workorder = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Arbetsorder, room, author, message, NotStarted, NotAssigned);
        return workorder;
      }
      else
      {
        MessageModel chat = new(Guid.NewGuid(), swedatetime, MessageModel.Messagetype.Chatt, NotUsed, author, message, NotUsed, NotUsed);
        return chat;
      }
    }
  }
}
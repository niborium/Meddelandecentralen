using Meddelandecentralen.Models;

namespace Meddelandecentralen.Services
{
  public interface IChatService
    {
      MessageModel CreateNewMessage(string messagetype, string room, string author, string message);
    }
}
using Microsoft.AspNetCore.SignalR.Client;
//@inject NavigationManager Navigation
using Microsoft.AspNetCore.Components;

namespace Meddelandecentralen.Pages
{
    public class MessageServiceBase : ComponentBase
    {
    [Inject]
    public NavigationManager Navigation { get; set; } = null!;
    //MessageInput
    private HubConnection? hubConnection;
    protected string? messagetypeInput;
    protected string? roomInput;
    protected string? authorInput;
    protected string? messageInput;
    protected string? infoMessage;
    //MessageRenderer
    protected List<string> messages = new();
    protected string? caseManager;
    protected string? casemanagerMessage;

    protected override async Task OnInitializedAsync()
    {
        messagetypeInput = "Chat";

        hubConnection = new HubConnectionBuilder()
            .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
            .Build();
        hubConnection.On<Models.MessageModel>("ReceiveWorkorder", (workorder) =>
        {
            var encodedMsg = $"[{workorder.Id}] - [{workorder.Date}] - [Arbetsorder]: Rum: {workorder.Room} - Publicerad av: {workorder.Author} - Status: {workorder.Status} - Tilldelad till: {workorder.Assigned} Meddelande: {workorder.Message}";
            messages.Add(encodedMsg);
            InvokeAsync(StateHasChanged);
        });
        hubConnection.On<Models.MessageModel>("ReceiveChat", (chat) =>
        {
            var encodedMsg = $"[{chat.Date}] - [Chatt]: - Publicerad av: {chat.Author} Meddelande: {chat.Message}";
            messages.Add(encodedMsg);
            InvokeAsync(StateHasChanged);
        });
        hubConnection.On<string, string, string>("ReceiveInvestigate", (id, casemanager, status) =>
        {
          int index = messages.FindIndex(ind => ind.Contains(id));
          var updated = messages[index].Replace("Ej tilldelad", casemanager).Replace("Ej påbörjad", status);
          messages.RemoveAt(index);
          messages.Insert(index, updated);
          InvokeAsync(StateHasChanged);
        });
        hubConnection.On<string, string, string>("ReceiveDone", (id, casemanager, status) =>
        {
          int index = messages.FindIndex(ind => ind.Contains(id));
          var updated = messages[index].Replace("Tilldelad till", "Utredd av").Replace("Ej tilldelad", casemanager).Replace("Ej påbörjad", status).Replace("Under utredning", status + " av " +casemanager);
          messages.RemoveAt(index);
          messages.Insert(index, updated);
          InvokeAsync(StateHasChanged);
        });
        await hubConnection.StartAsync();
    }
    protected async Task SendMessage()
    {
      if (hubConnection is not null)
      {
        if(authorInput?.Length > 1 && messageInput?.Length > 1){
          await hubConnection.SendAsync("SendMessage", messagetypeInput, roomInput, authorInput, messageInput);
          roomInput = "";
          messageInput = "";
        }
        else {
          infoMessage = "Du måste fylla i båda fälten Ditt namn och Meddelande ovan för att skicka meddelandet.";
        }
      }
    }
    protected async Task SendInvestigate(string caseId, Delegate hidemodal)
    {
      if (hubConnection is not null)
      {
        if(caseManager?.Length > 1){
          await hubConnection.SendAsync("SendInvestigate", caseId, caseManager);
          caseManager = "";
          hidemodal.DynamicInvoke();
        }
        else {
          casemanagerMessage = "Du måste fylla i ditt namn som handläggare innan du kan skicka.";
        }
      }
    }
    protected async Task SendDone(string caseId, Delegate hidemodal)
    {
      if (hubConnection is not null)
      {
        if(caseManager?.Length > 1){
          await hubConnection.SendAsync("SendDone", caseId, caseManager);
          caseManager = "";
          hidemodal.DynamicInvoke();
        }
        else {
          casemanagerMessage = "Du måste fylla i ditt namn som handläggare innan du kan skicka.";
        }
      }
    }
    public bool IsConnected =>
      hubConnection?.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
      if (hubConnection is not null)
      {
        await hubConnection.DisposeAsync();
      }
    }
    }
}
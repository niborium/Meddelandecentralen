# Meddelandecentralen
Chattapplikation för anställda hos Concorde Hotel New York för att hantera arbetsordrar och chatta med kollegor. 
# Teknik
Skapad med:  
[Blazor server (ASP.NET Core)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0) med [SignalR Hubs](https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-6.0)  
[SignalR Client](https://learn.microsoft.com/en-us/aspnet/core/signalr/client-features?view=aspnetcore-6.0)  
[BlazorStrap V5](https://blazorstrap.io/V5/)  

# Installationsanvisning  
<ins>För utvecklare och testning (lokalt):</ins>  
Ladda ner koden som zip eller klona ner med git clone via Code-knappen uppe till höger.  

Nödvändig förutsättning (Om inte installerat redan på dator):
[Download .NET](https://dotnet.microsoft.com/en-us/download)  

I din terminal så kör du:  
dotnet restore  
dotnet run  

Nu kan du surfa in på applikationen på angiven port och testa applikationen.

Vill du publicera/deploya applikationen så finns information nedan:  
[Host and deploy ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-6.0)  
[Deploy .NET Core apps with Visual Studio](https://learn.microsoft.com/en-us/dotnet/core/deploying/deploy-with-vs?tabs=vs156)  
[Publish .NET apps with the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/deploying/deploy-with-cli)  

  
# Inlämning 1 - Planering  
<ins>Val av idé:</ins>  
"2. En chatt där alla kan prata med alla, "som Slack ungefär", i så fall måste det vara tydligt vilket rum som är aktuellt och om rummets status påverkas."  

<ins>Typ (Arbetsorder):</ins>  
Tanken är att meddelandet som skickas innehåller tidstämpel (datum + klockslag), vem som skickat meddelandet, gällande vilket rum, meddelande, status och tilldelad till. Sedan kan man i realtid kunna toggla denna status via två knappar (andra anställda beroende på om det är åtgärdad eller under utredning) när man klickar på knappen så tilldelar den användaren automatiskt.

<ins>Typ (Chattmeddelande):</ins>  
tidstämpel (datum + klockslag), vem som skickat meddelandet och meddelande.

<ins>Initial planering (Kanban):</ins>  
1) [Öppna nedan Kanban bild i större storlek](https://github.com/niborium/Meddelandecentralen/blob/main/Kanban-initial.PNG)  
2) [Öppna Kanbanbrädet - Endast behöriga - Robin & Viktor](https://github.com/users/niborium/projects/1/views/1)   
3) [Se milstolpar och uppgifter](https://github.com/niborium/Meddelandecentralen/milestones)  
![Kanban](https://github.com/niborium/Meddelandecentralen/blob/main/Kanban-initial.PNG?raw=true)  

Observera att ovan är en Initial planering av arbetet. Det kan tillkomma uppgifter eller redigeras uppgifter under arbetets gång.

# Inlämning 2 - Lägesrapport
<ins>Klassdiagram:</ins>  
![Classdiagram](https://github.com/niborium/Meddelandecentralen/blob/main/Artefacts/Meddelandecentralen-classdiagram.png)

<ins>Kanban uppdatering:</ins>  
Ligger före planeringen med god marginal och har egentligen endast förbättring av meddelande formatet som kvarstår.
Det som kvarstår utöver det är tester (det som finns uppgifter för) och även eventuell förbättring av gränssnittet.

1) [Öppna nedan Kanban bild i större storlek](https://github.com/niborium/Meddelandecentralen/blob/main/Kanban-update.PNG)  
2) [Öppna Kanbanbrädet - Endast behöriga - Robin & Viktor](https://github.com/users/niborium/projects/1/views/1)   
3) [Se milstolpar och uppgifter](https://github.com/niborium/Meddelandecentralen/milestones)  
![Kanban](https://github.com/niborium/Meddelandecentralen/blob/main/Kanban-update.PNG?raw=true)  

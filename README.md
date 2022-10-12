# Meddelandecentralen
Chattapplikation för anställda hos Concorde Hotel New York för att hantera arbetsordrar och chatta med kollegor. 
# Teknik
Skapad med:  
[Blazor server (ASP.NET Core)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0) med [SignalR Hubs](https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-6.0)  
[SignalR Client](https://learn.microsoft.com/en-us/aspnet/core/signalr/client-features?view=aspnetcore-6.0)  
[BlazorStrap V5](https://blazorstrap.io/V5/)  

# Installationsanvisning  
Läggs till senare (inför överlämning och driftsättning) ..
  
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

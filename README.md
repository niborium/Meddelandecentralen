# Meddelandecentralen
Chattapplikation för anställda hos Concorde Hotel New York för att hantera arbetsordrar och chatta med kollegor. 
# Teknik
Skapad med:  
[Blazor server (ASP.NET Core)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0)  
[SignalR Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client)  
[BlazorStrap V5](https://blazorstrap.io/V5/)  
# Inlämning 1 - Planering  
Val av idé:  
"2. En chatt där alla kan prata med alla, "som Slack ungefär", i så fall måste det vara tydligt vilket rum som är aktuellt och om rummets status påverkas."  

Typ (Arbetsorder):  
Tanken är att meddelandet som skickas innehåller tidstämpel (datum + klockslag), vem som skickat meddelandet, gällande vilket rum, meddelande, status och tilldelad till. Sedan kan man i realtid kunna toggla denna status via två knappar (andra anställda beroende på om det är åtgärdad eller under utredning) när man klickar på knappen så tilldelar den användaren automatiskt.

Typ (Chattmeddelande):  
tidstämpel (datum + klockslag), vem som skickat meddelandet och meddelande.

Tillfällig planering (Kanban):
Kommer snart..

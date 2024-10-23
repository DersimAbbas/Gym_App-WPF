# Laboration 3 Gym bokningshantering Applikation Rapport
## Introduktion
Min labboration 3 " Gym bokningshantering Applikation" är designad till att hjälpa användaren som kör applikationen att hantera deras bokningsbara pass. Detta är uppnått genom att låta användaren som kör programmet -
1 - Att boka pass
2 - En sök funktion till att filtrera pass
3 - att kunna avboka pass som har bokats tidigare.
Programmet är skapad via WPF och följer MVVM design mönstret. Med hjälp av MVVM så är applikationen skalbar med händelsestyrd Programmering.

## Design Översikt
Projektet som jag har byggt är struktuerad runt MVVM arkitektur. vilket separerar applikationen till:
**Models**
- Representerar datan som jag har skapat med olika filer och klasser (Sessions, Users, BookingManager).
- hanterar business logik såsom boka pass användare hantering (vem som kör programmet och sparar data baserat på det med user instans) och kunna avboka pass.
**ViewModels** 
- Agerar mellan Models och Views.
- Hanterar appens logik och properties/metoder för interaktioner med UI. Tex: UserBookingViewModel och BookingViewModel hanterar logiken för visning av filtering i sökfunktionen i searchbah, bokning, och avbokning.
- Implementationen av INotifyPropertyChanged gör så att UI blir notifierad av ändring i datan och säkerställer live uppdatering.
**Views**
  - Definerar UI komponenterna.
  - binder data från properties i Viewmodels.
  - hanterar användarens input i searchbar/textbox.
  - UserControl i lediga pass page visar tillgängliga pass och listview så uppdateras datan dynamiskt beroende på sökning eller om man har bokat ett pass.
    
## Skalbarhet
Med hjälp av MVVM så är applikationen designad till att vara Skalbar på grund av uppdelning av filer med separerat ansvar vilket säkerställer-
att kod i en annan fil behöver inte ändras för att lägga till ett nytt pass i metoden LoadSessions()
Detta gäller även om man vill expandera sök funktionen med hjälp av LINQ query utan att behöva skriva om hela metoden.

Applikationen kan expanderas med mer data i framtiden med hjälp av DataBaser.
- Arkitekturen kring projektet stödjer att gå ifrån fil baserat lagring av data till data bas utan att behöva ändra mycket i projektet.
- Det tillåter att appen att utökas med fler användare och mer data.

## HändelseStyrdProgrammering
Applikationen förlitar sig mycket på Händelsestyrd kodning.
- CommandBindings: Användar Interkationer såsom boka/avboka/filtrera pass är hanterad genom Kommandon (ICommand) i XAML vilket är bunden till UI.
- Ett exempel : CancelBookedCommand triggar händelse då passet blir avbokat från både listan i backended och UI som vi ser i views.
- live uppdatering dynamiskt, Med INotifyPropertyChanged interface så säkerställer det att alla properties som SelectedBookedSession eller FilteredBookedSession ändras vilket gör att UI blir notifierad och uppdateras direkt.

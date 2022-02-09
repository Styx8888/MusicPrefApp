# MusicPrefApp
## Intro
This application uses Blazor Server side, it is similar to MVC in many ways, and gives many interesting opportunities.
Some information about differences can be found here:
https://www.telerik.com/blogs/difference-between-blazor-vs-razor

## Additional libraries used in the project
- Mudblazor components for Blazor : https://mudblazor.com/getting-started/installation
- RestEase for API Service : https://github.com/canton7/RestEase
- FluentValidation
- ServiceStack.Text for CSV export

## Requirements
- .NET 5.0
- Visual Studio 2019 or Visual Studio Code (For code check)

## How To Run It
- Fill the needed information in the appsettings.json (ClientId and ClientSecret)
- execute dotnet run command in directory MusicPrefApp(Root)\MusicPrefApp.UI
- Run it using visual studio code or visual studio 2019 with or without debugger

### Additional Information
- UI uses AppState for keeping the application states and refreshing correct components
- Some questions are dependant on each other (dynamic check options creation)
- UI part is not polished enough - it can have some common components
- To Add a new question, you need to implement IQuestion interface and then create UI component for it 
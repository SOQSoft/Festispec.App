
# Festispec.Database

## Installation

**1.**  Clone de repository 

**2.**  Open Command promp 

**3.**  `cd` naar de map met het project 

**4.** Voer de volgende lijnen uit
```cmd
#Restore npm packages
dotnet restore

# Restore database
dotnet ef database update
```


## Development
Nadat je aanpassingen aan de database models hebt gemaakt moet je migraties toevoegen om het daadwerkelijk te laten werken. 
Doe dit door de volgende commando uit te voeren: 
```cmd
#Restore npm packages
dotnet restore

# Add migration
dotnet ef migrations add #migrationname
```
#migrationname = Migratienaam bijvoorbeeld `Added users Name`




## Testing

### Tests draaien doormiddel van command line 
Het is mogelijk om via bash of cmd te draaien hiervoor moet je de volgende commando's invoeren: 
``` 
#Restore npm packages
dotnet restore

# Restore database
dotnet ef database update

# Run tests
dotnet test
```
### Tests draaien door middel van Visual studio
1.  Open  **Test Explorer**.
    
    ![On the Test menu, open Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/media/rununittest1.png?view=vs-2017)
    
2.  Run unit tests.
    
    ![Run unit tests in Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/media/rununittest2.png?view=vs-2017)
    
    Je kan in de de valende en werkende tests zien in  **Test Explorer**.
    
    ![Review unit test results in Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/media/rununittest3.png?view=vs-2017)


## Deployment
Voer de volgende commando uit in cmd, bash om de laatste versie op de halen binnen de andere reposiories
```
git submodule update --recursive --remote
```

Voor deze repository is geen deployment nodig deze wordt mee gedeployed met [Festispec.Api](https://github.com/SOQSoft/Festispec.Api)

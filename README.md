
# Festispec.App

## Installation

 **1.**  Clone de repository  using 
 
```cmd
git clone --recurse-submodules -j8 https://github.com/SOQSoft/Festispec.App.git
```

 
**2.** Open project in visual studio


**3.** Bij ``build`` klik op  ``Clean Solution``

**4.** Klik op start op het project te starten
  <img src="https://i.imgur.com/fh5Zaah.png" width="400"/>


## Development

Om de webapplicatie te draaien via cmd voer de volgende commando's uit
```cmd
#Restore npm packages
dotnet restore

# Restore database
dotnet ef database update

# Run project 
dotnet run
```


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
### Deployment method
Deployments gaan automatish doormiddel van intergratie van azure devops, zodra er iets naar de develop branch wordt gepushed wordt deze automatish op de test server gedeployed. 
Wil je het deployen naar de master server push dan de code van develop naar  ``Release`` aan in github, 


1.  Open Github en navigeer naar de repository.
    
2.  Under your repository name, click **Releases**.
![Releases tab](https://help.github.com/assets/images/help/releases/release-link.png =818x170)
    
3.  klik op **Draft a new release**.

![Releases tab](https://help.github.com/assets/images/help/releases/draft_release_button.png =371x171)

4.  ![Releases tagged version](https://github.com/SOQSoft/Technisch-Ontwerp/wiki/Versiebeheer =360x49) Schrijf het versie nummer neer van welke versie het is gebruik hierbij de benaming van het het  [versie beheer](https://git-scm.com/book/en/Git-Basics-Tagging) van het technish ontwerp.
5. Selecteer de master branch  pak geen andere branch anders kunnen testen fout gaan.
![Releases tagged branch](https://help.github.com/assets/images/help/releases/releases_tag_branch.png =356x104)
      
6. Schijf een titel en een beschrijving met wat er in deze release zit.  
7. ![Releases description](https://help.github.com/assets/images/help/releases/releases_description.png =401x249)
8.  ![Marking it as a prerelease](/assets/images/help/releases/prerelease_checkbox.png) Als je hem wilt releasen maar niet wilt deployen naar productie zet hem dan naar **This is a pre-release** dan zou hij door de  tweede test server in gebruik worde genomen. 
9.  Als je klaar bent om het te deployen klik dan op **Publish release**, wil je nog even wachten klik dan op **Save draft**
![Publish or draft release buttons](https://help.github.com/assets/images/help/releases/release_buttons.png =200x100)
10. Download nu de laatste versie van de release tab en verdeel dat onder de gebruikers

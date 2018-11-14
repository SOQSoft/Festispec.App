CREATE TABLE [dbo].[inspectie_werkgroep]
(
	[idInspectie] INT NOT NULL, 
    [idMedewerker] INT NOT NULL
	FOREIGN KEY (idInspectie) REFERENCES inspectie(id) ON DELETE CASCADE 
	FOREIGN KEY (idMedewerker) REFERENCES medewerker(id) ON DELETE CASCADE 
)

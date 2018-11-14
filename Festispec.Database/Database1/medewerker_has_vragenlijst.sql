CREATE TABLE [dbo].[medewerker_has_vragenlijst]
(
	[idMedewerker] INT NOT NULL, 
    [idVragenlijst] INT NOT NULL
	FOREIGN KEY (idVragenlijst) REFERENCES vragenlijst(id) ON DELETE CASCADE 
	FOREIGN KEY (idMedewerker) REFERENCES medewerker(id) ON DELETE CASCADE 
)

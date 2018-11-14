CREATE TABLE [dbo].[rapport]
(
	[idRapport] INT NOT NULL PRIMARY KEY IDENTITY, 
    [datum] DATE NOT NULL, 
    [idInspectie] INT NOT NULL, 
    [conclusie] TEXT NULL
	FOREIGN KEY (idInspectie) REFERENCES inspectie(id) ON DELETE CASCADE
)

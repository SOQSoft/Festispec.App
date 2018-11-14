CREATE TABLE [dbo].[antwoord]
(
	[idAntwoord] INT NOT NULL PRIMARY KEY IDENTITY, 
    [inhoud] TEXT NULL, 
    [idVraag] INT NOT NULL, 
    [ingevuld_antwoord] TEXT NOT NULL
	FOREIGN KEY (idVraag) REFERENCES vraag(id) ON DELETE CASCADE 
)

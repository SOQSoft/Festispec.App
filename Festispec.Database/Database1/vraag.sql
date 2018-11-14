CREATE TABLE [dbo].[vraag]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [inhoud] TEXT NOT NULL, 
    [idVragenlijst] INT NOT NULL
	FOREIGN KEY (idVragenlijst) REFERENCES vragenlijst(id) ON DELETE CASCADE 
)

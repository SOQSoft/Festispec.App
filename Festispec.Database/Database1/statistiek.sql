CREATE TABLE [dbo].[statistiek]
(
	[idStatistiek] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idRapport] INT NOT NULL, 
    [grafiek] VARCHAR(50) NOT NULL, 
    [beschrijving] TEXT NOT NULL,
    FOREIGN KEY (idRapport) REFERENCES rapport(idRapport) ON DELETE CASCADE
)
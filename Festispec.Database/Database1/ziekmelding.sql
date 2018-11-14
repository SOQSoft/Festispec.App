CREATE TABLE [dbo].[ziekmelding]
(
	[idZiekmelding] INT NOT NULL PRIMARY KEY IDENTITY, 
    [datum_ziek] DATE NOT NULL, 
    [datum_beter] DATE NULL, 
    [idMedewerker] INT NOT NULL
	FOREIGN KEY (idMedewerker) REFERENCES medewerker(id) ON DELETE CASCADE 
)

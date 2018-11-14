CREATE TABLE [dbo].[medewerker]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idUser] INT NOT NULL, 
    [voornaam] VARCHAR(50) NOT NULL, 
    [tussenvoegsel] VARCHAR(3) NULL, 
    [achernaam] VARCHAR(50) NOT NULL, 
    [geboortedatum] DATE NOT NULL,
	FOREIGN KEY (idUser) REFERENCES [user](id) ON DELETE CASCADE 
)

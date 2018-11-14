CREATE TABLE [dbo].[sollicitant]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [voornaam] VARCHAR(50) NOT NULL,
    [tussenvoegsel] VARCHAR(3) NULL,
    [achternaam] VARCHAR(50) NOT NULL, 
    [gebdatum] DATE NOT NULL, 
    [cvFilename] VARCHAR(50) NOT NULL, 
    [sollicitatiedatum] DATE NULL,
)

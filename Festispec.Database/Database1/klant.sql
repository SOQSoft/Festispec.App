CREATE TABLE [dbo].[klant]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [voornaam] VARCHAR(50) NOT NULL, 
    [tussenvoegsel] VARCHAR(3) NULL, 
    [achternaam] VARCHAR(50) NOT NULL, 
    [telnummer] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[factuur]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [opdracht] TEXT NOT NULL, 
    [kosten] FLOAT NOT NULL, 
    [is_Betaald] TINYINT NOT NULL,
    [is_Offerte] TINYINT NOT NULL
)

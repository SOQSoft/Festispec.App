CREATE TABLE [dbo].[inspectie]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idKlant] INT NOT NULL, 
    [idFactuur] INT NOT NULL,
	[idOfferte] INT NOT NULL,
    [idVragenlijst] INT NOT NULL, 
    [datum] DATE NOT NULL, 
    [is_geannuleerd] TINYINT NOT NULL, 
    [is_afgerond] TINYINT NOT NULL,
	FOREIGN KEY (idFactuur) REFERENCES factuur(id) ON DELETE CASCADE,
	FOREIGN KEY (idOfferte) REFERENCES offerte(id) ON DELETE CASCADE, 
	FOREIGN KEY (idKlant) REFERENCES klant(id) ON DELETE CASCADE,
	FOREIGN KEY (idVragenlijst) REFERENCES vragenlijst(id) ON DELETE CASCADE 
)

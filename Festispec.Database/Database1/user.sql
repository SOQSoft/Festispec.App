CREATE TABLE [dbo].[user]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idRol] INT NOT NULL, 
    [username] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(50) NOT NULL
	FOREIGN KEY (idRol) REFERENCES role_lookup(id) ON DELETE CASCADE 
)

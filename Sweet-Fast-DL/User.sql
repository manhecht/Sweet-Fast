CREATE TABLE [dbo].[Table1]
(
	[userID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [vorname] VARCHAR(50) NOT NULL, 
    [zuname] VARCHAR(50) NOT NULL, 
    [passwort] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [telefonnummer] VARCHAR(50) NOT NULL, 
    [strasse] VARCHAR(50) NOT NULL, 
    [hausnummer] INT NOT NULL, 
    [türnummer] INT NULL, 
    [plz] INT NOT NULL, 
    [ort] NVARCHAR(50) NOT NULL 
)

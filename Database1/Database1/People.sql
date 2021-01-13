CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CarId] INT NULL,
    [Imie] VARCHAR(50) NULL, 
    [Nazwisko] VARCHAR(50) NULL, 
    [Rok_urodzenia] DATE NULL, 
    CONSTRAINT [FK_People_Car] FOREIGN KEY ([CarId]) REFERENCES [CarRentalTable]([Id]) 
)

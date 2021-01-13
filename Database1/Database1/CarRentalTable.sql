CREATE TABLE [dbo].[CarRentalTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Marka] VARCHAR(50) NULL, 
    [Model] VARCHAR(50) NULL, 
    [Rok_produkcji] INT NULL, 
    [Moc_silnika] INT NULL, 
    [Rodzaj_paliwa] VARCHAR(50) NULL
)

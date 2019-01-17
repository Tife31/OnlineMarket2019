CREATE TABLE [dbo].[Market]
(
	[ProductId] INT NOT NULL PRIMARY KEY,
	[ProductTitle] NVARCHAR(200) NOT NULL,
	[ProductPrice] INT NOT NULL,
	[ProductInventory] INT NOT NULL
)

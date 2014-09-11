CREATE TABLE [Datasheet].[Category]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ParentCategoryId] INT NULL,
	[CategoryName] VARCHAR(128) NULL,
	CONSTRAINT FK_CATEGORY_CATEGORY FOREIGN KEY (ParentCategoryId)
	REFERENCES [Datasheet].[Category](CategoryId)
)

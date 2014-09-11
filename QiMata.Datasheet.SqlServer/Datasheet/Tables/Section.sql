CREATE TABLE [Datasheet].[Section]
(
	[SectionId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[SectionText] VARCHAR(MAX) NULL,
	[SectionImage] VARBINARY(MAX) NULL,
	[ParentSectionId] INT NULL,
	[DatasheetId] INT NOT NULL,
	CONSTRAINT FK_SECTION_DATASHEET FOREIGN KEY (DatasheetId)
	REFERENCES [Datasheet].[Datasheet](DatasheetId),
	CONSTRAINT FK_SECTION_SECTION FOREIGN KEY (ParentSectionId)
	REFERENCES [Datasheet].[Section](SectionId)
)

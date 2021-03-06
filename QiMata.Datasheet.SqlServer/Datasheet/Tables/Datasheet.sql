﻿CREATE TABLE [Datasheet].[Datasheet]
(
	[DatasheetId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Pdf] VARBINARY(MAX) NOT NULL,
	[DateSaved] DATETIMEOFFSET(0) NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	[PdfProvider] VARCHAR(128) NOT NULL, 
    [FilePath] NVARCHAR(256) NOT NULL UNIQUE
)

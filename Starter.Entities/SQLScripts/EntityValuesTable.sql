USE [Starter.Database]
GO

/****** Object:  Table [dbo].[EntityValues]    Script Date: 5/12/2021 5:06:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntityValues](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntityId] [bigint] NOT NULL,
	[AttributeId] [bigint] NOT NULL,
	[DataTypeId] [bigint] NULL,
	[LanguageId] [bigint] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EntityValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EntityValues]  WITH CHECK ADD  CONSTRAINT [FK_EntityValues_AttributeDataTypes_DataTypeId] FOREIGN KEY([DataTypeId])
REFERENCES [dbo].[AttributeDataTypes] ([Id])
GO

ALTER TABLE [dbo].[EntityValues] CHECK CONSTRAINT [FK_EntityValues_AttributeDataTypes_DataTypeId]
GO

ALTER TABLE [dbo].[EntityValues]  WITH CHECK ADD  CONSTRAINT [FK_EntityValues_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([Id])
GO

ALTER TABLE [dbo].[EntityValues] CHECK CONSTRAINT [FK_EntityValues_Attributes_AttributeId]
GO

ALTER TABLE [dbo].[EntityValues]  WITH CHECK ADD  CONSTRAINT [FK_EntityValues_Entities_EntityId] FOREIGN KEY([EntityId])
REFERENCES [dbo].[Entities] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EntityValues] CHECK CONSTRAINT [FK_EntityValues_Entities_EntityId]
GO

ALTER TABLE [dbo].[EntityValues]  WITH CHECK ADD  CONSTRAINT [FK_EntityValues_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EntityValues] CHECK CONSTRAINT [FK_EntityValues_Languages_LanguageId]
GO


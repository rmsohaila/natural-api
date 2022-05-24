USE [Starter.Database]
GO

/****** Object:  Table [dbo].[EntityCulturalName]    Script Date: 5/12/2021 5:06:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntityCulturalName](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntityId] [bigint] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_EntityCulturalName] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EntityCulturalName]  WITH CHECK ADD  CONSTRAINT [FK_EntityCulturalName_Entities_EntityId] FOREIGN KEY([EntityId])
REFERENCES [dbo].[Entities] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EntityCulturalName] CHECK CONSTRAINT [FK_EntityCulturalName_Entities_EntityId]
GO

ALTER TABLE [dbo].[EntityCulturalName]  WITH CHECK ADD  CONSTRAINT [FK_EntityCulturalName_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EntityCulturalName] CHECK CONSTRAINT [FK_EntityCulturalName_Languages_LanguageId]
GO


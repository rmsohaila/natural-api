USE [Starter.Database]
GO

/****** Object:  Table [dbo].[TemplateCulturalNames]    Script Date: 5/12/2021 5:07:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TemplateCulturalNames](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateId] [bigint] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_TemplateCulturalNames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TemplateCulturalNames]  WITH CHECK ADD  CONSTRAINT [FK_TemplateCulturalNames_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TemplateCulturalNames] CHECK CONSTRAINT [FK_TemplateCulturalNames_Languages_LanguageId]
GO

ALTER TABLE [dbo].[TemplateCulturalNames]  WITH CHECK ADD  CONSTRAINT [FK_TemplateCulturalNames_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TemplateCulturalNames] CHECK CONSTRAINT [FK_TemplateCulturalNames_Templates_TemplateId]
GO


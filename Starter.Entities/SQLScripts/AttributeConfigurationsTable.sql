USE [Starter.Database]
GO

/****** Object:  Table [dbo].[AttributeConfigurations]    Script Date: 5/12/2021 5:04:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AttributeConfigurations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AttributeId] [bigint] NOT NULL,
	[LanguageId] [bigint] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttributeConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AttributeConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_AttributeConfigurations_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AttributeConfigurations] CHECK CONSTRAINT [FK_AttributeConfigurations_Attributes_AttributeId]
GO

ALTER TABLE [dbo].[AttributeConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_AttributeConfigurations_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AttributeConfigurations] CHECK CONSTRAINT [FK_AttributeConfigurations_Languages_LanguageId]
GO



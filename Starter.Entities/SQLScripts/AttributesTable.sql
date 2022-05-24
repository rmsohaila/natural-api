USE [Starter.Database]
GO

/****** Object:  Table [dbo].[Attributes]    Script Date: 5/12/2021 5:05:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Attributes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DataTypeId] [bigint] NULL,
	[MarkEntityForLabeling] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [bigint] NOT NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Attributes] ADD  CONSTRAINT [DF__Attribute__MarkE__4222D4EF]  DEFAULT (CONVERT([bit],(0))) FOR [MarkEntityForLabeling]
GO

ALTER TABLE [dbo].[Attributes]  WITH CHECK ADD  CONSTRAINT [FK_Attributes_AttributeDataTypes_DataTypeId] FOREIGN KEY([DataTypeId])
REFERENCES [dbo].[AttributeDataTypes] ([Id])
GO

ALTER TABLE [dbo].[Attributes] CHECK CONSTRAINT [FK_Attributes_AttributeDataTypes_DataTypeId]
GO

ALTER TABLE [dbo].[Attributes]  WITH CHECK ADD  CONSTRAINT [FK_Attributes_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Attributes] CHECK CONSTRAINT [FK_Attributes_Templates_TemplateId]
GO


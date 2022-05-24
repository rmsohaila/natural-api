USE [Starter.Database]
GO

/****** Object:  Table [dbo].[Entities]    Script Date: 5/12/2021 5:06:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Entities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MarkForLabeling] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [bigint] NOT NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Entities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Entities] ADD  CONSTRAINT [DF_Entities_MarkForLabeling]  DEFAULT ((0)) FOR [MarkForLabeling]
GO

ALTER TABLE [dbo].[Entities]  WITH CHECK ADD  CONSTRAINT [FK_Entities_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Entities] CHECK CONSTRAINT [FK_Entities_Templates_TemplateId]
GO


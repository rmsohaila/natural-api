USE [Starter.Database]
GO

/****** Object:  Table [dbo].[Samples]    Script Date: 5/12/2021 5:07:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Samples](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IntentId] [bigint] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [bigint] NOT NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Samples] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Samples]  WITH CHECK ADD  CONSTRAINT [FK_Samples_Intents_IntentId] FOREIGN KEY([IntentId])
REFERENCES [dbo].[Intents] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Samples] CHECK CONSTRAINT [FK_Samples_Intents_IntentId]
GO


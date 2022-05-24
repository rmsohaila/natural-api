USE [Starter.Database]
GO

/****** Object:  Table [dbo].[Intents]    Script Date: 5/12/2021 5:06:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Intents](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [bigint] NOT NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Intents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


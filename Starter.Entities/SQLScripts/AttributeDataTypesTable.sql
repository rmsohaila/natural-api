USE [Starter.Database]
GO

/****** Object:  Table [dbo].[AttributeDataTypes]    Script Date: 5/12/2021 5:05:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AttributeDataTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DBType] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_AttributeDataTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Starter.Database]
GO

/****** Object:  Table [dbo].[SampleTypes]    Script Date: 5/12/2021 5:07:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SampleTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[WordStartIndex] [int] NOT NULL,
	[WordEndIndex] [int] NOT NULL,
	[SampleId] [bigint] NULL,
 CONSTRAINT [PK_SampleTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SampleTypes]  WITH CHECK ADD  CONSTRAINT [FK_SampleTypes_Samples_SampleId] FOREIGN KEY([SampleId])
REFERENCES [dbo].[Samples] ([Id])
GO

ALTER TABLE [dbo].[SampleTypes] CHECK CONSTRAINT [FK_SampleTypes_Samples_SampleId]
GO


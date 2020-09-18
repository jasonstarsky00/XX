USE [XX]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ChapterContent', @level2type=N'COLUMN',@level2name=N'chapterContent'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ChapterContent', @level2type=N'COLUMN',@level2name=N'catalogId'

GO

ALTER TABLE [dbo].[XX_ChapterContent] DROP CONSTRAINT [DF_XX_ChapterContent_createTime]
GO

/****** Object:  Table [dbo].[XX_ChapterContent]    Script Date: 2020/9/18 19:20:59 ******/
DROP TABLE [dbo].[XX_ChapterContent]
GO

/****** Object:  Table [dbo].[XX_ChapterContent]    Script Date: 2020/9/18 19:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[XX_ChapterContent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[catalogId] [int] NOT NULL,
	[chapterContent] [nvarchar](max) NOT NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_ChapterContent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[XX_ChapterContent] ADD  CONSTRAINT [DF_XX_ChapterContent_createTime]  DEFAULT (getdate()) FOR [createTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ä¿Â¼id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ChapterContent', @level2type=N'COLUMN',@level2name=N'catalogId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÕÂ½ÚÄÚÈÝ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ChapterContent', @level2type=N'COLUMN',@level2name=N'chapterContent'
GO



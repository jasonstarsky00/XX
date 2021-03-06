USE [XX]
GO
/****** Object:  Table [dbo].[XX_ColletionWeb]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_ColletionWeb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[webName] [nvarchar](50) NULL,
	[webUrl] [nvarchar](50) NULL,
	[webDescription] [nvarchar](200) NULL,
	[webLevel] [int] NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_ColletionWeb] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[XX_ColletionWeb] ON 

INSERT [dbo].[XX_ColletionWeb] ([id], [webName], [webUrl], [webDescription], [webLevel], [createTime]) VALUES (1, N'笔趣阁', N'https://www.biquge.com.cn/search.php?q=', N'url跟小说名称获取查询结果', 10, CAST(0x0000AC16017BCBCC AS DateTime))
INSERT [dbo].[XX_ColletionWeb] ([id], [webName], [webUrl], [webDescription], [webLevel], [createTime]) VALUES (2, N'纵横网', N'https://www.zh.com', N'纵横哇偶拉开进攻', 9, CAST(0x0000AC1601852A37 AS DateTime))
SET IDENTITY_INSERT [dbo].[XX_ColletionWeb] OFF
ALTER TABLE [dbo].[XX_ColletionWeb] ADD  CONSTRAINT [DF_XX_ColletionWeb_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ColletionWeb', @level2type=N'COLUMN',@level2name=N'webName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ColletionWeb', @level2type=N'COLUMN',@level2name=N'webUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ColletionWeb', @level2type=N'COLUMN',@level2name=N'webDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采集级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_ColletionWeb', @level2type=N'COLUMN',@level2name=N'webLevel'
GO

USE [XX]
GO
/****** Object:  Table [dbo].[XX_FictionType]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_FictionType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[type] [int] NOT NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_Fiction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[XX_FictionType] ON 

INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (1, N'玄幻', 1, CAST(0x0000ABFC01874327 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (2, N'都市', 1, CAST(0x0000ABFC01875B45 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (3, N'仙侠', 1, CAST(0x0000ABFC0187662A AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (4, N'游戏', 1, CAST(0x0000ABFC018772D7 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (5, N'现代言情', 2, CAST(0x0000ABFC01877A3C AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (6, N'穿越重生', 2, CAST(0x0000ABFC01877F63 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (7, N'豪门总裁', 2, CAST(0x0000ABFC0187845D AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (8, N'仙侠奇缘', 2, CAST(0x0000ABFC01878A78 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (9, N'医生', 3, CAST(0x0000ABFC0187936B AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (10, N'都市', 3, CAST(0x0000ABFC01879C01 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (11, N'种田', 3, CAST(0x0000ABFC0187A9E4 AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (12, N'特种兵', 3, CAST(0x0000ABFC0187AC7C AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (16, N'测试12', 3, CAST(0x0000ABFD0162444F AS DateTime))
INSERT [dbo].[XX_FictionType] ([id], [name], [type], [createTime]) VALUES (17, N'哈哈哈', 1, CAST(0x0000ABFD0162554A AS DateTime))
SET IDENTITY_INSERT [dbo].[XX_FictionType] OFF
ALTER TABLE [dbo].[XX_FictionType] ADD  CONSTRAINT [DF_XX_Fiction_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_FictionType', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类类型：1男生标签分类，2女生分类，3标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_FictionType', @level2type=N'COLUMN',@level2name=N'type'
GO

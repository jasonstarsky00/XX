USE [XX]
GO
/****** Object:  Table [dbo].[XX_Role]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](50) NOT NULL,
	[isEnable] [int] NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[XX_Role] ON 

INSERT [dbo].[XX_Role] ([id], [roleName], [isEnable], [createTime]) VALUES (1, N'超级管理员', 1, CAST(0x0000ABF601131CC3 AS DateTime))
INSERT [dbo].[XX_Role] ([id], [roleName], [isEnable], [createTime]) VALUES (2, N'管理员', 1, CAST(0x0000ABF601132493 AS DateTime))
INSERT [dbo].[XX_Role] ([id], [roleName], [isEnable], [createTime]) VALUES (3, N'测试角色', 0, CAST(0x0000ABF900AA2EEA AS DateTime))
INSERT [dbo].[XX_Role] ([id], [roleName], [isEnable], [createTime]) VALUES (4, N'小说管理', 1, CAST(0x0000ABF900B376BF AS DateTime))
INSERT [dbo].[XX_Role] ([id], [roleName], [isEnable], [createTime]) VALUES (8, N'动1', 1, CAST(0x0000ABFB0146DF31 AS DateTime))
SET IDENTITY_INSERT [dbo].[XX_Role] OFF
ALTER TABLE [dbo].[XX_Role] ADD  CONSTRAINT [DF_XX_Role_isEnable]  DEFAULT ((1)) FOR [isEnable]
GO
ALTER TABLE [dbo].[XX_Role] ADD  CONSTRAINT [DF_XX_Role_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Role', @level2type=N'COLUMN',@level2name=N'roleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用0否1是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Role', @level2type=N'COLUMN',@level2name=N'isEnable'
GO

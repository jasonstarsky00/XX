USE [XX]
GO
/****** Object:  Table [dbo].[XX_Permission]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_Permission](
	[permissId] [int] NOT NULL,
	[parentId] [int] NOT NULL,
	[permissName] [nvarchar](50) NOT NULL,
	[controller] [nvarchar](50) NOT NULL,
	[action] [nvarchar](50) NOT NULL,
	[type] [int] NULL,
	[sort] [int] NULL,
	[isEnable] [int] NULL,
	[isLog] [int] NULL,
	[createTime] [datetime] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (1, 0, N'用户管理', N'user', N'index', 1, 1, 1, 1, CAST(0x0000ABF601139EAC AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (2, 0, N'小说管理', N'Fiction', N'index', 3, 1, 1, 1, CAST(0x0000ABF6011403FF AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100101, 1, N'用户列表', N'user', N'userList', 3, 1, 1, 1, CAST(0x0000ABF6011447C4 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102, 1, N'角色列表', N'Role', N'roleList', 3, 1, 1, 1, CAST(0x0000ABF601147710 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101, 2, N'小说分类', N'Fiction', N'FictionType', 3, 1, 1, 1, CAST(0x0000ABF6011508BD AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200102, 2, N'小说列表', N'Fiction', N'FictionList', 3, 1, 1, 1, CAST(0x0000ABF601151C36 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100101101, 100101, N'编辑用户', N'user', N'UserEdit', 2, 1, 1, 1, CAST(0x0000ABF6011D54DB AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100101102, 100101, N'获取用户信息', N'user', N'GetUser', 2, 1, 1, 1, CAST(0x0000ABF6011D6950 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100101103, 100101, N'删除用户', N'user', N'DeleteUser', 2, 1, 1, 1, CAST(0x0000ABF6011D80B4 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102101, 100102, N'修改角色状态', N'Role', N'EditIsEnable', 2, 1, 1, 1, CAST(0x0000ABFB016DFC98 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102102, 100102, N'添加角色', N'Role', N'AddRole', 2, 1, 1, 1, CAST(0x0000ABFB016E6494 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102103, 100102, N'查询角色信息', N'Role', N'GetRole', 2, 1, 1, 1, CAST(0x0000ABFB016EAEB5 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102104, 100102, N'编辑角色', N'Role', N'EditRole', 2, 1, 1, 1, CAST(0x0000ABFB016EDBDB AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (100102105, 100102, N'删除角色', N'Role', N'DeleteRole', 2, 1, 1, 1, CAST(0x0000ABFB016F0AAE AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (3, 0, N'权限', N'1', N'1', 2, 1, 1, 1, CAST(0x0000ABFB016FDDAA AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (300101, 3, N'获取菜单', N'Permission', N'GetMenus', 2, 1, 1, 1, CAST(0x0000ABFB017073D8 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (300102, 3, N'获取权限', N'Permission', N'GetPermissions', 2, 1, 1, 1, CAST(0x0000ABFB0170CBAD AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (300103, 3, N'获取角色权限', N'Permission', N'GetRolePermissions', 2, 1, 1, 1, CAST(0x0000ABFB0171101F AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (300104, 3, N'角色授权', N'Permission', N'RoleAddPermissions', 2, 1, 1, 1, CAST(0x0000ABFB01714D98 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101103, 200101, N'删除', N'Fiction', N'DeleteFictionType', 2, 1, 1, 1, CAST(0x0000ABFD0133B7AA AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101104, 200101, N'编辑', N'Fiction', N'EditFictionType', 2, 1, 1, 1, CAST(0x0000ABFD015D628D AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101105, 200101, N'获取小说分类', N'Fiction', N'GetFictionType', 2, 1, 1, 1, CAST(0x0000ABFD015E1171 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200201101, 200102, N'删除小说', N'Fiction', N'DeleteFiction', 2, 1, 1, 1, CAST(0x0000ABFE015ED365 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (202201102, 200102, N'获取小说', N'Fiction', N'GetFiction', 2, 1, 1, 1, CAST(0x0000ABFF00EE537D AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (202101103, 200101, N'获取小说章节', N'Fiction', N'GetFictionCatalog', 2, 1, 1, 1, CAST(0x0000ABFF011351C7 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (4, 0, N'采集', N'Collection', N'index', 1, 1, 1, 1, CAST(0x0000ABFF011391A8 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (400102, 4, N'获取生成的xml文件', N'Collection', N'GetFictionXml', 2, 1, 1, 1, CAST(0x0000AC05001026BC AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (400103, 4, N'读取xml文件插入小说', N'Collection', N'InsertFiction', 2, 1, 1, 1, CAST(0x0000AC05001095C1 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101101, 200101, N'小说分类列表', N'Fiction', N'FictionTypeList', 2, 1, 1, 1, CAST(0x0000ABFD01298A7D AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (200101102, 200101, N'添加小说分类', N'Fiction', N'AddFictionType', 2, 1, 1, 1, CAST(0x0000ABFD012A4185 AS DateTime))
INSERT [dbo].[XX_Permission] ([permissId], [parentId], [permissName], [controller], [action], [type], [sort], [isEnable], [isLog], [createTime]) VALUES (400101, 4, N'初始化小说库', N'Collection', N'Init', 3, 1, 1, 1, CAST(0x0000ABFF012DF51C AS DateTime))
ALTER TABLE [dbo].[XX_Permission] ADD  CONSTRAINT [DF_XX_Permission_type]  DEFAULT ((2)) FOR [type]
GO
ALTER TABLE [dbo].[XX_Permission] ADD  CONSTRAINT [DF_XX_Permission_sort]  DEFAULT ((1)) FOR [sort]
GO
ALTER TABLE [dbo].[XX_Permission] ADD  CONSTRAINT [DF_XX_Permission_isEnable]  DEFAULT ((1)) FOR [isEnable]
GO
ALTER TABLE [dbo].[XX_Permission] ADD  CONSTRAINT [DF_XX_Permission_isLog]  DEFAULT ((1)) FOR [isLog]
GO
ALTER TABLE [dbo].[XX_Permission] ADD  CONSTRAINT [DF_XX_Permission_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单权限id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'permissId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'parentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'permissName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'controller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'action'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限类型：1菜单，2权限功能，3两者都是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用 0否1启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'isEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否记录日志 0否1是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XX_Permission', @level2type=N'COLUMN',@level2name=N'isLog'
GO

USE [XX]
GO
/****** Object:  Table [dbo].[XX_RolePermission]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_RolePermission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [int] NOT NULL,
	[permissionId] [int] NOT NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_RolePermission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[XX_RolePermission] ON 

INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (10, 2, 1, CAST(0x0000ABFA0186008C AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (12, 2, 2, CAST(0x0000ABFA01860774 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (46, 4, 1, CAST(0x0000ABFB0145ABB0 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (47, 4, 100101, CAST(0x0000ABFB0145ABB2 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (48, 4, 100101103, CAST(0x0000ABFB0145ABB4 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (49, 8, 100101101, CAST(0x0000ABFB0146F5D9 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (306, 1, 1, CAST(0x0000AC050012C820 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (307, 1, 100101, CAST(0x0000AC050012C823 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (308, 1, 100101101, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (309, 1, 100101102, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (310, 1, 100101103, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (311, 1, 100102, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (312, 1, 100102101, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (313, 1, 100102102, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (314, 1, 100102103, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (315, 1, 100102104, CAST(0x0000AC050012C824 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (316, 1, 100102105, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (317, 1, 2, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (318, 1, 200101, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (319, 1, 200101103, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (320, 1, 200101104, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (321, 1, 200101105, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (322, 1, 202101103, CAST(0x0000AC050012C825 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (323, 1, 200101101, CAST(0x0000AC050012C826 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (324, 1, 200101102, CAST(0x0000AC050012C826 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (325, 1, 200102, CAST(0x0000AC050012C826 AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (326, 1, 200201101, CAST(0x0000AC050012C82B AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (327, 1, 202201102, CAST(0x0000AC050012C82B AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (328, 1, 3, CAST(0x0000AC050012C82B AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (329, 1, 300101, CAST(0x0000AC050012C82D AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (330, 1, 300102, CAST(0x0000AC050012C82D AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (331, 1, 300103, CAST(0x0000AC050012C82F AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (332, 1, 300104, CAST(0x0000AC050012C82F AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (333, 1, 4, CAST(0x0000AC050012C82F AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (334, 1, 400102, CAST(0x0000AC050012C82F AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (335, 1, 400103, CAST(0x0000AC050012C82F AS DateTime))
INSERT [dbo].[XX_RolePermission] ([id], [roleId], [permissionId], [createTime]) VALUES (336, 1, 400101, CAST(0x0000AC050012C82F AS DateTime))
SET IDENTITY_INSERT [dbo].[XX_RolePermission] OFF
ALTER TABLE [dbo].[XX_RolePermission] ADD  CONSTRAINT [DF_XX_RolePermission_createTime]  DEFAULT (getdate()) FOR [createTime]
GO

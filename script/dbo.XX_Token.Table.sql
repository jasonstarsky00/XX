USE [XX]
GO
/****** Object:  Table [dbo].[XX_Token]    Script Date: 2020/9/18 19:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XX_Token](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[token] [nvarchar](50) NOT NULL,
	[expiredTime] [nvarchar](50) NOT NULL,
	[createTime] [datetime] NULL,
 CONSTRAINT [PK_XX_Token] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[XX_Token] ON 

INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (1, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007131544344701', CAST(0x0000ABF601036F65 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (2, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007131545076340', CAST(0x0000ABF601039642 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (3, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007131545290072', CAST(0x0000ABF60103AF4E AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (4, 8, N'FE2357CD6AF8A50E8D0D6FCD244A6A05', N'202007131608088720', CAST(0x0000ABF60109E9D6 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (5, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007141812437292', CAST(0x0000ABF7012C20A1 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (6, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007152206255500', CAST(0x0000ABF8016C507E AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (7, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007172308502229', CAST(0x0000ABFA017D749C AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (8, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007192249019806', CAST(0x0000ABFC0178043D AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (9, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007202257486548', CAST(0x0000ABFD017A6D65 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (10, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007221442172619', CAST(0x0000ABFF00F253E9 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (11, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007260209484407', CAST(0x0000AC030023A715 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (12, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202007280028347249', CAST(0x0000AC050007D977 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (13, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202008252158312930', CAST(0x0000AC21016A24A7 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (14, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202009131629286571', CAST(0x0000AC34010FC4A5 AS DateTime))
INSERT [dbo].[XX_Token] ([id], [uid], [token], [expiredTime], [createTime]) VALUES (15, 7, N'55A8C7CC4B0167171F10AA98984D2AEC', N'202009191504326955', CAST(0x0000AC3A00F870E2 AS DateTime))
SET IDENTITY_INSERT [dbo].[XX_Token] OFF
ALTER TABLE [dbo].[XX_Token] ADD  CONSTRAINT [DF_XX_Token_createTime]  DEFAULT (getdate()) FOR [createTime]
GO

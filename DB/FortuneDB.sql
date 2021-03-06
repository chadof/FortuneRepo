USE [FortuneDB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronomyc] [nvarchar](50) NULL,
	[NumberOfTheCar] [nchar](6) NOT NULL,
	[Phone] [nchar](11) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[GenderCode] [nchar](1) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [nchar](1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Successful] [bit] NOT NULL,
 CONSTRAINT [PK_loginHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[DateOfCreation] [date] NOT NULL,
	[DateOfRealize] [date] NOT NULL,
	[Status] [bit] NOT NULL,
	[Details] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.06.2021 22:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Login] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [Patronomyc], [NumberOfTheCar], [Phone], [Birthday], [Email], [GenderCode]) VALUES (2, N'Иван', N'Меренков', N'Владимирович', N'о007оо', N'79061879581', CAST(N'2002-12-03' AS Date), N'fmerenkov02@mail.ru', N'м')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [Patronomyc], [NumberOfTheCar], [Phone], [Birthday], [Email], [GenderCode]) VALUES (1006, N'Иван', N'Меренков', N'Владимирович', N'о007оо', N'79061879581', CAST(N'2002-12-03' AS Date), N'fmerenkov02@mail.ru', N'м')
INSERT [dbo].[Client] ([Id], [FirstName], [LastName], [Patronomyc], [NumberOfTheCar], [Phone], [Birthday], [Email], [GenderCode]) VALUES (1007, N'Иван', N'Меренковdfg', N'Владимирович', N'о007оо', N'79061879581', CAST(N'2002-12-03' AS Date), N'fmerenkov02@mail.ru', N'м')
SET IDENTITY_INSERT [dbo].[Client] OFF
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'ж', N'Женский   ')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'м', N'Мужской   ')
SET IDENTITY_INSERT [dbo].[LoginHistory] ON 

INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1115, N'a', CAST(N'2021-06-05 00:05:15.937' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1116, N'm', CAST(N'2021-06-05 00:05:30.843' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1117, N'm', CAST(N'2021-06-05 02:01:24.910' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1118, N'm', CAST(N'2021-06-05 02:02:31.547' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1119, N'm', CAST(N'2021-06-05 02:04:13.843' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1120, N'm', CAST(N'2021-06-05 02:05:32.453' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1121, N'm', CAST(N'2021-06-05 02:07:12.833' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1122, N'm', CAST(N'2021-06-05 11:41:47.380' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1123, N'm', CAST(N'2021-06-05 11:55:35.150' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1124, N'm', CAST(N'2021-06-05 11:58:07.950' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1125, N'm', CAST(N'2021-06-05 12:52:35.933' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1126, N'm', CAST(N'2021-06-05 12:53:53.210' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1127, N'm', CAST(N'2021-06-05 12:56:53.437' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1128, N'm', CAST(N'2021-06-05 12:59:19.473' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1129, N'm', CAST(N'2021-06-05 13:01:09.520' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1130, N'm', CAST(N'2021-06-05 13:02:37.503' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (1131, N'm', CAST(N'2021-06-05 13:04:44.480' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2130, N'm', CAST(N'2021-06-06 16:13:44.320' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2131, N'm', CAST(N'2021-06-06 16:15:42.827' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2132, N'm', CAST(N'2021-06-06 16:16:39.507' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2133, N'm', CAST(N'2021-06-06 16:17:45.797' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2134, N'm', CAST(N'2021-06-06 16:22:00.530' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2135, N'm', CAST(N'2021-06-06 21:08:47.263' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2136, N'm', CAST(N'2021-06-06 21:08:57.790' AS DateTime), 1)
INSERT [dbo].[LoginHistory] ([Id], [Login], [Date], [Successful]) VALUES (2137, N'm', CAST(N'2021-06-06 21:13:56.497' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[LoginHistory] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (25, 2, 19, CAST(N'2021-06-04' AS Date), CAST(N'2002-12-03' AS Date), 0, NULL)
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (26, 2, 27, CAST(N'2021-06-04' AS Date), CAST(N'2002-12-03' AS Date), 1, NULL)
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (29, 1006, 18, CAST(N'2021-06-05' AS Date), CAST(N'2002-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (30, 1006, 19, CAST(N'2021-06-05' AS Date), CAST(N'2002-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (31, 1006, 1, CAST(N'2021-06-05' AS Date), CAST(N'2002-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (32, 1006, 31, CAST(N'2021-06-05' AS Date), CAST(N'2003-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (33, 1007, 19, CAST(N'2021-06-06' AS Date), CAST(N'2021-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (34, 1007, 18, CAST(N'2021-06-06' AS Date), CAST(N'2021-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (35, 1007, 1, CAST(N'2021-06-06' AS Date), CAST(N'2021-01-01' AS Date), 1, N'asd')
INSERT [dbo].[Order] ([Id], [ClientId], [ServiceId], [DateOfCreation], [DateOfRealize], [Status], [Details]) VALUES (36, 1007, 25, CAST(N'2021-06-06' AS Date), CAST(N'2021-01-01' AS Date), 0, N'asd')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Менеджер')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Администратор')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (1, N'Диагностика автомобиля', 600.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (18, N'Замена масла в ДВС', 220.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (19, N'Замена масляного фильтра', 500.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (20, N'Замена воздушного фильтра', 550.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (21, N'Замена топливного фильтра', 600.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (22, N'Сброс межсервисных интервалов', 550.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (23, N'Замена тормозной жидкости', 300.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (24, N'Замена охлаждающей жидкости', 400.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (25, N'Замена патрубков системы охлаждения', 350.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (26, N'Замена жидкости ГУР', 500.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (27, N'Диагностика форсунок (диагностика инжектора)', 400.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (28, N'Промывка инжектора', 300.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (29, N'Промывка форсунок', 202.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (30, N'Диагностика свечей зажигания', 500.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (31, N'Замена свечей зажигания', 800.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (32, N'Замена масла', 200.0000)
INSERT [dbo].[Service] ([Id], [Name], [Cost]) VALUES (33, N'Чистка инжектора', 300.0000)
SET IDENTITY_INSERT [dbo].[Service] OFF
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'a', N'a', N'a', N'a', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'EfsNg', N'Новикова', N'Мария', N'IimucWSG', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'gQOBf', N'Дроздов', N'Фёдор', N'YpYieoDG', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'IeuFk', N'Черкасова', N'Анастасия', N'zEMZurBh', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'isVtM', N'Никонов', N'Артём', N'MxMsdOgh', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'IXGdS', N'Волков', N'Игорь', N'UNNmvGSB', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'jAJPH', N'Маслова', N'Юлия', N'PfWgmxnx', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'LnuTC', N'Федоров', N'Максим', N'ZcAOqVrm', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'LWDwi', N'Петухова', N'Кира', N'ZYGBdneN', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'm', N'm', N'm', N'm', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'OAYWy', N'Юдина', N'Мирослава', N'QtAGRsOj', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'PFfeS', N'Рябов', N'Матвей', N'ZuQPEGDN', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'pfMvi', N'Щербакова', N'Милана', N'HnSMZozg', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'qyuRm', N'Соколова', N'Варвара', N'dtqMMvyV', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'SNVwe', N'Климов', N'Владислав', N'addVKvMP', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'SRLNo', N'Макаров', N'Алексей', N'LfxkYCRy', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'SuDEO', N'Герасимов', N'Лев', N'wQkInkmE', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'uMskQ', N'Панов', N'Роман', N'BTyZeuux', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'uZEOH', N'Григорьев', N'Игорь', N'CDKCuycE', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'ZbLqR', N'Алехина', N'Анфиса', N'ADQPMnVp', 1)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'zUhrp', N'Трифонова', N'Дарья', N'qLfphrBK', 2)
INSERT [dbo].[Users] ([Login], [FirstName], [LastName], [Password], [RoleId]) VALUES (N'ZVmGI', N'Лебедев', N'Егор', N'ABiqyekw', 2)
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Gender] FOREIGN KEY([GenderCode])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Gender]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_Users] FOREIGN KEY([Login])
REFERENCES [dbo].[Users] ([Login])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_Users]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Service]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_TypeOfUsers] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_TypeOfUsers]
GO

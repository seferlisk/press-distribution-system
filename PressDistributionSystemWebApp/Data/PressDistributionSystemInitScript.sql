
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distributors]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KioskPublications]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KioskPublications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[KioskId] [int] NULL,
	[PublicationDistributorId] [int] NULL,
	[ReturnedQuantity] [int] NULL,
 CONSTRAINT [PK_KioskPublications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kiosks]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kiosks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DistributorId] [int] NULL,
 CONSTRAINT [PK_Kiosks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublicationDistributors]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublicationDistributors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DistributorId] [int] NULL,
	[PublicationId] [int] NULL,
 CONSTRAINT [PK_PublicationDistributors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publications]    Script Date: 18/6/2024 11:56:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ShipmentDate] [date] NOT NULL,
	[ReturnDate] [date] NOT NULL,
	[Issue] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Publications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616080812_PressSystemInit', N'8.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616083701_ExtraNavigationProperties', N'8.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616193259_ReturnedQuantity', N'8.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618200737_OnlyOneUserPerDistributor', N'8.0.6')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4B2341FA-1D98-47D8-A8E6-CB6B22AE92F6', N'Distributor', N'DISTRIBUTOR', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'F797D4D9-C50D-4C0C-A63B-920E77260DCF', N'Agency', N'AGENCY', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2f883aa2-782e-4798-a56a-2dc740de9c1f', N'4B2341FA-1D98-47D8-A8E6-CB6B22AE92F6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d885e56-b8bf-410b-9c63-1b9905700069', N'4B2341FA-1D98-47D8-A8E6-CB6B22AE92F6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'645723d7-e4b2-4e2b-a5de-927e76c1a778', N'F797D4D9-C50D-4C0C-A63B-920E77260DCF')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'961d442d-2f96-4ef4-823a-568b320821f6', N'F797D4D9-C50D-4C0C-A63B-920E77260DCF')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2f883aa2-782e-4798-a56a-2dc740de9c1f', N'distributor2@email.com', N'DISTRIBUTOR2@EMAIL.COM', N'distributor2@email.com', N'DISTRIBUTOR2@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEBGH/4JgHS/fxjEi+alBCx/YYLV1bf/wWhHdF6fu1dtrf2l1EVo6E+kTAP3f5kdNeA==', N'2VH74WN3CUCDSFTJC23N6Y55BMEMCKHS', N'621b129d-44c7-4d25-a4da-fdbf66a3897f', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5d885e56-b8bf-410b-9c63-1b9905700019', N'distributor3@email.com', N'DISTRIBUTOR3@EMAIL.COM', N'distributor3@email.com', N'DISTRIBUTOR3@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPCTow+rVIa6gNsbAHbqkoEjBwEo4cffdUCmbgE8ChVyb7XgnF/EKs0MBh0kSOragQ==', N'3LBHPROMQDEQ3ETXIDASDWQBNI3MXS6T', N'7b7135a0-4f5c-4255-bda7-2067757b488f', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'645723d7-e4b2-4e2b-a5de-927e76c1a778', N'AgencyUser2@email.com', N'AGENCYUSER2@EMAIL.COM', N'AgencyUser2@email.com', N'AGENCYUSER2@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPnrJTM2p1qfCngxekJ0rrjGPxcSfJ4iPFWZJvj9pfMR815Yi3BZxBAw1cN1sg6yMg==', N'J2HDFV2CAVMH42P3YFI2AA5IBEPVOLJQ', N'db99c8f1-ee31-4cd2-9fe5-897da01cee72', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6d885e56-b8bf-410b-9c63-1b9905700069', N'distributor1@email.com', N'DISTRIBUTOR1@EMAIL.COM', N'distributor1@email.com', N'DISTRIBUTOR1@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPCTow+rVIa6gNsbAHbqkoEjBwEo4cffdUCmbgE8ChVyb7XgnF/EKs0MBh0kSOragQ==', N'3LBHPROMQDEQ3ETXIDASDWQBNI3MXS6T', N'7b7135a0-4f5c-4255-bda7-2067757b488f', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'961d442d-2f96-4ef4-823a-568b320821f6', N'AgencyUser1@email.com', N'AGENCYUSER1@EMAIL.COM', N'AgencyUser1@email.com', N'AGENCYUSER1@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEFta5I3D6bM6cDH5ml/D9coh9m8JPafyg6JSGOBND9rRaJPZzVTyg2Uu869RRu4sIQ==', N'SIPLR5GAPLFDDBCYBVKCPGKDRRRSL5NN', N'6f42f5e0-4ed8-43c8-8874-d97f6138b986', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Distributors] ON 
GO
INSERT [dbo].[Distributors] ([Id], [Name], [UserId]) VALUES (1, N'Διανομέας 1', N'6d885e56-b8bf-410b-9c63-1b9905700069')
GO
INSERT [dbo].[Distributors] ([Id], [Name], [UserId]) VALUES (2, N'Διανομέας 2', N'2f883aa2-782e-4798-a56a-2dc740de9c1f')
GO
INSERT [dbo].[Distributors] ([Id], [Name], [UserId]) VALUES (3, N'Διανομέας 3', N'5d885e56-b8bf-410b-9c63-1b9905700019')
GO
SET IDENTITY_INSERT [dbo].[Distributors] OFF
GO
SET IDENTITY_INSERT [dbo].[KioskPublications] ON 
GO
INSERT [dbo].[KioskPublications] ([Id], [Quantity], [KioskId], [PublicationDistributorId], [ReturnedQuantity]) VALUES (1002, 2, 2, 2, 3)
GO
INSERT [dbo].[KioskPublications] ([Id], [Quantity], [KioskId], [PublicationDistributorId], [ReturnedQuantity]) VALUES (1003, 2, 2, 5, 4)
GO
INSERT [dbo].[KioskPublications] ([Id], [Quantity], [KioskId], [PublicationDistributorId], [ReturnedQuantity]) VALUES (1004, 1, 1, 1, 3)
GO
INSERT [dbo].[KioskPublications] ([Id], [Quantity], [KioskId], [PublicationDistributorId], [ReturnedQuantity]) VALUES (1005, 2, 1, 4, 3)
GO
SET IDENTITY_INSERT [dbo].[KioskPublications] OFF
GO
SET IDENTITY_INSERT [dbo].[Kiosks] ON 
GO
INSERT [dbo].[Kiosks] ([Id], [Name], [DistributorId]) VALUES (1, N'Περίπτερο 1', 1)
GO
INSERT [dbo].[Kiosks] ([Id], [Name], [DistributorId]) VALUES (2, N'Περιπτερο 2', 2)
GO
SET IDENTITY_INSERT [dbo].[Kiosks] OFF
GO
SET IDENTITY_INSERT [dbo].[PublicationDistributors] ON 
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (1, 5, 1, 1)
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (2, 3, 2, 1)
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (3, 4, 3, 1)
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (4, 2, 1, 2)
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (5, 3, 2, 2)
GO
INSERT [dbo].[PublicationDistributors] ([Id], [Quantity], [DistributorId], [PublicationId]) VALUES (6, 4, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[PublicationDistributors] OFF
GO
SET IDENTITY_INSERT [dbo].[Publications] ON 
GO
INSERT [dbo].[Publications] ([Id], [Name], [ShipmentDate], [ReturnDate], [Issue], [Quantity]) VALUES (1, N'Καθημερινή', CAST(N'2024-06-16' AS Date), CAST(N'2024-06-17' AS Date), N'Τευχος 50', 40)
GO
INSERT [dbo].[Publications] ([Id], [Name], [ShipmentDate], [ReturnDate], [Issue], [Quantity]) VALUES (2, N'Τα Νέα', CAST(N'2024-06-16' AS Date), CAST(N'2024-06-17' AS Date), N'Τευχος 44', 60)
GO
SET IDENTITY_INSERT [dbo].[Publications] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Distributors]  WITH CHECK ADD  CONSTRAINT [FK_Distributors_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Distributors] CHECK CONSTRAINT [FK_Distributors_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[KioskPublications]  WITH CHECK ADD  CONSTRAINT [FK_KioskPublications_Kiosks_KioskId] FOREIGN KEY([KioskId])
REFERENCES [dbo].[Kiosks] ([Id])
GO
ALTER TABLE [dbo].[KioskPublications] CHECK CONSTRAINT [FK_KioskPublications_Kiosks_KioskId]
GO
ALTER TABLE [dbo].[KioskPublications]  WITH CHECK ADD  CONSTRAINT [FK_KioskPublications_PublicationDistributors_PublicationDistributorId] FOREIGN KEY([PublicationDistributorId])
REFERENCES [dbo].[PublicationDistributors] ([Id])
GO
ALTER TABLE [dbo].[KioskPublications] CHECK CONSTRAINT [FK_KioskPublications_PublicationDistributors_PublicationDistributorId]
GO
ALTER TABLE [dbo].[Kiosks]  WITH CHECK ADD  CONSTRAINT [FK_Kiosks_Distributors_DistributorId] FOREIGN KEY([DistributorId])
REFERENCES [dbo].[Distributors] ([Id])
GO
ALTER TABLE [dbo].[Kiosks] CHECK CONSTRAINT [FK_Kiosks_Distributors_DistributorId]
GO
ALTER TABLE [dbo].[PublicationDistributors]  WITH CHECK ADD  CONSTRAINT [FK_PublicationDistributors_Distributors_DistributorId] FOREIGN KEY([DistributorId])
REFERENCES [dbo].[Distributors] ([Id])
GO
ALTER TABLE [dbo].[PublicationDistributors] CHECK CONSTRAINT [FK_PublicationDistributors_Distributors_DistributorId]
GO
ALTER TABLE [dbo].[PublicationDistributors]  WITH CHECK ADD  CONSTRAINT [FK_PublicationDistributors_Publications_PublicationId] FOREIGN KEY([PublicationId])
REFERENCES [dbo].[Publications] ([Id])
GO
ALTER TABLE [dbo].[PublicationDistributors] CHECK CONSTRAINT [FK_PublicationDistributors_Publications_PublicationId]
GO

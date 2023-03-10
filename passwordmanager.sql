USE [master]
GO
/****** Object:  Database [passwordManager]    Script Date: 23.12.2022 01:27:21 ******/
CREATE DATABASE [passwordManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'passwordManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\passwordManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'passwordManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\passwordManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [passwordManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [passwordManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [passwordManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [passwordManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [passwordManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [passwordManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [passwordManager] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [passwordManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [passwordManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [passwordManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [passwordManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [passwordManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [passwordManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [passwordManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [passwordManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [passwordManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [passwordManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [passwordManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [passwordManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [passwordManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [passwordManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [passwordManager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [passwordManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [passwordManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [passwordManager] SET  MULTI_USER 
GO
ALTER DATABASE [passwordManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [passwordManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [passwordManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [passwordManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [passwordManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [passwordManager] SET QUERY_STORE = OFF
GO
USE [passwordManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountProperties]    Script Date: 23.12.2022 01:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemTypeId] [int] NOT NULL,
	[PlatformId] [int] NOT NULL,
	[SafeId] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[AccountName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[isFavorite] [bit] NOT NULL,
 CONSTRAINT [PK_AccountProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 23.12.2022 01:27:21 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 23.12.2022 01:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountPropertyId] [int] NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 23.12.2022 01:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemTypeId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Safes]    Script Date: 23.12.2022 01:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Safes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Safes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemTypes]    Script Date: 23.12.2022 01:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SystemTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221220203357_CreateTable', N'6.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221222214117_addAccountPropertyisFavoriteColumn', N'6.0.12')
GO
SET IDENTITY_INSERT [dbo].[AccountProperties] ON 

INSERT [dbo].[AccountProperties] ([Id], [SystemTypeId], [PlatformId], [SafeId], [Comment], [AccountName], [Address], [UserName], [Password], [CreateDate], [UpdateDate], [Status], [CreateBy], [ModifyBy], [isFavorite]) VALUES (1, 4, 8, 1, N'Venafi superadmin şifresi', N'Website - Venafi Web App - PasswordManager', N'https://www.google.com.tr', N'superadmin', N'zk1yyFokvj20OFHR4qEfew==', CAST(N'2022-12-22T22:36:05.5080458' AS DateTime2), CAST(N'2022-12-22T22:36:06.2717108' AS DateTime2), 1, N'2dc8bfa7-6301-4fa3-83e2-5d37fd2b0674', N'2dc8bfa7-6301-4fa3-83e2-5d37fd2b0674', 0)
SET IDENTITY_INSERT [dbo].[AccountProperties] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2dc8bfa7-6301-4fa3-83e2-5d37fd2b0674', N'emrahsemiz@hotmail.com', N'EMRAHSEMIZ@HOTMAIL.COM', N'emrahsemiz@hotmail.com', N'EMRAHSEMIZ@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAEO+4kCeamt3EQsASaFxkqHxHGdAtOXapOdrMdjT7ucGQiybAKSqbGKCU80FhWUxFpQ==', N'LF6S5WGW2QG7ITM5C635S7IQJS5NDTPX', N'67b1b709-b113-4049-8d07-1c4d6fed4de2', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Platforms] ON 

INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (1, 1, N'Windows Desktop Local Accounts', CAST(N'2022-12-22T09:26:56.2357128' AS DateTime2), CAST(N'2022-12-22T09:26:56.2366929' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (2, 1, N'Windows Desktop Domain Accounts', CAST(N'2022-12-22T09:27:15.5542259' AS DateTime2), CAST(N'2022-12-22T09:27:15.5542281' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (3, 2, N'Microsoft SQL Server', CAST(N'2022-12-22T09:27:37.2749946' AS DateTime2), CAST(N'2022-12-22T09:27:37.2749971' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (4, 2, N'Oracle Database', CAST(N'2022-12-22T09:27:51.6378016' AS DateTime2), CAST(N'2022-12-22T09:27:51.6378039' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (5, 5, N'ILO via SSH', CAST(N'2022-12-22T09:28:21.7284012' AS DateTime2), CAST(N'2022-12-22T09:28:21.7284033' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (6, 4, N'IBM QRadar Web APP', CAST(N'2022-12-22T09:29:05.4432330' AS DateTime2), CAST(N'2022-12-22T09:29:05.4432351' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (7, 4, N'McAfee SIEM Web APP', CAST(N'2022-12-22T09:29:26.4694328' AS DateTime2), CAST(N'2022-12-22T09:29:26.4694354' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (8, 4, N'Venafi Web App', CAST(N'2022-12-22T09:29:46.8526347' AS DateTime2), CAST(N'2022-12-22T09:29:46.8526368' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (9, 3, N'CyberArk Vault', CAST(N'2022-12-22T09:30:20.4043667' AS DateTime2), CAST(N'2022-12-22T09:30:20.4043695' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (10, 1, N'Server Local Accounts', CAST(N'2022-12-22T09:30:51.4235203' AS DateTime2), CAST(N'2022-12-22T09:30:51.4235240' AS DateTime2), 1)
INSERT [dbo].[Platforms] ([Id], [SystemTypeId], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (11, 2, N'Mysql Database', CAST(N'2022-12-22T09:32:31.5178001' AS DateTime2), CAST(N'2022-12-22T09:32:31.5178021' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Platforms] OFF
GO
SET IDENTITY_INSERT [dbo].[Safes] ON 

INSERT [dbo].[Safes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'PasswordManager', CAST(N'2022-12-22T09:43:27.3967309' AS DateTime2), CAST(N'2022-12-22T09:43:27.3970102' AS DateTime2), 1)
INSERT [dbo].[Safes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (2, N'PasswordManagerShared', CAST(N'2022-12-22T09:43:41.2561820' AS DateTime2), CAST(N'2022-12-22T09:43:41.2561837' AS DateTime2), 1)
INSERT [dbo].[Safes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (3, N'NotificationEngine', CAST(N'2022-12-22T09:43:56.7377437' AS DateTime2), CAST(N'2022-12-22T09:43:56.7377456' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Safes] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemTypes] ON 

INSERT [dbo].[SystemTypes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (1, N'Windows', CAST(N'2022-12-21T11:37:39.1524232' AS DateTime2), CAST(N'2022-12-21T11:37:39.1526768' AS DateTime2), 1)
INSERT [dbo].[SystemTypes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (2, N'Database', CAST(N'2022-12-21T11:37:56.6398174' AS DateTime2), CAST(N'2022-12-21T11:37:56.6398192' AS DateTime2), 1)
INSERT [dbo].[SystemTypes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (3, N'Application', CAST(N'2022-12-21T11:38:05.0972241' AS DateTime2), CAST(N'2022-12-21T11:38:05.0972253' AS DateTime2), 1)
INSERT [dbo].[SystemTypes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (4, N'Website', CAST(N'2022-12-21T11:38:13.1113779' AS DateTime2), CAST(N'2022-12-21T11:38:13.1113792' AS DateTime2), 1)
INSERT [dbo].[SystemTypes] ([Id], [Name], [CreateDate], [UpdateDate], [Status]) VALUES (5, N'Remote Access', CAST(N'2022-12-21T11:38:20.9723126' AS DateTime2), CAST(N'2022-12-21T11:38:20.9723139' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[SystemTypes] OFF
GO
/****** Object:  Index [IX_AccountProperties_PlatformId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AccountProperties_PlatformId] ON [dbo].[AccountProperties]
(
	[PlatformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountProperties_SafeId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AccountProperties_SafeId] ON [dbo].[AccountProperties]
(
	[SafeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountProperties_SystemTypeId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AccountProperties_SystemTypeId] ON [dbo].[AccountProperties]
(
	[SystemTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 23.12.2022 01:27:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 23.12.2022 01:27:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Favorites_AccountPropertyId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_Favorites_AccountPropertyId] ON [dbo].[Favorites]
(
	[AccountPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Platforms_SystemTypeId]    Script Date: 23.12.2022 01:27:21 ******/
CREATE NONCLUSTERED INDEX [IX_Platforms_SystemTypeId] ON [dbo].[Platforms]
(
	[SystemTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountProperties] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isFavorite]
GO
ALTER TABLE [dbo].[AccountProperties]  WITH CHECK ADD  CONSTRAINT [FK_AccountProperties_Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
GO
ALTER TABLE [dbo].[AccountProperties] CHECK CONSTRAINT [FK_AccountProperties_Platforms_PlatformId]
GO
ALTER TABLE [dbo].[AccountProperties]  WITH CHECK ADD  CONSTRAINT [FK_AccountProperties_Safes_SafeId] FOREIGN KEY([SafeId])
REFERENCES [dbo].[Safes] ([Id])
GO
ALTER TABLE [dbo].[AccountProperties] CHECK CONSTRAINT [FK_AccountProperties_Safes_SafeId]
GO
ALTER TABLE [dbo].[AccountProperties]  WITH CHECK ADD  CONSTRAINT [FK_AccountProperties_SystemTypes_SystemTypeId] FOREIGN KEY([SystemTypeId])
REFERENCES [dbo].[SystemTypes] ([Id])
GO
ALTER TABLE [dbo].[AccountProperties] CHECK CONSTRAINT [FK_AccountProperties_SystemTypes_SystemTypeId]
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
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_AccountProperties_AccountPropertyId] FOREIGN KEY([AccountPropertyId])
REFERENCES [dbo].[AccountProperties] ([Id])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_AccountProperties_AccountPropertyId]
GO
ALTER TABLE [dbo].[Platforms]  WITH CHECK ADD  CONSTRAINT [FK_Platforms_SystemTypes_SystemTypeId] FOREIGN KEY([SystemTypeId])
REFERENCES [dbo].[SystemTypes] ([Id])
GO
ALTER TABLE [dbo].[Platforms] CHECK CONSTRAINT [FK_Platforms_SystemTypes_SystemTypeId]
GO
USE [master]
GO
ALTER DATABASE [passwordManager] SET  READ_WRITE 
GO

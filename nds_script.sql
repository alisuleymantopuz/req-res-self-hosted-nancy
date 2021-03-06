USE [master]
GO
/****** Object:  Database [NorthwindDataServer]    Script Date: 6.11.2015 16:17:57 ******/
CREATE DATABASE [NorthwindDataServer] ON  PRIMARY 
( NAME = N'NorthwindDataServer', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthwindDataServer.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NorthwindDataServer_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NorthwindDataServer_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Turkish_CI_AS
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NorthwindDataServer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NorthwindDataServer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET ARITHABORT OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NorthwindDataServer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NorthwindDataServer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NorthwindDataServer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NorthwindDataServer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NorthwindDataServer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NorthwindDataServer] SET  MULTI_USER 
GO
ALTER DATABASE [NorthwindDataServer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NorthwindDataServer] SET DB_CHAINING OFF 
GO
USE [NorthwindDataServer]
GO
/****** Object:  Schema [Authentication]    Script Date: 6.11.2015 16:17:58 ******/
CREATE SCHEMA [Authentication]
GO
/****** Object:  Schema [Common]    Script Date: 6.11.2015 16:17:58 ******/
CREATE SCHEMA [Common]
GO
/****** Object:  Schema [Store]    Script Date: 6.11.2015 16:17:58 ******/
CREATE SCHEMA [Store]
GO
/****** Object:  Table [Authentication].[User]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Authentication].[User](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_User_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[Surname] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[UserName] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Authentication].[UserClaims]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Authentication].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[Language]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Language](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Language_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[Code] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[ResponseCode]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Common].[ResponseCode](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ResponseCode_Id]  DEFAULT (newid()),
	[Code] [varchar](4) COLLATE Turkish_CI_AS NOT NULL,
 CONSTRAINT [PK_ResponseCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Common].[ResponseCodeDescription]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[ResponseCodeDescription](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ResponseCodeDescription_Id]  DEFAULT (newid()),
	[Description] [nvarchar](500) COLLATE Turkish_CI_AS NOT NULL,
	[Message] [nvarchar](150) COLLATE Turkish_CI_AS NOT NULL,
	[LanguageId] [uniqueidentifier] NOT NULL,
	[ResponseCodeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ResponseCodeDescription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Store].[Products]    Script Date: 6.11.2015 16:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Store].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) COLLATE Turkish_CI_AS NOT NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) COLLATE Turkish_CI_AS NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
	[Discontinued] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [Authentication].[User] ([Id], [Name], [Surname], [UserName], [Password]) VALUES (N'dca5cd47-85d4-4621-aec1-6cbe465ce8d2', N'Ali Suleyman', N'Topuz', N'atopuz', N'1234567')
SET IDENTITY_INSERT [Authentication].[UserClaims] ON 

INSERT [Authentication].[UserClaims] ([Id], [Name], [UserId]) VALUES (1, N'Admin', N'dca5cd47-85d4-4621-aec1-6cbe465ce8d2')
SET IDENTITY_INSERT [Authentication].[UserClaims] OFF
INSERT [Common].[Language] ([Id], [Name], [Code]) VALUES (N'0fe55190-b681-4060-92be-02fb56380435', N'Türkçe', N'tr-TR')
INSERT [Common].[Language] ([Id], [Name], [Code]) VALUES (N'7e472809-e343-4f0c-b991-bf6f3abbe9a5', N'English', N'en-EN')
INSERT [Common].[ResponseCode] ([Id], [Code]) VALUES (N'86082562-8673-4645-b6d4-4be2179e260c', N'1002')
INSERT [Common].[ResponseCode] ([Id], [Code]) VALUES (N'0b534a9d-8c9f-4ab7-974b-53adae3f7d91', N'0000')
INSERT [Common].[ResponseCode] ([Id], [Code]) VALUES (N'08de223e-eb0b-4bcc-8e21-80802665d556', N'1001')
INSERT [Common].[ResponseCode] ([Id], [Code]) VALUES (N'8fdadcdd-99b4-478c-817e-fa105741a1e3', N'1003')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'665cc4c7-5c3e-43d8-850b-0735b903baff', N'Invalid request.', N'Invalid request.', N'7e472809-e343-4f0c-b991-bf6f3abbe9a5', N'86082562-8673-4645-b6d4-4be2179e260c')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'dd30241e-4cb9-42cb-a6e4-21fb08ff8b5e', N'Tanımsız parametre.', N'Tanımsız parametre.', N'0fe55190-b681-4060-92be-02fb56380435', N'8fdadcdd-99b4-478c-817e-fa105741a1e3')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'be8677d4-9c5b-44e2-b0eb-23acfe93d81a', N'Yetki hatası.', N'Yetki hatası.', N'0fe55190-b681-4060-92be-02fb56380435', N'08de223e-eb0b-4bcc-8e21-80802665d556')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'06833128-b96e-4185-9ee8-35e5e530e2e8', N'Undefined parameter.', N'Undefined parameter.', N'7e472809-e343-4f0c-b991-bf6f3abbe9a5', N'8fdadcdd-99b4-478c-817e-fa105741a1e3')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'deff21db-f4f0-4ae1-a358-8ad9e27c1a3d', N'Authentication problem.', N'Authentication problem.', N'7e472809-e343-4f0c-b991-bf6f3abbe9a5', N'08de223e-eb0b-4bcc-8e21-80802665d556')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'773f3f2c-b658-4b11-baf3-bf626d525403', N'İşleminiz başarılı.', N'Başarılı.', N'0fe55190-b681-4060-92be-02fb56380435', N'0b534a9d-8c9f-4ab7-974b-53adae3f7d91')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'a51187d5-7dcc-4ff7-932a-d0640e3931f3', N'Hatalı istek.', N'Hatalı istek.', N'0fe55190-b681-4060-92be-02fb56380435', N'86082562-8673-4645-b6d4-4be2179e260c')
INSERT [Common].[ResponseCodeDescription] ([Id], [Description], [Message], [LanguageId], [ResponseCodeId]) VALUES (N'3bf19da1-c2fc-4685-8d67-f3ba00958412', N'Your operation is success.', N'Success.', N'7e472809-e343-4f0c-b991-bf6f3abbe9a5', N'0b534a9d-8c9f-4ab7-974b-53adae3f7d91')
SET IDENTITY_INSERT [Store].[Products] ON 

INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (1, N'Chai', 1, 1, N'10 boxes x 20 bags', 18.0000, 39, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (2, N'Chang', 1, 1, N'24 - 12 oz bottles', 19.0000, 17, 40, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (3, N'Aniseed Syrup', 1, 2, N'12 - 550 ml bottles', 10.0000, 13, 70, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (4, N'Chef Anton''s Cajun Seasoning', 2, 2, N'48 - 6 oz jars', 22.0000, 53, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (5, N'Chef Anton''s Gumbo Mix', 2, 2, N'36 boxes', 21.3500, 5, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (6, N'Grandma''s Boysenberry Spread', 3, 2, N'12 - 8 oz jars', 25.0000, 120, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (7, N'Uncle Bob''s Organic Dried Pears', 3, 7, N'12 - 1 lb pkgs.', 30.0000, 15, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (8, N'Northwoods Cranberry Sauce', 3, 2, N'12 - 12 oz jars', 40.0000, 6, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (9, N'Mishi Kobe Niku', 4, 6, N'18 - 500 g pkgs.', 97.0000, 29, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (10, N'Ikura', 4, 8, N'12 - 200 ml jars', 31.0000, 31, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (11, N'Queso Cabrales', 5, 4, N'1 kg pkg.', 21.0000, 22, 30, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (12, N'Queso Manchego La Pastora', 5, 4, N'10 - 500 g pkgs.', 38.0000, 86, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (13, N'Konbu', 6, 8, N'2 kg box', 6.0000, 24, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (14, N'Tofu', 6, 7, N'40 - 100 g pkgs.', 23.2500, 35, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (15, N'Genen Shouyu', 6, 2, N'24 - 250 ml bottles', 15.5000, 39, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (16, N'Pavlova', 7, 3, N'32 - 500 g boxes', 17.4500, 29, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (17, N'Alice Mutton', 7, 6, N'20 - 1 kg tins', 39.0000, 0, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (18, N'Carnarvon Tigers', 7, 8, N'16 kg pkg.', 62.5000, 42, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (19, N'Teatime Chocolate Biscuits', 8, 3, N'10 boxes x 12 pieces', 9.2000, 25, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (20, N'Sir Rodney''s Marmalade', 8, 3, N'30 gift boxes', 81.0000, 40, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (21, N'Sir Rodney''s Scones', 8, 3, N'24 pkgs. x 4 pieces', 10.0000, 3, 40, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (22, N'Gustaf''s Knäckebröd', 9, 5, N'24 - 500 g pkgs.', 21.0000, 104, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (23, N'Tunnbröd', 9, 5, N'12 - 250 g pkgs.', 9.0000, 61, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (24, N'Guaraná Fantástica', 10, 1, N'12 - 355 ml cans', 4.5000, 20, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (25, N'NuNuCa Nuß-Nougat-Creme', 11, 3, N'20 - 450 g glasses', 14.0000, 76, 0, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (26, N'Gumbär Gummibärchen', 11, 3, N'100 - 250 g bags', 31.2300, 15, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (27, N'Schoggi Schokolade', 11, 3, N'100 - 100 g pieces', 43.9000, 49, 0, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (28, N'Rössle Sauerkraut', 12, 7, N'25 - 825 g cans', 45.6000, 26, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (29, N'Thüringer Rostbratwurst', 12, 6, N'50 bags x 30 sausgs.', 123.7900, 0, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (30, N'Nord-Ost Matjeshering', 13, 8, N'10 - 200 g glasses', 25.8900, 10, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (31, N'Gorgonzola Telino', 14, 4, N'12 - 100 g pkgs', 12.5000, 0, 70, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (32, N'Mascarpone Fabioli', 14, 4, N'24 - 200 g pkgs.', 32.0000, 9, 40, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (33, N'Geitost', 15, 4, N'500 g', 2.5000, 112, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (34, N'Sasquatch Ale', 16, 1, N'24 - 12 oz bottles', 14.0000, 111, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (35, N'Steeleye Stout', 16, 1, N'24 - 12 oz bottles', 18.0000, 20, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (36, N'Inlagd Sill', 17, 8, N'24 - 250 g  jars', 19.0000, 112, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (37, N'Gravad lax', 17, 8, N'12 - 500 g pkgs.', 26.0000, 11, 50, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (38, N'Côte de Blaye', 18, 1, N'12 - 75 cl bottles', 263.5000, 17, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (39, N'Chartreuse verte', 18, 1, N'750 cc per bottle', 18.0000, 69, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (40, N'Boston Crab Meat', 19, 8, N'24 - 4 oz tins', 18.4000, 123, 0, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (41, N'Jack''s New England Clam Chowder', 19, 8, N'12 - 12 oz cans', 9.6500, 85, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (42, N'Singaporean Hokkien Fried Mee', 20, 5, N'32 - 1 kg pkgs.', 14.0000, 26, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (43, N'Ipoh Coffee', 20, 1, N'16 - 500 g tins', 46.0000, 17, 10, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (44, N'Gula Malacca', 20, 2, N'20 - 2 kg bags', 19.4500, 27, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (45, N'Rogede sild', 21, 8, N'1k pkg.', 9.5000, 5, 70, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (46, N'Spegesild', 21, 8, N'4 - 450 g glasses', 12.0000, 95, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (47, N'Zaanse koeken', 22, 3, N'10 - 4 oz boxes', 9.5000, 36, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (48, N'Chocolade', 22, 3, N'10 pkgs.', 12.7500, 15, 70, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (49, N'Maxilaku', 23, 3, N'24 - 50 g pkgs.', 20.0000, 10, 60, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (50, N'Valkoinen suklaa', 23, 3, N'12 - 100 g bars', 16.2500, 65, 0, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (51, N'Manjimup Dried Apples', 24, 7, N'50 - 300 g pkgs.', 53.0000, 20, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (52, N'Filo Mix', 24, 5, N'16 - 2 kg boxes', 7.0000, 38, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (53, N'Perth Pasties', 24, 6, N'48 pieces', 32.8000, 0, 0, 0, 1)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (54, N'Tourtière', 25, 6, N'16 pies', 7.4500, 21, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (55, N'Pâté chinois', 25, 6, N'24 boxes x 2 pies', 24.0000, 115, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (56, N'Gnocchi di nonna Alice', 26, 5, N'24 - 250 g pkgs.', 38.0000, 21, 10, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (57, N'Ravioli Angelo', 26, 5, N'24 - 250 g pkgs.', 19.5000, 36, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (58, N'Escargots de Bourgogne', 27, 8, N'24 pieces', 13.2500, 62, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (59, N'Raclette Courdavault', 28, 4, N'5 kg pkg.', 55.0000, 79, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (60, N'Camembert Pierrot', 28, 4, N'15 - 300 g rounds', 34.0000, 19, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (61, N'Sirop d''érable', 29, 2, N'24 - 500 ml bottles', 28.5000, 113, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (62, N'Tarte au sucre', 29, 3, N'48 pies', 49.3000, 17, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (63, N'Vegie-spread', 7, 2, N'15 - 625 g jars', 43.9000, 24, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (64, N'Wimmers gute Semmelknödel', 12, 5, N'20 bags x 4 pieces', 33.2500, 22, 80, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (65, N'Louisiana Fiery Hot Pepper Sauce', 2, 2, N'32 - 8 oz bottles', 21.0500, 76, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (66, N'Louisiana Hot Spiced Okra', 2, 2, N'24 - 8 oz jars', 17.0000, 4, 100, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (67, N'Laughing Lumberjack Lager', 16, 1, N'24 - 12 oz bottles', 14.0000, 52, 0, 10, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (68, N'Scottish Longbreads', 8, 3, N'10 boxes x 8 pieces', 12.5000, 6, 10, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (69, N'Gudbrandsdalsost', 15, 4, N'10 kg pkg.', 36.0000, 26, 0, 15, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (70, N'Outback Lager', 7, 1, N'24 - 355 ml bottles', 15.0000, 15, 10, 30, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (71, N'Flotemysost', 15, 4, N'10 - 500 g pkgs.', 21.5000, 26, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (72, N'Mozzarella di Giovanni', 14, 4, N'24 - 200 g pkgs.', 34.8000, 14, 0, 0, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (73, N'Röd Kaviar', 17, 8, N'24 - 150 g jars', 15.0000, 101, 0, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (74, N'Longlife Tofu', 4, 7, N'5 kg pkg.', 10.0000, 4, 20, 5, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (75, N'Rhönbräu Klosterbier', 12, 1, N'24 - 0.5 l bottles', 7.7500, 125, 0, 25, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (76, N'Lakkalikööri', 23, 1, N'500 ml', 18.0000, 57, 0, 20, 0)
INSERT [Store].[Products] ([ProductId], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (77, N'Original Frankfurter grüne Soße', 12, 2, N'12 boxes', 13.0000, 32, 0, 15, 0)
SET IDENTITY_INSERT [Store].[Products] OFF
ALTER TABLE [Authentication].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_User] FOREIGN KEY([UserId])
REFERENCES [Authentication].[User] ([Id])
GO
ALTER TABLE [Authentication].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_User]
GO
ALTER TABLE [Common].[ResponseCodeDescription]  WITH CHECK ADD  CONSTRAINT [FK_ResponseCodeDescription_Language] FOREIGN KEY([LanguageId])
REFERENCES [Common].[Language] ([Id])
GO
ALTER TABLE [Common].[ResponseCodeDescription] CHECK CONSTRAINT [FK_ResponseCodeDescription_Language]
GO
ALTER TABLE [Common].[ResponseCodeDescription]  WITH CHECK ADD  CONSTRAINT [FK_ResponseCodeDescription_ResponseCode] FOREIGN KEY([ResponseCodeId])
REFERENCES [Common].[ResponseCode] ([Id])
GO
ALTER TABLE [Common].[ResponseCodeDescription] CHECK CONSTRAINT [FK_ResponseCodeDescription_ResponseCode]
GO
USE [master]
GO
ALTER DATABASE [NorthwindDataServer] SET  READ_WRITE 
GO

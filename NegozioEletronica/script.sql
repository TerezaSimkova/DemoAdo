USE [master]
GO
/****** Object:  Database [NegozioElettronica]    Script Date: 26.08.2021 15:38:07 ******/
CREATE DATABASE [NegozioElettronica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NegozioElettronica', FILENAME = N'C:\Users\terez\NegozioElettronica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NegozioElettronica_log', FILENAME = N'C:\Users\terez\NegozioElettronica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NegozioElettronica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NegozioElettronica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ARITHABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NegozioElettronica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NegozioElettronica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NegozioElettronica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET  MULTI_USER 
GO
ALTER DATABASE [NegozioElettronica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NegozioElettronica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NegozioElettronica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NegozioElettronica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NegozioElettronica] SET QUERY_STORE = OFF
GO
USE [NegozioElettronica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NegozioElettronica]
GO
/****** Object:  Table [dbo].[Elettronica]    Script Date: 26.08.2021 15:38:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elettronica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[MemoryGB] [int] NULL,
	[OPSystem] [int] NULL,
	[Touch] [bit] NULL,
	[InchTv] [int] NULL,
	[Discirminator] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Elettronica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Elettronica] ON 

INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (1, N'Samsung', N'Galaxy', 56, 26, NULL, NULL, NULL, N'Phone')
INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (2, N'Nokia', N'XCV', 69, 16, NULL, NULL, NULL, N'Phone')
INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (3, N'Lenovo', N'Intel', 89, NULL, 1, 1, NULL, N'Pc')
INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (5, N'Dell', N'X6d', 56, NULL, 3, 0, NULL, N'Pc')
INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (6, N'Samsung', N'I5xC5', 21, NULL, NULL, NULL, 55, N'Tv')
INSERT [dbo].[Elettronica] ([Id], [Brand], [Model], [Quantity], [MemoryGB], [OPSystem], [Touch], [InchTv], [Discirminator]) VALUES (7, N'Huawei', N'CVx', 65, NULL, NULL, NULL, 65, N'Tv')
SET IDENTITY_INSERT [dbo].[Elettronica] OFF
GO
USE [master]
GO
ALTER DATABASE [NegozioElettronica] SET  READ_WRITE 
GO

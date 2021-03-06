USE [master]
GO
/****** Object:  Database [Example]    Script Date: 05/29/2019 11:38:31 ******/
CREATE DATABASE [Example] ON  PRIMARY 
( NAME = N'Example', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Example.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Example_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Example_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Example] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Example].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Example] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Example] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Example] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Example] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Example] SET ARITHABORT OFF
GO
ALTER DATABASE [Example] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Example] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Example] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Example] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Example] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Example] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Example] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Example] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Example] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Example] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Example] SET  DISABLE_BROKER
GO
ALTER DATABASE [Example] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Example] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Example] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Example] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Example] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Example] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Example] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Example] SET  READ_WRITE
GO
ALTER DATABASE [Example] SET RECOVERY FULL
GO
ALTER DATABASE [Example] SET  MULTI_USER
GO
ALTER DATABASE [Example] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Example] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Example', N'ON'
GO
USE [Example]
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 05/29/2019 11:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_SysUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SysUser] ON
INSERT [dbo].[SysUser] ([ID], [UserName], [Age], [Remark]) VALUES (1, N'TestName', 18, N'this is a test thing')
SET IDENTITY_INSERT [dbo].[SysUser] OFF

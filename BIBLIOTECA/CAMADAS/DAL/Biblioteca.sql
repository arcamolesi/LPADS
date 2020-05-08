USE [master]
GO
/****** Object:  Database [BIBLIOTECA2020]    Script Date: 07/05/2020 21:24:00 ******/
CREATE DATABASE [BIBLIOTECA2020]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BIBLIOTECA2020', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BIBLIOTECA2020.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BIBLIOTECA2020_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BIBLIOTECA2020_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BIBLIOTECA2020] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BIBLIOTECA2020].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BIBLIOTECA2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BIBLIOTECA2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BIBLIOTECA2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BIBLIOTECA2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BIBLIOTECA2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BIBLIOTECA2020] SET  MULTI_USER 
GO
ALTER DATABASE [BIBLIOTECA2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BIBLIOTECA2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BIBLIOTECA2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BIBLIOTECA2020] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BIBLIOTECA2020] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BIBLIOTECA2020] SET QUERY_STORE = OFF
GO
USE [BIBLIOTECA2020]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 07/05/2020 21:24:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](35) NOT NULL,
	[curso] [varchar](25) NULL,
	[dias] [int] NULL,
	[multa] [float] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emprestimo]    Script Date: 07/05/2020 21:24:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprestimo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clienteID] [int] NULL,
	[data] [datetime] NULL,
 CONSTRAINT [PK_Emprestimo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itens]    Script Date: 07/05/2020 21:24:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[emprestimoID] [int] NULL,
	[livroID] [int] NULL,
	[entrega] [datetime] NULL,
 CONSTRAINT [PK_Itens] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livros]    Script Date: 07/05/2020 21:24:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nchar](35) NULL,
	[editora] [nchar](20) NULL,
	[autor] [nchar](30) NULL,
	[valor] [real] NULL,
	[situacao] [tinyint] NULL,
 CONSTRAINT [PK_Livros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id], [nome], [curso], [dias], [multa]) VALUES (2, N'Diomara', N'TPD', 0, 0)
INSERT [dbo].[Clientes] ([id], [nome], [curso], [dias], [multa]) VALUES (3, N'Alex', N'BCC', 3, 2)
INSERT [dbo].[Clientes] ([id], [nome], [curso], [dias], [multa]) VALUES (4, N'Alex Poletto', N'ADS', 6, 16)
INSERT [dbo].[Clientes] ([id], [nome], [curso], [dias], [multa]) VALUES (8, N'Ruan', N'ADS', 1, 1000)
INSERT [dbo].[Clientes] ([id], [nome], [curso], [dias], [multa]) VALUES (15, N'Begosso', N'BCC', 3, 3)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Livros] ON 

INSERT [dbo].[Livros] ([id], [titulo], [editora], [autor], [valor], [situacao]) VALUES (1, N'Poeira em Alto mar                 ', N'Camolesi            ', N'Almir                         ', 12, 1)
SET IDENTITY_INSERT [dbo].[Livros] OFF
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimo_Clientes] FOREIGN KEY([clienteID])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_Emprestimo_Clientes]
GO
ALTER TABLE [dbo].[Itens]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Emprestimo] FOREIGN KEY([emprestimoID])
REFERENCES [dbo].[Emprestimo] ([id])
GO
ALTER TABLE [dbo].[Itens] CHECK CONSTRAINT [FK_Itens_Emprestimo]
GO
ALTER TABLE [dbo].[Itens]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Livros] FOREIGN KEY([livroID])
REFERENCES [dbo].[Livros] ([id])
GO
ALTER TABLE [dbo].[Itens] CHECK CONSTRAINT [FK_Itens_Livros]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ESTE CAMPO GUARDA O VALOR DA MULTA. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clientes', @level2type=N'COLUMN',@level2name=N'multa'
GO
USE [master]
GO
ALTER DATABASE [BIBLIOTECA2020] SET  READ_WRITE 
GO

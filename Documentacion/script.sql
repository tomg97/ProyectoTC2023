USE [master]
GO
/****** Object:  Database [ComercializAR]    Script Date: 11-Jul-23 5:28:45 PM ******/
CREATE DATABASE [ComercializAR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComercializAR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ComercializAR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ComercializAR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ComercializAR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComercializAR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComercializAR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComercializAR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComercializAR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComercializAR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComercializAR] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComercializAR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComercializAR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComercializAR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComercializAR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComercializAR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComercializAR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComercializAR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComercializAR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComercializAR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComercializAR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComercializAR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComercializAR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComercializAR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComercializAR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComercializAR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComercializAR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComercializAR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComercializAR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComercializAR] SET  MULTI_USER 
GO
ALTER DATABASE [ComercializAR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComercializAR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComercializAR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComercializAR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ComercializAR] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ComercializAR]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[domicilio] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id] [nvarchar](50) NOT NULL,
	[ventaJson] [nvarchar](max) NOT NULL,
	[despachada] [bit] NULL,
	[idCliente] [nvarchar](50) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisoPermiso]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoPermiso](
	[idPerfilPadre] [nvarchar](50) NOT NULL,
	[idPerfilHijo] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[permiso] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[nombreProducto] [nvarchar](50) NOT NULL,
	[id] [nvarchar](50) NOT NULL,
	[marcaProducto] [nvarchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[nomUsu] [nvarchar](50) NOT NULL,
	[idPermiso] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[nomUsu] ASC,
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[nomUsu] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](64) NOT NULL,
	[bloqueado] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[nomUsu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[productosVendidos] [nvarchar](max) NOT NULL,
	[id] [nvarchar](100) NOT NULL,
	[monto] [nvarchar](50) NOT NULL,
	[fecha] [nvarchar](50) NOT NULL,
	[clienteId] [nvarchar](50) NOT NULL,
	[facturada] [bit] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([id], [nombre], [apellido], [domicilio], [telefono]) VALUES (N'NDA2NzY3NjM=', N'Tom2', N'Graña2', N'U2FybWllbnRvIDM3Nw==', N'MTE2NDA4NTQ2Ng==')
INSERT [dbo].[Cliente] ([id], [nombre], [apellido], [domicilio], [telefono]) VALUES (N'NDA2NzY3NjQ=', N'Tomás', N'Graña', N'U2FybWllbnRvIDM3Nw==', N'MTE2NDA4NTQ2Ng==')
GO
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'0e5062ff-62ae-450b-9160-c631a9adb610', N'{"id":"0e5062ff-62ae-450b-9160-c631a9adb610","productosVendidos":"[{\"nombreProducto\":\"Core i5 13600K\",\"marcaProducto\":\"Intel\",\"id\":\"1\",\"cantidad\":1,\"precio\":\"100000\"}]","idCliente":"40676764","fecha":"26-Jun-23 12:26:05 AM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'183c1f50-37db-4cfe-94ad-768ea5b7f050', N'{"id":"183c1f50-37db-4cfe-94ad-768ea5b7f050","productosVendidos":"[{\"nombreProducto\":\"Core i5 13600K\",\"marcaProducto\":\"Intel\",\"id\":\"1\",\"cantidad\":4,\"precio\":\"100000\"},{\"nombreProducto\":\"Core i5 13500\",\"marcaProducto\":\"Intel\",\"id\":\"3\",\"cantidad\":3,\"precio\":\"80000\"}]","idCliente":"40676764","fecha":"26-Jun-23 7:40:47 PM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'1b100144-fdce-4d97-b42b-300abf95a300', N'{"_listaProductosVendidos":[{"nombreProducto":"Core i7 13700","marcaProducto":"Intel","id":"5","cantidad":1,"precio":"110000"},{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":2,"precio":"80000"},{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":3,"precio":"90000"}],"id":"1b100144-fdce-4d97-b42b-300abf95a300","productosVendidos":"[{\"nombreProducto\":\"Core i7 13700\",\"marcaProducto\":\"Intel\",\"id\":\"5\",\"cantidad\":1,\"precio\":\"110000\"},{\"nombreProducto\":\"Core i5 13500\",\"marcaProducto\":\"Intel\",\"id\":\"3\",\"cantidad\":2,\"precio\":\"80000\"},{\"nombreProducto\":\"Core i5 13600\",\"marcaProducto\":\"Intel\",\"id\":\"2\",\"cantidad\":3,\"precio\":\"90000\"}]","idCliente":"40676764","fecha":"26-Jun-23 9:08:35 PM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'1c20b448-e769-458d-9bda-a117d6555441', N'{"id":"1c20b448-e769-458d-9bda-a117d6555441","productosVendidos":"[{\"nombreProducto\":\"Core i5 13600K\",\"marcaProducto\":\"Intel\",\"id\":\"1\",\"cantidad\":7,\"precio\":\"100000\"}]","idCliente":"40676764","fecha":"26-Jun-23 12:03:57 AM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'2d5dcebc-4a78-418d-9f48-6e6e8e34f7f1', N'{"id":"2d5dcebc-4a78-418d-9f48-6e6e8e34f7f1","productosVendidos":"[{\"nombreProducto\":\"Core i5 13600\",\"marcaProducto\":\"Intel\",\"id\":\"2\",\"cantidad\":3,\"precio\":\"90000\"}]","idCliente":"40676764","fecha":"25-Jun-23 11:54:41 PM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'92f24f83-ad22-4d16-ab74-c51207617fc1', N'{"_listaProductosVendidos":[{"nombreProducto":"Core i5 13600K","marcaProducto":"Intel","id":"1","cantidad":1,"precio":"100000"}],"id":"92f24f83-ad22-4d16-ab74-c51207617fc1","productosVendidos":"[{\"nombreProducto\":\"Core i5 13600K\",\"marcaProducto\":\"Intel\",\"id\":\"1\",\"cantidad\":1,\"precio\":\"100000\"}]","idCliente":"40676764","fecha":"27-Jun-23 11:55:21 AM","monto":null}', NULL, N'40676764')
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'c0b909e3-e2f5-426a-af7c-ff5d30986295', N'{"id":"c0b909e3-e2f5-426a-af7c-ff5d30986295","productosVendidos":"[{\"nombreProducto\":\"Core i5 13500\",\"marcaProducto\":\"Intel\",\"id\":\"3\",\"cantidad\":2,\"precio\":\"80000\"}]","idCliente":"40676763","fecha":"25-Jun-23 7:05:32 PM","monto":null}', NULL, NULL)
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'd083cac9-b6ac-4b5f-b6ac-0d751b6579e8', N'{"_listaProductosVendidos":[{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":2,"precio":"80000"},{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":3,"precio":"90000"}],"id":"d083cac9-b6ac-4b5f-b6ac-0d751b6579e8","productosVendidos":"[{\"nombreProducto\":\"Core i5 13500\",\"marcaProducto\":\"Intel\",\"id\":\"3\",\"cantidad\":2,\"precio\":\"80000\"},{\"nombreProducto\":\"Core i5 13600\",\"marcaProducto\":\"Intel\",\"id\":\"2\",\"cantidad\":3,\"precio\":\"90000\"}]","idCliente":"40676764","fecha":"26-Jun-23 9:43:36 PM","monto":null}', NULL, N'40676764')
INSERT [dbo].[Factura] ([id], [ventaJson], [despachada], [idCliente]) VALUES (N'f1510fc8-8235-414e-a615-dd238317dc05', N'{"id":"f1510fc8-8235-414e-a615-dd238317dc05","productosVendidos":null,"idCliente":"40676764","fecha":"26-Jun-23 8:56:27 PM","monto":null}', NULL, NULL)
GO
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'16', N'2')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'16', N'10')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'16', N'12')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'15', N'14')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'15', N'13')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'16', N'15')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'17', N'10')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'18', N'12')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'1')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'2')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'3')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'4')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'5')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'6')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'7')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'8')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'9')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'10')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'11')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'12')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'13')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'20', N'14')
INSERT [dbo].[PermisoPermiso] ([idPerfilPadre], [idPerfilHijo]) VALUES (N'19', N'11')
GO
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (1, N'admin_usuarios', N'admin_usuarios')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (2, N'admin_perfiles', N'admin_perfiles')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (3, N'admin_idiomas', N'admin_idiomas')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (4, N'admin_backup', N'admin_backup')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (5, N'admin_bitacora', N'admin_bitacora')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (6, N'maestros_productos', N'maestros_productos')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (7, N'maestros_clientes', N'maestros_clientes')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (8, N'maestros_proveedores', N'maestros_proveedores')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (9, N'usuario', N'usuario')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (10, N'ventas_select', N'ventas_select')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (11, N'ventas_facturar', N'ventas_facturar')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (12, N'ventas_despachar', N'ventas_despachar')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (13, N'compras', N'compras')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (14, N'reportes', N'reportes')
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (15, N'testFamilia', NULL)
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (16, N'test2familia', NULL)
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (17, N'vendedor', NULL)
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (18, N'despachante', NULL)
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (19, N'cajero', NULL)
INSERT [dbo].[Permisos] ([idPermiso], [nombre], [permiso]) VALUES (20, N'admin', NULL)
GO
INSERT [dbo].[Producto] ([nombreProducto], [id], [marcaProducto], [cantidad], [precio]) VALUES (N'Core i5 13600K', N'1', N'Intel', 15, N'100000')
INSERT [dbo].[Producto] ([nombreProducto], [id], [marcaProducto], [cantidad], [precio]) VALUES (N'Core i5 13600', N'2', N'Intel', 15, N'90000')
INSERT [dbo].[Producto] ([nombreProducto], [id], [marcaProducto], [cantidad], [precio]) VALUES (N'Core i5 13500', N'3', N'Intel', 15, N'80000')
INSERT [dbo].[Producto] ([nombreProducto], [id], [marcaProducto], [cantidad], [precio]) VALUES (N'Core i7 13700K', N'4', N'Intel', 15, N'120000')
INSERT [dbo].[Producto] ([nombreProducto], [id], [marcaProducto], [cantidad], [precio]) VALUES (N'Core i7 13700', N'5', N'Intel', 15, N'110000')
GO
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 1)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 2)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 3)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 4)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 5)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 6)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 7)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 8)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 9)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 10)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 11)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 12)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 13)
INSERT [dbo].[UsuarioPermiso] ([nomUsu], [idPermiso]) VALUES (N'admin', 14)
GO
INSERT [dbo].[Usuarios] ([nomUsu], [pass], [bloqueado]) VALUES (N'admin', N'FD984BAD363E9A30021460091726467B65BB1E88C31752D93C68ADE87E4946E4', 0)
INSERT [dbo].[Usuarios] ([nomUsu], [pass], [bloqueado]) VALUES (N'usuario1', N'15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc', 0)
INSERT [dbo].[Usuarios] ([nomUsu], [pass], [bloqueado]) VALUES (N'usuario2', N'15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc', 0)
INSERT [dbo].[Usuarios] ([nomUsu], [pass], [bloqueado]) VALUES (N'usuario3', N'15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc', 0)
GO
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600K","marcaProducto":"Intel","id":"1","cantidad":1,"precio":"100000"}]', N'0e5062ff-62ae-450b-9160-c631a9adb610', N'MTAwMDAw', N'26-Jun-23 12:26:05 AM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600K","marcaProducto":"Intel","id":"1","cantidad":4,"precio":"100000"},{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":3,"precio":"80000"}]', N'183c1f50-37db-4cfe-94ad-768ea5b7f050', N'NjQwMDAw', N'26-Jun-23 7:40:47 PM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i7 13700","marcaProducto":"Intel","id":"5","cantidad":1,"precio":"110000"},{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":2,"precio":"80000"},{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":3,"precio":"90000"}]', N'1b100144-fdce-4d97-b42b-300abf95a300', N'NTQwMDAw', N'26-Jun-23 9:08:35 PM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600K","marcaProducto":"Intel","id":"1","cantidad":7,"precio":"100000"}]', N'1c20b448-e769-458d-9bda-a117d6555441', N'NzAwMDAw', N'26-Jun-23 12:03:57 AM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":3,"precio":"90000"}]', N'2d5dcebc-4a78-418d-9f48-6e6e8e34f7f1', N'MjcwMDAw', N'25-Jun-23 11:54:41 PM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600K","marcaProducto":"Intel","id":"1","cantidad":1,"precio":"100000"}]', N'92f24f83-ad22-4d16-ab74-c51207617fc1', N'MTAwMDAw', N'27-Jun-23 11:55:21 AM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":2,"precio":"80000"}]', N'c0b909e3-e2f5-426a-af7c-ff5d30986295', N'MTYwMDAw', N'25-Jun-23 7:05:32 PM', N'40676763', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13500","marcaProducto":"Intel","id":"3","cantidad":2,"precio":"80000"},{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":3,"precio":"90000"}]', N'd083cac9-b6ac-4b5f-b6ac-0d751b6579e8', N'NDMwMDAw', N'26-Jun-23 9:43:36 PM', N'40676764', 1)
INSERT [dbo].[Venta] ([productosVendidos], [id], [monto], [fecha], [clienteId], [facturada]) VALUES (N'[{"nombreProducto":"Core i5 13600","marcaProducto":"Intel","id":"2","cantidad":2,"precio":"90000"}]', N'f1510fc8-8235-414e-a615-dd238317dc05', N'MTgwMDAw', N'26-Jun-23 8:56:27 PM', N'40676764', 1)
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Permiso] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permisos] ([idPermiso])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Permiso]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuarios] FOREIGN KEY([nomUsu])
REFERENCES [dbo].[Usuarios] ([nomUsu])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[AñadirAStockPredefinido]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AñadirAStockPredefinido]
	-- Add the parameters for the stored procedure here
	@cantidad int
AS
BEGIN
	update Producto
	set cantidad = @cantidad 
END
GO
/****** Object:  StoredProcedure [dbo].[AutenticarUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutenticarUsuario]
    @nomUsu VARCHAR(50),
    @pass VARCHAR(64),
	@Result INT OUTPUT
AS
BEGIN
  DECLARE @Counter INT;

  -- Check if the user exists in the table
  IF EXISTS(SELECT 1 FROM Usuarios WHERE nomUsu = @nomUsu)
  BEGIN
    -- Get the current counter value for the user
    SELECT @Counter = bloqueado FROM Usuarios WHERE nomUsu = @nomUsu;

    -- Check if the counter field is already at 3
    IF @Counter = 3
    BEGIN
      SET @Result = 0; -- User's counter field is already at 3
    END
    ELSE
    BEGIN
      -- Check if the password matches
      IF EXISTS(SELECT 1 FROM Usuarios WHERE nomUsu = @nomUsu AND pass = @pass)
      BEGIN
		SET @Counter = 0
		UPDATE Usuarios SET bloqueado = @Counter WHERE nomUsu = @nomUsu
        SET @Result = 3; -- User found and password matched
      END
      ELSE
      BEGIN
        SET @Counter = @Counter + 1; -- Increment the counter field
        SET @Result = 2; -- User found but password not matched
        -- Update the counter field in the table
        UPDATE Usuarios SET bloqueado = @Counter WHERE nomUsu = @nomUsu;
      END
    END
  END
  ELSE
  BEGIN
    SET @Result = 1; -- User not found
  END
END
GO
/****** Object:  StoredProcedure [dbo].[CambioContraseña]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CambioContraseña] 
	@nomUsu VARCHAR(50),
	@pass VARCHAR(64),
	@passNueva VARCHAR(64),
	@Result INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT 1 FROM Usuarios WHERE nomUsu = @nomUsu AND pass = @pass)
	BEGIN
	UPDATE Usuarios SET pass = @passNueva WHERE nomUsu = @nomUsu;
	SET @Result = 1;
	END
	ELSE
	BEGIN 
	SET @Result = 0;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CrearCliente]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearCliente]
    @Id nVARCHAR(50),
    @Nombre nVARCHAR(100),
    @Apellido nVARCHAR(100),
    @Domicilio nVARCHAR(200),
    @Telefono nVARCHAR(200)
AS
BEGIN
    INSERT INTO Cliente (id, nombre, apellido, domicilio, telefono)
    VALUES (@Id, @Nombre, @Apellido, @Domicilio, @Telefono)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearFactura]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearFactura]
	-- Add the parameters for the stored procedure here
	@id nvarchar(100),
	@jsonVenta nvarchar(1000),
	@idCliente nvarchar(50)
AS
BEGIN
	INSERT into Factura (id, ventaJson, idCliente)
	VALUES (@id, @jsonVenta, @idCliente)
	update Venta
	set facturada = 1
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearUsuario]
  @nomUsu VARCHAR(50),
  @pass VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON
  -- Insert the new user into the table
  INSERT INTO Usuarios (nomUsu, pass, bloqueado)
  VALUES (@nomUsu, @pass, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[CrearVenta]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearVenta]
	-- Add the parameters for the stored procedure here
	@productosVendidos nvarchar(max),
	@id nvarchar(100),
	@monto nvarchar(50),
	@fecha nvarchar(50),
	@cliente nvarchar(50),
	@facturada bit
AS
BEGIN
	INSERT into Venta (productosVendidos, id, monto, fecha, clienteId, facturada)
	VALUES (@productosVendidos, @id, @monto, @fecha, @cliente, @facturada)
END
GO
/****** Object:  StoredProcedure [dbo].[DesbloquearUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DesbloquearUsuario]
	@nomUsu VARCHAR(50)
AS
BEGIN
  SET NOCOUNT ON;
  Update Usuarios
  SET bloqueado = 0
  WHERE nomUsu = @nomUsu
END

GO
/****** Object:  StoredProcedure [dbo].[DespachoFactura]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DespachoFactura]
    @id NVARCHAR(50),
	@idCliente NVARCHAR (50)
AS
BEGIN
    -- Check if the item exists and the "dispatched" field is not 1
    IF EXISTS (SELECT 1 FROM Factura WHERE id = @id AND idCliente = @idCliente AND despachada <> 1)
    BEGIN
        -- Update the "dispatched" field to 1
		SELECT * from Factura WHERE id = @id;
        UPDATE Factura SET despachada = 1 WHERE id = @id;
        	
    END
    ELSE
    BEGIN
        SELECT 'Not found';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[getListaProductosEnStock]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getListaProductosEnStock] 
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * from Producto WHERE cantidad > 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsuariosBloqueados]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsuariosBloqueados]
AS
BEGIN
  SET NOCOUNT ON;

  SELECT nomUsu
  FROM Usuarios
  WHERE bloqueado = 3;
END

GO
/****** Object:  StoredProcedure [dbo].[GetVentasNoFacturadas]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVentasNoFacturadas]
AS
BEGIN
	Select * from Venta
	where facturada = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarComponente]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarComponente]
    @nombre NVARCHAR(50),
	@permiso NVARCHAR(50)
AS
BEGIN
	DECLARE @ultimoId INT;
	SELECT @ultimoId = MAX(idPermiso) FROM Permisos
	DECLARE @nuevoId int = ISNULL(@ultimoId, 0) + 1;
	insert into Permisos (nombre,permiso, idPermiso) values (@nombre,@permiso, @nuevoId);  SELECT idPermiso AS LastID FROM Permisos WHERE idPermiso = @@Identity
END

GO
/****** Object:  StoredProcedure [dbo].[GuardarFamiliaPaso1]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarFamiliaPaso1]
    @id INT
AS
BEGIN
    delete from PermisoPermiso where idPerfilPadre=@id
END

GO
/****** Object:  StoredProcedure [dbo].[GuardarFamiliaPaso2]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarFamiliaPaso2]
    @idPadre INT,
	@idHijo INT
AS
BEGIN
    insert into PermisoPermiso (idPerfilPadre,idPerfilHijo) values (@idPadre,@idHijo)
END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPerfilPaso1]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarPerfilPaso1]
    @nomUsu NVARCHAR(50)
AS
BEGIN
    delete from UsuarioPermiso where nomUsu=@nomUsu
END

GO
/****** Object:  StoredProcedure [dbo].[GuardarPerfilPaso2]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarPerfilPaso2]
    @nomUsu NVARCHAR(50),
	@idPermiso INT
AS
BEGIN
   insert into UsuarioPermiso (nomUsu, idPermiso) values (@nomUsu, @idPermiso)
END

GO
/****** Object:  StoredProcedure [dbo].[LookupCliente]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LookupCliente] 
	@id VARCHAR(50),
	@Result INT OUTPUT
AS
BEGIN
    IF EXISTS(SELECT 1 FROM Cliente WHERE id = @id)
	BEGIN
		SET @Result = 1;
	END
	ELSE
	BEGIN
		SET @Result = 0;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[LookupUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LookupUsuario]
    @nomUsu VARCHAR(50),
	@Result INT OUTPUT
AS
BEGIN
    IF EXISTS(SELECT 1 FROM Usuarios WHERE nomUsu = @nomUsu)
	BEGIN
		SET @Result = 1;
	END
	ELSE
	BEGIN
		SET @Result = 0;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarNombreUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarNombreUsuario]
  @usuViejo VARCHAR(50),
  @usuNuevo VARCHAR(50),
  @Result INT OUTPUT
AS
BEGIN
  SET NOCOUNT ON;
  -- Check if the new username already exists
  IF EXISTS(SELECT 1 FROM Usuarios WHERE nomUsu = @usuNuevo)
  BEGIN
    SET @Result = 0;
  END

  -- Update the username
  UPDATE Usuarios
  SET nomUsu = @usuNuevo
  WHERE nomUsu = @usuViejo;
  SET @Result = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[RemoverDeStock]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoverDeStock]
	-- Add the parameters for the stored procedure here
	@Id Nvarchar(50),
	@Cantidad INT
AS
BEGIN
	Update Producto
	set cantidad = cantidad - @Cantidad
	WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[TraerFamilias]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TraerFamilias]
AS
BEGIN
	SELECT * FROM Permisos where permiso is NULL
END
GO
/****** Object:  StoredProcedure [dbo].[TraerPermisosByUsuario]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TraerPermisosByUsuario]
    @nomUsu NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM UsuarioPermiso up
    INNER JOIN Permisos p ON up.idPermiso = p.idPermiso
    WHERE up.nomUsu = @nomUsu;
END

GO
/****** Object:  StoredProcedure [dbo].[TraerTodasPatentes]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TraerTodasPatentes] 
AS
BEGIN
	SELECT * FROM Permisos p
	WHERE p.permiso IS NOT NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[TraerTodosUsuarios]    Script Date: 11-Jul-23 5:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TraerTodosUsuarios]
AS
BEGIN
	SELECT * FROM Usuarios
END
GO
USE [master]
GO
ALTER DATABASE [ComercializAR] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [ComercializAR]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  Table [dbo].[Factura]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  Table [dbo].[Venta]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AñadirAStockPredefinido]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AutenticarUsuario]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CambioContraseña]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CrearCliente]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CrearFactura]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CrearVenta]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DesbloquearUsuario]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DespachoFactura]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getListaProductosEnStock]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUsuariosBloqueados]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetVentasNoFacturadas]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LookupCliente]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LookupUsuario]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[ModificarNombreUsuario]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RemoverDeStock]    Script Date: 02-Jul-23 6:39:50 PM ******/
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
USE [master]
GO
ALTER DATABASE [ComercializAR] SET  READ_WRITE 
GO

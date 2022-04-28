USE [PruebaWTW]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 27/04/2022 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Numero_Identificacion] [varchar](50) NOT NULL,
	[Tipo_Identificacion] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Fecha_Creacion]  AS (getdate()), --FechaGenerada Actual
	[Identificacion_Tipo]  AS (([Numero_Identificacion]+'  ')+[Tipo_Identificacion]),--Columna Calculada
	[Nombre_Completo]  AS (([Nombres]+'  ')+[Apellidos]),--Columna Calculada
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/04/2022 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[Fecha_Creacion]  AS (getdate()),
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerPersonas]    Script Date: 27/04/2022 19:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerPersonas] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Nombres]
      ,[Apellidos]
      ,[Numero_Identificacion]
      ,[Tipo_Identificacion]
      ,[Email]
      ,[Fecha_Creacion]
      ,[Identificacion_Tipo]
      ,[Nombre_Completo]
	 FROM [dbo].[Persona]
END
GO

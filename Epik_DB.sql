
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Epik_DB')
BEGIN
    CREATE DATABASE Epik_DB;
END
GO
USE [Epik_DB]
GO
/****** Object:  Table [dbo].[TiposIdentificacion]    Script Date: 18/11/2025 12:10:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposIdentificacion](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [nvarchar](3) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TiposIdentificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [uniqueidentifier] NOT NULL,
	[Identificacion] [nvarchar](30) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Edad] [int] NOT NULL,
	[TipoIdentificacionId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[GeneroId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[Id] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaPersonalFemenino] AS
SELECT p.Id, p.Identificacion, p.Nombres, p.Apellidos, p.Edad, p.IsActive,
       ti.Descripcion AS TipoIdentificacion,
       g.Descripcion AS Genero
FROM Personas p
INNER JOIN TiposIdentificacion ti ON p.TipoIdentificacionId = ti.Id
INNER JOIN Generos g ON p.GeneroId = g.Id
WHERE g.Id = 'D1867452-8D60-49E1-B6D8-48032577FF1E' -- Femenino
GO
INSERT [dbo].[Generos] ([Id], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'f608f4c5-791b-483d-a467-07c762cf52fd', N'Masculino', CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[Generos] ([Id], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'd1867452-8d60-49e1-b6d8-48032577ff1e', N'Femenino', CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), NULL, 1)

INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'3c2f1f66-9a65-44fc-b1ea-34ac2eab2553', N'CE', N'Cédula de Extranjería', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'1a8d3e2f-4f23-4b0e-9d29-44eae48bbaa1', N'PA', N'Pasaporte', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'2bfe05a9-df9a-4932-8a6a-511d6cccd8e6', N'TI', N'Tarjeta de Identidad', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'4e1c1499-8b27-4c65-b9f3-6a1918e842db', N'PEP', N'Permiso Especial de Permanencia (PEP)', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'0c0785e7-4863-48f7-ada7-ba819cf91e2d', N'CC', N'Cédula de Ciudadanía', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[TiposIdentificacion] ([Id], [Codigo], [Descripcion], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (N'0c0785e7-4863-48f7-ada7-cfe3b67df097', N'RC', N'Registro Civil', CAST(N'2025-11-01T00:00:00.0000000' AS DateTime2), NULL, 1)
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [GeneroId]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Generos_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Generos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Generos_GeneroId]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TiposIdentificacion_TipoIdentificacionId] FOREIGN KEY([TipoIdentificacionId])
REFERENCES [dbo].[TiposIdentificacion] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TiposIdentificacion_TipoIdentificacionId]
GO

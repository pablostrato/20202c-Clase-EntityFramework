USE [2020-2c-EF]
GO

/****** Object:  Table [dbo].[Marca]    Script Date: 10/21/2020 10:08:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



ALTER TABLE dbo.Producto ADD CONSTRAINT
	FK_Producto_Marca FOREIGN KEY
	(
	IdMarca
	) REFERENCES dbo.Marca
	(
	IdMarca
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
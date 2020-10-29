
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ProductoCategoria](
	[IdCategoria] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [PK_ProductoCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProductoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProductoCategoria_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO

ALTER TABLE [dbo].[ProductoCategoria] CHECK CONSTRAINT [FK_ProductoCategoria_Categoria]
GO

ALTER TABLE [dbo].[ProductoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProductoCategoria_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductoCategoria] CHECK CONSTRAINT [FK_ProductoCategoria_Producto]
GO


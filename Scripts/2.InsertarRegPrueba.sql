USE [OPHELIA]
GO
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([IdTipoDocumento], [Nombre]) VALUES (1, N'CC')
INSERT [dbo].[TipoDocumento] ([IdTipoDocumento], [Nombre]) VALUES (2, N'NIT')
INSERT [dbo].[TipoDocumento] ([IdTipoDocumento], [Nombre]) VALUES (3, N'CE')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [IdTipoDocumento], [Documento], [FechaNacimiento], [Correo], [EstaActivo], [FechaCreacion], [FechaActualizacion]) VALUES (1, N'Jennifer', N'Brequeman', 1, N'1083004812', CAST(N'1995-10-24' AS Date), N'jbrequeman@gmail.com', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [IdTipoDocumento], [Documento], [FechaNacimiento], [Correo], [EstaActivo], [FechaCreacion], [FechaActualizacion]) VALUES (2, N'Pepito', N'Perez', 1, N'293544', CAST(N'1998-03-06' AS Date), N'pepito@gmail.com', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [IdTipoDocumento], [Documento], [FechaNacimiento], [Correo], [EstaActivo], [FechaCreacion], [FechaActualizacion]) VALUES (3, N'Juanito', N'Escarcha', 1, N'3993939', CAST(N'1993-11-12' AS Date), N'juanito@gmail.com', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [IdTipoDocumento], [Documento], [FechaNacimiento], [Correo], [EstaActivo], [FechaCreacion], [FechaActualizacion]) VALUES (4, N'Maria', N'Gomez', 1, N'2000300', CAST(N'1988-01-23' AS Date), N'mary@gmail.com', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [IdTipoDocumento], [Documento], [FechaNacimiento], [Correo], [EstaActivo], [FechaCreacion], [FechaActualizacion]) VALUES (5, N'Karen', N'Rodriguez', 1, N'93393939', CAST(N'1970-06-16' AS Date), N'karen@gmail.com', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Compra] ON 

INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (1, 1, CAST(N'2020-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (2, 1, CAST(N'2020-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (4, 2, CAST(N'2000-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (6, 4, CAST(N'2020-03-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (7, 5, CAST(N'2000-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Compra] ([IdCompra], [IdCliente], [Fecha]) VALUES (8, 4, CAST(N'2021-02-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Compra] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio], [Descripcion], [EstaActivo], [FechaCreacion], [FechaActualizacion], [Cantidad], [CantidadExistente]) VALUES (1, N'Mouse', CAST(20000.00 AS Decimal(18, 2)), N'Mouse lindo', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime), 10, 5)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio], [Descripcion], [EstaActivo], [FechaCreacion], [FechaActualizacion], [Cantidad], [CantidadExistente]) VALUES (3, N'Teclado', CAST(3406442.21 AS Decimal(18, 2)), N'', 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime), 15, 6)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio], [Descripcion], [EstaActivo], [FechaCreacion], [FechaActualizacion], [Cantidad], [CantidadExistente]) VALUES (4, N'Pantalla', CAST(2901000.99 AS Decimal(18, 2)), NULL, 1, CAST(N'2021-04-18T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime), 4, 3)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (1, 1, 1)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (1, 3, 3)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (2, 4, 2)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (4, 1, 3)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (4, 3, 1)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (6, 3, 5)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (6, 4, 3)
INSERT [dbo].[Compra_Producto] ([IdCompra], [IdProducto], [Cantidad]) VALUES (7, 1, 1)
GO

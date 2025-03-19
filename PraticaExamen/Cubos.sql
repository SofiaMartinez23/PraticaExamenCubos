
DROP TABLE IF EXISTS [dbo].[COMPRA];
DROP TABLE IF EXISTS [dbo].[CUBOS];
DROP TABLE IF EXISTS [dbo].[MARCA];
DROP TABLE IF EXISTS [dbo].[USUARIOS];


CREATE TABLE [dbo].[USUARIOS](
	[id_user] INT NOT NULL IDENTITY(1,1),  -- Hacemos la columna IdUsuario auto-incremental
	[nombre] NVARCHAR(500) NOT NULL,
	[email] NVARCHAR(500) NOT NULL,
	[password] NVARCHAR(500) NOT NULL,
	PRIMARY KEY ([id_user])  -- Establecemos la clave primaria
);
CREATE TABLE [dbo].[MARCA](
    [id_marca] INT NOT NULL IDENTITY(1,1),  -- Clave primaria
    [nombre] NVARCHAR(500) NOT NULL,          -- Nombre del género (o marca)
    PRIMARY KEY ([id_marca])
);
CREATE TABLE [dbo].[CUBOS](
	[id_cubo] INT NOT NULL IDENTITY(1,1),
	[nombre] NVARCHAR(500) NOT NULL,           -- Nombre del cubo (similar al título del libro)
	[modelo] NVARCHAR(500) NOT NULL,           -- Modelo del cubo
	[precio] INT NOT NULL,                     -- Precio del cubo
	[imagen] NVARCHAR(500) NOT NULL,          -- Imagen del cubo (similar a la portada del libro)
	[id_marca] INT NOT NULL,                  -- Relación con la tabla de géneros (marcas)
	CONSTRAINT FK_CUBOS_GENERO FOREIGN KEY ([id_marca]) REFERENCES [dbo].[MARCA]([id_marca]),
	PRIMARY KEY ([id_cubo])
);
CREATE TABLE [dbo].[COMPRA](
	[id_pedido] INT NOT NULL IDENTITY(1,1),      -- Clave primaria del pedido
	[id_usuario] INT NOT NULL,                    -- Usuario que realiza el pedido
	[id_cubo] INT NOT NULL,                       -- Cubo que ha sido pedido
	[cantidad] INT NOT NULL,                      -- Cantidad de cubos pedidos
	[fecha] DATETIME NOT NULL,                    -- Fecha en que se hizo el pedido
	[precio_final] INT NOT NULL,                  -- Precio total del pedido
	CONSTRAINT FK_PEDIDOS_USUARIO FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[USUARIOS]([id_user]),
	CONSTRAINT FK_PEDIDOS_CUBO FOREIGN KEY ([id_cubo]) REFERENCES [dbo].[CUBOS]([id_cubo]),
	PRIMARY KEY ([id_pedido])
);




-- Insertar marcas
INSERT INTO [dbo].[MARCA] ([nombre]) 
VALUES 
    ('ShengShou Cube'),
    ('QiYi MoFangGe'),
    ('MoYu'),
    ('Dayan'),
    ('Qiyi');

	-- Insertar cubos
INSERT INTO [dbo].[CUBOS] ([nombre], [modelo], [precio], [imagen], [id_marca]) 
VALUES 
    (N'Megaminx', N'Megaminx', 3, N'https://kubekings.com/17452-medium_default/shengshou-legend-3x3-s.jpg', 1),   -- ShengShou Cube
    (N'Sandwich', N'Gear', 3, N'https://img.joomcdn.net/17c496ece5b2e99c316777d06ef23eb63b433efa_original.jpeg', 2),  -- QiYi MoFangGe
    (N'Mirror 2x2x2', N'Mirror', 4, N'https://img.dynos.es/img/2458d/2458d/554080103-0.jpg', 2),  -- QiYi MoFangGe
    (N'Meilong Pyraminx', N'Pyraminx', 4, N'https://img.dynos.es/img/22540/2458d/4545050103-0.jpg', 3),  -- MoYu
    (N'Fisher cube', N'Fisher', 5, N'https://img.joomcdn.net/b8912421b62b2be51f17fd3a9bf39a499f580d5e_original.jpeg', 2), -- QiYi MoFangGe
    (N'Lingpo', N'2X2X2', 3, N'https://m.media-amazon.com/images/I/61ZhSt6ZshL._SL1001_.jpg', 3),  -- MoYu
    (N'Skewb', N'Skewb', 5, N'https://www.maskecubos.com/4439-large_default/qiyi-qiheng-skewb.jpg', 1), -- ShengShou Cube
    (N'Yileng Fisher', N'Fisher', 6, N'https://www.juegosbesa.com/9613-large_default/qiyi-yileng-fisher-negro.jpg', 3), -- MoYu
    (N'Megaminx 13x13x13', N'Megaminx', 590, N'https://i.pinimg.com/originals/26/df/a7/26dfa7e1eca203c545b2d58711ca29ad.jpg', 1), -- ShengShou Cube
    (N'Elephant 2x2x2', N'2X2X2', 6, N'https://iqgyerekjatekok.hu/image/kinai/yongjun/yongjun-special-2x2x2-cube-elephant-blue-35135.JPG', 2), -- QiYi MoFangGe
    (N'Mastermorphix 3x3x3', N'Mastermorphix', 5, N'https://kubekings.com/13766-large_default/qiyi-mastermorphix.jpg', 1), -- ShengShou Cube
    (N'Weipo WRS', N'2x2x2', 4, N'https://kubekings.com/26593-medium_default/moyu-weipo-wrs-m-2x2.jpg', 3), -- MoYu
    (N'DaYan TengYun', N'2x2', 22, N'https://www.losmundosderubik.es/4390-large_default/dayan-tengyun-2x2-plus-m.jpg', 4), -- Dayan
    (N'Qiyi Wuxia', N'2x2', 18, N'https://www.losmundosderubik.es/1853-large_default/qiyi-wuxia-2x2-magnetico.jpg', 5); -- Qiyi


	-- Insertar usuarios
INSERT INTO [dbo].[USUARIOS] ([nombre], [email], [password]) 
VALUES 
    (N'User 1', N'user1@gmail.com', N'12345'),
    (N'User 2', N'user2@gmail.com', N'12345'),
    (N'User 3', N'user3@gmail.com', N'12345');


	-- Insertar pedidos
INSERT INTO [dbo].[COMPRA] ([id_usuario], [id_cubo], [cantidad], [fecha], [precio_final]) 
VALUES 
    (1, 2, 1, CAST(N'2022-02-20T02:18:02.090' AS DateTime), 3),  -- User 1 compró un Megaminx
    (1, 4, 2, CAST(N'2022-02-20T02:18:02.307' AS DateTime), 6),  -- User 1 compró dos Sandwiches
    (2, 5, 1, CAST(N'2022-02-20T14:32:16.723' AS DateTime), 4),  -- User 2 compró un Mirror 2x2x2
    (2, 6, 1, CAST(N'2022-02-20T14:32:16.890' AS DateTime), 4),  -- User 2 compró un Meilong Pyraminx
    (3, 7, 1, CAST(N'2022-02-20T20:29:59.257' AS DateTime), 5),  -- User 3 compró un Fisher Cube
    (3, 8, 2, CAST(N'2022-02-20T20:45:23.100' AS DateTime), 6);  -- User 3 compró dos Lingpo



	CREATE OR ALTER VIEW VISTACOMPRAS AS
SELECT 
    c.id_pedido AS IDVISTACOMPRA,            
    c.id_usuario AS IdUsuario,            
    u.nombre AS NombreUsuario,                  
    c.id_cubo AS IdCubo,                     
    cubo.nombre AS NombreCubo,                
    cubo.precio AS PrecioCubo,                  
    cubo.imagen AS ImagenCubo,                
    c.cantidad AS Cantidad,                     
    c.fecha AS FechaCompra,                      
    (c.cantidad * cubo.precio) AS PrecioFinal    
FROM 
    COMPRA c
JOIN 
    CUBOS cubo ON c.id_cubo = cubo.id_cubo     
JOIN 
    USUARIOS u ON c.id_usuario = u.id_user;     -- Relación entre compra y usuarios

Create Database BAEventos
GO
Use BAEventos
GO
Create Table Provincia(
ID bigint not null primary key identity(1,1),
Nombre varchar(50) not null
)

Create Table Ciudad(
IDCiudad bigint not null primary key identity(1,1),
IDProvincia bigint not null foreign key references Provincia(ID),
Nombre varchar(50) not null,
CodigoPostal varchar(10) not null
)

Create Table Direccion(
ID smallint not null primary key identity(1,1),
Calle varchar(50) not null,
Altura varchar(10) not null,
)

Create table Ubicacion(
IDUbicacion bigint not null primary key identity (1,1),
IDCiudad bigint not null foreign key references Ciudad(IDCiudad),
IDDireccion smallint not null foreign key references Direccion(ID)
)

Create Table Rol(
IDRol smallint not null primary key identity(1,1),
Rol varchar(50) not null
)

Create Table Usuario(
IDUsuario bigint not null primary key identity(1,1),
IDRol smallint not null foreign key references Rol(IDRol),
Contrasena varchar(256) not null,
Apellido varchar(50) not null,
Nombre varchar(50) not null,
DNI varchar(10) not null UNIQUE,
CorreoElectronico varchar(50) not null UNIQUE,
FechaNacimiento date not null,
Estado bit not null,
)

Create Table Imagen_x_Usuario(
    IDImagen smallint not null primary key identity(1,1),
    IDUsuario bigint not null foreign key references Usuario(IDUsuario),
    ImgUrl nvarchar(max) not null,
)

Create Table Disciplina(
IDDisciplina bigint not null primary key identity(1,1),
Disciplina varchar(50) not null
)

Create Table Evento(
IDEvento bigint not null primary key identity(1,1),
Nombre varchar(100) not null,
FechaEvento date not null,
Ubicacion bigint not null foreign key references Ubicacion(IDUbicacion),
CostoInscripcion money null,
Estado char(1) not null check (Estado = 'D' or Estado = 'F' or Estado = 'C'),
EdadMinima tinyint null,
EdadMaxima tinyint null,
CuposDisponibles int not null,
)

Create Table Imagen_x_Evento(
    IDImagen smallint not null primary key identity(1,1),
    IDEvento bigint not null foreign key references Evento(IDEvento),
    ImgUrl nvarchar(max) not null,
)

Create Table Disciplina_x_Evento(
IDEvento bigint not null foreign key references Evento(IDEvento),
IDDisciplina bigint not null foreign key references Disciplina(IDDisciplina),
Distancia DECIMAL NOT NULL CHECK(Distancia > 0)
)

Create Table Usuario_x_Evento(
    IDEvento bigint not null foreign key references Evento(IDEvento),
    IDUsuario bigint not null foreign key references Usuario(IDUsuario),
    primary key (IDEvento, IDUsuario)
)

Create Table Resultado_x_Evento(
IDEvento bigint not null foreign key references Evento(IDEvento),
IDDisciplina bigint not null foreign key references Disciplina(IDDisciplina),
IDUsuario bigint not null foreign key references Usuario(IDUsuario),
Puesto tinyint null,
Tiempo time null
)

INSERT INTO Provincia (Nombre) VALUES 
('Buenos Aires'),
('Córdoba'),
('Santa Fe'),
('Mendoza'),
('Tucumán'),
('Entre Ríos'),
('Salta'),
('Misiones'),
('Chaco'),
('Corrientes'),
('Santiago del Estero'),
('San Juan'),
('Jujuy'),
('Río Negro'),
('Neuquén'),
('Formosa'),
('Chubut'),
('San Luis'),
('Catamarca'),
('La Rioja'),
('La Pampa'),
('Santa Cruz'),
('Tierra del Fuego');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(1, 'La Plata', '1900'),
(1, 'Mar del Plata', '7600'),
(1, 'Bahía Blanca', '8000'),
(1, 'Tandil', '7000');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(2, 'Villa Carlos Paz', '5152'),
(2, 'Río Cuarto', '5800');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(3, 'Rosario', '2000'),
(3, 'Rafaela', '2300');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(4, 'San Rafael', '5600'),
(4, 'Luján de Cuyo', '5507');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(5, 'San Miguel de Tucumán', '4000'),
(5, 'Tafí Viejo', '4103'),
(5, 'Yerba Buena', '4107');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(6, 'Paraná', '3100'),
(6, 'Concordia', '3200'),
(6, 'Gualeguaychú', '2820');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(7, 'Cafayate', '4427'),
(7, 'Tartagal', '4560');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(8, 'Posadas', '3300'),
(8, 'Oberá', '3360'),
(8, 'Eldorado', '3380');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(9, 'Resistencia', '3500'),
(9, 'Barranqueras', '3503'),
(9, 'Villa Ángela', '3540');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(10, 'Goya', '3450'),
(10, 'Paso de los Libres', '3230');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(11, 'La Banda', '4300'),
(11, 'Termas de Río Hondo', '4220');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(12, 'San Juan', '5400'),
(12, 'Jáchal', '5460'),
(12, 'Calingasta', '5401');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(13, 'San Salvador de Jujuy', '4600'),
(13, 'Palpalá', '4612'),
(13, 'Humahuaca', '4630');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(14, 'Viedma', '8500'),
(14, 'San Carlos de Bariloche', '8400'),
(14, 'General Roca', '8332');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(15, 'San Martín de los Andes', '8370'),
(15, 'Plottier', '8316');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(16, 'Clorinda', '3610');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(17, 'Rawson', '9103'),
(17, 'Comodoro Rivadavia', '9000'),
(17, 'Puerto Madryn', '9120');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(18, 'Villa Mercedes', '5730'),
(18, 'Merlo', '5881');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(19, 'San Fernando del Valle de Catamarca', '4700'),
(19, 'Belén', '4750');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(20, 'Chilecito', '5360');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(21, 'Santa Rosa', '6300'),
(21, 'General Pico', '6360');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(22, 'Río Gallegos', '9400'),
(22, 'Caleta Olivia', '9011');

INSERT INTO Ciudad (IDProvincia, Nombre, CodigoPostal) VALUES 
(23, 'Río Grande', '9420');

INSERT INTO Direccion (Calle, Altura) VALUES ('Av. Libertador', '1000');
INSERT INTO Direccion (Calle, Altura) VALUES ('Calle 9 de Julio', '4567');
INSERT INTO Direccion (Calle, Altura) VALUES ('Calle Falsa', '1010');
INSERT INTO Direccion (Calle, Altura) VALUES ('Boulevard Constitución', '789');
INSERT INTO Direccion (Calle, Altura) VALUES ('Avenida Santa Fe', '345');
INSERT INTO Direccion (Calle, Altura) VALUES ('Calle San Martín', '222');
INSERT INTO Direccion (Calle, Altura) VALUES ('Avenida Corrientes', '100');
INSERT INTO Direccion (Calle, Altura) VALUES ('Calle Florida', '555');
INSERT INTO Direccion (Calle, Altura) VALUES ('Calle Moreno', '6789');
INSERT INTO Direccion (Calle, Altura) VALUES ('Avenida de Mayo', '321');

INSERT INTO Rol (Rol) VALUES ('Administrador');
INSERT INTO Rol (Rol) VALUES ('Usuario');
INSERT INTO Rol (Rol) VALUES ('Organizador');

INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (1, 'contrasena123', 'García', 'Juan', '12345678', 'juan@example.com', '1990-01-01', 1);
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (2, 'password456', 'Pérez', 'Ana', '87654321', 'ana@example.com', '1992-02-02', 1);
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (3, 'password891', 'Rodriguez', 'Ana', '87333321', 'anarodriguez@example.com', '1992-06-02', 1);

INSERT INTO Disciplina (Disciplina) VALUES ('Natación');
INSERT INTO Disciplina (Disciplina) VALUES ('Ciclismo');
INSERT INTO Disciplina (Disciplina) VALUES ('Atletismo');

INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (1, 1); 
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (2, 2);  
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (3, 3);  
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (4, 4);  
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (5, 5); 

INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles) 
VALUES ('Circuito MDQ Aguas abiertas', '2024-12-01', 1, 100.00, 'D', 16 , 30, 50);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles) 
VALUES ('Maratón de la Ciudad', '2024-11-15', 1, 50.00, 'D', 18 , 30, 200);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles) 
VALUES ('Ciclismo Juvenil', '2024-12-10', 1, 75.00, 'D', 14 , 30, 100);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles) 
VALUES ('Competencia de Natación', '2024-11-20', 1, 30.00, 'D', 10 , 30, 150);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles) 
VALUES ('Campeonato de Ciclismo', '2024-10-30', 1, 40.00, 'D', 15 , 30, 120);

INSERT INTO Imagen_x_Evento (IDEvento, ImgUrl) VALUES (1,'https://saltograndeextra.com/wp-content/uploads/2024/02/1-2.jpg');
INSERT INTO Imagen_x_Evento (IDEvento, ImgUrl) VALUES (2,'https://i0.wp.com/diariolujan.ar/wp-content/uploads/2021/12/POTRERILLOS-2019-largada-7.jpg?ssl=1');
INSERT INTO Imagen_x_Evento (IDEvento, ImgUrl) VALUES (3,'https://superiorcads.edu.ar/imgd/certificacion-running-maraton-fondo-medio-fondo-trail-2-019334.jpg');
INSERT INTO Imagen_x_Evento (IDEvento, ImgUrl) VALUES (4,'https://upload.wikimedia.org/wikipedia/commons/0/05/Military_cyclists_in_pace_line.jpg');
INSERT INTO Imagen_x_Evento (IDEvento, ImgUrl) VALUES (5,'https://cdn.shopify.com/s/files/1/0512/7641/5146/files/nadadores-competencia-lanzandose_1.jpg?v=1717258328');

INSERT INTO Imagen_x_Usuario(IDUsuario, ImgUrl)VALUES(2, 'https://imgs.search.brave.com/yrfIQwgHOwPGYdSdJGOk8vkuc49ghPKsdasBwCYk8aw/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9wbHVz/LnVuc3BsYXNoLmNv/bS9wcmVtaXVtX3Bo/b3RvLTE2NjQyOTk5/NzE1ODItMTVjYTVk/MTUxZjQ2P2ZtPWpw/ZyZxPTYwJnc9MzAw/MCZpeGxpYj1yYi00/LjAuMyZpeGlkPU0z/d3hNakEzZkRCOE1I/eHpaV0Z5WTJoOE1Y/eDhkMjl0WVc0bE1q/QnlkVzV1YVc1bmZH/VnVmREI4ZkRCOGZI/d3c.jpeg')

INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina, Distancia) VALUES (1, 1, 10); -- Circuito MDQ Aguas abiertas - Natación
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina, Distancia) VALUES (2, 3, 10); -- Maratón de la Ciudad - Natación
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina, Distancia) VALUES (3, 2, 10); -- Ciclismo Juvenil - Basketball
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina, Distancia) VALUES (4, 1, 10); -- Competencia de Natación - Natación
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina, Distancia) VALUES (5, 2, 10); -- Campeonato de Ciclismo - Ciclismo
GO

CREATE PROCEDURE SP_OBTENER_PROVINCIAS 
AS
SELECT * FROM Provincia

GO
CREATE PROCEDURE SP_OBTENER_CIUDADES
AS
SELECT 
    IDCiudad, 
    IDProvincia, 
    C.Nombre AS Ciudad, 
    P.Nombre AS Provincia 
FROM Ciudad AS C 
INNER JOIN Provincia AS P 
ON IDProvincia = P.ID

GO

CREATE PROCEDURE SP_INSERTAR_EVENTO(
    @CALLE VARCHAR(50),
    @ALTURA VARCHAR(10),
    @ID_CIUDAD BIGINT,
    @NOMBRE VARCHAR(100),
    @FECHA DATE,
    @COSTO_INSCRIPCION MONEY,
    @ESTADO CHAR(1),
    @EDAD_MINIMA TINYINT,
    @EDAD_MAXIMA TINYINT,
    @CUPOS_DISPONIBLES INT)
AS BEGIN
BEGIN TRY
    BEGIN TRANSACTION

    DECLARE @ID_DIRECCION SMALLINT
    DECLARE @ID_UBICACION BIGINT
    INSERT INTO Direccion(Calle, Altura)VALUES(@CALLE, @ALTURA)
    IF(@@ROWCOUNT > 0)
        SET @ID_DIRECCION = @@IDENTITY
    
    IF @ID_DIRECCION IS NULL
    BEGIN
        RAISERROR('NO HAY REGISTRO DE UNA NUEVA DIRECCION', 16,1)
        ROLLBACK TRANSACTION
        RETURN
    END

    INSERT INTO Ubicacion(IDCiudad, IDDireccion)VALUES(@ID_CIUDAD, @ID_DIRECCION)
       IF(@@ROWCOUNT > 0)
        SET @ID_UBICACION = @@IDENTITY
    
     IF @ID_UBICACION IS NULL
     BEGIN
        RAISERROR('NO HAY REGISTRO DE UNA NUEVA UBICACION', 16,1)
        ROLLBACK TRANSACTION
        RETURN
    END

    INSERT INTO EVENTO(Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, EdadMaxima, CuposDisponibles)
    VALUES(@NOMBRE, @FECHA, @ID_UBICACION, @COSTO_INSCRIPCION, @ESTADO, @EDAD_MINIMA, @EDAD_MAXIMA, @CUPOS_DISPONIBLES)
    SELECT SCOPE_IDENTITY()
    IF(@@TRANCOUNT > 0)
        COMMIT TRANSACTION
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE()
    IF(@@TRANCOUNT > 0)
    BEGIN
        COMMIT TRANSACTION
    END
    ROLLBACK TRANSACTION
END CATCH
END

GO

CREATE PROCEDURE SP_OBTENER_REGISTRO_USUARIO(
    @EMAIL VARCHAR(50), 
    @PASSWORD VARCHAR(256)
)
AS BEGIN
    BEGIN TRY
        SELECT 
            U.IDUsuario, 
            U.IDRol, 
            U.Contrasena, 
            U.Apellido, 
            U.Nombre, 
            U.DNI, 
            U.CorreoElectronico, 
            U.FechaNacimiento, 
            U.Estado,
            IxU.IDImagen,
            IxU.ImgURL
            FROM Usuario AS U
            LEFT JOIN Imagen_x_Usuario AS IxU
            ON U.IDUsuario = IxU.IDUsuario
            WHERE U.CorreoElectronico = @EMAIL AND U.Contrasena = @PASSWORD
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END
GO

Create TRIGGER tr_InscripcionEvento ON Usuario_x_Evento
AFTER INSERT
AS BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE Evento SET CuposDisponibles = CuposDisponibles - 1 WHERE IDEvento = (Select IDEvento from inserted)
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        ROLLBACK TRANSACTION
    END CATCH
END

GO

CREATE OR ALTER PROCEDURE OBTENER_EVENTOS_USUARIO(@IDUSUARIO BIGINT)
AS BEGIN
    BEGIN TRY
        IF @IDUSUARIO IS NULL
        RETURN
        
    SELECT 
        E.IDEvento,
        E.Nombre,
        E.FechaEvento,
        E.CostoInscripcion,
        E.CuposDisponibles,
        E.EdadMinima,
        E.EdadMaxima,
        E.Estado,
        C.Nombre AS NombreCiudad,
        P.ID AS IDProvincia,
        P.Nombre AS NombreProvincia,
        D.Calle, 
        D.Altura,
        IxE.ImgUrl
    FROM 
        Evento AS E 
    INNER JOIN 
        Usuario_x_Evento AS UxE 
        ON E.IDEvento = UxE.IDEvento
    INNER JOIN 
        Ubicacion AS U
        ON E.Ubicacion = U.IDUbicacion
    INNER JOIN 
        Ciudad AS C
        ON C.IDCiudad = U.IDCiudad
    INNER JOIN
        Provincia AS P
        ON P.ID = U.IDCiudad
    INNER JOIN 
        Direccion AS D
        ON D.ID = U.IDDireccion
    LEFT JOIN 
        Imagen_x_Evento AS IxE
        ON IxE.IDEvento = E.IDEvento

    WHERE UxE.IDUsuario = @IDUSUARIO

    END TRY

    BEGIN CATCH
        PRINT ERROR_MESSAGE()
    END CATCH
END

GO

CREATE TRIGGER TR_DEVOLVER_CUPO ON Usuario_x_Evento
AFTER DELETE
AS BEGIN
    BEGIN TRY
        DECLARE @IDEVENTO BIGINT
        DECLARE @ESTADO CHAR(1)
        DECLARE @CUPOS INT
        SELECT @IDEVENTO = D.IDEvento, @ESTADO = E.Estado, @CUPOS = E.CuposDisponibles FROM DELETED AS D INNER JOIN Evento AS E ON E.IDEvento = D.IDEvento

        -- FALTA UN ESTADO PARA UN EVENTO SIN CUPOS
        IF @ESTADO = 'C' AND @CUPOS = 0
        BEGIN
            UPDATE Evento SET Estado = 'D' WHERE IDEvento = @IDEVENTO
        END

        UPDATE Evento SET CuposDisponibles += 1 WHERE IDEvento = @IDEVENTO
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        IF(@@TRANCOUNT > 0)
            ROLLBACK TRANSACTION
    END CATCH
END

GO

-- CREATE PROCEDURE SP_LISTA_EVENTO
-- AS BEGIN
--     BEGIN TRY
--         Select 
--             E.IDEvento, 
--             E.Nombre, 
--             E.FechaEvento, 
--             E.CostoInscripcion, 
--             E.EdadMinima, 
--             E.EdadMaxima, 
--             E.CuposDisponibles, 
--             E.Estado,
--             P.ID as IDProvincia, 
--             P.Nombre as Provincia, 
--             C.IDCiudad, 
--             C.Nombre as Ciudad, 
--             Dir.ID, 
--             Dir.Calle, 
--             Dir.Altura,  
--             IxE.IDImagen, 
--             IxE.ImgURL
--         FROM 
--             Evento AS E
--         left join 
--             Imagen_x_Evento AS IxE On IxE.IDEvento = E.IDEvento 
--         Inner join 
--             Ubicacion AS U On U.IDUbicacion = E.Ubicacion 
--         Inner join 
--             Ciudad AS C On C.IDCiudad = u.IDCiudad 
--         Inner join 
--         Provincia AS P On P.ID = C.IDProvincia 
--         Inner join
--             Direccion AS Dir On Dir.ID = U.IDDireccion 
--         Where E.Estado = 'D'
--     END TRY
--     BEGIN CATCH
--         PRINT ERROR_MESSAGE()
--     END CATCH
-- END

GO

CREATE OR ALTER PROCEDURE SP_LISTA_EVENTO(@IDEVENTO BIGINT = NULL)
AS BEGIN
    BEGIN TRY
        Select 
            E.IDEvento, 
            E.Nombre, 
            E.FechaEvento, 
            E.CostoInscripcion, 
            E.EdadMinima, 
            E.EdadMaxima, 
            E.CuposDisponibles, 
            E.Estado,
            P.ID as IDProvincia, 
            P.Nombre as Provincia, 
            C.IDCiudad, 
            C.Nombre as Ciudad, 
            Dir.ID, 
            Dir.Calle, 
            Dir.Altura,  
            IxE.IDImagen, 
            IxE.ImgURL
        FROM 
            Evento AS E
        left join 
            Imagen_x_Evento AS IxE On IxE.IDEvento = E.IDEvento 
        Inner join 
            Ubicacion AS U On U.IDUbicacion = E.Ubicacion 
        Inner join 
            Ciudad AS C On C.IDCiudad = u.IDCiudad 
        Inner join 
        Provincia AS P On P.ID = C.IDProvincia 
        Inner join
            Direccion AS Dir On Dir.ID = U.IDDireccion 
        Where E.Estado = 'D' AND (@IDEVENTO IS NULL OR E.IDEvento = @IDEVENTO)
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
    END CATCH
END

GO

CREATE PROCEDURE SP_DISCPLINAS_X_EVENTO(@IDEVENTO BIGINT)
AS BEGIN
    BEGIN TRY
        SELECT 
            DxE.IDDisciplina, 
            D.Disciplina, 
            DxE.Distancia 
        FROM Disciplina_x_Evento AS DxE
        INNER JOIN Disciplina AS D
        ON D.IDDisciplina = DxE.IDDisciplina
        WHERE IDEvento = @IDEVENTO 
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
    END CATCH
END



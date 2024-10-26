Create Database BAEventos

Use BAEventos

Create Table Pais(
IDPais bigint not null primary key identity(1,1),
Nombre varchar(50) not null
)

Create Table Ciudad(
IDCiudad bigint not null primary key identity(1,1),
IDPais bigint not null foreign key references Pais(IDPais),
Nombre varchar(50) not null,
)

Create Table Direccion(
    ID smallint not null primary key identity(1,1),
    Calle varchar(50) not null,
    Altura varchar(10) not null,
    CodigoPostal varchar(10) not null
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

Create Table Imagen(
    ID smallint not null primary key identity(1,1),
    ImgURL nvarchar(999) not null
)

Create Table Usuario(
IDUsuario bigint not null primary key identity(1,1),
IDRol smallint not null foreign key references Rol(IDRol),
Contrasena varchar(50) not null,
Apellido varchar(50) not null,
Nombre varchar(50) not null,
DNI varchar(10) not null,
CorreoElectronico varchar(50) not null,
FechaNacimiento date not null,
Estado bit not null,
)

Create Table Imagen_x_Usuario(
    IDImagen smallint not null foreign key references Imagen(ID),
    IDUsuario bigint not null foreign key references Usuario(IDUsuario),
    primary key (IDImagen, IDUsuario)
)

Create Table Disciplina(
IDDisciplina bigint not null primary key identity(1,1),
Disciplina varchar(50) not null
)

Create Table Evento(
IDEvento bigint not null primary key identity(1,1),
Nombre varchar(100) not null,
FechaEvento date not null,
Ubicacion bigint not null foreign key references Ciudad(IDCiudad),
CostoInscripcion money null,
Estado char(1) not null check (Estado = 'D' or Estado = 'F' or Estado = 'C'),
EdadMinima tinyint null,
CuposDisponibles int not null,
)

Create Table Imagen_x_Evento(
    IDImagen smallint not null foreign key references Imagen(ID),
    IDEvento bigint not null foreign key references Evento(IDEvento)
    primary key (IDImagen, IDEvento)
)

Create Table Disciplina_x_Evento(
IDEvento bigint not null foreign key references Evento(IDEvento),
IDDisciplina bigint not null foreign key references Disciplina(IDDisciplina)
)

Create Table Resultado_x_Evento(
IDEvento bigint not null foreign key references Evento(IDEvento),
IDDisciplina bigint not null foreign key references Disciplina(IDDisciplina),
IDUsuario bigint not null foreign key references Usuario(IDUsuario),
Puesto tinyint null,
Tiempo time null
)

-- Inserts para la tabla Pais
INSERT INTO Pais (Nombre) VALUES ('Argentina');
INSERT INTO Pais (Nombre) VALUES ('Chile');
INSERT INTO Pais (Nombre) VALUES ('Uruguay');

-- Inserts para la tabla Ciudad
INSERT INTO Ciudad (IDPais, Nombre) VALUES (1, 'Buenos Aires');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (1, 'Córdoba');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (2, 'Santiago');

-- Inserts para la tabla Direccion
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Av. Libertador', '1000', 'C1000');
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Calle Florida', '200', 'C1000');

-- Inserts para la tabla Ubicacion
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (1, 1);
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (2, 2);

-- Inserts para la tabla Rol
INSERT INTO Rol (Rol) VALUES ('Administrador');
INSERT INTO Rol (Rol) VALUES ('Usuario');

-- Inserts para la tabla Imagen
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/image1.jpg');
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/image2.jpg');

-- Inserts para la tabla Usuario
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (1, 'password1', 'García', 'Juan', '12345678', 'juan@example.com', '1990-01-01', 1);
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (2, 'password2', 'Pérez', 'Ana', '87654321', 'ana@example.com', '1992-02-02', 1);

-- Inserts para la tabla Imagen_x_Usuario
INSERT INTO Imagen_x_Usuario (IDImagen, IDUsuario) VALUES (1, 1);
INSERT INTO Imagen_x_Usuario (IDImagen, IDUsuario) VALUES (2, 2);

-- Inserts para la tabla Disciplina
INSERT INTO Disciplina (Disciplina) VALUES ('Fútbol');
INSERT INTO Disciplina (Disciplina) VALUES ('Baloncesto');

-- Inserts para la tabla Evento
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Torneo de Fútbol', '2024-12-01', 1, 50.00, 'D', 10, 100);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Copa de Baloncesto', '2024-12-15', 2, 30.00, 'D', 12, 50);

-- Inserts para la tabla Imagen_x_Evento
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (1, 1);
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (2, 2);

-- Inserts para la tabla Disciplina_x_Evento
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (1, 1);
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (2, 2);

-- Inserts para la tabla Resultado_x_Evento
INSERT INTO Resultado_x_Evento (IDEvento, IDDisciplina, IDUsuario, Puesto, Tiempo) 
VALUES (1, 1, 1, 1, '00:30:00');
INSERT INTO Resultado_x_Evento (IDEvento, IDDisciplina, IDUsuario, Puesto, Tiempo) 
VALUES (2, 2, 2, 2, '00:25:00');

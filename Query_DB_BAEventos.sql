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

Create Table Imagen_x_Evento(
    IDImagen smallint not null foreign key references Imagen(ID),
    IDEvento bigint not null foreign key references Evento(IDEvento)
    primary key (IDImagen, IDEvento)
)

Create Table Imagen_x_Usuario(
    IDImagen smallint not null foreign key references Imagen(ID),
    IDUsuario bigint not null foreign key references Usuario(IDUsuario),
    primary key (IDImagen, IDUsuario)
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

--Tabla: Pais
INSERT INTO Pais (Nombre) VALUES ('Argentina');
INSERT INTO Pais (Nombre) VALUES ('Brasil');
INSERT INTO Pais (Nombre) VALUES ('México');
--Tabla: Ciudad
INSERT INTO Ciudad (IDPais, Nombre) VALUES (1, 'Buenos Aires');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (2, 'Río de Janeiro');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (3, 'Ciudad de México');
--Tabla: Rol
INSERT INTO Rol (Rol) VALUES ('Administrador');
INSERT INTO Rol (Rol) VALUES ('Organizador');
INSERT INTO Rol (Rol) VALUES ('Usuario');
--Tabla: Usuario
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, IDCiudad, Estado)
VALUES (1, 'password123', 'Pérez', 'Juan', '12345678', 'juan.perez@mail.com', '1980-05-14', 1, 1);

INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, IDCiudad, Estado)
VALUES (2, 'mypassword', 'Rodriguez', 'Ana', '87654321', 'ana.rodriguez@mail.com', '1992-09-23', 2, 1);

INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, IDCiudad, Estado)
VALUES (3, 'securepass', 'Gomez', 'Carlos', '11223344', 'carlos.gomez@mail.com', '1985-11-02', 3, 0);
--Tabla: Disciplina
INSERT INTO Disciplina (Disciplina) VALUES ('Ciclismo');
INSERT INTO Disciplina (Disciplina) VALUES ('Natación');
INSERT INTO Disciplina (Disciplina) VALUES ('Atletismo');
--Tabla: Evento
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, RangoEdad, CuposDisponibles)
VALUES ('Maratón Buenos Aires', '2024-12-15', 1, 500.00, 'D', 18, 100);

INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, RangoEdad, CuposDisponibles)
VALUES ('Copa Brasil Natación', '2024-11-10', 2, 300.00, 'F', 16, 50);

INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, RangoEdad, CuposDisponibles)
VALUES ('Atletismo CDMX', '2024-10-20', 3, 150.00, 'C', 15, 80);
--Tabla: Disciplina_x_Evento
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (1, 3); -- Ciclismo y Atletismo
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (2, 2); -- Natación en la Copa Brasil
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (3, 3); -- Atletismo CDMX
... (9 líneas restantes)
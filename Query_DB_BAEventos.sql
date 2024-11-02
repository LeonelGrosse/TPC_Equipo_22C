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
Ubicacion bigint not null foreign key references Ubicacion(IDUbicacion),
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

-- Inserciones para la tabla Pais
INSERT INTO Pais (Nombre) VALUES ('Argentina');
INSERT INTO Pais (Nombre) VALUES ('Chile');
INSERT INTO Pais (Nombre) VALUES ('Brasil');
INSERT INTO Pais (Nombre) VALUES ('Uruguay');
INSERT INTO Pais (Nombre) VALUES ('Paraguay');

-- Inserciones para la tabla Ciudad
INSERT INTO Ciudad (IDPais, Nombre) VALUES (1, 'Buenos Aires');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (1, 'Córdoba');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (2, 'Santiago');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (3, 'São Paulo');
INSERT INTO Ciudad (IDPais, Nombre) VALUES (4, 'Montevideo');

-- Inserciones para la tabla Direccion
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Av. Libertador', '1000', 'C1000');
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Calle 7', '200', 'C2000');
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Av. Brasil', '300', 'C3000');
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Calle Principal', '400', 'C4000');
INSERT INTO Direccion (Calle, Altura, CodigoPostal) VALUES ('Calle Uruguay', '500', 'C5000');

-- Inserciones para la tabla Rol
INSERT INTO Rol (Rol) VALUES ('Administrador');
INSERT INTO Rol (Rol) VALUES ('Usuario');

-- Inserciones para la tabla Imagen
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/imagen1.jpg');
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/imagen2.jpg');
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/imagen3.jpg');
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/imagen4.jpg');
INSERT INTO Imagen (ImgURL) VALUES ('http://example.com/imagen5.jpg');

-- Inserciones para la tabla Usuario
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (1, 'contrasena123', 'García', 'Juan', '12345678', 'juan@example.com', '1990-01-01', 1);
INSERT INTO Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) 
VALUES (2, 'password456', 'Pérez', 'Ana', '87654321', 'ana@example.com', '1992-02-02', 1);

-- Inserciones para la tabla Disciplina
INSERT INTO Disciplina (Disciplina) VALUES ('Fútbol');
INSERT INTO Disciplina (Disciplina) VALUES ('Basketball');
INSERT INTO Disciplina (Disciplina) VALUES ('Natación');
INSERT INTO Disciplina (Disciplina) VALUES ('Ciclismo');
INSERT INTO Disciplina (Disciplina) VALUES ('Atletismo');

-- Inserciones para la tabla Ubicacion
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (1, 1); -- Buenos Aires, Av. Libertador
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (2, 2); -- Córdoba, Calle 7
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (3, 3); -- Santiago, Av. Brasil
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (4, 4); -- São Paulo, Calle Principal
INSERT INTO Ubicacion (IDCiudad, IDDireccion) VALUES (5, 5); -- Montevideo, Calle Uruguay

-- Inserciones para la tabla Evento
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Torneo de Fútbol', '2024-12-01', 1, 100.00, 'D', 16, 50);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Maratón de la Ciudad', '2024-11-15', 1, 50.00, 'D', 18, 200);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Torneo de Basketball Juvenil', '2024-12-10', 2, 75.00, 'D', 14, 100);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Competencia de Natación', '2024-11-20', 1, 30.00, 'D', 10, 150);
INSERT INTO Evento (Nombre, FechaEvento, Ubicacion, CostoInscripcion, Estado, EdadMinima, CuposDisponibles) 
VALUES ('Campeonato de Ciclismo', '2024-10-30', 3, 40.00, 'D', 15, 120);

-- Inserciones para la tabla Imagen_x_Evento
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (1, 1);
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (2, 1);
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (3, 2);
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (4, 3);
INSERT INTO Imagen_x_Evento (IDImagen, IDEvento) VALUES (5, 4);

-- Inserciones para la tabla Disciplina_x_Evento
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (1, 1); -- Torneo de Fútbol - Fútbol
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (2, 3); -- Maratón de la Ciudad - Natación
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (3, 2); -- Torneo de Basketball Juvenil - Basketball
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (4, 3); -- Competencia de Natación - Natación
INSERT INTO Disciplina_x_Evento (IDEvento, IDDisciplina) VALUES (5, 4); -- Campeonato de Ciclismo - Ciclismo


Select e.IDEvento, e.Nombre, e.FechaEvento, e.CostoInscripcion, e.EdadMinima, e.CuposDisponibles, e.Estado, p.IDPais, p.Nombre as Pais, c.IDCiudad, c.Nombre as Ciudad, dire.ID, dire.Calle, dire.Altura, dire.CodigoPostal, d.IDDisciplina, d.Disciplina, i.ID, i.ImgURL from Evento e
Inner join Disciplina_x_Evento de On de.IDEvento = e.IDEvento
Inner join Disciplina d On d.IDDisciplina = de.IDDisciplina
Inner join Imagen_x_Evento ie On ie.IDEvento = e.IDEvento
Inner join Imagen i On i.ID = ie.IDImagen
Inner join Ubicacion u On u.IDUbicacion = e.Ubicacion
Inner join Ciudad c On c.IDCiudad = u.IDCiudad
Inner join Pais p On p.IDPais = c.IDPais
Inner join Direccion dire On dire.ID = u.IDDireccion
Where e.Estado = 'D'
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

Create Table Rol(
	IDRol smallint not null primary key identity(1,1),
	Rol varchar(50) not null
)

Create Table Usuario(
	IDUsuario bigint not null primary key identity(1,1),
	IDRol smallint not null foreign key references Rol(IDRol),
	Contrase�a varchar(50) not null,
	Apellido varchar(50) not null,
	Nombre varchar(50) not null,
	DNI varchar(10) not null,
	CorreoElectronico varchar(50) not null,
	FechaNacimiento date not null,
	IDCiudad bigint not null foreign key references Ciudad(IDCiudad),
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
	RangoEdad tinyint null,
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
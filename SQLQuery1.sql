create table mascotas (
	id_mascota int primary key identity(1,1),
	nombre varchar(30),
	raza varchar (30),
	edad int,
	especie varchar(30),
	sexo varchar (30),
	fechaAlta datetime,
	nombreRazaEspecie varchar(60)
)

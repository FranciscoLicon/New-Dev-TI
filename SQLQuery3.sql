exec spObtenerMascotas
create proc spAgregarMascota(
	@nombre varchar(30),
	@raza varchar(30),
	@edad int,
	@especie varchar(30),
	@sexo varchar(30),
	@fechaAlta datetime,
	@nombreRazaEspecie varchar(100)
)
as
begin
	insert into mascotas values (@nombre,@raza,@edad,@especie,@sexo,@fechaAlta,@nombreRazaEspecie)
end

create proc spEditarMascota(
	@nombre varchar(30),
	@raza varchar(30),
	@edad int,
	@especie varchar(30),
	@sexo varchar(30),
	@nombreRazaEspecie varchar(100),
	@id int
)
as
begin
	update mascotas set nombre=@nombre,raza=@raza,edad=@edad,especie=@especie,sexo=@sexo,nombreRazaEspecie=@nombreRazaEspecie where id_mascota=@id
end

create proc spBorrarMAscota(
	@id int
)
as
begin
	delete from mascotas where id_mascota=@id
end

create proc spObtenerMascota(
	@id int
)
as
begin
	select * from mascotas where id_mascota = @id
end

create proc spObtenerMascotaPorNombre(
	@nombreMascota varchar(30)
)
as
begin
	select * from mascotas where nombre like '%'+@nombreMascota+'%'
end

create proc spValidarNombreRepetido(
	@nombre varchar(30),
	@raza varchar(30),
	@id int
)
as
begin
	if @id != 0
		select * from mascotas where nombre=@nombre and raza=@raza and id_mascota!=@id
	else
		select * from mascotas where nombre=@nombre and raza=@raza
end
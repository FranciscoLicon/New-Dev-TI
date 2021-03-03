create proc spObtenerMascotas 
as
begin
	select * from mascotas order by nombre
end
-- Crea tabla de Alumno
create table public.alumno(
	dni integer primary key,
	nombre varchar (30) not null,
	apellido varchar (30) not null,
	mac varchar (20) null
);

-- Crea table de Registro
create table public.registro_asistencia(
	registro_id integer primary key,
	dni integer not null REFERENCES public.alumno(dni),
	fecha timestamp
);

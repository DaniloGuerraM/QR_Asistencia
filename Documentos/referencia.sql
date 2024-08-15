
create table public.Alumno(
	dni integer primary key,
	nombre varchar (30) not null,
	apellido varchar (30) not null,
	mac varchar (20) null
);

create table public.registro(
	registro_id integer primary key,
	dni integer not null REFERENCES public.Alumno(dni),}
	fecha varchar (20),
	hora varchar (20)
);

-- Database: QR_Asistencias

-- DROP DATABASE IF EXISTS "QR_Asistencias";

CREATE DATABASE "QR_Asistencias"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Argentina.1252'
    LC_CTYPE = 'Spanish_Argentina.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- Crea tabla de Alumno
create table public.alumno(
	dni integer primary key,
	nombre varchar (30) not null,
	apellido varchar (30) not null,
	mac varchar (20) UNIQUE null
);
-- Crea table de Registro
create table public.registro_asistencia(
	registro_id integer primary key,
	dni integer not null REFERENCES public.alumno(dni),
	fecha bigint
);

-- la fecha  esta en bigint y no en timestamp, porque desde el web server le pasamos un long, que el timestamp no acepta


--la siginte linea es para que la mac de cada alumno sea unico y que quede de esta manera
--	mac varchar (20) UNIQUE null
--yo lo tenia haci
--	mac varchar (20) null
ALTER TABLE public.alumno ADD CONSTRAINT unique_mac UNIQUE (mac);

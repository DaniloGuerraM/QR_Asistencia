using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QR_Asistencia.Libreria.Modelo;

namespace QR_Asistencia.Libreria.Repocitorio;

public class QrContexto : DbContext
{
    private static QrContexto intanciaContexto;
    private readonly string _cadenaConexion;
    //////////////////////////////// Contructor ////////////////////////////////
    private QrContexto (string cadenaConexion)
    {
        _cadenaConexion = cadenaConexion;
    }

    //////////////////////////////// tablas ////////////////////////////////
    public DbSet<Alumno> alumno {get; set;}
    public DbSet<Registro_Asistencia> registro_Asistencia {get; set;}

    //////////////////////////////// configuracion ////////////////////////////////
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_cadenaConexion);
        base.OnConfiguring(optionsBuilder);
    }
    
    //////////////////////////////// crea la instancia ////////////////////////////////
    public static QrContexto Crearinstancia()
    {
        if (intanciaContexto == null)
        {
            // la contraseña regites es para la maquina de escritorio del instituto
            // la contraseña Nachoytom es para mi maquina
            intanciaContexto = new QrContexto("host=localhost; port=5432; Database=QR_Asistencias; user id=postgres; sslmode=prefer;Password=redites"); 
        }
        return intanciaContexto;
    }
    
}

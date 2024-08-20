using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QR_Asistencia.Libreria.Modelo;

namespace QR_Asistencia.Libreria.Repocitorio;

public class QrContexto : DbContext
{
    private static QrContexto intanciaContexto;
    private readonly string _cadenaConexion;
    private QrContexto (string cadenaConexion)
    {
        _cadenaConexion = cadenaConexion;
    }

    public DbSet<Alumno> alumno {get; set;}
    public DbSet<Registro_Asistencia> registro_Asistencia {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_cadenaConexion);
        base.OnConfiguring(optionsBuilder);
    }

    
}

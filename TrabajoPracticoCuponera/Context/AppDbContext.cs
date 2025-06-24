using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<RolModel> Roles { get; set; }
   
        public DbSet<CuponModel> Cupones { get; set; }

        public DbSet<CuponDetalleModel> CuponesDetalle { get; set; }

        public DbSet<TipoCuponModel> TipoCupones { get; set; }

        public DbSet<ArticuloModel> Articulos { get; set; }

        public DbSet<CuponHistorialModel> CuponesHistorial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CuponDetalleModel>()
        .HasKey(cd => new { cd.NroCupon, cd.id_Articulo });


            base.OnModelCreating(modelBuilder);
        }


    }


}


namespace ODS.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=ods_system_bdd")
        {
        }

        public virtual DbSet<ods_estado> ods_estado { get; set; }
        public virtual DbSet<ods_estado_tarea> ods_estado_tarea { get; set; }
        public virtual DbSet<ods_indicador> ods_indicador { get; set; }
        public virtual DbSet<ods_interesado> ods_interesado { get; set; }
        public virtual DbSet<ods_meta> ods_meta { get; set; }
        public virtual DbSet<ods_meta_municipio> ods_meta_municipio { get; set; }
        public virtual DbSet<ods_municipio> ods_municipio { get; set; }
        public virtual DbSet<ods_objetivo> ods_objetivo { get; set; }
        public virtual DbSet<ods_objetivo_municipio> ods_objetivo_municipio { get; set; }
        public virtual DbSet<ods_pais> ods_pais { get; set; }
        public virtual DbSet<ods_seguimiento_tarea> ods_seguimiento_tarea { get; set; }
        public virtual DbSet<ods_tablero_indicador> ods_tablero_indicador { get; set; }
        public virtual DbSet<ods_tactica> ods_tactica { get; set; }
        public virtual DbSet<ods_tarea> ods_tarea { get; set; }
        public virtual DbSet<ods_vinculo_meta_municipio> ods_vinculo_meta_municipio { get; set; }

        public virtual DbSet<ods_meta_vw> ods_meta_vw { get; set; }
        public virtual DbSet<ods_tablero_indicador_vw> ods_tablero_indicador_vw { get; set; }
        public virtual DbSet<ods_vinculo_meta_municipio_vw> ods_vinculo_meta_municipio_vw { get; set; }


        public virtual DbSet<ods_tablero_indicador_ods_vw> ods_tablero_indicador_ods_vw { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ods_estado>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<ods_estado>()
                .HasMany(e => e.ods_municipio)
                .WithRequired(e => e.ods_estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_estado_tarea>()
                .Property(e => e.EstadoTarea)
                .IsUnicode(false);

            modelBuilder.Entity<ods_estado_tarea>()
                .HasMany(e => e.ods_tarea)
                .WithRequired(e => e.ods_estado_tarea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_indicador>()
                .Property(e => e.Indicador)
                .IsUnicode(false);

            modelBuilder.Entity<ods_indicador>()
                .HasMany(e => e.ods_meta_municipio)
                .WithRequired(e => e.ods_indicador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_indicador>()
                .HasMany(e => e.ods_tablero_indicador)
                .WithRequired(e => e.ods_indicador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.Interesado)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.Contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.CorreoRecuperacion)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .Property(e => e.IPUltimaSesion)
                .IsUnicode(false);

            modelBuilder.Entity<ods_interesado>()
                .HasMany(e => e.ods_seguimiento_tarea)
                .WithRequired(e => e.ods_interesado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_interesado>()
                .HasMany(e => e.ods_tarea)
                .WithRequired(e => e.ods_interesado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_meta>()
                .Property(e => e.Numeral)
                .IsUnicode(false);

            modelBuilder.Entity<ods_meta>()
                .Property(e => e.Meta)
                .IsUnicode(false);

            modelBuilder.Entity<ods_meta>()
                .HasMany(e => e.ods_vinculo_meta_municipio)
                .WithRequired(e => e.ods_meta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_meta_municipio>()
                .Property(e => e.MetaMuncipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_meta_municipio>()
                .Property(e => e.DebeCumplirse)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_meta_municipio>()
                .Property(e => e.Avance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_meta_municipio>()
                .HasMany(e => e.ods_vinculo_meta_municipio)
                .WithRequired(e => e.ods_meta_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_meta_municipio>()
                .HasMany(e => e.ods_tarea)
                .WithRequired(e => e.ods_meta_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_municipio>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_municipio>()
                .HasMany(e => e.ods_indicador)
                .WithRequired(e => e.ods_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_municipio>()
                .HasMany(e => e.ods_interesado)
                .WithRequired(e => e.ods_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_municipio>()
                .HasMany(e => e.ods_objetivo_municipio)
                .WithRequired(e => e.ods_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_municipio>()
                .HasMany(e => e.ods_tactica)
                .WithRequired(e => e.ods_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_objetivo>()
                .Property(e => e.Objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<ods_objetivo>()
                .HasMany(e => e.ods_meta)
                .WithRequired(e => e.ods_objetivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_objetivo_municipio>()
                .Property(e => e.Numeral)
                .IsUnicode(false);

            modelBuilder.Entity<ods_objetivo_municipio>()
                .Property(e => e.ObjetivoMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_objetivo_municipio>()
                .HasMany(e => e.ods_meta_municipio)
                .WithRequired(e => e.ods_objetivo_municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_pais>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<ods_pais>()
                .HasMany(e => e.ods_estado)
                .WithRequired(e => e.ods_pais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_seguimiento_tarea>()
                .Property(e => e.Avance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_seguimiento_tarea>()
                .Property(e => e.Comentarios)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador>()
                .Property(e => e.ValorIndicador)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_tablero_indicador>()
                .Property(e => e.ValorAlcanzado)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_tactica>()
                .Property(e => e.Tactica)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tactica>()
                .HasMany(e => e.ods_tarea)
                .WithRequired(e => e.ods_tactica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_tarea>()
                .Property(e => e.Tarea)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tarea>()
                .Property(e => e.Avance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_tarea>()
                .HasMany(e => e.ods_seguimiento_tarea)
                .WithRequired(e => e.ods_tarea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ods_meta_vw>()
                  .Property(e => e.Objetivo)
                  .IsUnicode(false);

            modelBuilder.Entity<ods_meta_vw>()
                .Property(e => e.Numeral)
                .IsUnicode(false);

            modelBuilder.Entity<ods_meta_vw>()
                .Property(e => e.Meta)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador_vw>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador_vw>()
                .Property(e => e.Indicador)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador_vw>()
                .Property(e => e.ValorIndicador)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_tablero_indicador_vw>()
                .Property(e => e.ValorAlcanzado)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.Objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.Numeral)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.Meta)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.MetaMuncipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.DebeCumplirse)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.AVANCE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.NumeralObjetivo)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.ObjetivoMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.Indicador)
                .IsUnicode(false);

            modelBuilder.Entity<ods_vinculo_meta_municipio_vw>()
                .Property(e => e.Municipio)
                .IsUnicode(false);


            modelBuilder.Entity<ods_tablero_indicador_ods_vw>()
                .Property(e => e.Municipio)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador_ods_vw>()
                .Property(e => e.Objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<ods_tablero_indicador_ods_vw>()
                .Property(e => e.Avance)
                .HasPrecision(38, 6);

        }
    }
}

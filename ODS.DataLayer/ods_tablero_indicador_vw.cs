namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_tablero_indicador_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTableroIndicador { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdIndicador { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Año")]
        public int Anio { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string Municipio { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Indicador { get; set; }

        [Key]
        [Column(Order = 5)]
        [DisplayName("Valor")]
        public decimal ValorIndicador { get; set; }

        [Key]
        [Column(Order = 6)]
        [DisplayName("Alcanzado")]
        public decimal ValorAlcanzado { get; set; }

        [Key]
        [Column(Order = 7)]
        [DisplayName("Escala Positiva")]
        public bool EscalaPositiva { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ODS Objetivos")]
        public int ods_objetivos { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ODS Metas")]
        public int ods_metas { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Objetivos Municipio")]
        public int municipio_objetivos { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Metas Municipio")]
        public int municipio_metas { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Tacticas Municipio")]
        public int municipio_tacticas { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Tareas Municipio")]
        public int municipio_tareas { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool Vigente { get; set; }
    }
}

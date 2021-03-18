namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_vinculo_meta_municipio_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdObjetivo { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Objetivo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Numeral { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Meta { get; set; }

        [Key]
        [Column(Order = 4)]
        [DisplayName("Meta Municipio")]
        public string MetaMuncipio { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Año")]
        public int Anio { get; set; }

        [Key]
        [Column(Order = 6)]
        [DisplayName("Debe Cumplirse")]
        public decimal DebeCumplirse { get; set; }

        [DisplayName("Avance")]
        public decimal? AVANCE { get; set; }

        [Key]
        [Column(Order = 7)]
        [DisplayName("Escala Positiva")]
        public bool EscalaPositiva { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        [DisplayName("Inicio")]
        public DateTime FechaInicio { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "date")]
        [DisplayName("Termino")]
        public DateTime FechaTermino { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(10)]
        public string NumeralObjetivo { get; set; }

        [Key]
        [Column(Order = 11)]
        [DisplayName("Objetivo Municipio")]
        public string ObjetivoMunicipio { get; set; }

        [Key]
        [Column(Order = 12)]
        [DisplayName("Objetivo Vigente")]
        public bool ObjetivoVigente { get; set; }

        [Key]
        [Column(Order = 13)]
        public string Indicador { get; set; }

        [Key]
        [Column(Order = 14)]
        [DisplayName("Indicador Vigente")]
        public bool IndicadorVigente { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(256)]
        public string Municipio { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Id Meta")]
        public int IdMeta { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Id Meta Municipio")]
        public int IdMetaMunicipio { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Id Objetivo Municipio")]
        public int IdObjetivoMunicipio { get; set; }

        [Key]
        [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Indicador")]
        public int IdIndicador { get; set; }

        [Key]
        [Column(Order = 20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }
    }
}

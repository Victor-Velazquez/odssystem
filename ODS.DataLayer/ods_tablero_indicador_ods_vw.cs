namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_tablero_indicador_ods_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMunicipio { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string Municipio { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Año")]
        public int Anio { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdObjetivo { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Objetivo { get; set; }

        [DisplayName("Metas ODS")]
        public int? MetasODS { get; set; }

        [DisplayName("Objetivos Municipio")]
        public int? ObjetivosMunicipio { get; set; }

        [DisplayName("Metas Municipio")]
        public int? MetasMunicipio { get; set; }

        [DisplayName("Indicadores Municipio")]
        public int? IndicadoresMunicipio { get; set; }

        public decimal? Avance { get; set; }
    }
}

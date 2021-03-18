namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_tablero_indicador
    {
        [Key]
        public int IdTableroIndicador { get; set; }

        [DisplayName("Año")]
        public int Anio { get; set; }

        [DisplayName("Valor")]
        public decimal ValorIndicador { get; set; }

        [DisplayName("Alcanzado")]
        public decimal ValorAlcanzado { get; set; }

        [DisplayName("Escala Positiva")]
        public bool EscalaPositiva { get; set; }

        [DisplayName("ODS Objetivos")]
        public int ods_objetivos { get; set; }

        [DisplayName("ODS Metas")]
        public int ods_metas { get; set; }

        [DisplayName("Objetivos Municipio")]
        public int municipio_objetivos { get; set; }

        [DisplayName("Metas Municipio")]
        public int municipio_metas { get; set; }

        [DisplayName("Tacticas Municipio")]
        public int municipio_tacticas { get; set; }

        [DisplayName("Tareas Municipio")]
        public int municipio_tareas { get; set; }

        [DisplayName("Indicador")]
        public int IdIndicador { get; set; }

        public virtual ods_indicador ods_indicador { get; set; }
    }
}

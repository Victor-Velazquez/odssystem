namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_meta_municipio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_meta_municipio()
        {
            ods_vinculo_meta_municipio = new HashSet<ods_vinculo_meta_municipio>();
            ods_tarea = new HashSet<ods_tarea>();
        }

        [Key]
        [DisplayName("Meta Municipio")]
        public int IdMetaMunicipio { get; set; }

        [Required]
        [DisplayName("Meta Municipio")]
        [DataType(DataType.MultilineText)]
        public string MetaMuncipio { get; set; }

        [DisplayName("Año")]
        public int Anio { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Inicio")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Termino")]
        public DateTime FechaTermino { get; set; }

        [DisplayName("Valor")]
        public decimal DebeCumplirse { get; set; }

        [DisplayName("Escala Positiva")]
        public bool EscalaPositiva { get; set; }

        public decimal Avance { get; set; }

        public bool Cumplida { get; set; }

        [DisplayName("Indicador")]
        public int IdIndicador { get; set; }

        [DisplayName("Objetivo Municipio")]
        public int IdObjetivoMunicipio { get; set; }

        public virtual ods_indicador ods_indicador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_vinculo_meta_municipio> ods_vinculo_meta_municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tarea> ods_tarea { get; set; }

        public virtual ods_objetivo_municipio ods_objetivo_municipio { get; set; }
    }
}

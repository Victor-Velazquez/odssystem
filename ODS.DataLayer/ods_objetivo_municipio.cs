namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_objetivo_municipio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_objetivo_municipio()
        {
            ods_meta_municipio = new HashSet<ods_meta_municipio>();
        }

        [Key]
        [DisplayName("Objetivo Municipio")]
        public int IdObjetivoMunicipio { get; set; }

        [Required]
        [StringLength(10)]
        public string Numeral { get; set; }

        [Required]
        [DisplayName("Objetivo Municipio")]
        [DataType(DataType.MultilineText)]
        public string ObjetivoMunicipio { get; set; }

        public bool Vigente { get; set; }

        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_meta_municipio> ods_meta_municipio { get; set; }

        public virtual ods_municipio ods_municipio { get; set; }
    }
}

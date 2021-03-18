namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_meta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_meta()
        {
            ods_vinculo_meta_municipio = new HashSet<ods_vinculo_meta_municipio>();
        }

        [Key]
        [DisplayName("Meta ODS")]
        public int IdMeta { get; set; }

        [Required]
        [StringLength(10)]
        public string Numeral { get; set; }

        [Required]
        public string Meta { get; set; }

        [DisplayName("Objetivo")]
        public int IdObjetivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_vinculo_meta_municipio> ods_vinculo_meta_municipio { get; set; }

        public virtual ods_objetivo ods_objetivo { get; set; }
    }
}

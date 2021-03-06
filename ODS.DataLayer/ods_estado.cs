namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_estado()
        {
            ods_municipio = new HashSet<ods_municipio>();
        }

        [Key]
        public int IdEstado { get; set; }

        [Required]
        [StringLength(256)]
        public string Estado { get; set; }

        public int IdPais { get; set; }

        public virtual ods_pais ods_pais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_municipio> ods_municipio { get; set; }
    }
}

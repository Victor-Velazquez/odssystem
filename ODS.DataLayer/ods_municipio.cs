namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_municipio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_municipio()
        {
            ods_indicador = new HashSet<ods_indicador>();
            ods_interesado = new HashSet<ods_interesado>();
            ods_objetivo_municipio = new HashSet<ods_objetivo_municipio>();
            ods_tactica = new HashSet<ods_tactica>();
        }

        [Key]
        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        [Required]
        [StringLength(256)]
        public string Municipio { get; set; }

        [DisplayName("Estado")]
        public int IdEstado { get; set; }

        public virtual ods_estado ods_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_indicador> ods_indicador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_interesado> ods_interesado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_objetivo_municipio> ods_objetivo_municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tactica> ods_tactica { get; set; }
    }
}

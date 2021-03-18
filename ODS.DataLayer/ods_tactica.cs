namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_tactica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_tactica()
        {
            ods_tarea = new HashSet<ods_tarea>();
        }

        [Key]
        public int IdTactica { get; set; }

        [Required]
        public string Tactica { get; set; }

        public bool Vigente { get; set; }

        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        public virtual ods_municipio ods_municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tarea> ods_tarea { get; set; }
    }
}

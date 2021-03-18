namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_estado_tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_estado_tarea()
        {
            ods_tarea = new HashSet<ods_tarea>();
        }

        [Key]
        [DisplayName("Id Estado Tarea")]
        public int IdEstadoTarea { get; set; }

        [Required]
        [StringLength(256)]
        [DisplayName("Estado Tarea")]
        public string EstadoTarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tarea> ods_tarea { get; set; }
    }
}

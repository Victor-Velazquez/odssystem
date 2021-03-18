namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_tarea()
        {
            ods_seguimiento_tarea = new HashSet<ods_seguimiento_tarea>();
        }

        [Key]
        public int IdTarea { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Tarea { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Inicio")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Termino")]
        public DateTime FechaTermino { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Inicio Real")]
        public DateTime? FechaInicioReal { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Termino Real")]
        public DateTime? FechaTerminoReal { get; set; }

        public decimal Avance { get; set; }

        [DisplayName("Estado")]
        public int IdEstadoTarea { get; set; }

        [DisplayName("Tactica")]
        public int IdTactica { get; set; }

        [DisplayName("Interesado")]
        public int IdInteresado { get; set; }

        [DisplayName("Meta")]
        public int IdMetaMunicipio { get; set; }

        public virtual ods_estado_tarea ods_estado_tarea { get; set; }

        public virtual ods_interesado ods_interesado { get; set; }

        public virtual ods_meta_municipio ods_meta_municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_seguimiento_tarea> ods_seguimiento_tarea { get; set; }

        public virtual ods_tactica ods_tactica { get; set; }
    }
}

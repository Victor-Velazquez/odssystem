namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_seguimiento_tarea
    {
        [Key]
        public int IdSeguimiento { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Fecha Revisión")]
        public DateTime Fecha { get; set; }

        public decimal Avance { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; }

        [DisplayName("Supervisor")]
        public int IdInteresado { get; set; }

        [DisplayName("Tarea")]
        public int IdTarea { get; set; }

        public virtual ods_interesado ods_interesado { get; set; }

        public virtual ods_tarea ods_tarea { get; set; }
    }
}

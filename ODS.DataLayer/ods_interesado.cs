namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_interesado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_interesado()
        {
            ods_seguimiento_tarea = new HashSet<ods_seguimiento_tarea>();
            ods_tarea = new HashSet<ods_tarea>();
        }

        [Key]
        [DisplayName("Interesado")]
        public int IdInteresado { get; set; }

        [Required]
        [StringLength(255)]
        public string Interesado { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(1024)]
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("Correo de recuperación")]
        public string CorreoRecuperacion { get; set; }

        [DisplayName("Ultima Sesión")]
        public DateTime UltimaSesion { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("IP Ultima Sesión")]
        public string IPUltimaSesion { get; set; }

        [DisplayName("Es Administrador")]
        public bool Administrador { get; set; }

        [DisplayName("Es Super Usuario")]
        public bool SuperUsuario { get; set; }

        public bool Bloqueado { get; set; }

        public bool Activo { get; set; }

        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_seguimiento_tarea> ods_seguimiento_tarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tarea> ods_tarea { get; set; }

        public virtual ods_municipio ods_municipio { get; set; }
    }
}

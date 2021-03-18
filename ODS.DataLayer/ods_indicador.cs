namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_indicador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ods_indicador()
        {
            ods_meta_municipio = new HashSet<ods_meta_municipio>();
            ods_tablero_indicador = new HashSet<ods_tablero_indicador>();
        }

        [Key]
        [DisplayName("Indicador")]
        public int IdIndicador { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Indicador { get; set; }

        public bool Vigente { get; set; }

        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_meta_municipio> ods_meta_municipio { get; set; }

        public virtual ods_municipio ods_municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ods_tablero_indicador> ods_tablero_indicador { get; set; }
    }
}

namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_meta_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdObjetivo { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Objetivo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Numeral { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Meta { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMeta { get; set; }
    }
}

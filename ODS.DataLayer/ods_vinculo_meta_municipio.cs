namespace ODS.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ods_vinculo_meta_municipio
    {
        [Key]
        public int IdVinculo { get; set; }

        [DisplayName("Meta ODS")]
        public int IdMeta { get; set; }

        [DisplayName("Meta Municipio")]
        public int IdMetaMunicipio { get; set; }

        public virtual ods_meta ods_meta { get; set; }

        public virtual ods_meta_municipio ods_meta_municipio { get; set; }
    }
}

namespace TestSınıflar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_SoruCevap
    {
        [Key]
        public int SoruCevapid { get; set; }

        public int? Soruid { get; set; }

        public bool? Dogruluk { get; set; }

        public int? Testid { get; set; }

        public virtual Table_Soru Table_Soru { get; set; }

        public virtual Table_Test Table_Test { get; set; }
    }
}

namespace TestSınıflar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_KategorikOran
    {
        [Key]
        public int KategorikOranid { get; set; }

        public int? Testid { get; set; }

        public int? Kategoriid { get; set; }

        public int? Kullaniciid { get; set; }

        public int? Oran { get; set; }

        public virtual Table_Kategoriler Table_Kategoriler { get; set; }

        public virtual Table_Kullanici Table_Kullanici { get; set; }

        public virtual Table_Test Table_Test { get; set; }
    }
}

namespace YGS_Hazirlik
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Soru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Soru()
        {
            Table_SoruCevap = new HashSet<Table_SoruCevap>();
        }

        [Key]
        public int Soruid { get; set; }

        [StringLength(1000)]
        public string soru { get; set; }

        public int? Kategoriid { get; set; }

        public int? Kullaniciid { get; set; }

        [StringLength(250)]
        public string A { get; set; }

        [StringLength(250)]
        public string B { get; set; }

        [StringLength(250)]
        public string C { get; set; }

        [StringLength(250)]
        public string D { get; set; }

        [StringLength(250)]
        public string E { get; set; }

        public int? Resimid { get; set; }

        [StringLength(1)]
        public string DogruCevap { get; set; }

        public virtual Table_Kategoriler Table_Kategoriler { get; set; }

        public virtual Table_Kullanici Table_Kullanici { get; set; }

        public virtual Table_Resimler Table_Resimler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_SoruCevap> Table_SoruCevap { get; set; }
    }
}

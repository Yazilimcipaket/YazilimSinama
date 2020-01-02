namespace YGS_Hazirlik
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Test()
        {
            Table_KategorikOran = new HashSet<Table_KategorikOran>();
            Table_SoruCevap = new HashSet<Table_SoruCevap>();
        }

        [Key]
        public int Testid { get; set; }

        public int? Kullaniciid { get; set; }

        public DateTime? Zaman { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_KategorikOran> Table_KategorikOran { get; set; }

        public virtual Table_Kullanici Table_Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_SoruCevap> Table_SoruCevap { get; set; }
    }
}

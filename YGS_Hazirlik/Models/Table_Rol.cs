namespace YGS_Hazirlik
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Rol()
        {
            Table_Kullanici = new HashSet<Table_Kullanici>();
        }

        [Key]
        public int Rolid { get; set; }

        [StringLength(50)]
        public string RolAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Kullanici> Table_Kullanici { get; set; }
    }
}

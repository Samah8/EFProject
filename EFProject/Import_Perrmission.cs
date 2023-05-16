namespace EFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Import_Perrmission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Import_Perrmission()
        {
            Import_Items = new HashSet<Import_Items>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int import_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? import_date { get; set; }

        public int? store_id { get; set; }

        public int? supplier_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Import_Items> Import_Items { get; set; }

        public virtual Store Store { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}

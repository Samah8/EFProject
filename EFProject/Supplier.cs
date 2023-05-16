namespace EFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Import_Perrmission = new HashSet<Import_Perrmission>();
            Transformations = new HashSet<Transformation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sup_id { get; set; }

        [StringLength(10)]
        public string sup_name { get; set; }

        [StringLength(50)]
        public string sup_phone { get; set; }

        [Column(TypeName = "text")]
        public string sup_fax { get; set; }

        [StringLength(50)]
        public string sup_mobile { get; set; }

        [StringLength(20)]
        public string sup_email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Import_Perrmission> Import_Perrmission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transformation> Transformations { get; set; }
    }
}

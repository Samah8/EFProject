namespace EFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transformation")]
    public partial class Transformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int trans_id { get; set; }

        public int? from_store { get; set; }

        public int? to_store { get; set; }

        public int? item_id { get; set; }

        public int? item_quantity { get; set; }

        public int? supplier_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? production_item { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? item_expiry { get; set; }

        public virtual Item Item { get; set; }

        public virtual Store Store { get; set; }

        public virtual Store Store1 { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}

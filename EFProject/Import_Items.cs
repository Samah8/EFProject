namespace EFProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Import_Items
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int import_id { get; set; }

        public int? item_quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? item_production { get; set; }

        [Column(TypeName = "date")]
        public DateTime? item_expiry { get; set; }

        public virtual Import_Perrmission Import_Perrmission { get; set; }

        public virtual Item Item { get; set; }
    }
}

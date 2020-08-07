namespace DBClassLib.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerTable")]
    public partial class CustomerTable
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(32)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(40)]
        public string CustomerEmail { get; set; }

        [StringLength(256)]
        public string CustomerAddress { get; set; }

        public DateTime? DateInserted { get; set; }

        public Guid? OrderID { get; set; }

        public virtual OrderTable OrderTable { get; set; }
    }
}

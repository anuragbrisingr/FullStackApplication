using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBClassLib.DBModels
{
    [Table("CustomerTable")]
    public partial class CustomerTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(32)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(40)]
        public string CustomerEmail { get; set; }

        [StringLength(256)]
        public string CustomerAddress { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateInserted { get; set; }

        public Guid? OrderID { get; set; }

        public virtual OrderTable OrderTable { get; set; }
    }
}

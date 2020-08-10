using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBClassLib.DBModels
{
    [Table("ProductTable")]
    public partial class ProductTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductTable()
        {
            OrderTables = new HashSet<OrderTable>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(3)]
        public string ProductCode { get; set; }

        [StringLength(1024)]
        public string ProductDesc { get; set; }

        public bool StockStatus { get; set; }

        public int? StockCount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateInserted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}

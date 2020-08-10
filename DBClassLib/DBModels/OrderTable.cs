using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBClassLib.DBModels
{
    [Table("OrderTable")]
    public partial class OrderTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderTable()
        {
            CustomerTables = new HashSet<CustomerTable>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        public decimal OrderAmount { get; set; }

        public int OrderProductCount { get; set; }

        public Guid? ProductID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateInserted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTable> CustomerTables { get; set; }

        public virtual ProductTable ProductTable { get; set; }
    }
}

namespace Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscription")]
    public partial class Subscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscription()
        {
            Customers = new HashSet<Customer>();
        }

        [Required]
        [StringLength(50)]
        public string SubscriptionName { get; set; }

        [Key]
        [StringLength(50)]
        public string SubscriptionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string SubscriptionPackge { get; set; }

        public double SubscriptionFee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

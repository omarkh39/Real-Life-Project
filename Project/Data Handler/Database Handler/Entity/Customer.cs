namespace Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Key]
        [StringLength(10)]
        public string CustomerPhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        public double Amount { get; set; }

        [StringLength(50)]
        public string SubscriptionCode { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}

namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            DetailOrder = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public string Note { get; set; }

        [StringLength(4)]
        public string PaymentMethod { get; set; }

        public int? IdVoucher { get; set; }

        public int? IdState { get; set; }

        public int? IdCustomer { get; set; }

        public int? IdInformation { get; set; }

        public int? TotalPrice { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrder { get; set; }

        public virtual Information Information { get; set; }

        public virtual State State { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}

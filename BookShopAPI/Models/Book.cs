namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            DetailOrder = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Discount { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        public string Description { get; set; }

        public int IdPublisher { get; set; }

        public int IdCategory { get; set; }

        public int IdAuthor { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrder { get; set; }
    }
}

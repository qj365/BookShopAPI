namespace BookShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voucher")]
    public partial class Voucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voucher()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        [Display(Name = "Mã khuyến mãi")]
        public int Id { get; set; }

        [Display(Name = "Phần trăm khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập phần trăm khuyến mãi")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn 0")]
        public int Discount { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày kết thúc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        public DateTime EndDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập tên khuyến mãi")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã code khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập code khuyến mãi")]
        public string Code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

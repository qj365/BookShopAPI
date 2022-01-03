using BookShopAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BookShopAPI.Areas.Admin.ViewModel
{
    public class BookViewModel
    {

        public string Title
        {
            get
            {
                return Id != 0 ? "Sửa sách" : "Thêm sách";
            }
        }

        public BookViewModel()
        {
            Id = 0;
        }

        public BookViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Discount = book.Discount;
            Price = book.Price;
            Amount = book.Amount;
            Photo = book.Photo;
            Description = book.Description;
            IdPublisher = book.IdPublisher;
            IdAuthor = book.IdAuthor;
            IdCategory = book.IdCategory;
        }


        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }


        [Display(Name = "Giảm giá")]
        [Range(0, 100, ErrorMessage = ("{0} phải lớn hơn {1} và nhỏ hơn {2}"))]
        public int Discount { get; set; }


        [Display(Name = "Giá tiền")]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        [Range(0, int.MaxValue, ErrorMessage = ("{0} phải lớn hơn {1}"))]
        public int Price { get; set; }


        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        [Range(0, int.MaxValue, ErrorMessage = ("{0} phải lớn hơn {1}"))]
        public int Amount { get; set; }


        [StringLength(500)]
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        [Display(Name = "Nhà xuất bản")]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        public int IdPublisher { get; set; }
        [ForeignKey("IdPublisher")]

        public HttpPostedFileBase PhotoFile { get; set; }


        [Display(Name = "Thể loại")]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]


        [Display(Name = "Tác giả")]
        [Required(ErrorMessage = "Vui lòng nhập {0}.")]
        public int IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]

        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Discount { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public int IdPublisher { get; set; }

        public int IdCategory { get; set; }

        public int IdAuthor { get; set; }

        public virtual AuthorDto Author { get; set; }

        public virtual CategoryDto Category { get; set; }

        public virtual PublisherDto Publisher { get; set; }
    }
}
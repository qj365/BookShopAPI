using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class PublisherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }
    }
}
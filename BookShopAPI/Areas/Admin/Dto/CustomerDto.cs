using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Sdt { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
    }
}
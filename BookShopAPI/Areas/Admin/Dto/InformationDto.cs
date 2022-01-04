using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class InformationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Sdt { get; set; }

        public bool? Defaults { get; set; }

        public int? IdCustomer { get; set; }

        public virtual CustomerDto Customer { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class VoucherDto
    {

        public int Id { get; set; }

        public int Discount { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }

        public string Name { get; set; }
    }
}
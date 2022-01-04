using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public string Note { get; set; }

        public string PaymentMethod { get; set; }

        public int? IdVoucher { get; set; }

        public int? IdState { get; set; }

        public int? IdCustomer { get; set; }

        public int? IdInformation { get; set; }

        public int? TotalPrice { get; set; }


        public string Reason { get; set; }

        public virtual CustomerDto Customer { get; set; }

        //public virtual ICollection<DetailOrder> DetailOrder { get; set; }

        public virtual InformationDto Information { get; set; }

        public virtual StateDto State { get; set; }

        public virtual VoucherDto Voucher { get; set; }
    }
}
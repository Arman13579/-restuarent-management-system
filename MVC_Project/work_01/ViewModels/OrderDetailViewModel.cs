using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace work_01.ViewModels
{
    public class OrderDetailViewModel
    {
        [Key]
        public int OrderDetailId { get; set; }
    
        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal Total { get; set; }

    }
}
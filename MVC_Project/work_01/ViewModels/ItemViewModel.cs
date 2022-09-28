using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace work_01.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }

        public int Category { get; set; }
        public bool IsAvailable { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public HttpPostedFileBase Picture { get; set; }
    }
}
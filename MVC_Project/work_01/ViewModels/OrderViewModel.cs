using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using work_01.ViewModels;

namespace work_01.ViewModels
{
    public class OrderViewModel
    {
         public int OrderId { get; set; }
       
       
        [Display(Name ="Payment Type")]
        public int PaymentTypeId { get; set; }
       
     
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        
        [Display(Name ="Order Number")]
        public string OrderNumber { get; set; }
       
        [Required]
        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0: yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        
        [Display(Name = "Final Total")]
        public decimal FinalTotal { get; set; }

        public IEnumerable<OrderDetailViewModel> ListOfOrderDetailsViewModel { get; set; }

    }
}
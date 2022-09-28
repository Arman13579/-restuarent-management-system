using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace work_01.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required,StringLength(40, ErrorMessage = "Customer name is Required")]
        [Display(Name ="Customer Name")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        
        public string CustomerName { get; set; }
      
    }
    
    public class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; }
        
        [Required]
        [MaxLength(20), MinLength(3)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        //nev for item talbe
        public virtual IList<Item> Items { get; set; }

    }

    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        
        [Required, StringLength(40, ErrorMessage = "Item name is Required")]
        [Display(Name = "Item Name")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string ItemName { get; set; }
        
        [Required(ErrorMessage ="Item Price is required"),Column(TypeName ="money") ]
        [Display(Name = "Item Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:0.00}")]       
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }


        [ForeignKey("ItemCategory")]
        public int Category { get; set; }
        public bool IsAvailable { get; set; }
        [Display(Name ="Picture")]
        public string ItemPicture { get; set; }

        
        //nev for category table
        public virtual ItemCategory ItemCategory { get; set; }


    }
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
       
        [Required, StringLength(40, ErrorMessage = "Payment type is Required")]
        [Display(Name = "Payment Type")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string PaymentTypeName { get; set; }   
    }

    public class Order
    {
        [Key]
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

        //nev for order Details(child table)
        public virtual ICollection<OrderDetail>  OrderDetail { get; set; }

    }

    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        
        [ForeignKey("Order")]
        [Display(Name ="Order")]
        public int OrderId { get; set; }
        
       
        [Display(Name ="Item")]
        public int ItemId { get; set; }
        
        [Display(Name ="Unit Price")]
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        public decimal Discount { get; set; }
        
        [Display(Name ="Total Amount")]
        public decimal Total { get; set; }

        //nev for order and item table (Parent table)
        public virtual Order Order { get; set; }
       

    }

    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
            
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        

        [Display(Name ="Transaction Date")]
        [DisplayFormat(DataFormatString ="{0: yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }
        
        public int TypeId { get; set; }

        
        
        
    }

    public class RestuarentDbContext: DbContext
    {
        public RestuarentDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
    }


}
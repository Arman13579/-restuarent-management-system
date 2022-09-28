using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using work_01.Models;
using System.Web.Mvc;

namespace work_01.Repositories
{
    public class CustomerRepository
    {
        private RestuarentDbContext objRestuarentDbContext;
        public CustomerRepository()
        {
            objRestuarentDbContext = new RestuarentDbContext();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestuarentDbContext.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }
                                      ).ToList();
            return objSelectListItems;
        }
    }
}
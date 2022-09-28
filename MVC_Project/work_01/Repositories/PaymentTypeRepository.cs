using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work_01.Models;

namespace work_01.Repositories
{
    public class PaymentTypeRepository
    {
        private RestuarentDbContext objRestuarentDbContext;
        public PaymentTypeRepository()
        {
            objRestuarentDbContext = new RestuarentDbContext();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestuarentDbContext.PaymentTypes
                                        select new SelectListItem()
                                      {
                                          Text = obj.PaymentTypeName,
                                          Value = obj.PaymentTypeId.ToString(),
                                          Selected = true
                                      }
                                      ).ToList();
            return objSelectListItems;
        }

    }
}
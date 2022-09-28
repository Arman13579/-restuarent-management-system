using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using work_01.Models;
using System.Web.Mvc;

namespace work_01.Repositories
{
    public class ItemRepository
    {
        private RestuarentDbContext objRestuarentDbContext;
        public ItemRepository()
        {
            objRestuarentDbContext = new RestuarentDbContext();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestuarentDbContext.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false
                                  }
                                      ).ToList();
            return objSelectListItems;
        }
    }
}
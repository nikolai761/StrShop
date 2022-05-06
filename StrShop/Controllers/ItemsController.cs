using Microsoft.AspNetCore.Mvc;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using StrShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IAllItems _AllItems;
        private readonly IItemCategory _AllCategories;


        public ItemsController(IAllItems iallItems, IItemCategory iitemCategories)
        {
            _AllItems = iallItems;
            _AllCategories = iitemCategories;

        }

        

        [Route("Items/ItemList")]
        [Route("Items/ItemList/{category}")]
        public ViewResult ItemList(string category)
        {
            string _category = category;
            IEnumerable<Item> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(_category))
            {
                items = _AllItems.Items.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("lak",category,StringComparison.OrdinalIgnoreCase))
                {
                    items = _AllItems.Items.Where(i => i.Category.CategoryName.Equals("Лаки")).OrderBy(i => i.id);
                    currCategory = "Лаки";
                }
                else if (string.Equals("smes", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _AllItems.Items.Where(i => i.Category.CategoryName.Equals("Смеси")).OrderBy(i => i.id);
                    currCategory = "Смеси";
                }
                else if (string.Equals("kras", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _AllItems.Items.Where(i => i.Category.CategoryName.Equals("Краски")).OrderBy(i => i.id);
                    currCategory = "Краски";
                }
                
            }

            var obj = new ItemListViewModel
            {
                AllItems = items,
                ItemCategory = currCategory
            };

            ViewBag.Title = "Страница с товарами";
          
            return View(obj);
        }
    }
}

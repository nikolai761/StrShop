using StrShop.Data;
using StrShop.Data.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrShop.ViewModels;

namespace StrShop.Controllers
{
    public class SearchController : Controller
    {

        private readonly DBconnection dBconnection;

        public SearchController(DBconnection dBconnection)
        {
            this.dBconnection = dBconnection;
        }

        public IActionResult Search()
        {
            SearchViewModel model = new SearchViewModel();
            model.items = dBconnection.Item.ToList();
            return View(model);
        }

        private List<Item> SearchEverywhere(string text) => dBconnection.Item.Include(i=>i.Producer).FullTextSearchQuery(text).ToList();


        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {

            if (!string.IsNullOrEmpty(model.Text))
            {
                model.items = SearchEverywhere(model.Text).ToList();
            }
            else model.items = dBconnection.Item.ToList();
            model.items = model.items.Distinct().ToList();
            return View(model);
        }
    }
}
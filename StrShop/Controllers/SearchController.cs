/*
using StrShop.Data;
using StrShop.Data.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrShop.ViewsModels;

namespace StrShop.Controllers
{
    public class SearchController : Controller
    {

        private readonly DBconnection dBconnection;
        private List<int> CollectionIDs = new List<int>();
        private List<int> ItemsIDs = new List<int>();

        public SearchController(DBconnection dBconnection)
        {
            this.dBconnection = dBconnection;
        }

        public IActionResult Search()
        {
            SearchViewModel model = new SearchViewModel();
            model.items = dBconnection.Item.Include(i => i.ItemName).ToList();
            foreach (Item item in model.items) item.Collection = dBContent.Collection.FirstOrDefault(u => u.ID == item.CollectionID);
            return View(model);
        }

        private List<Item> SearchEverywhere(string text)
        {
            foreach (var col in dBContent.Collection.FullTextSearchQuery(text)) CollectionIDs.Add(col.ID);
            foreach (var com in dBContent.Comment.FullTextSearchQuery(text)) ItemsIDs.Add(com.ItemID);
            List<Item> result = dBContent.Item.Include(i => i.tags).FullTextSearchQuery(text).ToList();
            foreach (var id in CollectionIDs) result.AddRange(dBContent.Item.Include(i => i.tags).Where(u => u.CollectionID == id));
            foreach (var id in ItemsIDs) result.Add(dBContent.Item.Include(i => i.tags).FirstOrDefault(u => u.ID == id));
            return result;
        }

        public IActionResult TagSearch(string tag)
        {
            SearchViewModel model = new SearchViewModel();
            if (!string.IsNullOrEmpty(tag))
            {
                model.items = SearchEverywhere(tag).ToList();
                foreach (var item in model.items) item.Collection = dBContent.Collection.FirstOrDefault(u => u.ID == item.CollectionID);
            }
            else model.items = dBContent.Item.Include(i => i.tags).ToList();
            model.items = model.items.Distinct().ToList();
            return View("Search", model);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {

            if (!string.IsNullOrEmpty(model.Text))
            {
                model.items = SearchEverywhere(model.Text).ToList();
                foreach (var item in model.items) item.Collection = dBContent.Collection.FirstOrDefault(u => u.ID == item.CollectionID);
            }
            else model.items = dBContent.Item.Include(i => i.tags).ToList();
            model.items = model.items.Distinct().ToList();
            return View(model);
        }
    }
}*/
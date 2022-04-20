using Microsoft.AspNetCore.Mvc;
using StrShop.Data.Interfaces;
using StrShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllItems _itemRepository;

        public HomeController(IAllItems itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Главная страница";
            var homeItems = new HomeViewModel
            {
                actionItems = _itemRepository.GetAction
            };
            return View(homeItems);
        }
    }
}

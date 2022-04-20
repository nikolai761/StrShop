using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data
{
    public class DbObject
    {
        public static void initial(DBconnection content)
        {
          


            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c=>c.Value));
            }

            if (!content.Producer.Any())
            {
                content.Producer.AddRange(Producer.Select(c => c.Value));
            }

            if (!content.Storage.Any())
            {
                content.Storage.AddRange(Storage.Select(c => c.Value));
            }

            if (!content.Item.Any())
            {
                content.AddRange(
                    new Item
                    {
                        ItemName = "Краска Белая",
                        Description = "Краска для стен",
                        price = 7,
                        Category = Categories["Краски"],
                        Producer = Producer["Sniezka"],
                        Storage = Storage["Уручье"],
                        isAction = true,
                        img = "/img/Sniezka.jpg"

                    },
                    new Item
                    {
                        ItemName = "Штукатурка",
                        Description = "Бюджетная",
                        price = 15,
                        Category = Categories["Смеси"],
                        Producer = Producer["Sniezka"],
                        Storage = Storage["Уручье"],
                        isAction = true,
                        img = "/img/Sniezka.jpg"

                    },
                    new Item
                    {
                        ItemName = "Краска Красная",
                        Description = "По металлу ",
                        price = 11,
                        Category = Categories["Краски"],
                        Producer = Producer["Condor"],
                        Storage = Storage["Уручье"],
                        isAction = false,
                        img = "/img/Condor.jpg"

                    },
                    new Item
                    {
                        ItemName = "Лак для пола",
                        Description = "Сверхпрочный ",
                        price = 15,
                        Category = Categories["Лаки"],
                        Producer = Producer["Farbitex"],
                        Storage = Storage["Уручье"],
                        isAction = true,
                        img = "/img/lak.jpg"

                    }
                    );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Producer> producer;
        public static Dictionary<string, Producer> Producer
        {
            get{
                if (producer == null) {
                    var list = new Producer[]
                    {
                        new  Producer{  ProducerName ="Sniezka"},
                        new  Producer{  ProducerName ="Condor"},
                         new  Producer{  ProducerName ="Farbitex"}
                    };

                    producer = new Dictionary<string, Producer>();
                    foreach (Producer el in list) { producer.Add(el.ProducerName, el); }
                }
                return producer;
            }
           
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ CategoryName ="Смеси"},
                        new Category{ CategoryName ="Краски"},
                         new Category{ CategoryName ="Лаки"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list) { category.Add(el.CategoryName, el); }
                }
                return category;
            }

        }

        private static Dictionary<string, Storage> storage;
        public static Dictionary<string, Storage> Storage
        {
            get
            {
                if (storage == null)
                {
                    var list = new Storage[]
                    {
                        new Storage{ StorageAddress ="Уручье"},
                        new Storage{ StorageAddress ="Зеленый луг"},
                    };

                    storage = new Dictionary<string, Storage>();
                    foreach (Storage el in list) { storage.Add(el.StorageAddress, el); }
                }
                return storage;
            }

        }
    }
}

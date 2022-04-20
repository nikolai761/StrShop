using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Mocks
{
    public class MockItems : IAllItems
    {
        private readonly IItemCategory _ICategory = new MockCategory();
        private readonly IProducer _IProducer = new MockProducers();
        private readonly IStorages _IStorage = new MockStorages();

        public IEnumerable<Item> Items
        {
            get
            {
                return new List<Item>
                {
                    new Item
                    {
                        ItemName ="Краска Белая" ,
                        Description = "Краска для стен" ,
                        price =7,
                        Category= _ICategory.AllCategories.Last(),
                        img="/img/Condor.jpg",
                        Producer= _IProducer.AllProducers.Last(),
                        Storage= _IStorage.AllStorages.First()
                    },
                    new Item
                    {
                        ItemName ="Штукатурка" ,
                        Description = "Бюджетная" ,
                        price =15,
                        Category= _ICategory.AllCategories.First(),
                        img="/img/Sniezka.jpg",
                        Producer= _IProducer.AllProducers.First(),
                        Storage= _IStorage.AllStorages.Last()
                    },
                    new Item
                    {
                        ItemName ="Краска Красная" ,
                        Description = "По металлу " ,
                        price =11,
                        Category= _ICategory.AllCategories.Last(),
                         img="/img/Sniezka.jpg",
                        Producer= _IProducer.AllProducers.First(),
                        Storage= _IStorage.AllStorages.First()
                    },
                };
            }
        }

        public IEnumerable<Item> GetAction => throw new NotImplementedException();

        public Item GetItemById(int ItemId)
        {
            throw new NotImplementedException();
        }
    }
}

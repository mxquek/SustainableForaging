using NUnit.Framework;
using SustainableForaging.BLL.Tests.TestDoubles;
using SustainableForaging.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SustainableForaging.BLL.Tests
{
    public class ForageServiceTest
    {
        ForageService service = new ForageService(
           new ForageRepositoryDouble(),
           new ForagerRepositoryDouble(),
           new ItemRepositoryDouble());

        [Test]
        public void ShouldAdd()
        {
            Forage forage = new Forage();
            forage.Date = DateTime.Today;
            forage.Forager = ForagerRepositoryDouble.FORAGER;
            forage.Item = ItemRepositoryDouble.ITEM;
            forage.Kilograms = 0.5M;

            Result<Forage> result = service.Add(forage);
            Assert.IsTrue(result.Success);
            Assert.NotNull(result.Value);
            Assert.AreEqual(36, result.Value.Id.Length);
        }

        [Test]
        public void ShouldNotAddWhenForagerNotFound()
        {
            Forager forager = new Forager();
            forager.Id = "30816379-188d-4552-913f-9a48405e8c08";
            forager.FirstName = "Ermengarde";
            forager.LastName ="Sansom";
            forager.State ="NM";

            Forage forage = new Forage();
            forage.Date = DateTime.Today;
            forage.Forager = forager;
            forage.Item = ItemRepositoryDouble.ITEM;
            forage.Kilograms = 0.5M;

            Result<Forage> result = service.Add(forage);
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void ShouldNotAddWhenItemNotFound()
        {
            Item item = new Item(11, "Dandelion", Category.Edible, 0.05M);

            Forage forage = new Forage();
            forage.Date = DateTime.Today;
            forage.Forager = ForagerRepositoryDouble.FORAGER;
            forage.Item = item;
            forage.Kilograms =0.5M;

            Result<Forage> result = service.Add(forage);
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void ShouldNotAddWhenDuplicate()
        {
            Forage forage = new Forage();
            forage.Date = DateTime.Today;
            forage.Forager = ForagerRepositoryDouble.FORAGER;
            forage.Item = ItemRepositoryDouble.ITEM;
            forage.Kilograms = 0.5M;

            service.Add(forage);
            Result<Forage> result = service.Add(forage);
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void ShouldReportKgPerItem()
        {
            Forage forage1 = new Forage();
            forage1.Date = DateTime.Today.Date;
            forage1.Forager = ForagerRepositoryDouble.FORAGER;
            forage1.Item = ItemRepositoryDouble.ITEM;
            forage1.Kilograms = 0.5M;
            service.Add(forage1);

            Forage forage2 = new Forage();
            forage2.Date = DateTime.Today.Date;
            forage2.Forager = ForagerRepositoryDouble.FORAGER2;
            forage2.Item = ItemRepositoryDouble.ITEM;
            forage2.Kilograms = 0.15M;
            service.Add(forage2);

            Forage forage3 = new Forage();
            forage3.Date = DateTime.Today.Date;
            forage3.Forager = ForagerRepositoryDouble.FORAGER2;
            forage3.Item = ItemRepositoryDouble.ITEM2;
            forage3.Kilograms = 0.3M;
            service.Add(forage3);

            Dictionary<Item, decimal> result = service.ReportKgPerItem(DateTime.Today.Date);
            Assert.IsTrue(result.Where(record => record.Key.Name == ItemRepositoryDouble.ITEM.Name)
                                .Sum(record => record.Value)
                                == 0.65M);
            Assert.IsTrue(result.Where(record => record.Key.Name == ItemRepositoryDouble.ITEM2.Name)
                                .Sum(record => record.Value)
                                == 0.3M);
        }

        [Test]
        public void ShouldReportCategoryValue()
        {
            List<Forage> todaysForages = service.FindByDate(DateTime.Today);
            List<decimal> expectedValues = new List<decimal>();     //ADD in values later
            Dictionary<Category, decimal> expected = new Dictionary<Category, decimal>();
            Category category;
            for (int i = 0; i < 4; i++)
            {
                category = (Category)Enum.Parse(typeof(Category),i.ToString());
                expected.Add(category, 0);
            }
            
            Dictionary<Category,decimal> actual = service.ReportCategoryValue(DateTime.Today);
        }
    }
}

using NUnit.Framework;
using SustainableForaging.Core.Models;
using System.Collections.Generic;
using System.IO;

namespace SustainableForaging.DAL.Tests
{
    public class ForagerFileRepositoryTest
    {
        const string SEED_PATH = @"data\foragers.csv";
        const string TEST_PATH = @"data\foragers-test.csv";

        ForagerFileRepository repository = new ForagerFileRepository(TEST_PATH);

        [SetUp]
        public void SetUp()
        {
            File.Copy(SEED_PATH, TEST_PATH, true);
        }

        [Test]
        public void ShouldFindAll()
        {
            ForagerFileRepository repo = new ForagerFileRepository(@"data\foragers.csv");
            List<Forager> all = repo.FindAll();
            Assert.AreEqual(1000, all.Count);
        }

        [Test]
        public void ShouldAdd()
        {
            Forager expected = MakeForager();
            Forager forager = MakeForager();

            Forager actual = repository.Add(forager);
            Assert.AreEqual(expected, actual);
        }

        private Forager MakeForager()
        {
            Forager forager = new Forager();
            forager.Id = "0e4707f4-407e-4ec9-9665-baca0aabe88c";
            forager.FirstName = "Jilly";
            forager.LastName = "Sisse";
            forager.State = "GA";
            return forager;
        }
    }
}

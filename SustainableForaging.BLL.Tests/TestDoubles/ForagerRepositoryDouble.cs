using SustainableForaging.Core.Models;
using SustainableForaging.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SustainableForaging.BLL.Tests.TestDoubles
{
    public class ForagerRepositoryDouble : IForagerRepository
    {
        public readonly static Forager FORAGER = MakeForager();
        public readonly static Forager FORAGER2 = MakeForager2();

        private readonly List<Forager> foragers = new List<Forager>();

        public ForagerRepositoryDouble()
        {
            foragers.Add(FORAGER);
            foragers.Add(FORAGER2);
        }
        //TODO copy implementation of ForagerFileRepository Add()
        public Forager Add(Forager forager)
        {
            List<Forager> all = FindAll();
            forager.Id = Guid.NewGuid().ToString();
            all.Add(forager);

            return forager;
        }
        public List<Forager> FindAll()
        {
            return foragers;
        }

        public Forager FindById(string id)
        {
            return foragers.FirstOrDefault(i => i.Id == id);
        }

        public List<Forager> FindByState(string stateAbbr)
        {
            return foragers
                .Where(i => i.State.Equals(stateAbbr, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private static Forager MakeForager()
        {
            Forager forager = new Forager();
            forager.Id = "0e4707f4-407e-4ec9-9665-baca0aabe88c";
            forager.FirstName = "Jilly";
            forager.LastName = "Sisse";
            forager.State = "GA";
            return forager;
        }

        private static Forager MakeForager2()
        {
            Forager forager2 = new Forager();
            forager2.Id = "40816379-188d-4552-913f-9a48405e8c09";
            forager2.FirstName = "John";
            forager2.LastName = "Smith";
            forager2.State = "TX";

            return forager2;
        }
    }
}

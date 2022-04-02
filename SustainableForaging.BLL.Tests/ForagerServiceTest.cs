using NUnit.Framework;
using SustainableForaging.BLL.Tests.TestDoubles;
using SustainableForaging.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustainableForaging.BLL.Tests
{
    class ForagerServiceTest
    {
        ForagerService service = new ForagerService(new ForagerRepositoryDouble());

        [Test]
        //Service.Add() Not Yet Implemented
        public void ShouldNotSaveNullFirstName()
        {
            Forager forager = new Forager("ID", null, "Smith", "TX");
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveBlankFirstName()
        {
            Forager forager = new Forager("ID", "", "Smith", "TX");
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveNullLastName()
        {
            Forager forager = new Forager("ID", "John", null, "TX");
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveBlankLastName()
        {
            Forager forager = new Forager("ID", "John", "", "TX");
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveNullState()
        {
            Forager forager = new Forager("ID", "John", "Smith", null);
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveBlankState()
        {
            Forager forager = new Forager("ID", "John", "Smith", "");
            Result<Forager> result = service.Add(forager);
            Assert.IsFalse(result.Success);
        }
        [Test]
        public void ShouldNotSaveDuplicateForager()
        {
            Result<Forager> result = service.Add(ForagerRepositoryDouble.FORAGER);
            Assert.IsFalse(result.Success);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldData.Models;

namespace WorldData.Models.Tests
{
  [TestClass]
  public class CountryTests : IDisposable
  {
    public void Dispose()
    {
      Country.DeleteAll();
    }

    public CountryTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      int result = Country.GetAll().Count;

      Assert.AreEqual(0, result);
    }
  }
}

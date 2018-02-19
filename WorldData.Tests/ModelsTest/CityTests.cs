using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldData.Models;

namespace WorldData.Models.Tests
{
  [TestClass]
  public class CityTest
  {

    [TestMethod]
    public void Test_GetCity_True()
    {
      Assert.AreEqual(4080, City.GetCity().Count);
    }

    [TestMethod]
    public void Test_GetCityName_String()
    {
      Assert.AreEqual(City.GetCity()[4079].cityName, "Dogtown");

    }
  }
}

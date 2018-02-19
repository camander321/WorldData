using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class City
  {

    public int id { get; set; }
    public string cityName { get; set; }
    public string cityCountryCode { get; set; }
    public int cityPopulation { get; set; }
    public string cityDistrict { get; set; }

    public City(int id, string name, string code, int population, string district)
    {
      this.id = id;
      cityName = name;
      cityCountryCode = code;
      cityPopulation = population;
      cityDistrict = district;
    }

    public static List<City> GetCities(string command)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = command;
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityCountryCode = rdr.GetString(2);
        int cityPopulation = rdr.GetInt32(4);
        string cityDistrict = rdr.GetString(3);
        City newCity = new City(cityId, cityName, cityCountryCode, cityPopulation, cityDistrict);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static List<City> GetAll()
    {
      return GetCities(@"SELECT * FROM city");
    }

    public static List<City> GetPop(int min = 0, int max = 99999999)
    {
      return GetCities(@"SELECT * FROM city WHERE population >= " + min + " AND population <= " + max);
    }

    public static List<City> GetCountry(string country)
    {
      return GetCities(@"SELECT * FROM city WHERE countrycode LIKE '" + country + "'");
    }

    //MORE SEARCH/FILTER METHODS HERE

  }
}

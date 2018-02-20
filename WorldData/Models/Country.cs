using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class Country
  {
    public string countryName { get; set; }
    public string countryContinent { get; set; }
    public string countryCapital { get; set; }
    public int countryPop { get; set; }

    public Country(string name, string continent, string capital, int population)
    {
      countryName = name;
      countryContinent = continent;
      countryCapital = capital;
      countryPop = population;
    }

    public static List<Country> GetCountries(string command)
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = command;
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string CountryName = rdr.GetString(1);
        string CountryContinent = rdr.GetString(2);
        int CountryPop = rdr.GetInt32(6);
        //Console.WriteLine(rdr.GetInt32(13));
        string CountryCapital = "";
        if (!rdr.IsDBNull(13))
          CountryCapital = City.GetFromId(rdr.GetInt32(13))[0].cityName;
        Country newCountry = new Country(CountryName, CountryContinent, CountryCapital, CountryPop);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM country;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Country> GetAll()
    {
      return GetCountries(@"SELECT * FROM country");
    }

    public static List<Country> GetName(string name)
    {
      return GetCountries(@"SELECT * FROM country WHERE name LIKE '" + name + "'");
    }

    public static List<Country> GetContinent(string continent)
    {
      return GetCountries(@"SELECT * FROM country WHERE continent LIKE '" + continent + "'");
    }

    public static List<Country> GetPop(int min = 0, int max = 99999999)
    {
      return GetCountries(@"SELECT * FROM country WHERE population >= " + min + " AND population <= " + max);
    }
  }
}

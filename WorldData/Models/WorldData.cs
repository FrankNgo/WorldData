using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class Country
  {
    private string _name;
    private string _continent;
    private string _region;
    private float _surface;
    private int _population;




    public Country(string Name, string continent, string region, float surface, int population)
    {

      _name = Name;
      _continent = continent;
      _region = region;
      _surface = surface;
      _population = population;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public string GetRegion()
    {
      return _region;
    }

    public float GetSurface()
    {
      return _surface;
    }

    public int GetPopulation()
    {
      return _population;
    }



    public static List<Country> GetAll()
    {
        List<Country> AllCountrys = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT Name, Continent, Region, SurfaceArea, Population FROM country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryName = rdr.GetString(0);
          string countryContinent = rdr.GetString(1);
          string countryRegion = rdr.GetString(2);
          float countrySurface = rdr.GetFloat(3);
          int countryPopulation = rdr.GetInt32(4);
          Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
          AllCountrys.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return AllCountrys;
    }

    public static List<Country> FilterCountry(string userInput)
    {
        List<Country> filterByCountries = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT Name, Continent, REgion, SurfaceArea, Population FROM Country WHERE Name LIKE '%" + userInput + "%';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryName = rdr.GetString(0);
          string countryContinent = rdr.GetString(1);
          string countryRegion = rdr.GetString(2);
          float countrySurface = rdr.GetFloat(3);
          int countryPopulation = rdr.GetInt32(4);
          Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
          filterByCountries.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return filterByCountries;
    }

    public static List<Country> FilterContinent()
    {
        List<Country> filterByContinent = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT Name, Continent, Region, SurfaceArea, Population FROM Country ORDER BY Continent";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryName = rdr.GetString(0);
          string countryContinent = rdr.GetString(1);
          string countryRegion = rdr.GetString(2);
          float countrySurface = rdr.GetFloat(3);
          int countryPopulation = rdr.GetInt32(4);
          Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
          filterByContinent.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return filterByContinent;
    }

      public static List<Country> FilterRegion()
      {
          List<Country> filterByRegion = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT Name, Continent, Region, SurfaceArea, Population FROM Country ORDER BY Region";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string countryName = rdr.GetString(0);
            string countryContinent = rdr.GetString(1);
            string countryRegion = rdr.GetString(2);
            float countrySurface = rdr.GetFloat(3);
            int countryPopulation = rdr.GetInt32(4);
            Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
            filterByRegion.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return filterByRegion;
      }

      public static List<Country> FilterSurface()
      {
          List<Country> filterBySurface = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT Name, Continent, Region, SurfaceArea, Population FROM Country ORDER BY SurfaceArea desc";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string countryName = rdr.GetString(0);
            string countryContinent = rdr.GetString(1);
            string countryRegion = rdr.GetString(2);
            float countrySurface = rdr.GetFloat(3);
            int countryPopulation = rdr.GetInt32(4);
            Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
            filterBySurface.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return filterBySurface;
      }

      public static List<Country> FilterPopulation()
      {
          List<Country> filterByPopulation = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT Name, Continent, Region, SurfaceArea, Population FROM Country ORDER BY Population desc";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string countryName = rdr.GetString(0);
            string countryContinent = rdr.GetString(1);
            string countryRegion = rdr.GetString(2);
            float countrySurface = rdr.GetFloat(3);
            int countryPopulation = rdr.GetInt32(4);
            Country newCountry = new Country(countryName,countryContinent, countryRegion, countrySurface, countryPopulation);
            filterByPopulation.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return filterByPopulation;
      }


  }
}

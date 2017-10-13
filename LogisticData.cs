using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Npgsql;

namespace LogisticDB
{

  public class City
  {
    //int id;
    //public int Id { get { return id; } set { id = value; } }
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
      return Id.ToString() + " " + Name;
    }
  }

  public class LogisticData
  {
    string ConnectStr { get { return "Server=127.0.01;Port=5439;User=postgres;Password=postgres;Database=logistic;CommandTimeout=60"; } }

    public List<City> GetCities()
    {

      NpgsqlConnection conn = new NpgsqlConnection(ConnectStr);
      conn.Open();
      var com = String.Format("SELECT id, name FROM cities ORDER BY name");
      NpgsqlCommand cmd = new NpgsqlCommand(com, conn);
      NpgsqlDataReader dr = cmd.ExecuteReader();

      var cities = new List<City>();
      while (dr.Read())
      {
        cities.Add(new City { Id = dr.GetInt32(0), Name = dr.GetString(1) });
      }
      
      conn.Close();
      return cities;
    }
  }
}

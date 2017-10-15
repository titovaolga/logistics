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
        public int id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return id.ToString() + " " + name;
        }
    }

    public class Car
    {
        public int id { get; set; }
        public string number { get; set; }
        public double cost { get; set; }
        public int cartype_id { get; set; }
        public override string ToString()
        {
            return id.ToString() + " " + number;
        }
    }

   /* public class CarType
    {
        public int id { get; set; }
        public string cargo_type { get; set; }
        public double cost_empty { get; set; }
        public double cost_full { get; set; }
        public double cost_stand { get; set; }
        public float payload { get; set; }
    }*/

    public class CarModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cargo_type { get; set; }
        public float payload { get; set; }
        public double cost_empty { get; set; }
        public double cost_full { get; set; }
        public double cost_stand { get; set; }
        public override string ToString()
        {
            return id.ToString() + " " + name + " " + cargo_type + " " + payload;
        }
    }

    public class Transaction
    {
        public int id { get; set; }
        public int car_id { get; set; }
        public bool is_full { get; set; }
        public int city_from { get; set; }
        public int city_to { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class LogisticData
    {
        string ConnectStr { get { return "Server=127.0.01;Port=5439;User=postgres;Password=postgres;Database=logistic;CommandTimeout=60"; } }

        public List<City> GetCities()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConnectStr);
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT id, name FROM cities WHERE name != 'store' ORDER BY name", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            var cities = new List<City>();
            while (dr.Read())
            {
                cities.Add(new City { id = dr.GetInt32(0), name = dr.GetString(1) });
            }
            conn.Close();

            return cities;
        }

        public List<CarModel> GetCarTypes()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectStr))
            {
                return conn.Query<CarModel>("SELECT * FROM carmodels").ToList();
            }
        }

       public List<Car> GetAppropriateCars(City city, string cargo_type, DateTime date, double payload)
       {
            NpgsqlConnection conn = new NpgsqlConnection(ConnectStr);
            conn.Open();

            string tmp = string.Format("SELECT id, number FROM cars WHERE cars.cartype_id = (SELECT id FROM carmodels WHERE carmodels.cargo_type = cargo_type AND carmodels.payload > payload)");//, cargo_type, payload);
            NpgsqlCommand cmd = new NpgsqlCommand(tmp, conn); 
            //cmd.CommandText = string.Format("SELECT id, number FROM cars WHERE cartype_id = (SELECT id FROM carmodels WHERE cargo_type = {0} AND payload > {1})", cargo_type, payload);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            var cars = new List<Car>();
            while (dr.Read())
            {
                cars.Add(new Car { id = dr.GetInt32(0), number = dr.GetString(1) });
            }
            conn.Close();

            return cars;
       }

    public Car BuyCar(City city, CarModel carModel, DateTime date, double cost, string number)
    {
        var car = new Car()
        {
            cartype_id = carModel.id,
            cost = cost,
            number = number
        };
            
        using (NpgsqlConnection conn = new NpgsqlConnection(ConnectStr))
        {
            car.id = conn.ExecuteScalar<int>(@"INSERT INTO cars (number, cost, cartype_id) 
                                              VALUES (@number,@cost,@cartype_id) RETURNING id", car);
            var transaction = new Transaction()
            {
                is_full = false,
                car_id = car.id,
                city_from = conn.ExecuteScalar<int>("SELECT id FROM cities WHERE name = 'store'"),
                city_to = city.id,
                date_from = date,
                date_to = date  
            };
            conn.Execute(@"INSERT INTO transactions (is_full, car_id, city_from, city_to, date_from, date_to) VALUES 
                            (@is_full, @car_id, @city_from, @city_to, @date_from, @date_to)", transaction);
        }
        
        return car;
    }

  }
}

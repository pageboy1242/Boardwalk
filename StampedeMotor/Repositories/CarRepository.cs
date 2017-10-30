using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public class CarRepository : ICarRepository
    {
        public List<Car> GetAll()
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();
            
            var cars = new List<Car>();
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT C.Id," +
                                       "C.Image," +
                                       "C.Description," +
                                       "C.Price," +
                                       "Makes.Id," +
                                       "Makes.Make_Name," +
                                       "Models.Id," +
                                       "Models.Model_Name" +
                                       " FROM Cars C INNER JOIN Makes ON C.Make_Id = Makes.Id" +
                                       " INNER JOIN Models ON C.Model_id = Models.Id";
                var oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var make = new Make((int)oReader["Id"], oReader["Make_Name"].ToString());
                        var model = new CarModel((int)oReader["Id"], oReader["Model_Name"].ToString());

                        var imageBytes = (byte[]) oReader["Image"];
                        
                        var description = oReader["Description"].ToString();
                        var price = (decimal) oReader["Price"];

                        var car = new Car(make,
                            model,
                            imageBytes,
                            description,
                            price) { Id = (int)oReader["Id"] };

                        cars.Add(car);
                    }

                    myConnection.Close();
                }
            }
            return cars;
        }

        public void Add(Car car)
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "INSERT INTO Cars (Image, Description, Price, Make_Id, Model_Id) output INSERTED.ID VALUES (@Image, @Description, @Price, @Make_Id, @Model_Id)";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@Image", SqlDbType.Image).Value = car.Image;
                oCmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = car.Description;
                oCmd.Parameters.Add("@Price", SqlDbType.SmallMoney).Value = car.Price;
                oCmd.Parameters.Add("@Make_Id", SqlDbType.Int).Value = car.Make.Id;
                oCmd.Parameters.Add("@Model_Id", SqlDbType.Int).Value = car.CarModel.Id;

                myConnection.Open();
                car.Id = (int)oCmd.ExecuteScalar();
                myConnection.Close();
            }
        }

        public int Delete(Car car)
        {
            if (car == null)
                throw new ArgumentNullException();

            var rowsAffected = 0;

            if (car.Id <= 0)
                return rowsAffected;

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "DELETE FROM Cars WHERE Id=@id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = car.Id;

                myConnection.Open();
                rowsAffected = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return rowsAffected;
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
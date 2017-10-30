using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        /// <summary>
        /// Adds the specified CarModel object to the store
        /// </summary>
        /// <param name="carModel"></param>
        public CarModel Add(CarModelViewModel carModelViewModel)
        {
            if (carModelViewModel == null)
                throw new ArgumentNullException();

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            CarModel carModel = null;
            
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "INSERT INTO Models (Model_Name) output INSERTED.ID VALUES (@Name)";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = carModelViewModel.ModelName;

                myConnection.Open();
                var id = (int)oCmd.ExecuteScalar();
                myConnection.Close();

                carModel = new CarModel(id, carModelViewModel.ModelName);
            }
            return carModel;
        }

        /// <summary>
        /// Deletes the specified CarModel object from the store
        /// </summary>
        /// <param name="carModel"></param>
        /// <returns>The number of objects deleted</returns>
        public int Delete(CarModel carModel)
        {
            if (carModel == null)
                throw new ArgumentNullException();

            var rowsAffected = 0;

            if (carModel.Id <= 0)
                return rowsAffected;

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "DELETE FROM Models WHERE Id=@id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = carModel.Id;

                myConnection.Open();
                rowsAffected = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return rowsAffected;
        }

        /// <summary>
        /// Returnes all the CarModel objects in the store
        /// </summary>
        /// <returns></returns>
        public List<CarModel> GetAll()
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var models = new List<CarModel>();
            
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT * FROM Models";
                var oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var model = new CarModel((int)oReader["Id"], oReader["Model_Name"].ToString());
                        models.Add(model);
                    }

                    myConnection.Close();
                }
            }
            return models;
        }

        public CarModel Find(int id)
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var models = new List<CarModel>();
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT * FROM Models WHERE Id = @Id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var model = new CarModel((int)oReader["Id"], oReader["Model_Name"].ToString());
                        models.Add(model);
                    }

                    myConnection.Close();
                }
            }
            return models.FirstOrDefault();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public class ModelRepository : IModelRepository
    {
        /// <summary>
        /// Adds the specified Model object to the store
        /// </summary>
        /// <param name="model"></param>
        public void Add(Model model)
        {
            if (model == null)
                throw new ArgumentNullException();

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "INSERT INTO Models (Model_Name) output INSERTED.ID VALUES (@Name)";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = model.Name;

                myConnection.Open();
                model.Id = (int)oCmd.ExecuteScalar();
                myConnection.Close();
            }
        }

        /// <summary>
        /// Deletes the specified Model object from the store
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The number of objects deleted</returns>
        public int Delete(Model model)
        {
            if (model == null)
                throw new ArgumentNullException();

            var rowsAffected = 0;

            if (model.Id <= 0)
                return rowsAffected;

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "DELETE FROM Models WHERE Id=@id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = model.Id;

                myConnection.Open();
                rowsAffected = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return rowsAffected;
        }

        /// <summary>
        /// Returnes all the Model objects in the store
        /// </summary>
        /// <returns></returns>
        public List<Model> GetAll()
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var models = new List<Model>();
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT * FROM Models";
                var oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var model = new Model(oReader["Model_Name"].ToString()) { Id = (int)oReader["Id"] };
                        models.Add(model);
                    }

                    myConnection.Close();
                }
            }
            return models;
        }

        public Model Find(int id)
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var models = new List<Model>();
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
                        var model = new Model(oReader["Model_Name"].ToString()) { Id = (int)oReader["Id"] };
                        models.Add(model);
                    }

                    myConnection.Close();
                }
            }
            return models.FirstOrDefault();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StampedeMotor.Models;

namespace StampedeMotor.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        public void Add(Make make)
        {
            if(make == null)
                throw new ArgumentNullException();

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "INSERT INTO Makes (Make_Name) output INSERTED.ID VALUES (@Name)";
                var oCmd = new SqlCommand(oString, myConnection);
                
                oCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = make.Name;
                
                myConnection.Open();
                make.Id = (int) oCmd.ExecuteScalar();
                myConnection.Close();
            }
        }

        /// <summary>
        /// Deletes the specified object from the store
        /// </summary>
        /// <param name="make"></param>
        /// <returns>The number of objects deleted</returns>
        public int Delete(Make make)
        {
            if(make == null)
                throw new ArgumentNullException();

            var rowsAffected = 0;

            if (make.Id <= 0)
                return rowsAffected;

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();
            
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "DELETE FROM Makes WHERE Id=@id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = make.Id;

                myConnection.Open();
                rowsAffected = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return rowsAffected;
        }

        public List<Make> GetAll()
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var makes = new List<Make>();
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT * FROM Makes";
                var oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var make = new Make(oReader["Make_Name"].ToString()) {Id = (int) oReader["Id"]};
                        makes.Add(make);
                    }

                    myConnection.Close();
                }
            }
            return makes;
        }

        public Make Find(int id)
        {
            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();

            var makes = new List<Make>();
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "SELECT * FROM Makes WHERE Id = @Id";
                var oCmd = new SqlCommand(oString, myConnection);

                oCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                myConnection.Open();
                using (var oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var make = new Make(oReader["Make_Name"].ToString()) { Id = (int)oReader["Id"] };
                        makes.Add(make);
                    }

                    myConnection.Close();
                }
            }
            return makes.FirstOrDefault();
        }
    }
}
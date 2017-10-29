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
        /// <summary>
        /// Adds a new Make from a viewModel to the object store and returns the new Make
        /// </summary>
        /// <param name="makeViewModel"></param>
        /// <returns>Make object instance</returns>
        public Make Add(MakeViewModel makeViewModel)
        {
            if(makeViewModel == null)
                throw new ArgumentNullException();

            var con = ConfigurationManager.ConnectionStrings["StampedeMotorsDB"].ToString();
            Make newMake = null;
            using (var myConnection = new SqlConnection(con))
            {
                const string oString = "INSERT INTO Makes (Make_Name) output INSERTED.ID VALUES (@Name)";
                var oCmd = new SqlCommand(oString, myConnection);
                
                oCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = makeViewModel.MakeName;
                
                myConnection.Open();
                var db_id = (int) oCmd.ExecuteScalar();
                myConnection.Close();
                newMake = new Make(db_id, makeViewModel.MakeName);
            }
            return newMake;
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
        /// <summary>
        /// Gets all Makes from the object store
        /// </summary>
        /// <returns>List of Makes</returns>
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
                        var make = new Make((int)oReader["Id"], oReader["Make_Name"].ToString());
                        makes.Add(make);
                    }

                    myConnection.Close();
                }
            }
            return makes;
        }
        /// <summary>
        /// returns the Make object identified by the specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Make</returns>
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
                        var make = new Make((int)oReader["Id"], oReader["Make_Name"].ToString());
                        makes.Add(make);
                    }

                    myConnection.Close();
                }
            }
            return makes.FirstOrDefault();
        }
    }
}
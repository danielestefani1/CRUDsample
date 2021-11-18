using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace pastic
{
    class cakes
    {
        // allow the usage for variables within the class
        private static string myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        //method to return the value of cakeID variable and other data
        private string cakeID { get; set; }
        public string cakeName { get; set; }
        public string cakePrice { get; set; }
        public string cakeIngredients { get; set; }
        public string cakeQuantity { get; set; }

        private const string SelectQuery = "Select * from bakery";
        private const string InsertQuery = "insert into";
        private const string UpdateQuery = "update cake details";
        private const string DeleteQuery = "delete cake details";
        internal DataTable DataSource;

        //opens the database pasticceria from SSMS
        public DataTable GetDolci()
        {

            //bridge betewwn dataset and the data source
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using(SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        
        public bool Insertcakes (cakes Cakes)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@cakeID", Cakes.cakeID);
                    com.Parameters.AddWithValue("@cakeName", Cakes.cakeName);
                    com.Parameters.AddWithValue("@cakePrice", Cakes.cakePrice);
                    com.Parameters.AddWithValue("@cakeIngredients", Cakes.cakeIngredients);
                    com.Parameters.AddWithValue("@cakeQuantity", Cakes.cakeQuantity);
                    rows = com.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool Updatecakes(cakes Cakes)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@cakeID", Cakes.cakeID);
                    rows = com.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool Deletecakes(cakes Cakes)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@cakeID", Cakes.cakeID);
                    rows = com.ExecuteNonQuery();
                }
                return (rows > 0) ? true : false;
            }
        }
        
    }
}

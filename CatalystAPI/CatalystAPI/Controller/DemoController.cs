using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalystAPI.Controller
{
    public class DemoController : ApiController
    {
        public string Get()
        {
            string userName = string.Empty;
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings["CatalystDBConnectionString"].ConnectionString))
            using (SqlCommand command = new SqlCommand("select Name from Demo where ID = 1", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userName = reader["Name"].ToString();
                    }
                }
            }
            return "Welcome "+ userName;
        }
    }
}

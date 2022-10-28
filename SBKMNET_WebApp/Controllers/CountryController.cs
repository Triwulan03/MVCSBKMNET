using Microsoft.AspNetCore.Mvc;
using SBKMNET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SBKMNET_WebApp.Controllers
{
    public class CountryController : Controller
    {
        SqlConnection sqlConnection;


        string connectionString = "Data Source = LAPTOP-LHIHGK76\\MSSQLEXPRESS;Initial Catalog = SIBKMNET;" +
                "User ID=sibkmnet;Password=1234567890;Connect Timeout=30;";
        // GET ALL
        // GET
        public IActionResult Index()
        {
            string query = "SELECT * FORM Country";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            List<Country> Countries = new List<Country>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.HasRows)
                        {
                            Country country = new Country();
                            country.Id = Convert.ToInt32(sqlDataReader[0]);
                            country.Name = sqlDataReader[1].ToString();
                            Countries.Add(country);        
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return View(Countries);
        }
        

        // GET BY ID
        // GET

        // CREATE
        // GET
        // POST

        // UPDATE
        // GET
        // POST

        // DELETE
        // GET
        // POST

    }
}

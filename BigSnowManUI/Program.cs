using System;
using BigSnowManLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BigSnowManUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            PersonModel person = new PersonModel
            {
                FirstName = "Frank",
                LastName = "Berrocal",
                Age = 35
            };

            


            System.Console.WriteLine($"{person.FirstName} {person.LastName} is my name, and my age is {person.Age}");

            */
            //testing connection
            /*
            string connectionString =
                "Data Source =  (localhost/1433); Initial Catalog = AP" + "Integrated Security = true";

            string queryString = 
                "SELECT animalID, animalName, animalEats FROM AP.dbo.animal";

            using(System.Data.SqlClient.SqlConnection connection = 
                    new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        System.Data.SqlClient.SqlCommand command = 
                            new System.Data.SqlClient.SqlCommand(queryString, connection);
                        string test = connection.ToString();
                        try
                        {
                            connection.Open();
                            System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
                            while(reader.Read())
                            {
                                System.Console.WriteLine("\t{0}\t{1}\t{2}",
                                    reader[0], reader[1], reader[2]);
                            }    
                            reader.Close();    
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("Connection failed " + ex.Message);
                        }
                        Console.ReadLine();
                    }


           */

            //Code from internet, working perfectly fine!
            //https://www.microsoft.com/en-us/sql-server/developer-get-started/csharp/macos/step/2.html
           
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "localhost";   // update me
                    builder.UserID = "sa";              // update me
                    builder.Password = "myPassw0rd";      // update me
                    builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    String sql = "USE AP;";


                    using (System.Data.SqlClient.SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("selection of AP DB.");
                    }

                    StringBuilder sb = new StringBuilder(); 

                    Console.WriteLine("Select all from Vendors table, press any key to continue...");

                    sb.Append("SELECT VendorID, VendorName, VendorCity FROM Vendors;");
                    sql = sb.ToString();


                    Console.ReadKey(true);
                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} - {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                }
                            }
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }


                    //read from invoices


                    sb.Clear();

                    sql = "USE AP;";


                    using (System.Data.SqlClient.SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("selection of AP DB.");
                    }

                    sb = new StringBuilder(); 

                    Console.WriteLine("Select all from Vendors table, press any key to continue...");

                    sb.Append("SELECT VendorID, VendorName, VendorCity FROM Vendors;");
                    sql = sb.ToString();


                    Console.ReadKey(true);
                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} - {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                }
                            }
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                    

                    

                }

                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            

            
            

            
           

        }
    }
}
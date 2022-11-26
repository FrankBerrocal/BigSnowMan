using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;



namespace BigSnowManUI
{
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {


                //Question 1
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1440";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "myPassw0rd";      // update me
                builder.InitialCatalog = "master";



                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    String sql = "USE Ulysses;";

                    //question 2
                    using (System.Data.SqlClient.SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("selection of AP DB.");
                    }


                    StringBuilder sb = new StringBuilder();

                    //Connection Test
                    //Get information from Vendors via Select

                    Console.WriteLine("\n\nSelect all from Role table, press any key to continue...");

                    sb.Append("SELECT RL_Role_ID AS Role, RL_Role_Description AS Description FROM RL_Role_tbl;");
                    sql = sb.ToString();


                    Console.ReadKey(true);
                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                Console.WriteLine("{0}\t {1}", reader.GetName(0), reader.GetName(1));


                                while (reader.Read())
                                {
                                    Console.WriteLine("{0}\t\t {1}", reader.GetInt32(0), reader.GetString(1));
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

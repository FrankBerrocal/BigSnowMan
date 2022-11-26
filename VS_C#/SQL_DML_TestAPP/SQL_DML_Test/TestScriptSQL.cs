using System;
using System.Text;
using System.Data.SqlClient;


namespace TestSQLScript
{
    class Connection
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Connect to SQL Server and demo Create, Read, Update and Delete operations.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1440";   
                builder.UserID = "sa";              
                builder.Password = "myPassw0rd";      
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Close();
                    connection.Open();
                    Console.WriteLine("Connection Open.");

                    //crear la base de
                    String sql = "";
                    StringBuilder sb = new StringBuilder();
                    /*
                    sb.Append("DROP DATABASE IF EXISTS [TestDB2];");
                    sb.Append("CREATE DATABASE [TestDB2];");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " database created");
                    }*/


                    //alterar las caracteristicas de la base de datos.
                    Console.Write("Alter Database");
                    sb.Clear();
                    sb.Append("USE TestDB; ");

                    sb.Append("ALTER DATABASE CURRENT");
                    sb.Append("     SET RECOVERY SIMPLE, ");
                    sb.Append("     ANSI_NULLS ON,  ");
                    sb.Append("     ANSI_PADDING ON, ");
                    sb.Append("     ANSI_WARNINGS ON, ");
                    sb.Append("     ARITHABORT ON,  ");
                    sb.Append("     CONCAT_NULL_YIELDS_NULL ON,  ");
                    sb.Append("     QUOTED_IDENTIFIER ON,  ");
                    sb.Append("     NUMERIC_ROUNDABORT OFF,  ");
                    sb.Append("     PAGE_VERIFY CHECKSUM,   ");
                    sb.Append("     ALLOW_SNAPSHOT_ISOLATION OFF;  ");
                    //sb.Append("GO ");  This is T-SQL especific.  Cannot be used in SQLClient. SqlException (0x80131904): Incorrect syntax near 'GO'.
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Database has been Altered");
                    }





     
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done.");

        }
    }
}
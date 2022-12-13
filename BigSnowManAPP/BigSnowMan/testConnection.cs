using System;
using System.Text;
using System.Data.SqlClient;

//this dont belong to the project, reference only.
namespace SqlServerSample
{
    class Program2
    {
        static void Maintest(string[] args)
        {
            try
            {


                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(); //Connection builder
                builder.DataSource = "localhost, 1440"; //parameter
                builder.UserID = "sa";   //parameter
                builder.Password = "myPassw0rd";  //parameter
                builder.InitialCatalog = "master";  //parameter


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Close();
                    connection.Open();
                    Console.WriteLine("Connection Open.");






                    //************************************************esto es codigo adicional 
                    /*
                    String sql = "";
                    StringBuilder sb = new StringBuilder();

                    sb.Append("DROP DATABASE IF EXISTS [Ulysses];");
                    sb.Append("CREATE DATABASE [Ulysses];");

                    
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))  //Aqui uso Connection de nuevo.
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " database created");
                    }

                    //objeto tipo createTable, padre objetoDB
                    Console.Write("Creating table Projects");
                    sb.Clear();
                    sb.Append("USE Ulysses; ");
                    sb.Append("IF OBJECT_ID('Projects') IS NOT NULL ");
                    sb.Append("Drop Table dbo.Projects;");

                    sb.Append("CREATE TABLE Projects( ");
                    sb.Append("     Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL , ");
                    sb.Append("     Name NVARCHAR(50), ");
                    sb.Append("     Location NVARCHAR(50) ");
                    sb.Append("); ");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " table created");
                    }



                    //objeto tipo insert de una linea, padre objetoDB
                    Console.WriteLine("Inserting new row");
                    sb.Clear();
                    sb.Append("INSERT Projects(Name, Location) ");
                    sb.Append("VALUES (@name, @location);");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", "Redrum2");
                        command.Parameters.AddWithValue("@location", "Turquia");


                        //validation, not required.  Execute the query and save result in variable
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted");
                    }


                    //objeto tipo insert de varias lineas, padre objetoDB
                    sb.Clear();
                    Console.WriteLine("Inserting several rows");
                    sb.Append("INSERT INTO Projects (Name, Location) VALUES ");
                    sb.Append("(N'Optimus', N'Australia'), ");
                    sb.Append("(N'Nikita', N'India'), ");
                    sb.Append("(N'LaserBeak', N'Germany'), ");
                    sb.Append("(N'Lucy', N'United States'); ");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted");
                    }

                    //objeto tipo update, padre objetoDB
                    sb.Clear();
                    Console.WriteLine("Upate record");
                    String projectToUpdate = "Nikita";
                    sb.Append("UPDATE Projects SET Location = N'Costa Rica' WHERE Name = @name");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", projectToUpdate);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated");
                    }


                    //objeto tipo update, padre objetoDB
                    sb.Clear();
                    Console.WriteLine("Delete record");
                    String projectToDelete = "Lucy";
                    sb.Append("DELETE FROM Projects WHERE Name = @name;");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", projectToDelete);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) deleted");
                    }



                    //object tipo select, padre displayDB
                    sb.Clear();
                    Console.WriteLine("Select all Records");
                    sql = "SELECT Id, Name, Location FROM Projects;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0}\t\t\t {1}\t\t {2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                            while (reader.Read())
                            {

                                Console.WriteLine("{0}\t\t {1}\t\t {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }




                    */

                    //**********************************************************************  Hasta aqui el codigo adicional.
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
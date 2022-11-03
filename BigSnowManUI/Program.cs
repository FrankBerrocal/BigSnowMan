using System;
using BigSnowManLibrary;
using System.Data;
using System.Data.SqlClient;

namespace BigSnowManUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel
            {
                FirstName = "Frank",
                LastName = "Berrocal",
                Age = 35
            };

            System.Console.WriteLine("hello world!");


            System.Console.WriteLine($"{person.FirstName} {person.LastName} is my name, and my age is {person.Age}");


            //testing connection
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


           


        }
    }
}
/*****************************************************************
 * Project Management Office Evaluation System (Prototype)       
 * PMOES                                                                               
 *                                                                                           
 * Final Project                                                                                                                                       
 *                                                                                            
 * Frank Berrocal - 427887                                                      
 * SODV2202 - Object Oriented Programming                            
 * Prof.  Dr. Sohaib Bajwa                                                         
 *                                
 * 
 * Bow Valley College
 * December 2022
 ******************************************************************/


using System;
using System.Text;
using System.Data.SqlClient;

namespace SQLConnectionBuilder
{
	public class ConnectionBuilder
	{
		public ConnectionBuilder(string _dataSource, string _userID, string _pass, string _catalog)
		{
			try
			{
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _dataSource;
                builder.UserID = _userID;
                builder.Password = _pass;
                builder.InitialCatalog = _catalog;

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Close();
                    connection.Open();
                    Console.WriteLine("Connection Open.");
                }

             }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
	}
}


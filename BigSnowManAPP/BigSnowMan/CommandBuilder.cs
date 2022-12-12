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
using System.Data.Common;
using System.Data;
using System.Reflection.PortableExecutable;


namespace CommandBuilderObject
{
	public class CommandBuilder
	{
        private SqlConnection Connection;
		private String SQL;
		private List<SqlCommand> Statements;
		private SqlCommand Command;
		private StringBuilder SB;
        private String ConnectionString;
        SqlDataReader reader;



        public CommandBuilder()
		{
			
		}



        public CommandBuilder(String _sql, SqlConnection _connection, StringBuilder _sb, List<SqlCommand> _statements)
        {
            Connection = _connection;
            SQL = _sql;
			SB = _sb;
			Statements = _statements;
        }

        public void createCommandBuilderBasic(String _sql, SqlConnection _connection, StringBuilder _sb, string _connectionString)
        {
            Connection = _connection;
            SQL = _sql;
            SB = _sb;
            ConnectionString = _connectionString;
        }


        public void createDML()
		{

            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            ValidateConnection(Connection, "user");

            SB.Append("SELECT PJ_Project_ID, PJ_Project_Name, PJ_Project_Description ");
            SB.Append("     FROM PJ_Project_tbl; ");
            SQL = SB.ToString();
			Command = new SqlCommand(SQL, Connection);

			using (Command)
			{
                try
                {
                    int rowsAffected = Command.ExecuteNonQuery();
                    if(rowsAffected == -1)
                        rowsAffected = 1;
                    Console.WriteLine(rowsAffected + " elements affected");
                }
			    catch(SqlException e)
                {
                    Console.WriteLine("SQL Error in createDML " +e.Message);
                }

			}
		}


		//select specific elements from the table Project (id, name, description)
        public void selectDMLTableProjectQuery()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            ValidateConnection(Connection, "user");

            SB.Append("SELECT PJ_Project_ID, PJ_Project_Name, PJ_Project_Description ");
            SB.Append("     FROM PJ_Project_tbl; ");
            SQL = SB.ToString();
            Command = new SqlCommand(SQL, Connection);

            using (Command)
            {
                reader = Command.ExecuteReader();
                try  //exclusive object, each select depends on the number of rows returned.
                {
                    Console.WriteLine("{0}\t\t\t {1}\t\t {2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t\t {1}\t\t {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Command error " + e.Message);
                }
            }
        }

        private static void ValidateConnection(SqlConnection _connection, string _userID)
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine(_userID + " connection ok");
            }
            else if (_connection.State == System.Data.ConnectionState.Closed)
            {
                Console.WriteLine(_userID + " connection closed");
            }
            else if (_connection.State == System.Data.ConnectionState.Broken)
            {
                Console.WriteLine(_userID + " connection borken");
            }
        }
    }
}

/*
 * 
 * All SQLCommands provide a different structure to access SQL CRUD commands.
 * Even for a select, the number of tables will vary.  
 * For this exercise, it is assumed all queries have been preprogrammed.
 * In future iterations I will explore a dynamic way to create all the variable commands in Insert, Update, and Select.
 * 
 * Reference
 * Connection state:  https://stackoverflow.com/questions/18809537/sql-server-connection-gets-closed
 * 
 * 
 */


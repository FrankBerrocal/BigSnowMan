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
using BigSnowMan;
using Status;
using Tool;
using Project;
using System.Data.SqlTypes;

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
        private ToolObject CostReport;


        public CommandBuilder(String _sql, SqlConnection _connection, StringBuilder _sb, string _connectionString)
		{
            Connection = _connection;
            SQL = _sql;
            SB = _sb;
            ConnectionString = _connectionString;
        }

        public CommandBuilder(String _sql, SqlConnection _connection, StringBuilder _sb, List<SqlCommand> _statements)
        {
            Connection = _connection;
            SQL = _sql;
			SB = _sb;
			Statements = _statements;
        }

        public void insertDMLTableProjectQuery(string _name,
                                                                    string _desc,
                                                                    DateTime _startDate,
                                                                    DateTime _expEndDate,
                                                                    DateTime _realEndDate,
                                                                    Dictionary<OptionObject<string>, int> _status,
                                                                    int _statusID,
                                                                    Dictionary<OptionObject<string>, int> _type,
                                                                    int _typeID,
                                                                    Dictionary<OptionObject<string>, int> _toolType,
                                                                    int _toolTypeId,
                                                                    Dictionary<OptionObject<string>, int> _toolKA,
                                                                    int _toolKAid)
		{

            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            ValidateConnection(Connection, "user");

            SB.Clear();
            SB.Append("USE Ulysses; ");
            SB.Append("INSERT Project.PJ_Project_tbl ( ");
            SB.Append("                         PJ_Project_Name, PJ_Project_Description, PJ_Project_StartDate, ");
            SB.Append("                         PJ_Project_ExpectedEndDate, PJ_Project_RealEndDate, ");
            SB.Append("                         PJ_Project_ST_Status_ID, PJ_Project_PT_ProjectType_ID ) VALUES ");
            SB.Append("                         (@_name, @_desc, @_startDate, @_expEndDate, @_realEndDate, @_statusID, @_typeID); ");
            SQL = SB.ToString();
			Command = new SqlCommand(SQL, Connection);

			using (Command)
			{
                try
                {
                    Command.Parameters.Add("@_name", SqlDbType.VarChar).Value = _name;

                    Command.Parameters.Add("@_desc", SqlDbType.VarChar).Value = _desc;

                    Command.Parameters.Add("@_startDate", SqlDbType.DateTime).Value = _startDate;

                    Command.Parameters.Add("@_expEndDate", SqlDbType.Date).Value = _expEndDate;

                    Command.Parameters.Add("@_realEndDate", SqlDbType.Date).Value=  _realEndDate;

                    //Command.Parameters.Add("@_CostReport", SqlDbType.Int).Value = 0;   //this should be retrieved from SQL, after Cost Report has been created.  Egg and Chicken.

                    Command.Parameters.Add("@_statusID", SqlDbType.Int).Value = _statusID;

                    Command.Parameters.Add("@_typeID", SqlDbType.Int).Value = _typeID;

                    int rowsAffected = Command.ExecuteNonQuery();
                    if(rowsAffected == -1)
                        rowsAffected = 1;
                    Console.WriteLine(rowsAffected + " elements affected");
                }
			    catch(SqlException e)
                {
                    Console.WriteLine("SQL Error in insertDMLTableProjectQuery() " + e.Message);
                }


			}
            //reproduction of object and information in C#, same structure as SQL.
            ProjectObject Proyecto = new ProjectObject(_name,
                                                                                _desc,
                                                                                _startDate,
                                                                                _expEndDate,
                                                                                _realEndDate,
                                                                                _status,
                                                                                _statusID,
                                                                                _type,
                                                                                _typeID,
                                                                                _toolType,
                                                                                _toolTypeId,
                                                                                _toolKA,
                                                                                _toolKAid);
            
            Console.WriteLine("\n\n"+Proyecto.ProjectInfoDisplay() +"\n\n");  //project information display, same information as in Database.
            //The system acts as a backup for the information on the database.
        }


        //select specific elements from the table Project (id, name, description)
        public void selectDMLTableProjectQuery( )
 
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            ValidateConnection(Connection, "user");

            
            SB.Clear();
            SB.Append("USE Ulysses; ");
            SB.Append("SELECT PJ_Project_ID AS 'Project ID', PJ_Project_Name AS 'Project Name', PJ_Project_Description AS Description, PJ_Project_StartDate as Start  ");
            SB.Append("     FROM Project.PJ_Project_tbl; ");
            SQL = SB.ToString();
            Command = new SqlCommand(SQL, Connection);

            using (Command)
            {
                reader = Command.ExecuteReader();
                try  //exclusive object, each select depends on the number of rows returned.
                {
                    Console.WriteLine("{0}\t\t\t {1}\t\t {2}\t\t\t\t\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t\t\t {1}\t\t{2}\t\t{3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2),  reader.GetDateTime(3));
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Command error " + e.Message);
                }
            }
            Connection.Close();
        }

        //select specific elements from the table Project (id, name, description)
        public void selectDMLTableKnowledgeAreaQuery()

        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            ValidateConnection(Connection, "user");


            SB.Clear();
            SB.Append("USE Ulysses; ");
            SB.Append("SELECT KA_KnowledgeArea_ID AS ID, KA_KnowledgeArea_Description AS 'Knowledge Areas' ");
            SB.Append("     FROM Project.KA_KnowledgeArea_tbl; ");
            SQL = SB.ToString();
            Command = new SqlCommand(SQL, Connection);

            using (Command)
            {
                reader = Command.ExecuteReader();
                try  //exclusive object, each select depends on the number of rows returned.
                {
                    Console.WriteLine("\t{0}\t\t\t {1}", reader.GetName(0), reader.GetName(1));
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t\t\t {1}", reader.GetInt32(0), reader.GetString(1));
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
 * Date parse error, and Add method extension https://learn.microsoft.com/en-us/answers/questions/307663/failed-to-convert-parameter-value-from-a-datetimeo.html
 * 
 */


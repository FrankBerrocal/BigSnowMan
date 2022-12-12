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

namespace ConnectionBuilderObject
{
	public class ConnectionBuilder
	{

        private string DataSource;
        private string UserID;
        private string Password;
        private string InitialCatalog;
        public SqlConnectionStringBuilder Builder;
        public SqlConnection Connection;
        string BuilderString;

        public ConnectionBuilder(    string _dataSource,
                                                string _userID,
                                                string _pass,
                                                string _catalog)
		{
            DataSource = _dataSource;
            UserID = _userID;
            Password = _pass;
            InitialCatalog = _catalog;
        }

        public SqlConnection createConnection()
        {

                Builder = new SqlConnectionStringBuilder();
                Builder.DataSource = DataSource;
                Builder.UserID = UserID;
                Builder.Password = Password;
                Builder.InitialCatalog = InitialCatalog;
                
                BuilderString = Builder.ConnectionString;
                Connection = new SqlConnection(BuilderString);

                 return Connection;

        }

        public SqlConnection getConnection
        {
            get => Connection;
        }

        public string getBuilderString
        {
            get => BuilderString;
        }


	}
}
/*
 * 
 * 
 * 
 * References
 * SQLConnection class: https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection?view=dotnet-plat-ext-7.0
 * 
 */
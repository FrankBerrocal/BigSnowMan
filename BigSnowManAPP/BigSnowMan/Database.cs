using System;
using System.Data.SqlClient;
using System.Text;

public class Database
{
	public Database()
	{
        Console.WriteLine("test");
        Connection();
	}

        //static void Main(string[] args)
        static void Connection()
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
                    Console.WriteLine("Connection Open.\n");


                    //Block #:   Database setting up

                    //create database
                    String sql = "";
                    StringBuilder sb = new StringBuilder();



                    sb.Append("DROP DATABASE IF EXISTS [Ulysses];");
                    sb.Append("CREATE DATABASE [Ulysses];");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " database created\n");
                    }

                    //Block #:  Altering Database structure

                    //alter the main elements of the database, full backup and snapshot isolation enabled.
                    Console.Write("Alter Database");
                    databaseSelection();  //sb.Append("USE Ulysses; ");
                    sb.Clear();

                    sb.Append("ALTER DATABASE CURRENT");
                    sb.Append("     SET RECOVERY FULL, ");
                    sb.Append("     ANSI_NULLS ON,  ");
                    sb.Append("     ANSI_PADDING ON, ");
                    sb.Append("     ANSI_WARNINGS ON, ");
                    sb.Append("     ARITHABORT ON,  ");
                    sb.Append("     CONCAT_NULL_YIELDS_NULL ON,  ");
                    sb.Append("     QUOTED_IDENTIFIER ON,  ");
                    sb.Append("     NUMERIC_ROUNDABORT OFF,  ");
                    sb.Append("     PAGE_VERIFY CHECKSUM,   ");
                    sb.Append("     ALLOW_SNAPSHOT_ISOLATION ON;  ");
                    //sb.Append("GO ");  This is T-SQL especific.  Cannot be used in SQLClient. SqlException (0x80131904): Incorrect syntax near 'GO'.
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Database has been Altered\n");
                    }

                    //Block #:  DBA creation

                    sb.Append("USE master; ");
                    sb.Append("IF OBJECT_ID('PMOES_dbadmin') IS NOT NULL ");
                    sb.Append("DROP LOGIN PMOES_dbadmin; ");

                    Console.Write("Creation of Database admin user\n");



                    sb.Append("CREATE LOGIN PMOES_dbadmin WITH PASSWORD=N'Lucy!nth3_5ky', ");
                    sb.Append("DEFAULT_DATABASE = Ulysses; ");
                    sb.Append("EXEC master..sp_addsrvrolemember @loginame = N'PMOES_dbadmin', @rolename = N'sysadmin'; ");
                    sb.Append("CREATE USER JBenton FOR LOGIN PMOES_dbadmin; ");



                    //Block #:  creation of schemas

                    //creation of schema, should be the first statment of a query. Appending of USE substituted.


                    databaseSelection();
                    sb.Clear();
                    sb.Append("CREATE SCHEMA Calculation AUTHORIZATION dbo; ");  //authorization should be replaced with dba

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Calculation schema created");
                    }
                    //Creation of schemas and Command should be abstracted, user should be replaced
                    sb.Clear();
                    sb.Append("CREATE SCHEMA Project AUTHORIZATION dbo; ");  //authorization should be replaced with dba

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection)) //This definition of SQLCommand should be an object.
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Project schema created");
                    }

                    sb.Clear();
                    sb.Append("CREATE SCHEMA Cost AUTHORIZATION dbo; ");

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Cost schema created");
                    }



                    sb.Clear();
                    sb.Append("CREATE SCHEMA Scope AUTHORIZATION dbo; ");

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Scope schema created");
                    }


                    sb.Clear();
                    sb.Append("CREATE SCHEMA Schedule AUTHORIZATION dbo; ");

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Schedule schema created");
                    }

                    sb.Clear();
                    sb.Append("CREATE SCHEMA Stakeholders AUTHORIZATION dbo; ");

                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Schedule schema created");
                    }







                    //Block #:   Cost Variance *************************************************************

                    //COST VARIANCE TABLE, PRIMARY TABLE, CALCULATION TYPE===-
                    Console.Write("Create table CostVariance under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.CV_CostVariance_tbl') IS NOT NULL ");

                    sb.Append("Drop Table Calculation.CV_CostVariance_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.CV_CostVariance_tbl( ");
                    sb.Append("     CV_CostVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     CV_CostVariance_Date DATE NOT NULL, ");
                    sb.Append("     CV_CostVariance_EarnedValue FLOAT NOT NULL, ");
                    sb.Append("     CV_CostVariance_ActualCost FLOAT NOT NULL, ");
                    sb.Append("     CV_CostVariance_Value FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_CV_CostVariance_tbl_CostVariance_Date ");
                    sb.Append(" ON Calculation.CV_CostVariance_tbl (CV_CostVariance_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_CV_CostVariance_tbl_CostVariance_Value ");
                    sb.Append("ON Calculation.CV_CostVariance_tbl (CV_CostVariance_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //all This tables should be created as individual objects to make it easier to mantain them.
                    //Block #:   Schedule Variance *************************************************************

                    //SCHEDULE VARIANCE, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Schedule Variance under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.SV_ScheduleVariance_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.SV_ScheduleVariance_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.SV_ScheduleVariance_tbl( ");
                    sb.Append("     SV_ScheduleVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     SV_ScheduleVariance_Date DATE NOT NULL, ");
                    sb.Append("     SV_ScheduleVariance_EarnedValue FLOAT NOT NULL, ");
                    sb.Append("     SV_ScheduleVariance_PlannedValue FLOAT NOT NULL, ");
                    sb.Append("     SV_ScheduleVariance_Value FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_SV_ScheduleVariance_tbl_ScheduleVariance_Date ");
                    sb.Append(" ON Calculation.SV_ScheduleVariance_tbl (SV_ScheduleVariance_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_SV_ScheduleVariance_tbl_ScheduleVariance_Value ");
                    sb.Append("ON Calculation.SV_ScheduleVariance_tbl (SV_ScheduleVariance_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Variance At Completion *************************************************************

                    //VARIANCE AT COMPLETION, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Variance At Completion under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.VAC_VarianceAtCompletion_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.VAC_VarianceAtCompletion_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.VAC_VarianceAtCompletion_tbl( ");
                    sb.Append("     VAC_VarianceAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     VAC_VarianceAtCompletion_Date DATE NOT NULL, ");
                    sb.Append("     VAC_VarianceAtCompletion_BudgetAtCompletion FLOAT NOT NULL, ");
                    sb.Append("     VAC_VarianceAtCompletion_EstimateAtCompletion FLOAT NOT NULL, ");
                    sb.Append("     VAC_VarianceAtCompletion_Value FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Date ");
                    sb.Append(" ON Calculation.VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Value ");
                    sb.Append("  ON Calculation.VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }




                    //Block #:   Cost Performance Index *************************************************************

                    //COST PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Cost Performance Index under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('CPI_CostPerformanceIndex_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.CPI_CostPerformanceIndex_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.CPI_CostPerformanceIndex_tbl( ");
                    sb.Append("     CPI_CostPerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     CPI_CostPerformanceIndex_Date DATE NOT NULL, ");
                    sb.Append("     CPI_CostPerformanceIndex_EarnedValue FLOAT NOT NULL, ");
                    sb.Append("     CPI_CostPerformanceIndex_ActualCost  FLOAT NOT NULL, ");
                    sb.Append("     CPI_CostPerformanceIndex_Value  FLOAT NOT NULL, ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Date ");
                    sb.Append(" ON Calculation.CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Value ");
                    sb.Append(" ON Calculation.CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Schedule Performance Index *************************************************************

                    //SCHEDULE PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Schedule Performance Index under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('SPI_SchedulePerformanceIndex_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.SPI_SchedulePerformanceIndex_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.SPI_SchedulePerformanceIndex_tbl( ");
                    sb.Append("     SPI_SchedulePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     SPI_SchedulePerformanceIndex_Date DATE NOT NULL, ");
                    sb.Append("     SPI_SchedulePerformanceIndex_EarnedValue FLOAT NOT NULL, ");
                    sb.Append("     SPI_SchedulePerformanceIndex_PlannedValue  FLOAT NOT NULL, ");
                    sb.Append("     SPI_SchedulePerformanceIndex_Value  FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_SPI_SchedulePerformanceIndex_tbl_SchedulePerformanceIndex_Date ");
                    sb.Append(" ON Calculation.SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_SPI_SchedulePerformanceIndex_tbl_SchedulePerformanceIndex_Value ");
                    sb.Append(" ON Calculation.SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Estimate At Completion *************************************************************

                    //ESTIMATE AT COMPLETION, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Estimate At Completion under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.EAC_EstimateAtCompletion_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.EAC_EstimateAtCompletion_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.EAC_EstimateAtCompletion_tbl( ");
                    sb.Append("     EAC_EstimateAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     EAC_EstimateAtCompletion_Date DATE NOT NULL, ");
                    sb.Append("     EAC_EstimateAtCompletion_BudgetAtCompletion FLOAT NOT NULL, ");
                    sb.Append("     EAC_EstimateAtCompletion_CostPerformanceIndex  FLOAT NOT NULL, ");
                    sb.Append("     EAC_EstimateAtCompletion_Value  FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_EAC_EstimateAtCompletion_tbl_EstimateAtCompletion_Date ");
                    sb.Append(" ON Calculation.EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_EAC_EstimateAtCompletion_tbl_EstimateAtCompletion_Value ");
                    sb.Append(" ON Calculation.EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Estimate To Complete *************************************************************

                    //ESTIMATE TO COMPLETE, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Estimate To Complete under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.ETC_EstimateToComplete_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.ETC_EstimateToComplete_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.ETC_EstimateToComplete_tbl( ");
                    sb.Append("     ETC_EstimateToComplete_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     ETC_EstimateToComplete_Date DATE NOT NULL, ");
                    sb.Append("     ETC_EstimateToComplete_EstimateAtCompletion FLOAT NOT NULL, ");
                    sb.Append("     ETC_EstimateToComplete_ActualCost  FLOAT NOT NULL, ");
                    sb.Append("     ETC_EstimateToComplete_Value  FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_ETC_EstimateToComplete_tbl_EstimateToComplete_Date ");
                    sb.Append(" ON Calculation.ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_ETC_EstimateToComplete_tbl_EstimateToComplete_Value ");
                    sb.Append(" ON Calculation.ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   To Complete Performance Index *************************************************************

                    //TO COMPLETE PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table To Complete Performance Index under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.TCPI_ToCompletePerformanceIndex_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.TCPI_ToCompletePerformanceIndex_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.TCPI_ToCompletePerformanceIndex_tbl( ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_Date DATE NOT NULL, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_BudgetAtCompletion FLOAT NOT NULL, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_EarnedValue FLOAT NOT NULL, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_ActualCost  FLOAT NOT NULL, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_Value  FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_TCPI_ToCompletePerformanceIndex_tbl_ToCompletePerformanceIndex_Date ");
                    sb.Append(" ON Calculation.TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_TCPI_ToCompletePerformanceIndex_tbl_ToCompletePerformanceIndex_Value ");
                    sb.Append(" ON Calculation.TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Total Cost *************************************************************

                    //TOTAL COST, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Total Cost under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.TC_TotalCost_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.TC_TotalCost_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.TC_TotalCost_tbl( ");
                    sb.Append("     TC_TotalCost_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     TC_TotalCost_Date DATE NOT NULL, ");
                    sb.Append("     TC_TotalCost_TotalHours FLOAT NOT NULL, ");
                    sb.Append("     TC_TotalHours_CostHour FLOAT NOT NULL, ");
                    sb.Append("     TC_TotalCost_Value FLOAT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_TC_TotalCost_tbl_TotalCost_Date ");
                    sb.Append(" ON Calculation.TC_TotalCost_tbl (TC_TotalCost_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_TC_TotalCost_tbl_TotalCost_Value ");
                    sb.Append(" ON Calculation.TC_TotalCost_tbl (TC_TotalCost_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Power/Interest *************************************************************

                    //POWER_INTEREST, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Power/Interest under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PIT_PowerInterest_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PIT_PowerInterest_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.PIT_PowerInterest_tbl( ");
                    sb.Append("     PIT_PowerInterest_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PIT_PowerInterest_Date DATE NOT NULL, ");
                    sb.Append("     PIT_PowerInterest_Power FLOAT NOT NULL, ");
                    sb.Append("     PIT_PowerInterest_Interest FLOAT NOT NULL, ");
                    sb.Append("     PIT_PowerInterest_Value INT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PIT_PowerInterest_tbl_PowerInterest_Date ");
                    sb.Append(" ON Calculation.PIT_PowerInterest_tbl (PIT_PowerInterest_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PIT_PowerInterest_tbl_PowerInterest_Value ");
                    sb.Append(" ON Calculation.PIT_PowerInterest_tbl (PIT_PowerInterest_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Power/Incfluence *************************************************************

                    //POWER_INFLUENCE, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Power/Influence under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PIT_PowerInterest_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PIT_PowerInterest_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.PIF_PowerInfluence_tbl( ");
                    sb.Append("     PIF_PowerInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PIF_PowerInfluence_Date DATE NOT NULL, ");
                    sb.Append("     PIF_PowerInfluence_Power FLOAT NOT NULL, ");
                    sb.Append("     PIF_PowerInfluence_Influence FLOAT NOT NULL, ");
                    sb.Append("     PIF_PowerInfluence_Value INT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PIF_PowerInfluence_tbl_PowerInfluence_Date ");
                    sb.Append(" ON Calculation.PIF_PowerInfluence_tbl (PIF_PowerInfluence_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PIF_PowerInfluence_tbl_PowerInfluence_Value ");
                    sb.Append(" ON Calculation.PIF_PowerInfluence_tbl (PIF_PowerInfluence_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Interest/Influence *************************************************************

                    //INTEREST_INFLUENCE, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Interest/Influence under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.II_InterestInfluence_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.II_InterestInfluence_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.II_InterestInfluence_tbl( ");
                    sb.Append("     II_InterestInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     II_InterestInfluence_Date DATE NOT NULL, ");
                    sb.Append("     II_InterestInfluence_Power FLOAT NOT NULL, ");
                    sb.Append("     II_InterestInfluence_Influence FLOAT NOT NULL, ");
                    sb.Append("     II_InterestInfluence_Value INT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_II_InterestInfluence_tbl_InterestInfluence_Date ");
                    sb.Append(" ON Calculation.II_InterestInfluence_tbl (II_InterestInfluence_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_II_InterestInfluence_tbl_InterestInfluence_Value ");
                    sb.Append(" ON Calculation.II_InterestInfluence_tbl (II_InterestInfluence_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Priority *************************************************************

                    //PRIORITY, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Priority under Calculation schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PT_Priority_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PT_Priority_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Calculation.PT_Priority_tbl( ");
                    sb.Append("     PT_Priority_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PT_Priority_Date DATE NOT NULL, ");
                    sb.Append("     PT_Priority_Value INT NOT NULL ");
                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PT_Priority_tbl_InterestInfluence_Date ");
                    sb.Append(" ON Calculation.PT_Priority_tbl (PT_Priority_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_PT_Priority_tbl_InterestInfluence_Value ");
                    sb.Append(" ON Calculation.PT_Priority_tbl (PT_Priority_Value DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Knowledge Area *************************************************************

                    //KNOWLEDGE AREA TABLE, PRIMARY TABLE, PRIMARY TABLE
                    Console.Write("Create table Knowledge Area under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.KA_KnowledgeArea_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.KA_KnowledgeArea_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.KA_KnowledgeArea_tbl( ");
                    sb.Append("     KA_KnowledgeArea_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     KA_KnowledgeArea_Description VARCHAR(50) NOT NULL ");
                    sb.Append("); ");

                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Project Type *************************************************************

                    //PROJECT TYPE, PRIMARY TABLE, REFERENCE TYPE
                    Console.Write("Create table Project Type under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.PT_ProjectType_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.PT_ProjectType_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.PT_ProjectType_tbl( ");
                    sb.Append("     PT_ProjectType_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PT_ProjectType_PJ_Project_ID INT NOT NULL ");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Status *************************************************************

                    //STATUS, PRIMARY TABLE, REFERENCE TYPE
                    Console.Write("Create table Status under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.ST_Status_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.ST_Status_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.ST_Status_tbl( ");
                    sb.Append("     ST_Status_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     ST_Status_Description VARCHAR(50) NOT NULL ");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Field *************************************************************

                    //FIELD, PRIMARY TABLE, REFERENCE TYPE
                    Console.Write("Create table Field under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Stakeholders.FD_Field_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Stakeholders.FD_Field_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Stakeholders.FD_Field_tbl( ");
                    sb.Append("     FD_Field_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     FD_Field_Description VARCHAR(50) NOT NULL ");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Role *************************************************************

                    //ROLE, PRIMARY TABLE, REFERENCE TYPE
                    Console.Write("Create table Role under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Stakeholders.RL_Role_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Stakeholders.RL_Role_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Stakeholders.RL_Role_tbl( ");
                    sb.Append("     RL_Role_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     RL_Role_Description VARCHAR(50) NOT NULL ");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }





                    //Block #:   Project Type *************************************************************

                    //PROEJCT TYPE, PRIMARY TABLE, REFERENCE TYPE
                    Console.Write("Create table Project Type under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.PT_ProjectType_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.PT_ProjectType_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.PT_ProjectType_tbl( ");
                    sb.Append("     PT_ProjectType_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PT_ProjectType_Description VARCHAR(50) NOT NULL ");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }







                    //Block #:   Cost Record *************************************************************

                    //COST RECORD, SECONDARY TABLE, RECORD TYPE
                    Console.Write("Create table Cost Record under Cost schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Cost.CRC_CostRecord_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Cost.CRC_CostRecord_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Cost.CRC_CostRecord_tbl( ");
                    sb.Append("     CRC_CostRecord_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     CRC_CostRecord_Date DATE NOT NULL, ");
                    sb.Append("     CRC_CostRecord_CV_CostVariance_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_SV_ScheduleVariance_ID INT NULL,");
                    sb.Append("     CRC_CostRecord_VAC_VarianceAtCompletion_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_CPI_CostPerformanceIndex_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_SPI_SchedulePerformanceIndex_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_EAC_EstimateAtCompletion_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_ETC_EstimateToComplete_ID INT NULL, ");
                    sb.Append("     CRC_CostRecord_TCPI_ToCompletePerformanceIndex_ID INT NULL ");

                    //foreign keys

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_CV_CostVariance_ID FOREIGN KEY (CRC_CostRecord_CV_CostVariance_ID) ");
                    sb.Append("         REFERENCES Calculation.CV_CostVariance_tbl (CV_CostVariance_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_SV_ScheduleVariance_ID FOREIGN KEY (CRC_CostRecord_SV_ScheduleVariance_ID) ");
                    sb.Append("         REFERENCES Calculation.SV_ScheduleVariance_tbl (SV_ScheduleVariance_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_VAC_VarianceAtCompletion_ID FOREIGN KEY (CRC_CostRecord_VAC_VarianceAtCompletion_ID) ");
                    sb.Append("         REFERENCES Calculation.VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_CPI_CostPerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_CPI_CostPerformanceIndex_ID) ");
                    sb.Append("         REFERENCES Calculation.CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_SPI_SchedulePerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_SPI_SchedulePerformanceIndex_ID) ");
                    sb.Append("         REFERENCES Calculation.SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_EAC_EstimateAtCompletion_ID FOREIGN KEY (CRC_CostRecord_EAC_EstimateAtCompletion_ID) ");
                    sb.Append("         REFERENCES Calculation.EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_ETC_EstimateToComplete_ID FOREIGN KEY (CRC_CostRecord_ETC_EstimateToComplete_ID) ");
                    sb.Append("         REFERENCES Calculation.ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostRecord_tbl_TCPI_ToCompletePerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_TCPI_ToCompletePerformanceIndex_ID) ");
                    sb.Append("         REFERENCES Calculation.TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION ");

                    sb.Append("); ");

                    //I need composite indexing here

                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Cost Report *************************************************************

                    //COST REPORT, SECONDARY TABLE, TOOL TYPE
                    Console.Write("Create table Cost Report under Cost schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Cost.CRP_CostReport_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Cost.CRP_CostReport_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Cost.CRP_CostReport_tbl( ");
                    sb.Append("     CRP_CostReport_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     CRP_CostReport_Date DATE NOT NULL, ");
                    sb.Append("     CRC_CostReport_PJ_Project_ID INT NOT NULL, ");
                    sb.Append("     CRC_CostReport_KA_KnowledgeArea_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("CONSTRAINT FK_CRC_CostReport_tbl_KA_KnowledgeArea_ID FOREIGN KEY (CRC_CostReport_KA_KnowledgeArea_ID)");
                    sb.Append("     REFERENCES Project.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)  ");
                    sb.Append("     ON DELETE NO ACTION");
                    sb.Append("     ON UPDATE NO ACTION");
                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Cost Report / Cost Record *************************************************************

                    //COST REPORT / COST RECORD, TERCIARY TABLE, JOIN TYPE
                    Console.Write("Create table Cost Report/ Cost Record under Cost schema\n");
                    sb.Clear();

                    databaseSelection();


                    sb.Append("IF OBJECT_ID('Cost.CRC_CostReport_CRP_CostRecord_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Cost.CRC_CostReport_CRP_CostRecord_tbl; ");


                    //table creation
                    sb.Append("CREATE TABLE Cost.CRC_CostReport_CRP_CostRecord_tbl( ");
                    sb.Append("     CRC_CostReport_CRP_CostRecord INT IDENTITY(1, 1) NOT NULL,  ");
                    sb.Append("     CRP_CostReport_ID INT NOT NULL,  ");
                    sb.Append("     CRC_CostRecord_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_CRC_CostReport_CRP_CostRecord_tbl_CRP_CostReport_ID FOREIGN KEY (CRP_CostReport_ID) ");
                    sb.Append("         REFERENCES Cost.CRP_CostReport_tbl (CRP_CostReport_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_CRC_CostReport_CRP_CostRecord_tbl_CRC_CostRecord_ID FOREIGN KEY (CRC_CostRecord_ID) ");
                    sb.Append("         REFERENCES Cost.CRC_CostRecord_tbl (CRC_CostRecord_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Work Package *************************************************************

                    //WORK PACKAGE, SECONDARY TABLE, RECORD TYPE
                    Console.Write("Create table Work Package under Scope schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Schedule.WP_WorkPackage_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Schedule.WP_WorkPackage_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Schedule.WP_WorkPackage_tbl( ");
                    sb.Append("     WP_WorkPackage_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     WP_WorkPackage_Date DATE NOT NULL, ");
                    sb.Append("     WP_WorkPackage_Level INT NOT NULL, ");
                    sb.Append("     WP_WorkPackage_WorkPackageSuperior_ID INT NULL, ");
                    sb.Append("     WP_WorkPackage_StartDate DATE NOT NULL, ");
                    sb.Append("     WP_WorkPackage_EndDate DATE NOT NULL, ");
                    sb.Append("     WP_WorkPackage_Name VARCHAR(20), ");
                    sb.Append("     WP_WorkPackage_Description VARCHAR(100), ");
                    sb.Append("     WP_WorkPackage_TC_TotalCost_ID INT NULL, ");
                    sb.Append("     WP_WorkPackage_ST_Status_ID INT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_WP_WorkPackage_tbl_TC_TotalCost_ID FOREIGN KEY (WP_WorkPackage_WorkPackageSuperior_ID) ");
                    sb.Append("         REFERENCES Calculation.TC_TotalCost_tbl (TC_TotalCost_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_WP_WorkPackage_tbl_ST_Status_ID FOREIGN KEY (WP_WorkPackage_ST_Status_ID) ");
                    sb.Append("         REFERENCES Project.ST_Status_tbl (ST_Status_ID)  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION ");

                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_WP_WorkPackage_tbl_WP_WorkPackage_Date ");
                    sb.Append("     ON Schedule.WP_WorkPackage_tbl (WP_WorkPackage_Date DESC); ");
                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_WP_WorkPackage_tbl_WP_WorkPackage_WorkPackageSuperior_ID ");
                    sb.Append("     ON Schedule.WP_WorkPackage_tbl (WP_WorkPackage_WorkPackageSuperior_ID DESC); ");




                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }



                    //Block #:   Workbreakdown Structure *************************************************************

                    //WORK BREAKDOWN STRUCTURE (WBS), PRIMARY TABLE, TOOL TYPE
                    Console.Write("Create table Workbreakdown Structure under Schedule schema\n");
                    sb.Clear();

                    databaseSelection();


                    sb.Append("IF OBJECT_ID('Schedule.WBS_WorkBreakdown_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Schedule.WBS_WorkBreakdown_tbl; ");


                    //table creation
                    sb.Append("CREATE TABLE Schedule.WBS_WorkBreakdown_tbl( ");
                    sb.Append("     WBS_WorkBreakdown_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     WBS_WorkBreakdown_DATE DATE, ");
                    sb.Append("     WBS_WorkBreakdown_PJ_Project_ID INT NOT NULL, ");
                    sb.Append("     WBS_WorkBreakdown_KA_KnowledgeArea_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_WBS_WorkBreakdown_tbl_KA_KnowledgeArea_ID FOREIGN KEY (WBS_WorkBreakdown_KA_KnowledgeArea_ID) ");
                    sb.Append("         REFERENCES Project.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Workbreakdown Structure / Work Package *************************************************************

                    //WORK BREAKDOWN WORK PACKAGE, TERCIARY TABLE, JOIN TYPE
                    Console.Write("Create table Workbreakdown Structure / Work Package under Schedule schema\n");
                    sb.Clear();

                    databaseSelection();


                    sb.Append("IF OBJECT_ID('Schedule.WBS_WorkBreakdown_WP_WorkPackage_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Schedule.WBS_WorkBreakdown_WP_WorkPackage_tbl; ");


                    //table creation
                    sb.Append("CREATE TABLE Schedule.WBS_WorkBreakdown_WP_WorkPackage_tbl( ");
                    sb.Append("     WBS_WorkBreakdown_WP_WorkPackage_ID INT IDENTITY(1, 1) NOT NULL,  ");
                    sb.Append("     WBS_WorkBreakdown_ID INT NOT NULL,  ");
                    sb.Append("     WP_WorkPackage_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_WBS_WorkBreakdown_WP_WorkPackage_tbl_WBS_WorkBreakdown_ID FOREIGN KEY (WBS_WorkBreakdown_ID) ");
                    sb.Append("         REFERENCES Schedule.WBS_WorkBreakdown_tbl (WBS_WorkBreakdown_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_WBS_WorkBreakdown_WP_WorkPackage_tbl_CRC_CostRecord_ID FOREIGN KEY (WP_WorkPackage_ID) ");
                    sb.Append("         REFERENCES Schedule.WP_WorkPackage_tbl (WP_WorkPackage_ID)  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Requirement Record *************************************************************

                    //REQUIREMENT RECORD, SECONDARY TABLE, RECORD TYPE
                    Console.Write("Create table Requirement Record under Scope schema\n");
                    sb.Clear();

                    databaseSelection();

                    sb.Append("IF OBJECT_ID('Scope.RR_RequirementRecord_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Scope.RR_RequirementRecord_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Scope.RR_RequirementRecord_tbl( ");
                    sb.Append("     RR_RequirementRecord_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     RR_RequirementRecord_DATE DATE, ");
                    sb.Append("     RR_RequirementRecord_Objective VARCHAR(100), ");
                    sb.Append("     RR_RequirementRecord_StatusDate DATE, ");
                    sb.Append("     RR_RequirementRecord_Version INT NOT NULL, ");
                    sb.Append("     RR_RequirementRecord_ST_Status_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_RR_RequirementRecord_tbl_ST_Status_ID FOREIGN KEY (RR_RequirementRecord_ST_Status_ID) ");
                    sb.Append("         REFERENCES Project.ST_Status_tbl (ST_Status_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("); ");

                    //indexing creation
                    sb.Append("CREATE NONCLUSTERED INDEX ix_RR_RequirementRecord_tbl_WP_RR_RequirementRecord_DATE ");
                    sb.Append("     ON Scope.RR_RequirementRecord_tbl (RR_RequirementRecord_DATE DESC); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Traceability Matrix *************************************************************

                    //TRACEABILITY MATRIX, SECONDARY TABLE, TOOL TYPE
                    Console.Write("Create table Traceability Matrix under Scope schema\n");
                    sb.Clear();

                    databaseSelection();

                    sb.Append("IF OBJECT_ID('Scope.TM_TraceabilityMatrix_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Scope.TM_TraceabilityMatrix_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Scope.TM_TraceabilityMatrix_tbl( ");
                    sb.Append("     TM_TraceabilityMatrix_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     TM_TraceabilityMatrix_DATE DATE, ");
                    sb.Append("     TM_Traceability_Matrix_PJ_Project_ID INT NOT NULL, ");
                    sb.Append("     TM_Traceability_Matrix_KA_KnowledgeArea_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_TM_TraceabilityMatrix_tbl_KA_KnowledgeArea_ID FOREIGN KEY (TM_Traceability_Matrix_KA_KnowledgeArea_ID) ");
                    sb.Append("         REFERENCES Project.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }


                    //Block #:   Traceability Matrix / Requirement Record *************************************************************

                    //TRACEABILITY MATRIX / REQUIREMENT RECORD, TERCIARY TABLE, JOIN TYPE
                    Console.Write("Create table Traceability Matrix / Requirement Record under Scope schema\n");
                    sb.Clear();

                    databaseSelection();


                    sb.Append("IF OBJECT_ID('Scope.TM_TraceabilityMatrix_RR_RequirementRecord_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Scope.TM_TraceabilityMatrix_RR_RequirementRecord_tbl; ");


                    //table creation
                    sb.Append("CREATE TABLE Scope.TM_TraceabilityMatrix_RR_RequirementRecord_tbl( ");
                    sb.Append("     TM_TraceabilityMatrix_RR_RequirementRecord_ID INT IDENTITY(1, 1) NOT NULL,  ");
                    sb.Append("     TM_TraceabilityMatrix_ID INT NOT NULL,  ");
                    sb.Append("     RR_RequirementRecord_ID INT NOT NULL ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_TM_TraceabilityMatrix_RR_RequirementRecord_tbl_TM_TraceabilityMatrix_ID FOREIGN KEY (TM_TraceabilityMatrix_ID) ");
                    sb.Append("         REFERENCES Scope.TM_TraceabilityMatrix_tbl (TM_TraceabilityMatrix_ID)  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_TM_TraceabilityMatrix_RR_RequirementRecord_tbl_CRC_RR_RequirementRecord_ID FOREIGN KEY (RR_RequirementRecord_ID )   ");
                    sb.Append("         REFERENCES Scope.RR_RequirementRecord_tbl (RR_RequirementRecord_ID )  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Project *************************************************************

                    //PROJECT, SECONDARY TABLE, REFERENCE TYPE
                    Console.Write("Create table  Project under Project schema\n");
                    sb.Clear();

                    databaseSelection();

                    sb.Append("IF OBJECT_ID('Project.PJ_Project_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.PJ_Project_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.PJ_Project_tbl( ");
                    sb.Append("     PJ_Project_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  ");
                    sb.Append("     PJ_Project_Name VARCHAR(20), ");
                    sb.Append("     PJ_Project_Description VARCHAR(100), ");
                    sb.Append("     PJ_Project_StartDate DATE NOT NULL, ");
                    sb.Append("     PJ_Project_ExpectedEndDate DATE NOT NULL, ");
                    sb.Append("     PJ_Project_RealEndDate DATE NOT NULL, ");

                    sb.Append("     PJ_Project_CRP_CostReport_ID INT NULL, ");
                    sb.Append("     PJ_Project_WBS_WorkBreakdown_ID INT NULL, ");
                    sb.Append("     PJ_Project_TM_TraceabilityMatrix_ID INT NULL, ");
                    sb.Append("     PJ_Project_ST_Status_ID INT NOT NULL, ");
                    sb.Append("     PJ_Project_PT_ProjectType_ID INT NOT NULL, ");

                    //foreign keys
                    sb.Append("     CONSTRAINT FK_PJ_Project_tbl_CRP_CostReport_ID FOREIGN KEY (PJ_Project_CRP_CostReport_ID) ");
                    sb.Append("         REFERENCES Cost.CRP_CostReport_tbl (CRP_CostReport_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_PJ_Project_tbl_WBS_WorkBreakdown_ID FOREIGN KEY (PJ_Project_WBS_WorkBreakdown_ID) ");
                    sb.Append("         REFERENCES Schedule.WBS_WorkBreakdown_tbl (WBS_WorkBreakdown_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_PJ_Project_tbl_TM_TraceabilityMatrix_ID FOREIGN KEY (PJ_Project_TM_TraceabilityMatrix_ID) ");
                    sb.Append("         REFERENCES Scope.TM_TraceabilityMatrix_tbl (TM_TraceabilityMatrix_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_PJ_Project_tbl_ST_Status_ID  FOREIGN KEY (PJ_Project_ST_Status_ID) ");
                    sb.Append("         REFERENCES Project.ST_Status_tbl (ST_Status_ID) ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION, ");

                    sb.Append("     CONSTRAINT FK_PJ_Project_tbl_PT_ProjectType_ID  FOREIGN KEY (PJ_Project_PT_ProjectType_ID) ");
                    sb.Append("         REFERENCES Project.PT_ProjectType_tbl (PT_ProjectType_ID)  ");
                    sb.Append("         ON DELETE NO ACTION ");
                    sb.Append("         ON UPDATE NO ACTION ");

                    sb.Append("); ");


                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }

                    //Block #:   Dashboard *************************************************************

                    //DASHBOARD, SECONDARY TABLE, TOOL TYPE
                    Console.Write("Create table Dashboard under Project schema\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.DB_Dashboard_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Projectl.DB_Dashboard_tbl; ");

                    //table creation
                    sb.Append("CREATE TABLE Project.DB_Dashboard_tbl( ");
                    sb.Append("     DB_Dashboard_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     DB_Dashboard_PJ_Project_ID INT NOT NULL ");
                    sb.Append("); ");

                    //query sending for execution
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Table created");
                    }



                    void databaseSelection()
                    {
                        //calling use of specific database.

                        sb.Clear();
                        sb.Append("USE Ulysses; \n");
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                        }
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





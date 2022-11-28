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
                        Console.WriteLine(rowsAffected + " database created");
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

                    Console.Write("Creation of Database admin user");
                    


                    sb.Append("CREATE LOGIN PMOES_dbadmin WITH PASSWORD=N'Lucy!nth3_5ky', ");
                    sb.Append("DEFAULT_DATABASE = Ulysses; ");
                    sb.Append("EXEC master..sp_addsrvrolemember @loginame = N'PMOES_dbadmin', @rolename = N'sysadmin'; ");
                    sb.Append("CREATE USER JBenton FOR LOGIN PMOES_dbadmin; ");



                    //Block #:  creation of schemas

                    //creation of schema, should be the first statment of a query. Appending of USE substituted.
                    
                    Console.Write("Create schema Calculation");
                    databaseSelection(); 
                    sb.Clear();
                    sb.Append("CREATE Schema Calculation authorization dbo; ");  //authorization should be replaced with dba
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " Schema created");
                    }



                    


                    //Block #:   Cost Variance *************************************************************

                    //COST VARIANCE TABLE, PRIMARY TABLE, CALCULATION TYPE===-
                    Console.Write("Create table CostVariance under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.CV_CostVariance_tbl') IS NOT NULL ");
                
                    sb.Append("Drop Table Calculation.CV_CostVariance_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.CV_CostVariance_tbl( ");
                    sb.Append("     CV_CostVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     CV_CostVariance_Date DATETIME NOT NULL, ");
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



                    //Block #:   Schedule Variance *************************************************************

                    //SCHEDULE VARIANCE, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table Schedule Variance under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.SV_ScheduleVariance_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.SV_ScheduleVariance_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.SV_ScheduleVariance_tbl( ");
                    sb.Append("     SV_ScheduleVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     SV_ScheduleVariance_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Variance At Completion under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.VAC_VarianceAtCompletion_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.VAC_VarianceAtCompletion_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.VAC_VarianceAtCompletion_tbl( ");
                    sb.Append("     VAC_VarianceAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     VAC_VarianceAtCompletion_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Cost Performance Index under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('CPI_CostPerformanceIndex_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.CPI_CostPerformanceIndex_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.CPI_CostPerformanceIndex_tbl( ");
                    sb.Append("     CPI_CostPerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     CPI_CostPerformanceIndex_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Schedule Performance Index under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('SPI_SchedulePerformanceIndex_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.SPI_SchedulePerformanceIndex_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.SPI_SchedulePerformanceIndex_tbl( ");
                    sb.Append("     SPI_SchedulePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     SPI_SchedulePerformanceIndex_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Estimate At Completion under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.EAC_EstimateAtCompletion_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.EAC_EstimateAtCompletion_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.EAC_EstimateAtCompletion_tbl( ");
                    sb.Append("     EAC_EstimateAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     EAC_EstimateAtCompletion_Date DATETIME NOT NULL, ");
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


                    //Block #:   To Complete Performance Index *************************************************************

                    //TO COMPLETE PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
                    Console.Write("Create table To Complete Performance Index under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.TCPI_ToCompletePerformanceIndex_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.TCPI_ToCompletePerformanceIndex_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.TCPI_ToCompletePerformanceIndex_tbl( ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     TCPI_ToCompletePerformanceIndex_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Total Cost under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.TC_TotalCost_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.TC_TotalCost_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.TC_TotalCost_tbl( ");
                    sb.Append("     TC_TotalCost_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     TC_TotalCost_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Power/Interest under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PIT_PowerInterest_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PIT_PowerInterest_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.PIT_PowerInterest_tbl( ");
                    sb.Append("     PIT_PowerInterest_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PIT_PowerInterest_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Power/Influence under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PIT_PowerInterest_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PIT_PowerInterest_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.PIF_PowerInfluence_tbl( ");
                    sb.Append("     PIF_PowerInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PIF_PowerInfluence_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Interest/Influence under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.II_InterestInfluence_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.II_InterestInfluence_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.II_InterestInfluence_tbl( ");
                    sb.Append("     II_InterestInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     II_InterestInfluence_Date DATETIME NOT NULL, ");
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
                    Console.Write("Create table Priority under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Calculation.PT_Priority_tbl ') IS NOT NULL ");
                    sb.Append("Drop Table Calculation.PT_Priority_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Calculation.PT_Priority_tbl( ");
                    sb.Append("     PT_Priority_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     PT_Priority_Date DATETIME NOT NULL, ");
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
//pendiente!!!!!!!!!
                    //KNOWLEDGE AREA TABLE, PRIMARY TABLE, PRIMARY TABLE
                    Console.Write("Create table Knowledge Area under schema Calculation\n");
                    sb.Clear();

                    databaseSelection();
                    sb.Append("IF OBJECT_ID('Project.KA_KnowledgeArea_tbl') IS NOT NULL ");
                    sb.Append("Drop Table Project.KA_KnowledgeArea_tbl; ");
                 
                    //table creation
                    sb.Append("CREATE TABLE Project.KA_KnowledgeArea_tbl( ");
                    sb.Append("     KA_KnowledgeArea_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    sb.Append("     KA_KnowledgeArea_Description VARCHAR(50) NOT NULL ");
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




















                    void databaseSelection()
                    {
                        //calling use of specific database.
                        Console.Write("Selecting Database");
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
}
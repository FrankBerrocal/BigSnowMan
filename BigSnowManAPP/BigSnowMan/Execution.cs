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
using System.Collections.Generic;
using BigSnowMan;
using Status;
using Project;
using Tool;
using Record;
using CalculationTool;
using Selection;
using ConnectionBuilderObject;
using System.Text;
using System.Data.SqlClient;
using CommandBuilderObject;
using TestSQLScript;

public class Execution
{


	static void Main(string[] args)
	{

        //Database Ulysses = new Database();

        //Connection for user DBA
        string DBA_DataSource = "localhost, 1440";
        string DBA_UserID = "sa";
        string DBA_Password = "myPassw0rd";
        string DBA_InitialCatalog = "master";
        String dba_sql = "";
        StringBuilder dba_sb = new StringBuilder();
        CommandBuilder DBA_command;
        SqlConnection DBA_Connection;

        ConnectionBuilder DbaBuilder = new ConnectionBuilder(DBA_DataSource, DBA_UserID, DBA_Password, DBA_InitialCatalog);
        
        DBA_Connection = DbaBuilder.createConnection();
        DBA_Connection = DbaBuilder.getConnection;
        DBA_Connection = new SqlConnection(DbaBuilder.getBuilderString);
        DBA_Connection.Open();
        ValidateConnection(DBA_Connection, DBA_UserID);

        DBA_command = new CommandBuilder();
        DBA_command.createCommandBuilderBasic(dba_sql, DBA_Connection, dba_sb, DbaBuilder.getBuilderString);

        //Select project Table
        DBA_command.selectDMLTableProjectQuery();

        /*
        //Connection for user Project Analyst
        string PA_DataSource = "localhost, 1440";
        string PA_UserID = "Analyst_JJones";
        string PA_Password = "JJones1234";
        string PA_InitialCatalog = "Ulysses";
        String pa_sql = "";
        StringBuilder pa_sb = new StringBuilder();
        CommandBuilder PA_command;
        SqlConnection PA_Connection;
        ConnectionBuilder PA_Builder = new ConnectionBuilder(DBA_DataSource, DBA_UserID, DBA_Password, DBA_InitialCatalog);

        PA_Connection = PA_Builder.createConnection();
        PA_Connection = PA_BuildergetConnection;
        PA_Connection = new SqlConnection(PA_Builder.getBuilderString);
        PA_Connection.Open();
        ValidateConnection(PA_Connection PA_UserID );

        PA_command = new CommandBuilder();
        PA_command.createCommandBuilderBasic(dba_sql, PA_Connection, pa_sb, PA_Builder.getBuilderString);

        //Select project Table
        PA_command.selectDMLTableProjectQuery();

        //Connection for user Cost Analyst
        string CA_DataSource = "localhost, 1440";
        string CA_UserID = "Analyst_JJones";
        string CA_Password = "JJones1234";
        string CA_InitialCatalog = "Ulysses";
        CommandBuilder DBA_command;
        SqlConnection PA_Connection;
        ConnectionBuilder Cost_Analyst_Builder = new ConnectionBuilder(DBA_DataSource, DBA_UserID, DBA_Password, DBA_InitialCatalog);

        DBA_Connection = DbaBuilder.createConnection();
        DBA_Connection = DbaBuilder.getConnection;
        DBA_Connection = new SqlConnection(DbaBuilder.getBuilderString);
        DBA_Connection.Open();
        ValidateConnection(DBA_Connection, DBA_UserID);

        DBA_command = new CommandBuilder();
        DBA_command.createCommandBuilderBasic(dba_sql, DBA_Connection, dba_sb, DbaBuilder.getBuilderString);

        //Select project Table
        DBA_command.selectDMLTableProjectQuery();
        */

        /*

        //Preparing to send individual queries per user dba
        String dba_sql = "";
        StringBuilder dba_sb = new StringBuilder();
        CommandBuilder dba_command = new CommandBuilder();*/

        //Preparing to send individual queries per user project analyst


        //Preparing to send individual queries per user cost analyst
        String ca_sql = "";
        StringBuilder ca_sb = new StringBuilder();


        dba_sb = testSelectDBA(dba_sb, dba_sql);

        


      /*
        ConnectionCommandObject DbaBuilder = new ConnectionCommandObject();
        DbaBuilder.initializeConnectionCommandObject(DBA_DataSource,
                                                                                DBA_UserID,
                                                                                DBA_Password,
                                                                                DBA_InitialCatalog,
                                                                                dba_sql,
                                                                                dba_sb);
        */

        //dba_command.createCommandBuilderBasic(dba_sql, DbaConnection, dba_sb);
        //dba_command.selectDMLTableProjectQuery1();



        /*
        //Creation of all persistent selection objects
        Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();
        SelectionObjects _status = new SelectionObjects();
        Status = _status.createSelectionObjectStatus();

        Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();
        SelectionObjects _type = new SelectionObjects();
        Type = _type.createSelectionObjectType();

        Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();
        SelectionObjects _karea= new SelectionObjects();
        KArea = _karea.createSelectionObjectKnowledgeArea();

        Dictionary<OptionObject<string>, int> Tool = new Dictionary<OptionObject<string>, int>();
        SelectionObjects _tool = new SelectionObjects();
        Tool = _tool.createSelectionObjectTool();



        Console.WriteLine("\nProject Definition\n");

        string ProjectName = "Lighthouse";
        string ProjectDescription = "Accounting project for Nest Consultants";
        var ProjectStartDate = new DateOnly(2022, 12, 08);
        var ProjectExpEndDate = new DateOnly(2023, 12, 08);
        var ProjectRealEndDate = ProjectExpEndDate;
        var StatusID = 4;  //active status as default
        var ProjectTypeID = 4;  //active status as default
        var ToolTypeID= 0;  //cost report
        var KAreaID = 3; //cost


        //Status and Type send as parameters
        ProjectObject Proyecto = new ProjectObject(  ProjectName,
                                                                            ProjectDescription,
                                                                            ProjectStartDate,
                                                                            ProjectExpEndDate,
                                                                            ProjectRealEndDate,
                                                                            Status,
                                                                            StatusID,
                                                                            Type,
                                                                            ProjectTypeID,
                                                                            Tool,
                                                                            ToolTypeID,
                                                                            KArea,
                                                                            KAreaID);

        Console.WriteLine(Proyecto.ProjectInfoDisplay());

        DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
        Proyecto.getCostReport().RecordLineCreation(2, _date);
        */
    }

    
    private static StringBuilder testSelectDBA(StringBuilder _sb, string _table)
    {
        _sb.Clear();
        _sb.Append("SELECT PJ_Project_ID, PJ_Project_Name, PJ_Project_Description ");
        _sb.Append("    FROM PJ_Project_tbl; ");
        return _sb;
    }

    private static void ValidateConnection(SqlConnection _connection, string _userID)
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            Console.WriteLine(_userID+" connection ok");
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

/*
 * 
 * 
 * 
 * References
 * Keep connection open: https://stackoverflow.com/questions/9316981/using-statement-with-connection-open
 * 
 * 
 */

/*
 * Reaching the Objects inside the Dictionary 
 * Console.WriteLine(	 Status.Keys.ElementAt(1));
 * Console.WriteLine(	 Status.Keys.ElementAt(1).Option.ToString());
 * Proyecto.ProjectStatusDisplay(StatusID) 
 * Proyecto.ProjectType.Keys.ElementAt(1).Description
 * 
 * 
 */


/*  TEST CODE
 *  
 *          //Console.WriteLine(Proyecto.ProjectInfoDisplay());
            //Console.WriteLine("\nProject output:\n");
            //Console.WriteLine(Proyecto.ProjectStatusDisplay() );
            //Console.WriteLine(Proyecto.ProjectTypeGS.Keys.ElementAt(1).Description ); 
            //Proyecto.ProjectStatusID = 0;  //status change
            // Console.WriteLine(Proyecto.ProjectStatusDisplay());

                Console.WriteLine("\nTool Definition\n");
                int ProjectID = 1;
               // int ToolTypeID = 0;
                int ToolKAID = 3;
                DateOnly ToolDate = new DateOnly(2022, 12, 11);


                //Tool and KArea sent as parameters
                ToolObject CostReportLH = new ToolObject(ProjectID, ToolDate, Tool, ToolTypeID, KArea, ToolKAID);

                Console.WriteLine("\nTool output:\n");
                Console.WriteLine(CostReportLH.displayToolInfo());
                CostReportLH.ProjectIDGS = 5;
                Console.WriteLine(CostReportLH.ProjectIDGS);
                CostReportLH.ToolTypeIDGS = 1;

                Console.WriteLine("\nRecord Definition\n");
                int ToolID = 1;
                DateOnly RecordDate = new DateOnly(2022, 12, 11);

                RecordObject CostReportLineLH = new RecordObject(ToolID, RecordDate);
                Console.WriteLine(CostReportLineLH.displayRecordInfo() );


                Console.WriteLine("\nCost Variance Definition\n");
                int costRecordID = 1;
                CostVarianceCalculationObject CV = new CostVarianceCalculationObject(costRecordID);

                double EV = 50000;
                double AC = 35000;


                CV.calculationSubtraction(EV, AC);
                Console.WriteLine(CV.displayCalculationResult());

                Console.WriteLine("\nSchedule Variance Definition\n");

                ScheduleVarianceCalculationObject SV = new ScheduleVarianceCalculationObject(costRecordID);
                double PV = 25590.56;

                SV.calculationSubtraction(EV, PV);
                Console.WriteLine(  SV.displayCalculationResult());

                Console.WriteLine("\nVariance at Completion Definition\n");

                VarianceCompletionCalculationObject VC = new VarianceCompletionCalculationObject(costRecordID);
                double BAC = 13000;
                double EAC = 17000;

                VC.calculationSubtraction(BAC, EAC);
                Console.WriteLine(VC.displayCalculationResult());

                Console.WriteLine("\nCost Performance Index \n");

                CostPerformanceIndexCalculationObject CPI = new CostPerformanceIndexCalculationObject(costRecordID);

                CPI.calculationDivision(EV, AC);
                Console.WriteLine(CPI.displayCalculationResult());

                Console.WriteLine("\nSchedule Performance Index \n");

                SchedulePerformanceIndexCalculationObject SPI = new SchedulePerformanceIndexCalculationObject(costRecordID);
                SPI.calculationDivision(EV, PV);

                Console.WriteLine(SPI.displayCalculationResult());
        */

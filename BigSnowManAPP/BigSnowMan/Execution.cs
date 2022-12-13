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
using ConnectionBuilderObject;
using System.Text;
using System.Data.SqlClient;
using CommandBuilderObject;
using System.Threading;
using System.Threading.Tasks;

public class Execution
{


	static void Main(string[] args)
	{

        Database Ulysses = new Database();



        
        //Connection for user DBA
        string DBA_DataSource = "localhost, 1440";
        string DBA_UserID = "sa";
        string DBA_Password = "myPassw0rd";
        string DBA_InitialCatalog = "master";
        String dba_sql = "";
        StringBuilder dba_sb = new StringBuilder();
        CommandBuilder DBA_command;
        SqlConnection DBA_Connection;

        ConnectionBuilder DBA_Builder = new ConnectionBuilder(DBA_DataSource, DBA_UserID, DBA_Password, DBA_InitialCatalog);
        
        DBA_Connection = DBA_Builder.createConnection();
        DBA_Connection = DBA_Builder.getConnection;
        DBA_Connection = new SqlConnection(DBA_Builder.getBuilderString);
        DBA_Connection.Open();
        ValidateConnection(DBA_Connection, DBA_UserID);

        DBA_command = new CommandBuilder(dba_sql, DBA_Connection, dba_sb, DBA_Builder.getBuilderString);

        
        //Connection for user Project Analyst
        string PA_DataSource = "localhost, 1440";
        string PA_UserID = "Analyst_JJones";
        string PA_Password = "JJones1234";
        string PA_InitialCatalog = "Ulysses";
        String PA_SQL = "";
        StringBuilder PA_SB = new StringBuilder();
        CommandBuilder PA_command;
        SqlConnection PA_Connection;

        ConnectionBuilder PA_Builder = new ConnectionBuilder(PA_DataSource, PA_UserID, PA_Password, PA_InitialCatalog);

        PA_Connection = PA_Builder.createConnection();
        PA_Connection = PA_Builder.getConnection;
        PA_Connection = new SqlConnection(PA_Builder.getBuilderString);
        PA_Connection.Open();
        ValidateConnection(PA_Connection, PA_UserID );

        PA_command = new CommandBuilder(PA_SQL, PA_Connection, PA_SB, PA_Builder.getBuilderString);

 
        //Connection for user Cost Analyst
        string CA_DataSource = "localhost, 1440";
        string CA_UserID = "Analyst_KBenton";
        string CA_Password = "KBenton1234";
        string CA_InitialCatalog = "Ulysses";
        String CA_SQL = "";
        StringBuilder CA_SB = new StringBuilder();
        CommandBuilder CA_command;
        SqlConnection CA_Connection;

        ConnectionBuilder CA_Builder = new ConnectionBuilder(CA_DataSource, CA_UserID, CA_Password, CA_InitialCatalog);

        CA_Connection = CA_Builder.createConnection();
        CA_Connection = CA_Builder.getConnection;
        CA_Connection = new SqlConnection(CA_Builder.getBuilderString);
        CA_Connection.Open();
        ValidateConnection(CA_Connection, CA_UserID );

        CA_command = new CommandBuilder(CA_SQL, CA_Connection, CA_SB, CA_Builder.getBuilderString);






        //Creation of all persistent selection objects
        Console.WriteLine("\nStatus object\n");
        Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();
        StatusObject StatusCreation = new StatusObject();
        Status = StatusCreation.CreateStatus();
        StatusCreation.DisplayStatus(Status); //display elements
     



        Console.WriteLine("\nProject Type object\n");
        Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();
        TypeObject TypeCreation = new TypeObject();
        Type = TypeCreation.CreateType();
        TypeCreation.DisplayType(Type); //display elements

        Console.WriteLine("\nKnowledge Area object\n");
        Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();
        KAreaObject KAreaCreation = new KAreaObject();
        KArea = KAreaCreation.CreateKArea();
        KAreaCreation.DisplayKArea(KArea);  //display elements

        Console.WriteLine("\nTool object\n");
        Dictionary<OptionObject<string>, int> Tool = new Dictionary<OptionObject<string>, int>();
        ToolType ToolTypesCreation = new ToolType();
        Tool = ToolTypesCreation.CreateToolType();
        ToolTypesCreation.DisplayTool(Tool);  //display elements


     
        //capture of information has been set ready for interaction with interface.
        //I decide to implement multiple tasks and the reproduction of those is not possible with UI.   I would have to work with 3 UIs to reproduce the
        //activity of 3 users at the same time.

        Console.WriteLine("\nProject Definition\n");

        string ProjectName = "Lighthouse";
        string ProjectDescription = "Accounting project for Nest Consultants";
        var ProjectStartDate = new DateTime(2022, 12, 08);
        var ProjectExpEndDate = new DateTime(2023, 12, 08);
        var ProjectRealEndDate = ProjectExpEndDate;
        var StatusID = 0;  //active status as default  
        var ProjectTypeID = 4;  //active status as default
        var ToolTypeID= 0;  //cost report
        var KAreaID = 3; //cost


        Task insertProjectDBA = new Task(() => DBA_command.insertDMLTableProjectQuery(ProjectName,
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
                                                                           KAreaID));
        
        //Select project Table
        Task selectProjectDBA = new Task(() => DBA_command.selectDMLTableProjectQuery());

        //Select project Table
        Task selectProjectPA = new Task(() => PA_command.selectDMLTableProjectQuery());

        //Select project Table
        Task selectProjectCA = new Task(()=> CA_command.selectDMLTableProjectQuery());

        insertProjectDBA.Start();
        selectProjectDBA.Wait(1000);
        selectProjectDBA.Start();
        selectProjectPA.Wait(1000);
        selectProjectPA.Start();
        selectProjectCA.Wait(1000);
        selectProjectCA.Start();



        /*

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

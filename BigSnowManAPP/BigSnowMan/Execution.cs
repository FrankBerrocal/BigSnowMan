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


public class Execution : StatusObject
{
	static void Main(string[] args)
	{
        //Database Ulysses = new Database();

        Console.WriteLine("\nStatus:\n");
        //Creation of list of status descriptions
        Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();
        StatusObject StatusCreation = new StatusObject();
        Status = StatusCreation.CreateStatus();
        StatusCreation.DisplayStatus(Status); //display elements

        Console.WriteLine("\nTypes:\n");
        //Creation of list of type descriptions
        Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();
        TypeObject TypeCreation = new TypeObject();
        Type = TypeCreation.CreateType();
        TypeCreation.DisplayType(Type); //display elements

        Console.WriteLine("\nKnowledge Areas:\n");
        //Creation of list of type descriptions
        Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();
        KAreaObject KAreaCreation = new KAreaObject();
        KArea = KAreaCreation.CreateKArea();
        KAreaCreation.DisplayKArea(KArea);  //display elements

        Console.WriteLine("\nTool Types:\n");
        //Creation of list of type descriptions
        Dictionary<OptionObject<string>, int> Tool = new Dictionary<OptionObject<string>, int>();
        ToolType ToolTypesCreation = new ToolType();
        Tool = ToolTypesCreation.CreateToolType();
        ToolTypesCreation.DisplayTool(Tool);  //display elements

        Console.WriteLine("\nProject Definition\n");
        string ProjectName = "Lighthouse";
        string ProjectDescription = "Accountig project for Nest Consultants";
        var ProjectStartDate = new DateOnly(2022, 12, 08);
        var ProjectExpEndDate = new DateOnly(2023, 12, 08);
        var ProjectRealEndDate = ProjectExpEndDate;
        var StatusID = 4;  //active status as default
        var TypeID = 4;  //active status as default

        //Status and Type send as parameters
        ProjectObject Proyecto = new ProjectObject(ProjectName, ProjectDescription, ProjectStartDate, ProjectExpEndDate, ProjectRealEndDate, Status, StatusID, Type, TypeID);

        Console.WriteLine("\nProject output:\n");
        Console.WriteLine(Proyecto.ProjectStatusDisplay() );
        Console.WriteLine(Proyecto.ProjectType.Keys.ElementAt(1).Description ); 
        Proyecto.ProjectStatusID = 0;  //status change
        Console.WriteLine(Proyecto.ProjectStatusDisplay());

        Console.WriteLine(Proyecto.ProjectInfoDisplay());

        Console.WriteLine("\nTool Definition\n");
        int ProjectID = 1;
        int ToolTypeID = 0;
        int ToolKAID = 3;
        DateOnly ToolDate = new DateOnly(2022, 12, 11);


        //Tool and KArea sent as parameters
        ToolObject CostReportLH = new ToolObject(ProjectID, ToolDate, Tool, ToolTypeID, KArea, ToolKAID);

        Console.WriteLine("\nTool output:\n");
        Console.WriteLine(CostReportLH.displayToolInfo());



        Console.WriteLine("\nRecord Definition\n");
        int ToolID = 1;
        DateOnly RecordDate = new DateOnly(2022, 12, 11);

        RecordObject CostReportLineLH = new RecordObject(ToolID, RecordDate);
        Console.WriteLine(CostReportLineLH.displayRecordInfo() );


        Console.WriteLine("\nRecord Definition\n");
        int costRecordID = 1;
        CostVarianceCalculationObject CV = new CostVarianceCalculationObject(costRecordID);

        float EV = 50000;
        float AC = 35000;
        float CostVariance;

        CV.calculationSubtraction(EV, AC);
        Console.WriteLine(CV.displayCalculationResult());



            

    }
}



/*
 * Reaching the Objects inside the Dictionary 
 * Console.WriteLine(	 Status.Keys.ElementAt(1));
 * Console.WriteLine(	 Status.Keys.ElementAt(1).Option.ToString());
 * Proyecto.ProjectStatusDisplay(StatusID) 
 * Proyecto.ProjectType.Keys.ElementAt(1).Description
 * 
 * 
 */

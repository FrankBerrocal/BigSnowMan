using System;
using System.Collections.Generic;
using BigSnowMan;
using Status;
using Project;


    public class Execution : StatusObject
	{
		static void Main(string[] args)
		{
            //Database Ulysses = new Database();


            Console.WriteLine("\nStatus");
            //Creation of list of status descriptions

            Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();

			StatusObject StatusCreation = new StatusObject();

			Status = StatusCreation.CreateStatus();

			StatusCreation.DisplayStatus(Status); //display elements






            Console.WriteLine("\nTypes");
            //Creation of list of type descriptions
            Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();

            TypeObject TypeCreation = new TypeObject();

			Type = TypeCreation.CreateType();

			TypeCreation.DisplayType(Type); //display elements

			


            Console.WriteLine("\nKnowledge Areas");
            //Creation of list of type descriptions
            Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();

           KAreaObject KAreaCreation = new KAreaObject();

            KArea = KAreaCreation.CreateKArea();

           KAreaCreation.DisplayKArea(KArea);  //display elements


			

			//ProjectObject project = new ProjectObject(Status, Type);





        string ProjectName = "Lighthouse";
        string ProjectDescription = "Accountig project for Nest Consultants";
        var ProjectStartDate = new DateOnly(2022, 12, 08);
        var ProjectExpEndDate = new DateOnly(2023, 12, 08);
        var ProjectRealEndDate = ProjectExpEndDate;

        var StatusID = 5;  //active status as default
        var ProjectStatus = Status;
        var TypeID = 4;  //active status as default
        var ProjectType = Type;

        ProjectObject Proyecto = new ProjectObject(ProjectName, ProjectDescription, ProjectStartDate, ProjectExpEndDate, ProjectRealEndDate, ProjectStatus, StatusID, ProjectType, TypeID);

        Console.WriteLine(Proyecto.ProjectStatusDisplay(StatusID) );
        Console.WriteLine(Proyecto.ProjectType.Keys.ElementAt(1).Description);

        

        }
	}



/*
 * Reaching the Objects inside the Dictionary 
 * Console.WriteLine(	 Status.Keys.ElementAt(1));
 * Console.WriteLine(	 Status.Keys.ElementAt(1).Option.ToString());
 * 
 * 
 * 
 */

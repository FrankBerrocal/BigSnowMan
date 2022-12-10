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
using System.Runtime.Serialization;
using BigSnowMan;


public class ProjectObject
{

    //List<string, string, DateOnly, DateOnly, int, int, int, int, Dictionary<OptionObject<string>, int>, Dictionary<OptionObject<string>, int>> Project =

    
    


    List<object> Project = new List<object>();

    public ProjectObject(Dictionary<OptionObject<string>, int> _status, Dictionary<OptionObject<string>, int> _type)
	{
       // CaptureProjectValues();
        CreateProject( _status, _type);

    }

	public List<object> CreateProject(Dictionary<OptionObject<string>, int> _status, Dictionary<OptionObject<string>, int> _type)
	{
        List<object> Project = new List<object>();
        

        CaptureProjectValues(Project, _status, _type);
        Console.WriteLine("\nProjects");
        //Console.WriteLine(string.Join(", ", Project));  //Concatenates in one single line and displays all information.
        Project.ForEach(i => Console.WriteLine(i.ToString()));  //presents information by element.
        for (int i = 0; i < Project.Count(); i++)
        {
            if (Project[i].GetType == OptionObject<string>)
            {

            }
        }


        return Project;

    }

    private List<object> CaptureProjectValues(List<object> _project, Dictionary<OptionObject<string>, int> _status, Dictionary<OptionObject<string>, int> _type)
    {
        //Capture values here, from Web Interface.  Create an object to capture web information.
        Dictionary<OptionObject<string>, int> ProjectStatus = new Dictionary<OptionObject<string>, int>();
        Dictionary<OptionObject<string>, int> ProjectType = new Dictionary<OptionObject<string>, int>();

        //All variables to be captured from UI

        string ProjectName = "Lighthouse";
        string ProjectDescription = "Accountig project for Nest Consultants";
        var ProjectStartDate = new DateOnly(2022,12,08);
        var ProjectExpEndDate = new DateOnly(2023, 12, 08);
        var ProjectRealEndDate = ProjectExpEndDate;
        var ProjectCostReport = "";
        var StatusID = 0;  //active status as default
        ProjectStatus.Add(_status.Keys.ElementAt(StatusID), _status.Values.ElementAt(StatusID));
        var TypeID = 0; //technology type as default.
        ProjectType.Add(_type.Keys.ElementAt(TypeID), _type.Values.ElementAt(TypeID));


        // setting the project dictionary.
        try
        {
            _project.Add(ProjectName);  //index 0
            _project.Add(ProjectDescription); //index 1
            _project.Add(ProjectStartDate); //index 2
            _project.Add(ProjectExpEndDate); //index 3
            _project.Add(ProjectRealEndDate); //index 4
            _project.Add(ProjectCostReport); //index 5
            _project.Add(ProjectStatus); //index 6
            _project.Add(ProjectType); //index 7

            _project.Insert(5, ProjectStatus);


        }
        catch(Exception e)
        {
            Console.WriteLine("Check the entries for Project definition" + e.Message);
        }

        return _project;
    }

    public void AddTools()
    {
        //add new tool elements after the project has been created.
    }

    public void DisplayTool()
    {
        //calls every tool DisplayCalculationsMethod and presents the information under the Project.
    }





}

/*
 * This object is not like the previous option types.   
 * 
 * Project should receive configuration parameters, as well as objects such as Dictionary, ProjectType, Status, etc.  
 * 
 * The reason behind treating those elements as parameters resides in the fact they are persistent, and should be added to every new project.  
 * 
 * Local objects to save the specific status and type for this project should be created.  The option is selected from the external object and saved in a local object.
 * 
 * 
 * References
 * 
 * Printing elements of a list https://www.educative.io/answers/how-to-print-all-elements-of-a-list-in-c-sharp
 * DateOnly https://code-maze.com/csharp-dateonly-timeonly/
 * Copy Dictionary: https://stackoverflow.com/questions/5963115/how-do-i-copy-the-content-of-a-dictionary-to-an-new-dictionary-in-c
 * List: https://blog.submain.com/c-list-definition-examples-best-practices-pitfalls/
 * List: https://www.softwaretestinghelp.com/c-sharp/csharp-list-and-dictionary/
 * Find all: https://www.geeksforgeeks.org/c-sharp-how-to-get-all-elements-of-a-list-that-match-the-conditions-specified-by-the-predicate/
 */
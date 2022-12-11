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

public class ToolType
{

    public ToolType()  //persistent data, no need to receive the descriptors everytime
    {
        CreateToolType();
        
    }

    public Dictionary<OptionObject<string>, int> CreateToolType()  //OptionObject forced to string parameter
    {
        Dictionary<OptionObject<string>, int> Tool = new Dictionary<OptionObject<string>, int>();

        OptionObject<string> CostReport = new OptionObject<string>("Cost Report");  //names of entities not required.  I choose Dictionary to use the Database ID.
        OptionObject<string> WBS = new OptionObject<string>("Workbreakdown Structure");
        OptionObject<string> Traceability = new OptionObject<string>("Traceability Matrix");
        OptionObject<string> StakeholderList = new OptionObject<string>("Stakeholder List");
        OptionObject<string> StakeholderMatrix = new OptionObject<string>("Stakeholder Evaluation Matrix");
        OptionObject<string> ComsMatrix = new OptionObject<string>("Communications Matrix");
        OptionObject<string> RiskMatrix = new OptionObject<string>("Risk Identification Matrix");

        Tool.Add(CostReport, 1);
        Tool.Add(WBS, 2);
        Tool.Add(Traceability, 3);
        Tool.Add(StakeholderList, 4);
        Tool.Add(StakeholderMatrix, 5);
        Tool.Add(ComsMatrix, 6);
        Tool.Add(RiskMatrix, 7);

        return Tool;
    }

    public void DisplayTool(Dictionary<OptionObject<string>, int> _tool)
    {

        foreach (OptionObject<string> element in _tool.Keys)
            Console.WriteLine(element.Description);
    }

}

/*
 *  New options can be send by the user in later expansions, to create additional project types.   Same applies to Status, and eventually, Knowledge Areas.
 * 

 */


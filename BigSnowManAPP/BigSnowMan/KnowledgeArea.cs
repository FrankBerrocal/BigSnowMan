/*****************************************************************
 * Project Management Office Evaluation System (ProtoKArea)       
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

public class KAreaObject
{

    public KAreaObject()  //persistent data, no need to receive the descriptors everytime
    {
        CreateKArea();
    }

    public Dictionary<OptionObject<string>, int> CreateKArea()
    {
        Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();

        OptionObject<string> Integration = new OptionObject<string>("Project Integration Management");
        OptionObject<string> Scope = new OptionObject<string>("Project Scope Management");
        OptionObject<string> Time = new OptionObject<string>("Project Time Management'");
        OptionObject<string> Cost = new OptionObject<string>("Project Cost Management");
        OptionObject<string> Quality = new OptionObject<string>("Project Quality Management");
        OptionObject<string> Resource = new OptionObject<string>("Project Human Resource Management");
        OptionObject<string> Communications = new OptionObject<string>("Project Communications Management");
        OptionObject<string> Agriculture = new OptionObject<string>("Project Risk Management");
        OptionObject<string> Procurement = new OptionObject<string>("Project Procurement Management");
        OptionObject<string> Stakeholder = new OptionObject<string>("Project Stakeholder Management");

        KArea.Add(Integration, 1);  //index 0
        KArea.Add(Scope, 2);  //index 1
        KArea.Add(Time, 3); //index 2
        KArea.Add(Cost, 4);  //index 3
        KArea.Add(Quality, 5); //index 4
        KArea.Add(Resource, 6);  //index 5
        KArea.Add(Communications, 7);  //index 6
        KArea.Add(Procurement, 8);  //index 7
        KArea.Add(Stakeholder, 9); //index 8


        return KArea;
    }

    public void DisplayKArea(Dictionary<OptionObject<string>, int> _kArea)
    {

        foreach (OptionObject<string> element in _kArea.Keys)
            Console.WriteLine(element.Description);
    }

}


/*
 * 
 * References:  
 * Knowledge Areas: https://project-management.info/knowledge-areas-processes-pmbok/
 * 
 * */
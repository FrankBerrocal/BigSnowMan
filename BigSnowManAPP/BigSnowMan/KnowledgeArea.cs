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

    public KAreaObject()
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

        KArea.Add(Integration, 1);
        KArea.Add(Scope, 2);
        KArea.Add(Time, 3);
        KArea.Add(Cost, 4);
        KArea.Add(Quality, 5);
        KArea.Add(Resource, 6);
        KArea.Add(Communications, 7);
        KArea.Add(Procurement, 8);
        KArea.Add(Stakeholder, 8);


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
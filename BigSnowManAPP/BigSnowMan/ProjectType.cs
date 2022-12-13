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

public class TypeObject
{

    public TypeObject()  //persistent data, no need to receive the descriptors everytime
    {
        CreateType();
    }

    public Dictionary<OptionObject<string>, int> CreateType()
    {
        Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();

        OptionObject<string> Technology = new OptionObject<string>("Technology");
        OptionObject<string> Software = new OptionObject<string>("Software");
        OptionObject<string> Engineering = new OptionObject<string>("Engineering");
        OptionObject<string> Manufacturing = new OptionObject<string>("Manufacturing");
        OptionObject<string> Architecture = new OptionObject<string>("Architecture");
        OptionObject<string> Arts = new OptionObject<string>("Arts");
        OptionObject<string> Agriculture = new OptionObject<string>("Agriculture");
        OptionObject<string> Accounting = new OptionObject<string>("Accounting");
        OptionObject<string> Organizational = new OptionObject<string>("Organizational");


        Type.Add(Technology, 1);
        Type.Add(Software, 2);
        Type.Add(Engineering, 3);
        Type.Add(Manufacturing, 4);
        Type.Add(Architecture, 5);
        Type.Add(Arts, 6);
        Type.Add(Agriculture, 7);
        Type.Add(Accounting, 8);
        Type.Add(Organizational, 9);


        return Type;
    }

    public void DisplayType(Dictionary<OptionObject<string>, int> _Type)
    {

        foreach (OptionObject<string> element in _Type.Keys)
            Console.WriteLine(element.Description);
    }

}

/*
 *  New options can be send by the user in later expansions, to create additional project types.   Same applies to Status, and eventually, Knowledge Areas.
 * 

 */
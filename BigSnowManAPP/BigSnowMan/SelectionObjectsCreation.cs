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

namespace Selection
{

    public class SelectionObjects
    {

        public SelectionObjects()
        {
            createSelectionObjectStatus();
            createSelectionObjectType();
            createSelectionObjectKnowledgeArea();
            createSelectionObjectTool();
        }
        public Dictionary<OptionObject<string>, int> createSelectionObjectStatus()
        {

            Console.WriteLine("\nStatus:\n");
            //Creation of list of status descriptions
            Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();
            StatusObject StatusCreation = new StatusObject();
            Status = StatusCreation.CreateStatus();
            //StatusCreation.DisplayStatus(Status); //display elements

            return Status;
        }

        public Dictionary<OptionObject<string>, int> createSelectionObjectType()
        {

            Console.WriteLine("\nTypes:\n");
            //Creation of list of type descriptions
            Dictionary<OptionObject<string>, int> Type = new Dictionary<OptionObject<string>, int>();
            TypeObject TypeCreation = new TypeObject();
            Type = TypeCreation.CreateType();
            TypeCreation.DisplayType(Type); //display elements

            return Type;
        }

        public Dictionary<OptionObject<string>, int> createSelectionObjectKnowledgeArea()
        {

            Console.WriteLine("\nKnowledge Areas:\n");
            //Creation of list of type descriptions
            Dictionary<OptionObject<string>, int> KArea = new Dictionary<OptionObject<string>, int>();
            KAreaObject KAreaCreation = new KAreaObject();
            KArea = KAreaCreation.CreateKArea();
            KAreaCreation.DisplayKArea(KArea);  //display elements

            return KArea;
        }

        public Dictionary<OptionObject<string>, int> createSelectionObjectTool()
        {

            Console.WriteLine("\nTool Types:\n");
            //Creation of list of type descriptions
            Dictionary<OptionObject<string>, int> Tool = new Dictionary<OptionObject<string>, int>();
            ToolType ToolTypesCreation = new ToolType();
            Tool = ToolTypesCreation.CreateToolType();
            ToolTypesCreation.DisplayTool(Tool);  //display elements

            return Tool;
        }



    }


}

    




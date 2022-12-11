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
using System;
using BigSnowMan;

namespace Tool
{
	public class ToolObject : ToolInterface
	{
		private int ID;  //id in SQL, retrieved after creation, SQL Identity is on.
        private int ProjectID;
        private DateOnly Date;
        private int TypeID;
        private Dictionary<OptionObject<string>, int> ToolType;  //name of entity in SQL
        private Dictionary<OptionObject<string>, int> ToolKA;   //Knowledge Area


        public ToolObject(int _projectId, DateOnly _date, int _typeId, Dictionary<OptionObject<string>, int> _toolType, Dictionary<OptionObject<string>, int> _toolKA)
		{
            ProjectID = _projectId;
            Date = _date;
            TypeID = _typeId;
            ToolType = _toolType;
            ToolKA = _toolKA;
		}

		public int ToolID //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public DateOnly ToolDate
        {
            get => Date;
            set => Date = value;
        }

        public int ToolTypeID
        {
            get => TypeID;
            set => TypeID = value;
        }

        public Dictionary<OptionObject<string>, int> ProjectTool
        {
            get => ToolType;
            set => ToolType = value;
        }

        public Dictionary<OptionObject<string>, int> ToolKnowledgeArea
        {
            get => ToolKA;
            set => ToolKA = value;
        }

        public string ToolTypeDisplay()
        {
            string _toolName = ToolType.Keys.ElementAt(TypeID).Description;
            return _toolName;
        }

        public string KnowledgeAreaDisplay()
        {
            string _areaName = ToolKA.Keys.ElementAt(TypeID).Description;
            return _areaName;
        }

        public string displayToolInfo()
		{
			return null;
		}
	}
}


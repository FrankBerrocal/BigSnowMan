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
using Record;


namespace Tool
{
	public class ToolObject : ToolInterface
	{
		private int ID;  //id in SQL, retrieved after creation, SQL Identity is on.
        private int ProjectID;
        private DateTime Date;
        private int ToolTypeID;
        private RecordObject RecordLine;

        //selection objects
        private Dictionary<OptionObject<string>, int> ToolType;  //name of entity in SQL
        private int ToolKAID;
        private Dictionary<OptionObject<string>, int> ToolKA;   //Knowledge Area

        public ToolObject(int _projectId, DateTime _date, Dictionary<OptionObject<string>, int> _toolType, int _typeId, Dictionary<OptionObject<string>, int> _toolKA, int _toolKDid)
		{
            ProjectID = _projectId;
            Date = _date;
            ToolTypeID = _typeId;
            ToolType = _toolType;
            ToolKAID = _toolKDid;
            ToolKA = _toolKA;
            RecordLine = RecordLineCreation(ID, Date);

            //this should be substituted by information from SQL Server
            RecordLine.RecordID = 1;
        }

        public int ToolIDGS //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public int ProjectIDGS //retrieve after insertion of data in SQL
        {
            get => ProjectID;
            set => ProjectID = value;
        }

        public DateTime ToolDateGS
        {
            get => Date;
            set => Date = value;
        }

        public int ToolTypeIDGS
        {
            get => ToolTypeID;
            set => ToolTypeID = value;
        }

        public Dictionary<OptionObject<string>, int> ToolTypeGS
        {
            get => ToolType;
            set => ToolType = value;
        }

        public int ToolKAIDGS
        {
            get => ToolKAID;
            set => ToolKAID = value;
        }

        public Dictionary<OptionObject<string>, int> ToolKnowledgeAreaGS
        {
            get => ToolKA;
            set => ToolKA = value;
        }

        public RecordObject RecordLineCreation(int _id, DateTime _date)
        {
            RecordObject _recordLine = new RecordObject(_id, _date);
            return _recordLine;
        }

        public RecordObject getRecordLineObject()
        {
            return RecordLine;
        }

        public string getRecordLineInfo()
        {
            return RecordLine.displayRecordInfo();
        }

        public string ToolTypeDisplay()
        {
            string _toolName = ToolType.Keys.ElementAt(ToolTypeID).Description;
            return _toolName;
        }

        public string KnowledgeAreaDisplay()
        {
            string _areaName = ToolKA.Keys.ElementAt(ToolTypeID).Description;
            return _areaName;
        }

        public string displayToolInfo()
		{
            string _toolInfo;
            _toolInfo = "\nName of tool: " + ToolType.Keys.ElementAt(ToolTypeID).Description +
                                    "\nfor project " + ProjectID +
                                    ".\nCreated on: " + Date +
                                    ".\nKnowledge area: " + ToolKA.Keys.ElementAt(ToolKAID).Description;
            return _toolInfo;
		}

        //create records
	}
}


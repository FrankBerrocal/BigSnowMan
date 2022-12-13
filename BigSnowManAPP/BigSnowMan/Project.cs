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
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using BigSnowMan;
using Status;
using Tool;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class ProjectObject : ProjectInterface
    {
        private int ID;  
        private string Name; 
        private string Description;
        private DateTime StartDate;
        private DateTime ExpEndDate;
        private DateTime RealEndDate;
        private ToolObject CostReport;

        //all selection objects

        private Dictionary<OptionObject<string>, int> Status;
        private int StatusID;
        private Dictionary<OptionObject<string>, int> Type;
        private int ProjectTypeID;
        private Dictionary<OptionObject<string>, int> ToolType;
        private int ToolTypeID;
        private Dictionary<OptionObject<string>, int> ToolKA;
        private int ToolKAID;




        public ProjectObject(  string _name,
                                        string _desc,
                                        DateTime _startDate,
                                        DateTime _expEndDate,
                                        DateTime _realEndDate,
                                        Dictionary<OptionObject<string>, int> _status,
                                        int _statusID,
                                        Dictionary<OptionObject<string>, int> _type,
                                        int _typeID,
                                        Dictionary<OptionObject<string>, int> _toolType,
                                        int _toolTypeId,
                                        Dictionary<OptionObject<string>, int> _toolKA,
                                        int _toolKAid)
        {
            Name = _name;
            Description = _desc;
            StartDate = _startDate;
            ExpEndDate = _expEndDate;
            RealEndDate = _realEndDate;
            Status = _status;
            StatusID = _statusID;
            Type = _type;
            ProjectTypeID = _typeID;
            ToolType = _toolType;
            ToolTypeID = _toolTypeId;
            ToolKA = _toolKA;
            ToolKAID = _toolKAid;
            ProjectStatusID = StatusID;
            Console.WriteLine(ProjectStatusID);
            CostReport = CreateCostReport();

            
            //this should be substituted by information from SQL Server
            CostReport.ProjectIDGS = 1;
            
        }

        public int ProjectIDGS  //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public string ProjectNameGS
        {
            get => Name;
            set => Name = value;
        }

        public string ProjectDescriptionGS
        {
            get => Description;
            set => Description = value;
        }

        public DateTime ProjectStartDateGS
        {
            get => StartDate;
            set => StartDate = value;
        }

        public DateTime ProjectExpectedEndDateGS
        {
            get => ExpEndDate;
            set => ExpEndDate = value;
        }

        public DateTime ProjectRealEndDateGS
        {
            get => RealEndDate;
            set => RealEndDate = value;
        }

        private int CostReportGS_ID
        {
            get => CostReport.ToolIDGS;
            set => CostReport.ToolIDGS = value;
        }

        private int CostReportGS_ProjectID
        {
            get => CostReport.ProjectIDGS;
            set => CostReport.ProjectIDGS = value;
        }

        private DateTime CostReportGS_Date
        {
            get => CostReport.ToolDateGS;
            set => CostReport.ToolDateGS = value;
        }

        private int CostReportGS_ToolTypeID
        {
            get => CostReport.ToolTypeIDGS;
            set => CostReport.ToolTypeIDGS = value;
        }

        private Dictionary<OptionObject<string>, int> ToolTypeGS
        {
            get => CostReport.ToolTypeGS;
            set => CostReport.ToolTypeGS = value;
        }

        private int CostReportGS_ToolKAID
        {
            get => CostReport.ToolKAIDGS;
            set => CostReport.ToolKAIDGS = value;
        }

        private Dictionary<OptionObject<string>, int> ToolKnowledgeAreaGS
        {
            get => CostReport.ToolKnowledgeAreaGS;
            set => CostReport.ToolKnowledgeAreaGS = value;
        }



        public int ProjectStatusID
        {
            get => StatusID;
            set => StatusID = value;
        }

        public int ProjectTypeIDGS
        {
            get => ProjectTypeID;
            set => ProjectTypeID = value;
        }

        public Dictionary<OptionObject<string>, int> ProjectStatusGS
        {
            get => Status;
            set => Status = value;
        }

        public Dictionary<OptionObject<string>, int> ProjectTypeGS
        {
            get => Type;
            set => Type = value;
        }

       public ToolObject CreateCostReport()
        {
            DateTime _date = DateTime.Now;
            ToolObject _costReport = new ToolObject(ID, _date, ToolType, ToolTypeID, ToolKA, ToolKAID);
            return _costReport;
        }

        public ToolObject getCostReport()
        {
            return CostReport;
        }

        public string ProjectStatusDisplay()
        {
            string statusName = Status.Keys.ElementAt(ProjectStatusID).Description;
            return statusName;
        }

        public string ProjectTypeDisplay()
        {
            string typeName = Type.Keys.ElementAt(ProjectTypeID).Description;
            return typeName;
        }

        public string ProjectInfoDisplay()
        {
            string _projectInfo;
            _projectInfo = "Name of Project: " + Name +
                                    ",\n" + Description +
                                    ".\nCreated on: " + StartDate +
                                    ",\nwith expected end date: " + ExpEndDate +
                                    ".\nProject " + Name + "  is type " + ProjectTypeDisplay() +
                                   ",\nand the current status is " + ProjectStatusDisplay() +
                                    "\n\nCost Report information: " +
                                    CostReport.displayToolInfo() +
                                    CostReport.getRecordLineObject().displayRecordInfo();
                                   


            return _projectInfo;
        }

    }
}

/*
 * References
 * DateOnly.FromDateTime:  https://learn.microsoft.com/en-us/dotnet/api/system.dateonly.fromdatetime?view=net-7.0
 * All DateOnly replaced due to issues with DateTime in SQL, though the date fields were created as Date.
 * 
 * 
 * 
 * 
 */
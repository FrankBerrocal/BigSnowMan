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

namespace Project
{
    public class ProjectObject : ProjectInterface
    {
        private int ID;  
        private string Name; 
        private string Description;
        private DateOnly StartDate;
        private DateOnly ExpEndDate;
        private DateOnly RealEndDate;
        //private string CostReport;
        private int StatusID;
        private Dictionary<OptionObject<string>, int> Status;
        private int TypeID;
        private Dictionary<OptionObject<string>, int> Type;




        public ProjectObject(string _name, string _desc, DateOnly _startDate, DateOnly _expEndDate, DateOnly _readlEndDate, Dictionary<OptionObject<string>, int> _status, int _statusID, Dictionary<OptionObject<string>, int> _type, int _typeID)
        {
            Name = _name;
            Description = _desc;
            Type = _type;
            StartDate = _startDate;
            ExpEndDate = _expEndDate;
            RealEndDate = _readlEndDate;
            StatusID = _statusID;
            Status = _status;
            TypeID = _typeID;
            Type = _type;

        }

        public int ProjectID  //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public string ProjectName
        {
            get =>Name;
            set => Name = value;
        }

        public string ProjectDescription
        {
            get => Description;
            set => Description = value;
        }

        public DateOnly ProjectStartDate
        {
            get => StartDate;
            set => StartDate = value;
        }

        public DateOnly ProjectExpectedEndDate
        {
            get => ExpEndDate;
            set => ExpEndDate = value;
        }

        public DateOnly ProjectRealEndDate
        {
            get => RealEndDate;
            set => RealEndDate = value;
        }

        public int ProjectStatusID
        {
            get => StatusID;
            set => StatusID = value;
        }

        public int ProjectTypeID
        {
            get => TypeID;
            set => TypeID = value;
        }

        public Dictionary<OptionObject<string>, int> ProjectStatus
        {
            get => Status;
            set => Status = value;
        }

        public Dictionary<OptionObject<string>, int> ProjectType
        {
            get => Type;
            set => Type = value;
        }

        public string ProjectStatusDisplay()
        {
            string statusName = Status.Keys.ElementAt(StatusID).Description;
            return statusName;
        }

        public string ProjectTypeDisplay()
        {
            string statusName = Type.Keys.ElementAt(TypeID).Description;
            return statusName;
        }

        public string ProjectInfoDisplay()
        {
            string _projectInfo;
            _projectInfo=   "Name of Project: " + Name +
                                    ",\n"+Description+
                                    ".\nCreated on: " + StartDate +
                                    ",\nwith expected end date: " + ExpEndDate +
                                    ".\nProject "+Name+ "  is type " + ProjectTypeDisplay() +
                                    ",\nand the current stats is " + ProjectStatusDisplay();


            return _projectInfo;
        }

    }
}


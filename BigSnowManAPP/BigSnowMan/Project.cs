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

namespace Project
{
    public class ProjectObject : ProjectInterface
    { 
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

        public string ProjectStartDate
        {
            get => Description;
            set => Description = value;
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

        public string ProjectStatusDisplay(int _statusID)
        {
            string statusName = Status.Keys.ElementAt(_statusID).Description;
            return statusName;
        }

        public string ProjectTypeDisplay(int _typeID)
        {
            string statusName = Type.Keys.ElementAt(_typeID).Description;
            return statusName;
        }

    }
}


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


namespace Record
{
	public class RecordObject 
	{
		private int ToolObjectID;
        private int ID;
		private DateOnly Date;


		public RecordObject(int _toollobjectId, DateOnly _date)
		{
            ID = _toollobjectId;
            Date = _date;
        }

        public int ToolID  
        {
            get => ToolObjectID;
            set => ToolObjectID = value;
        }
        public int RecordID  //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public DateOnly RecordDate
        {
            get => Date;
            set => Date = value;
        }

        public string displayRecordInfo()
        {
            string _recordInfo;
            _recordInfo = "Record ID: " + ID +
                                    ".\nCreated on: " + Date +".";
            return _recordInfo;
        }

        //create calculations
    }
}


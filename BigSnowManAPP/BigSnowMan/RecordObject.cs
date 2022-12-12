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
using CalculationTool;


namespace Record
{
	public class RecordObject 
	{
        

		private int ToolObjectID;
        private int ID;
		private DateOnly Date;

        //Calculations
        CostVarianceCalculationObject CV;
        ScheduleVarianceCalculationObject SV;
        VarianceCompletionCalculationObject VC;
        CostPerformanceIndexCalculationObject CPI;
        SchedulePerformanceIndexCalculationObject SPI;

        //delegates
        delegate CostVarianceCalculationObject CVDelegate(int _id); //class delegate
        delegate ScheduleVarianceCalculationObject SVDelegate(int _id);
        delegate VarianceCompletionCalculationObject VCDelegate(int _id);
        delegate CostPerformanceIndexCalculationObject CPIDelegate(int _id);
        delegate SchedulePerformanceIndexCalculationObject SPIDelegate(int _id);


        public RecordObject(int _toollobjectId, DateOnly _date)
		{
            ID = _toollobjectId;
            Date = _date;
            CVDelegate cv = new CVDelegate(CVcreation);  //new object delegate with method as parameter
            SVDelegate sv = new SVDelegate(SVcreation);  
            VCDelegate vc = new VCDelegate(VCcreation);  
            CPIDelegate cpi = new CPIDelegate(CPIcreation);  
            SPIDelegate spi = new SPIDelegate(SPIcreation);  

            CV = cv(ID);
            SV = sv(ID);
            VC = vc(ID);
            CPI = cpi(ID);
            SPI = spi(ID);

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

        public CostVarianceCalculationObject getCostVarianceObject()
        {
            return CV;
        }

        public string GetCostVarianceInfo()
        {
            return CV.displayCalculationResult();
        }

        public string displayRecordInfo()
        {
            string _recordInfo;
            _recordInfo = "\n\nRecord ID: " + ID +
                                    ".\nCreated on: " + Date + "." +
                                    "\n\nCost Variation Calculation: " +
                                    CV.displayCalculationResult()+
                                    SV.displayCalculationResult()+
                                    VC.displayCalculationResult()+
                                    CPI.displayCalculationResult()+
                                    SPI.displayCalculationResult();
            //include here all information from calculations.
            return _recordInfo;
        }

        //create calculations
        public CostVarianceCalculationObject CVcreation(int _id)
        {
            CostVarianceCalculationObject _cv = new CostVarianceCalculationObject(_id);
            return _cv;
        }

        public ScheduleVarianceCalculationObject SVcreation(int _id)
        {
            ScheduleVarianceCalculationObject _sv = new ScheduleVarianceCalculationObject(_id);
            return _sv;
        }

        public VarianceCompletionCalculationObject VCcreation(int _id)
        {
            VarianceCompletionCalculationObject _vc = new VarianceCompletionCalculationObject(_id);
            return _vc;
        }

        public CostPerformanceIndexCalculationObject CPIcreation(int _id)
        {
            CostPerformanceIndexCalculationObject _cv = new CostPerformanceIndexCalculationObject(_id);
            return _cv;
        }

        public SchedulePerformanceIndexCalculationObject SPIcreation(int _id)
        {
            SchedulePerformanceIndexCalculationObject _cv = new SchedulePerformanceIndexCalculationObject(_id);
            return _cv;
        }
    }
}


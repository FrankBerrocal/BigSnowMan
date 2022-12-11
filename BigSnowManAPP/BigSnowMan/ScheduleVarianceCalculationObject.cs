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


namespace CalculationTool
{
    public class ScheduleVarianceCalculationObject
    {
        private int RecordID;
        private int ScheduleVariance_ID;
        private double EV;  //earned value
        private double PV;  //planned value
        private double SVValue;  //schedule variance metric.

        public ScheduleVarianceCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int ScheduleVarianceID  //retrieve after insertion of data in SQL
        {
            get => ScheduleVariance_ID;
            set => ScheduleVariance_ID = value;
        }

        public double variableEV
        {
            get => EV;
            set => EV = value;
        }

        public double variablePV
        {
            get => PV;
            set => PV = value;
        }

        public double variableSVValue
        {
            get => SVValue;
            set => SVValue = value;
        }

        public double calculationSubtraction(double _var1, double _var2)
        {
            double _calculationResult = 0;
            EV = _var1;  
            PV = _var2; 
            try
            {
                _calculationResult = _var1 - _var2;
                SVValue = _calculationResult;  
            }
            catch (Exception e)
            {
                Console.WriteLine("Check format of variables in Sum method, parent calculation" + e.Message);
            }
            return _calculationResult;
        }

        public string displayCalculationResult()
        {
            string _calculationResult;
            _calculationResult = "Schedule Variance result:" +
                                        "\nEarned Value:\t" + EV +
                                        "\nActual Cost:\t" + PV +
                                        "\nCost Variance:\t" + SVValue;

            return _calculationResult;
        }
    }
}

/*
 * 
 * References
 * inheritance and Constructors:  https://www.geeksforgeeks.org/c-sharp-inheritance-in-constructors/
 * 
 */
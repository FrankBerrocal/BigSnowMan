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
using System.Xml.Linq;

namespace CalculationTool
{
    public class CostVarianceCalculationObject
    {
        private int RecordID;
        private int CostVariance_ID;
        private double EV;  //earned value
        private double AC;  //actual cost
        private double CVValue;  // Cost Variance result
  
        public CostVarianceCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int CostVarianceID  //retrieve after insertion of data in SQL
        {
            get => CostVariance_ID;
            set => CostVariance_ID = value;
        }

        public double variableEV
        {
            get => EV;
            set => EV = value;
        }

        public double variableAC
        {
            get => AC;
            set => AC = value;
        }

        public double variableCVValue
        {
            get => CVValue;
            set => CVValue = value;
        }

        public double calculationSubtraction(double _var1, double _var2)
        {
            double _calculationResult = 0;
            
            EV = _var1;  
            AC = _var2; 
            try
            {
                _calculationResult = _var1 - _var2;
                CVValue = _calculationResult;  
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

            _calculationResult = "\n\nCost Variance result:" +
                                    "\nEarned Value:\t" + EV +
                                    "\nActual Cost:\t" + AC +
                                    "\nCost Variance:\t" + CVValue;

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
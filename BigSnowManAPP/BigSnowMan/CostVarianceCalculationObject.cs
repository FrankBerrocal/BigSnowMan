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
        private float EV;
        private float AC;
        private float CVValue;
  
        public CostVarianceCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int CostVarianceID  //retrieve after insertion of data in SQL
        {
            get => CostVariance_ID;
            set => CostVariance_ID = value;
        }

        public float variableEV
        {
            get => EV;
            set => EV = value;
        }

        public float variableAC
        {
            get => AC;
            set => AC = value;
        }

        public float variableCVValue
        {
            get => CVValue;
            set => CVValue = value;
        }

        public float calculationSubtraction(float _var1, float _var2)
        {
            float _calculationResult = 0;
            EV = _var1;  //earned value
            AC = _var2; //actual cost
            try
            {
                _calculationResult = _var1 - _var2;
                CVValue = _calculationResult;  //cost variance value
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
            _calculationResult = "Cost Variance result:"+
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
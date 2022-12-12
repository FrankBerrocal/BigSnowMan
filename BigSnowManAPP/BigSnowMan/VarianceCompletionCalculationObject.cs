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
    public class VarianceCompletionCalculationObject
    {
        private int RecordID;
        private int VarianceCompletion_ID;
        private double BAC;  //budget at completion
        private double EAC;  //estimate at completion
        private double VCValue;

        public VarianceCompletionCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int VarianceCompletionID  //retrieve after insertion of data in SQL
        {
            get => VarianceCompletion_ID;
            set => VarianceCompletion_ID = value;
        }

        public double variableBAC
        {
            get => BAC;
            set => BAC = value;
        }

        public double variableEAC
        {
            get => EAC;
            set => EAC = value;
        }

        public double variableVCValue
        {
            get => VCValue;
            set => VCValue = value;
        }

        public double calculationSubtraction(double _var1, double _var2)
        {
            double _calculationResult = 0;
            BAC = _var1;  
            EAC = _var2; 
            try
            {
                _calculationResult = _var1 - _var2;
                VCValue = _calculationResult;  
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
            _calculationResult = "\n\nVariance at Completion result:" +
                                        "\nBudget at Completion Value:\t" + BAC +
                                        "\nEstimated at Completion Value:\t" + EAC +
                                        "\nVariance at Completion:\t\t" + VCValue;

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

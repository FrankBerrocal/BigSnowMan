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
    public class CostPerformanceIndexCalculationObject
    {
        private int RecordID;
        private int CostPerfIndex_ID;
        private double EV;  //Earned Value
        private double AC;  //Actual Cost
        private double CPIValue;

        public CostPerformanceIndexCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int CostPerfIndexID  //retrieve after insertion of data in SQL
        {
            get => CostPerfIndex_ID;
            set => CostPerfIndex_ID = value;
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

        public double variableCPIValue
        {
            get => CPIValue;
            set => CPIValue = value;
        }

        public double calculationDivision(double _var1, double _var2)
        {
            double _calculationResult = 0;
            EV = _var1;
            AC = _var2;
            try
            {
                _calculationResult = _var1 / _var2;
                CPIValue = _calculationResult;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by Zero not allowed" + e.Message);
            }
            catch(FormatException f)
            {
                Console.WriteLine("Check format of variables in Division method, parent calculation");
            }
            return _calculationResult;
        }

        public string displayCalculationResult()
        {
            string _calculationResult;
            _calculationResult = "Cost Performance Index result:" +
                                        "\nEarned Value:\t\t\t" + EV +
                                        "\nActual Cost Value:\t\t" + AC +
                                        "\nCost Perfornance Index Value:\t" + CPIValue;

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

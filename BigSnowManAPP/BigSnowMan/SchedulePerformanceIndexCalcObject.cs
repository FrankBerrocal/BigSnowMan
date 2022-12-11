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
    public class SchedulePerformanceIndexCalculationObject
    {
        private int RecordID;
        private int SchedulePerfIndex_ID;
        private double EV;  //earned value
        private double PV;  //planned value
        private double SPIValue;  //schedule variance metric.

        public SchedulePerformanceIndexCalculationObject(int _recID)
        {
            RecordID = _recID;
        }

        public int SchedulePerfIndexID  //retrieve after insertion of data in SQL
        {
            get => SchedulePerfIndex_ID;
            set => SchedulePerfIndex_ID = value;
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

        public double variableSPIValue
        {
            get => SPIValue;
            set => SPIValue = value;
        }

        public double calculationDivision(double _var1, double _var2)
        {
            double _calculationResult = 0;
            EV = _var1;
            PV = _var2;
            try
            {
                _calculationResult = _var1 / _var2;
                SPIValue = _calculationResult;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by Zero not allowed" + e.Message);
            }
            catch (FormatException f)
            {
                Console.WriteLine("Check format of variables in Division method, parent calculation");
            }
            return _calculationResult;
        }

        public string displayCalculationResult()
        {
            string _calculationResult;
            _calculationResult = "Schedule Performance Index result:" +
                                        "\nEarned Value:\t\t\t\t" + EV +
                                        "\nActual Cost:\t\t\t\t" + PV +
                                        "\nSchedule Performance Index Value:\t" + SPIValue;

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
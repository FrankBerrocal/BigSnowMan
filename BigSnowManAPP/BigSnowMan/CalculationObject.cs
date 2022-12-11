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


	public class CalculationObject 
	{

		private int ID;
		private int RecordID;
		private float Variable1;
		private float Variable2;
		private float Variable3;
		private float Variable4;
		private float Result;
		



        public int CalculationID  //retrieve after insertion of data in SQL
        {
            get => ID;
            set => ID = value;
        }

        public float WorkVariable1  
        {
            get => Variable1;
            set => Variable1 = value;
        }

        public float WorkVariable2 
        {
            get => Variable2;
            set => Variable2 = value;
        }

        public float WorkVariable3 
        {
            get => Variable3;
            set => Variable3 = value;
        }

        public float WorkVariable4 
        {
            get => Variable4;
            set => Variable4 = value;
        }

        public float WorkResult 
        {
            get =>  Result;
            set => Result = value;
        }

        public virtual float calculation2(int _var1, int _var2)
		{
            float _calculationResult = 0;
            return _calculationResult;
        }

        public virtual string displayCalculationInfo()
		{
            string _calculationInfo = "";
            return _calculationInfo;
            
		}
	}



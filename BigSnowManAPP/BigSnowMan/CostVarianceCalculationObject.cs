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




    public class CostVarianceCalculationObject : CalculationObject
    {
        private int ID;
        private int RecordID;
        private float Variable1;
        private float Variable2;
        private float Variable3;
        private float Variable4;
        private float Result;
        
        public CostVarianceCalculationObject(int _recID)
        {
            RecordID = _recID;
         }

        

        

        public override float calculation2(int _var1, int _var2)
        {
            float _calculationResult = 0;
            // insertar las operaciones aqui, necesito usar delegados por fuerza y lamdas
            return _calculationResult;
        }
    }


/*
 * 
 * References
 * inheritance and Constructors:  https://www.geeksforgeeks.org/c-sharp-inheritance-in-constructors/
 * 
 */
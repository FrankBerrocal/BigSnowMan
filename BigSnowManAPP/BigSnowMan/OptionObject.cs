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

namespace BigSnowMan
{
	public class OptionObject<T>
	{
		
        private T Option; // field

        public OptionObject(T _option)
        {
            Option = _option;
        }

        public T Description
        // property
        {
            get { return Option; }
            set { Option = value; }
        }
    }
}


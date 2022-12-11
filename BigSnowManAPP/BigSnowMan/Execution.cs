using System;
using System.Collections.Generic;

namespace BigSnowMan
{
	public class Execution
	{
		static void Main(string[] args)
		{
			//Database Ulysses = new Database();

			//Creation of list of status descriptions

			Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();
			StatusObject StatusCreation = new StatusObject();

			Status = StatusCreation.CreateStatus();

			
			
			


        }
	}
}


/*
 * Reaching the Objects inside the Dictionary 
 * Console.WriteLine(	 Status.Keys.ElementAt(1).Option.ToString());
 * 
 * 
 * 
 */

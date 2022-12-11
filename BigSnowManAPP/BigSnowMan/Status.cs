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
using System.Collections.Generic;
using BigSnowMan;

namespace Status
{
    public class StatusObject
    {

        public StatusObject()  //persistent data, no need to receive the descriptors everytime
        {
            CreateStatus();
        }

        public Dictionary<OptionObject<string>, int> CreateStatus()  //OptionObject forced to string parameter
        {
            Dictionary<OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();

            OptionObject<string> Active = new OptionObject<string>("Active");
            OptionObject<string> Archived = new OptionObject<string>("Archived");
            OptionObject<string> Cancelled = new OptionObject<string>("Cancelled");
            OptionObject<string> Completed = new OptionObject<string>("Completed");
            OptionObject<string> Draft = new OptionObject<string>("Draft");
            OptionObject<string> OnHold = new OptionObject<string>("On Hold");
            OptionObject<string> UnderReview = new OptionObject<string>("Under Review ");

            Status.Add(Active, 1);
            Status.Add(Archived, 2);
            Status.Add(Cancelled, 3);
            Status.Add(Completed, 4);
            Status.Add(Draft, 5);
            Status.Add(OnHold, 6);
            Status.Add(UnderReview, 7);

            string test = Status.Keys.ElementAt(1).Description;

            return Status;
        }

        public void DisplayStatus(Dictionary<OptionObject<string>, int> _status)
        {

            foreach (OptionObject<string> element in _status.Keys)
                Console.WriteLine(element.Description);

        }



    }
}

/*
 * This generic dictionary is adding generic OptionObject types, each one defined as a status.
 * The numberic value corresponds to the database primary key of the table with the same name. 
 * 
 * Then, the dictionary object is return to be consumed but the other entities. 
 * 
 * In a further implementation, this can be created as an object, and send the number of parameters and names, and include the data via iteration.
 * 
 * //Console.WriteLine(_status.Keys.ElementAt(i).ToString()); Method of my base generic object to display description only.
 * 
 * References:
 * 
 * Iteration example https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/ 
 * 
 * 
 * 
 * 
 */






//Regular encapsulation code.

/*
public class StatusObject
{
    public string Status;


    public StatusObject(String _status)
    {
        Status = _status;
    }
    public string getStatus()
    {
        return Status;
    }
    public override string ToString()
    {
        return Status;
    }
}
*/


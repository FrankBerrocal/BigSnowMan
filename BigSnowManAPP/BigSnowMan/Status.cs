using System;
using System.Collections.Generic;



public class StatusObject
{
   
    public StatusObject()
    {
        CreateStatus();
    }

    public Dictionary<OptionObject<string>, int> CreateStatus( )
    {
        Dictionary< OptionObject<string>, int> Status = new Dictionary<OptionObject<string>, int>();

        OptionObject<String> Active= new OptionObject<string>("Active");
        OptionObject<String> Archived = new OptionObject<string>("Archived");
        OptionObject<String> Cancelled = new OptionObject<string>("Cancelled");
        OptionObject<String> Completed= new OptionObject<string>("Completed");
        OptionObject<String> Draft= new OptionObject<string>("Draft");
        OptionObject<String> OnHold = new OptionObject<string>("On Hold");
        OptionObject<String> UnderReview = new OptionObject<string>("On Hold");

        Status.Add(Active, 1);
        Status.Add(Archived, 2);
        Status.Add(Cancelled, 3);
        Status.Add(Completed, 4);
        Status.Add(Draft, 5);
        Status.Add(OnHold, 6);
        Status.Add(UnderReview, 7);

        DisplayStatus(Status);
        return Status;
    }

    public static void  DisplayStatus(Dictionary<OptionObject<string>, int> _status)
    {
        foreach(Dictionary<OptionObject<string>, int> _stats in _status)
        {

            Console.WriteLine("{ 0 } and { 1 }", _stats.Keys, _stats.Values);
            //Console.WriteLine(_status.Keys.ElementAt(i).ToString());
        }
            


    }

}

/*
 * This generic dictionary is adding generic OptionObject types, each one defined as a status.
 * The numberic value corresponds to the database primary key of the table with the same name. 
 * 
 * Then, the dictionary object is return to be consumed but the other entities. 
 * 
 * 
 * References:
 * 
 * Iteration example https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/ 
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


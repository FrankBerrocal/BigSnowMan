using System;
using System.Collections.Generic;



public class OptionObject<OptionDesc>
{
    public OptionDesc Option;
    

    public OptionObject(OptionDesc _option)
    {
        Option = _option;
    }

    public override string ToString() => String.Format(Option.ToString());  
}



//Generic objects to replace multiple entities used to create selection elements, like status and project type.  


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


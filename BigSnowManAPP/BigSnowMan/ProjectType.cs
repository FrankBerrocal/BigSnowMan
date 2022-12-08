using System;
using System.Collections.Generic;



public class ProjectTypeObject
{
    public string Type;
    private int databaseID;

    public ProjectTypeObject(String _type)
    {
        Type = _type;
    }
    public string getStatus()
    {
        return Type;
    }
    public override string ToString()
    {
        return Type;
    }
}





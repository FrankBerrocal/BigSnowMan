using System.Security.AccessControl;
using System;

public class FirstObject
{
    private int Alpha { get; set; }
    private int Beta { get; set; }

    public void FirstObject(int a, int b)
    {
        Alpha = a;
        Beta = b;
    }
}
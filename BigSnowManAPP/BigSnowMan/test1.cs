using System;


class AreaOfTank : Tank
{

    string Color;

    // Constructor
    public AreaOfTank(string c, double r, double h)
    {

        // from base class
        Radius = r;
        Height = h;

        // from derived class
        Color = c;
    }

    // Return area of tank
    public double Area()
    {
        return 2 * 3.14 * Radius * Height;
    }

    // Display the color of tank
    public void DisplayColor()
    {
        Console.WriteLine("The Color of tank is "
                                        + Color);
    }
}

// Driver Class
class GFG
{

    // Main Method
    static void Main()
    {

        // Create and initialize the
        // object of AreaOfTank
        AreaOfTank t1 = new AreaOfTank("Green", 6.0, 12.0);
        t1.DisplayColor();
        t1.DisplayDimension();
        Console.WriteLine("Area is " + t1.Area());
    }
}


using System;

// Class Tank to give the
// dimension of the tank
class Tank
{

    double t_radius;
    double t_height;

    // Properties for Radius and Height
    public double Radius
    {
        get
        {
            return t_radius;
        }

        set
        {
            t_radius = value < 0 ? -value : value;
        }
    }

    public double Height
    {
        get
        {
            return t_height;
        }

        set
        {
            t_height = value < 0 ? -value : value;
        }
    }

    // Display the dimension of tanks
    public void DisplayDimension()
    {
        Console.WriteLine("The radius of tank is :" + Radius
                 + " and the height of tank is :" + Height);
    }
}


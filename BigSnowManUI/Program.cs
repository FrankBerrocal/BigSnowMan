using System;
using BigSnowManLibrary;

namespace BigSnowManUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel
            {
                FirstName = "Frank",
                LastName = "Berrocal",
                Age = 35
            };

            System.Console.WriteLine("hello world!");
            System.Console.WriteLine("This is a test");
            System.Console.WriteLine("The End");

            System.Console.WriteLine($"{person.FirstName} {person.LastName} is my name, and my age is {person.Age}");
        }
    }
}
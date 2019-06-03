using System;

namespace gradebook
{
    public class Statistics
    {
        public double Average 
        {
            get
            {
                return Sum / Count;
            } 
        }
        public double Low {get; set;}
        public double High {get; set;}
        public char Letter
        {
            get
            {
                if (Average >= 90.0)
                    return 'A';
                else if (Average >= 80.0)
                    return 'B';
                else if (Average >= 70.0)
                    return 'C';
                else if (Average >= 60.0)
                    return 'D';
                else
                    return 'F';
            }
        }

        public double Sum;
        public int Count;


        public Statistics()
        {
            //low and high are set this way so that they will have values 
            //overwritten when compared with grades that conform to the 
            //0.0 to 100.0 setup
            Low = 100.0;
            High = 0.0;
        }

        public void Display()
        {
            Console.WriteLine($"The lowest grade is {Low:N2}");
            Console.WriteLine($"The highest grade is {High:N2}");
            Console.WriteLine($"The average grade is {Average:N2}");
        }
    }

}
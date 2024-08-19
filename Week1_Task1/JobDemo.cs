/*using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

Step 1: Create an application named JobDemo that declares and uses Job objects. The Job class holds job information for a home repair service. The class has five properties that include a job number, customer name, job description, estimated hours, and price for the job.

Step 2: Create a constructor that requires parameters for all the data except the price. Include auto-implemented properties for the job number, customer name, and job description, but not for hours or price; the price field value is calculated as estimated hours times $45.00 whenever the hours value is set.

Step 3: Create the following for the class:

An Equals() method that determines two Job s are equal if they have the same job number.
 A GetHashCode() method that returns the job number.
 A ToString() method that returns a string containing all job information.
The JobDemo application declares a few Job objects, sets their values and demonstrates that all the methods work as expected.
*/

using System;
using static System.Console;

class JobDemo
{
    static void Main()
    {
        Job job1 = new Job(111, "Smith", "exterior paint", 20);
        Job job2 = new Job(222, "Vega", "gutter clean", 4);
        Job job3 = new Job(111, "Land", "blacktop drive", 10);
        WriteLine(job1.ToString());
        WriteLine(job2.ToString());
        WriteLine(job3.ToString());
        CompareNumbers(job1, job2);
        CompareNumbers(job1, job3);
    }
    internal static void CompareNumbers(Job job1, Job job2)
    {
        if (job1.Equals(job2))
            WriteLine("{0} for {1} has the same job " +
            "number as {2} for {3}",
            job1.JobNumber, job1.Customer,
            job2.JobNumber, job2.Customer);
    }
}

class Job
{
    private double hours;
    private double price;
    public const double RATE = 45.00;

    //Constructor
    public Job(int num, string cust, string desc, double hrs)
    {
        JobNumber = num;
        Customer = cust;
        Description = desc;
        Hours = hrs;
    }
    public int JobNumber { get; set; }
    public string Customer { get; set; }
    public string Description { get; set; }
    public double Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = value;
            price = hours * RATE;
        }
    }
    public double Price
    {
        get
        {
            return price;
        }
    }
    public override string ToString()
    {
        return (GetType() + " " + JobNumber + " " + Customer + " " +
           Description + " " + Hours + " hours @ " + RATE.ToString("C") +
           " per hour. Total price is " + Price.ToString("C"));
    }
    public override bool Equals(Object e)
    {
        bool equal;
        Job temp = (Job)e;
        if (JobNumber == temp.JobNumber)
            equal = true;
        else
            equal = false;
        return equal;
    }
    public override int GetHashCode()
    {
        return JobNumber;
    }
}

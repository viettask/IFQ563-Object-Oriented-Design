/*
Step 1: Create a RushJob class that derives from Job . A RushJob has a $150.00 premium that is added to the normal price of the job.

Step 2: Override any methods in the parent class as necessary.

Step 3: Write a new application named JobDemo3 that creates an array of five RushJobs.

Step 4: Prompt the user for values for each, and do not allow duplicate job numbers.

Step 5: When five valid RushJob objects have been entered, display them all, plus a total of all prices.*/


using System;
using static System.Console;
class JobDemo3
{
    static void Main()
    {
        Job[] jobs = new RushJob[5];
        int x, y;
        double grandTotal = 0;
        bool goodNum;
        for (x = 0; x < jobs.Length; ++x)
        {
            jobs[x] = new RushJob();
            Write("Enter job number ");
            jobs[x].JobNumber = Convert.ToInt32(ReadLine());
            goodNum = true;
            for (y = 0; y < x; ++y)
            {
                if (jobs[x].Equals(jobs[y]))
                    goodNum = false;
            }
            while (!goodNum)
            {
                Write("Sorry, the job number " +
                   jobs[x].JobNumber + " is a duplicate. " +
                   "\nPlease reenter ");
                jobs[x].JobNumber = Convert.ToInt32(ReadLine());
                goodNum = true;
                for (y = 0; y < x; ++y)
                {
                    if (jobs[x].Equals(jobs[y]))
                        goodNum = false;
                }
            }
            Write("Enter customer name ");
            jobs[x].Customer = ReadLine();
            Write("Enter description ");
            jobs[x].Description = ReadLine();
            Write("Enter estimated hours ");
            jobs[x].Hours = Convert.ToDouble(ReadLine());
        }
        WriteLine("\nSummary:\n");
        for (x = 0; x < jobs.Length; ++x)
        {
            WriteLine(jobs[x].ToString());
            grandTotal += jobs[x].Price;
        }
        WriteLine("\nTotal for all jobs is " + grandTotal.ToString("C"));
    }

}
class Job
{
    protected double hours;
    protected double price;
    public const double RATE = 45.00;
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
           Description + " " + Hours + " hours @" + RATE.ToString("C") +
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

class RushJob : Job
{
    public const double PREMIUM = 150.00;
    public RushJob() : base(0, "", "", 0)
    {
    }
    public override string ToString()
    {
        return (GetType() + " " + JobNumber + " " + Customer + " " +
           Description + " " + Hours + " hours @" + RATE.ToString("C") +
           " per hour. Rush job adds " + PREMIUM +
           " premium. Total price is " + Price.ToString("C"));
    }
    public new double Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = value;
            price = hours * RATE + PREMIUM;
        }
    }
}

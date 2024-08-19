﻿/*
Step 1: Make any necessary modifications to the RushJob class so that it can be sorted by job number.

Step 2: Modify the JobDemo3 application so the displayed orders have been sorted.

Step 3: Save the application as JobDemo4.
*/

using System;
using static System.Console;
class JobDemo4
{
    static void Main()
    {
        RushJob[] jobs = new RushJob[5];
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
        Array.Sort(jobs);
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

class RushJob : Job, IComparable
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
    int IComparable.CompareTo(Object o)
    {
        int returnVal;
        RushJob temp = (RushJob)o;
        if (this.JobNumber > temp.JobNumber)
            returnVal = 1;
        else
           if (this.JobNumber < temp.JobNumber)
            returnVal = -1;
        else
            returnVal = 0;
        return returnVal;
    }
}

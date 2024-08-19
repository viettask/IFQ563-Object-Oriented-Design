/*
Step 1: Create a program named WritePatientRecords that allows a doctor's staff to enter data about patients 
and save the data to a file. 
Create a Patient class that contains fields for an ID number, name, and current balance owed to the doctor's office.

Step 2: Create a Patient class that contains fields for an ID number, name, and current balance owed to the doctor's office.
 * */


// file saved : C:\Users\vietn\Dropbox\C#\Week4_Task1\Week4_Task1\bin\Debug\net8.0\Patients.txt
using System;
using static System.Console;
using System.IO;
class WritePatientRecords
{
    static void Main()
    {
        const char DELIM = ',';
        const string END = "999";
        const string FILENAME = "Patients.txt";
        Patient patient = new Patient();
        FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(outFile);
        Write("Enter patient ID number or " + END +
           " to quit >> ");
        patient.IdNum = ReadLine();
        while (patient.IdNum != END)
        {
            Write("Enter last name >> ");
            patient.Name = ReadLine();
            Write("Enter balance >> ");
            patient.Balance = Convert.ToDouble(ReadLine());
            writer.WriteLine(patient.IdNum + DELIM + patient.Name +
               DELIM + patient.Balance);
            Write("Enter next patient ID number or " +
               END + " to quit >> ");
            patient.IdNum = ReadLine();
        }
        writer.Close();
        outFile.Close();
    }
}

class Patient
{
    public string IdNum { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public new string ToString()
    {
        return ("#" + IdNum + ',' + Name + ',' + Balance);
    }
}
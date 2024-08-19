/*
 Step 1: Create a program named DirectoryInformation that allows a user to continually enter directory names until the user types end.

Step 2: If the directory name exists, display a list of the files in it, otherwise, display a message indicating the directory does not exist.

Step 3: Create as many test directories and files as necessary to test your program.
*/

using System;
using static System.Console;
using System.IO;
class DirectoryInformation
{
    static void Main()
    {
        string directory;
        string[] files;
        int x;
        const string END = "end";
        Write("Enter a directory >> ");
        directory = ReadLine();
        while (directory != END)
        {
            if (Directory.Exists(directory))
            {
                files = Directory.GetFiles(directory);
                if (files.Length == 0)
                    WriteLine("There are no files in this directory: " + directory);
                else
                {
                    WriteLine(directory + " contains the following files");
                    for (x = 0; x < files.Length; ++x)
                        WriteLine("  " + files[x]);
                }
            }
            else
            {
                WriteLine("Directory " + directory + " does not exist");
            }
            Write("\nEnter another directory or type " + END + " to quit >> ");
            directory = ReadLine();
        }
    }
}

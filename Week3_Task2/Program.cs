/*
 Step 1: Create a program named FileComparison​ that compares two files.

Step 2: Use a text editor such as Notepad to save your favourite movie quote.

Step 3: Copy the file contents, and paste them into a word-processing program such as Word.

Step 4: Write the file-comparison application that displays the sizes of the two files as well as the ratio of their sizes to each other.

To discover a file's size, you can create a System.IO.FileInfo​ object using statements such as the following, where FILE_NAME​ is a string that contains the name of the file, and ​size​ has been declared as an integer:

PREFileInfo fileInfo = new FileInfo(FILE_NAME);

size = fileInfo.Length;
 */

using System;
using static System.Console;
using System.IO;
class FileComparison
{
    static void Main()
    {
        const string WORD_FILE = @"C:\CSharp\Chapter14\Quote.docx";
        const string NOTEPAD_FILE = @"C:\CSharp\Chapter14\Quote.txt";
        long wordSize;
        long notepadSize;
        double ratio;
        FileInfo wordInfo = new FileInfo(WORD_FILE);
        FileInfo notepadInfo = new FileInfo(NOTEPAD_FILE);
        wordSize = wordInfo.Length;
        notepadSize = notepadInfo.Length;
        WriteLine("The size of the Word file is " + wordSize +
            "\nand the size of the Notepad file is " + notepadSize);
        ratio = (double)notepadSize / wordSize;
        WriteLine("The Notepad file is {0} of the size of the Word file", ratio.ToString("P2"));
    }
}
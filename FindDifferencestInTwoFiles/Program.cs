using System.Collections.Generic;

namespace PrintOutDifferencesInTwoTextFiles
{

    // This program prints out the lines contents differences between File1 and File2
    class Program
    {
        static void Main(string[] args)
        {

            IDictionary<string, int> file1Contents = new Dictionary<string, int>();

            string line1;

            // Read the text file and store it in a dictionary line by line.  
            System.IO.StreamReader file1 =
                new System.IO.StreamReader("File1.txt");
            while ((line1 = file1.ReadLine()) != null)
            {
                string trimmedString = line1.Trim();
                if (!file1Contents.ContainsKey(trimmedString))
                {
                    file1Contents.Add(trimmedString, 1);
                }
            }

            file1.Close();

            string line2;

            // Read the file and display it line by line.  
            System.IO.StreamReader file2 =
                new System.IO.StreamReader("File2.txt");

            IDictionary<string, int> file2Contents = new Dictionary<string, int>();

            while ((line2 = file2.ReadLine()) != null)
            {
                string trimmedString = line2.Trim();
                if (!file2Contents.ContainsKey(trimmedString))
                {
                    file2Contents.Add(trimmedString, 1);
                }
            }

            file2.Close();

            System.Console.WriteLine("**************Lines exist in File1 but not File2****************");

            foreach (KeyValuePair<string, int> entry in file1Contents)
            {
                if (!file2Contents.ContainsKey(entry.Key))
                {
                    System.Console.WriteLine(entry.Key);
                }
            }

            System.Console.WriteLine("**************Lines exist in File2 but not File1****************");

            foreach (KeyValuePair<string, int> entry in file2Contents)
            {
                if (!file1Contents.ContainsKey(entry.Key))
                {
                    System.Console.WriteLine(entry.Key);
                }
            }

            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}

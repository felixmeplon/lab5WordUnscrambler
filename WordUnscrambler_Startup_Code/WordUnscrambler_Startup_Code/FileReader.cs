using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    // Read all lines from the file and return them as an array of strings
                    return File.ReadAllLines(filename);
                }
                catch (IOException e)
                {
                    // Handle any IOException that might occur while reading the file
                    Console.WriteLine(sdfb.Properties.Constants.errorread + e.Message);
                }
            }
            else
            {
                Console.WriteLine(sdfb.Properties.Constants.fdne + filename);
            }

            // Return an empty array if there was an error or the file does not exist
            return new string[0];

        }
    }
}

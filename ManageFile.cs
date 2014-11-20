using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace allstate
{
    public class ManageFile
    {
        string file;
        public string ReadFile(string location, ref bool fileIsThere)//pulls the respective .txt file into a string variable. If false false is not there
        {
            try
            {
                using (StreamReader reader = new StreamReader(location))
                {
                    file = reader.ReadToEnd();
                }
                fileIsThere = true;
            }
            catch (Exception e)
            {
                fileIsThere = false;
            }
            return file;
        }
        public void AppendPolicies(string policy)
        {
            using (StreamWriter sw = File.AppendText(@"c:\test\policies.txt"))
            {
                sw.WriteLine(policy);
            }
        }
        public void WriteToFile(string location, string update)// new write to file
        {
            if (location != null)
            {
                using (StreamWriter writer = new StreamWriter(location))
                {
                    writer.Write(update);
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            else
            {
                // i know i need something here.... 
            }
        }
    }
}

    
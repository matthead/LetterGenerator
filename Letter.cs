using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allstate
{
    class Letter
    {
        string name, amount, address, policy, date, policyType,file;

        public void UpdateFile(string file2)//Parses the .txt file with information that is in the variables
        {
            Form1 form = new Form1();
            if (IsValid())
            {
                this.file = file2;
                name.Trim();
                ManageFile manageFile = new ManageFile();
                bool fileIsThere = false; //flag for checking if file exists
                string location = @"c:\test\" + policyType.Trim()+ ".txt"; //reading file
                file = manageFile.ReadFile(location, ref fileIsThere);
                if (fileIsThere)
                {
                    if (name.Contains("&"))
                        file = file.Replace("XXXX12345", name.Substring(0, name.LastIndexOf(" ")));
                    else if (name.Contains(" "))
                        file = file.Replace("XXXX12345", name.Substring(0, name.IndexOf(" ")));
                    file = file.Replace("fullname", name);
                    file = file.Replace("xx1/xx1/xxxx1", DateTime.Now.ToString("M/d/yyyy"));
                    file = file.Replace("xx.xx", amount);
                    file = file.Replace("xx2/xx2/xxxx2", date);
                    file = file.Replace("addressgoeshere", address);
                    file = file.Replace("#number", policy);
                }
                else//file is not there
                {
                    throw new LetterException( "the letter for that database is not there");
                }
            }
            else //data is not vaild
            {
                throw new LetterException("in vaild date please re-enter the information");
            }
        }
        public bool IsValid()
        {
            bool flag = true;//if false all data is good
            if (name.Length == 0)
            {;
                flag = false;
            }
            if(amount.Length==0)
            {
                flag = false;
            }
            if (address.Length == 0)
            {
                flag = false;
            }
            if (policy.Length == 0)
            {
                flag = false;
            }
            if (policyType == "")
            {
                flag = false;
            }
            if (flag == false)
            {
                return false;
            }
             return true;
        }
        public override string ToString()
        {
            return base.ToString()+file;
        } 
        /// <summary>
        ///  I know u hate this code, but it makes sense to me at least for now
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <param name="policy"></param>
        /// <param name="policyType"></param>
        public Letter(string name, string address, string date, string amount, string policy, string policyType)//initializes variables 
        {
            this.name = name;
            this.address = address;
            this.date = date;
            this.amount = amount;
            this.policy = policy;
            this.policyType = policyType;
        }
    }
}

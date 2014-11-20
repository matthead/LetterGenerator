using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace allstate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulatePolicyList();
        }
        private string name, amount, address, policy, date, policyType;
        /// <summary>
        /// PopulatePolicyList has an object to the filemanager class. See summary of GetpolicyTypes in the filemanager class
        /// 
        /// </summary>
        private void PopulatePolicyList() 
        {
            ManageFile manageFiles = new ManageFile();
            bool FileExist = true;
            string stringPolicies = manageFiles.ReadFile(@"c:\test\policies.txt",ref FileExist);
           //List<string>policies =manageFiles.GetPolicyTypes(ref FileExist);
            List<string> policies = ParseStringsToList(stringPolicies);
            if (FileExist == false)
            {
                MessageBox.Show("the list of policies is missing, make sure it is in the correct folder");
            }
            else
            {
                //List<string>policies=ParseStringsToList(stringPolicies);
                for (int i = 0; i < policies.Count; i++)
                {
                    policyList.Items.Add(policies[i]);
                }
            }
            
        }
        /// <summary>
        /// Parses strings by "\n" each line is a sperate unit
        /// </summary>
        /// <param name="spolicies"></param>
        /// <returns>List of strings 1 line per element</returns>
        private List<string> ParseStringsToList(string spolicies)
        {
            int index=0;
            List<string> policies = new List<string>();
            while(spolicies.Contains("\n"))
            {
                policies.Add(spolicies.Substring(index,spolicies.IndexOf("\n")).Trim());
                spolicies=spolicies.Substring(spolicies.IndexOf("\n")+1);
            }
            return policies;
        }
        private void print_Click(object sender, EventArgs e)
        {
            ConvertTextBoxes();
            string emptyFields = "";
            bool isValidData = ValidateData(ref emptyFields);
            if (isValidData)
            {
                //manageFile manageFile = new manageFile(name, address, date, amount, policy,policyType);
                ManageFile manageFile = new ManageFile();
                Letter letter = new Letter(name, address, date, amount, policy, policyType);
                if (letter.IsValid()) //Read the file correctly
                {
                    bool fileIsThere = false;
                    string file2 = manageFile.ReadFile( @"c:\test\"+policyType+".txt",ref fileIsThere);
                    try
                    {
                        letter.UpdateFile(file2);

                        manageFile.WriteToFile(@"c:\test\aaaa.html", letter.ToString());
                        string storedInfo = BuildVarsForSave(); //format the local variables
                        manageFile.WriteToFile(@"c:\test\previousletter.txt", storedInfo); //stores the textfiled information 
                        Output output = new Output();
                        output.Print(printerCBox.Checked, eagentCBox.Checked);
                        Clear();
                    }
                    catch (LetterException)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("the file for the respective policy is not there. Please refer to the readme");
                }
            }
            else
            {
                MessageBox.Show("please fill in: "+emptyFields);
            }
        }
        /// <summary>
        /// pulls data from the gui and stores them in member variables
        /// </summary>
        private void ConvertTextBoxes() //pulls data from respective Texbox and stores in respective member variable 
        {
            //name = nameBox.Text;
            name = "";
            amount = amountBox.Text;
            address = addressBox.Text;
            date = dateBox.Text;
            policy = policyBox.Text;
            policyType = policyList.Text;

        }

        /// <summary>
        /// Checks to make sure that all local variables are not null
        /// </summary>
        /// <param name="emptyFileds">list of variables that are null and need to be fixed</param>
        /// <returns>returs true if valid</returns>
        private bool ValidateData(ref string emptyFileds)//validates that each variable is not null.
        {
            bool flag = false;//if false all data is good
           /* if (name.Length == 0)
            {
                emptyFileds += "name ";
                flag = true;
            }*/
            if(amount.Length==0)
            {
                emptyFileds+="amount ";
                flag = true;
            }
            if (address.Length == 0)
            {
                emptyFileds += "address ";
                flag = true;
            }
            if (date.Length == 0)
            {
                emptyFileds += "date ";
                flag = true;
            }
            if (policy.Length == 0)
            {
                emptyFileds += "policy ";
                flag = true;
            }
            if (policyType == "")
            {
                emptyFileds += " policy type";
                flag = true;
            }
            if (flag == true)
                return false;
             return true;
        }
        /// <summary>
        /// Formats the local variables in a way they could be saved to a .txt file if needed at a later date.
        /// </summary>
        /// <returns></returns>
        private string BuildVarsForSave()
        {
            return (name + "\n" + address + "\n" + date + "\n" + amount + "\n" + policy + "\n" + policyType);
        }
        private void Clear()//clears textboxes, and listboxselection and local vars
        {
            nameBox.Clear();
            amountBox.Clear();
            addressBox.Clear();
            dateBox.Clear();
            policyBox.Clear();
            policyList.ClearSelected();
            name = null; amount = null; address = null; policy = null; date = null; policyType = null;
        }     
        /// <summary>
        /// Event that is triggered when edit is clicked. has an object to popup form. 
        /// While textbox in popup form is not null. Will add the value to dropdownlist and policies.txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)//onclick for add Policy Calls PopUp Form
        {
            string emptyString = "";
            PopUp popUp= new PopUp();
            popUp.ShowDialog();
            string newPolicy = popUp.GetNewPolicy();
            if (newPolicy != emptyString)
            {
                ManageFile manageFile = new ManageFile();
                manageFile.AppendPolicies(newPolicy);
                AppendPolicyList(newPolicy);
            }
        }
        /// <summary>
        /// appends droplist with the new policy that was added from PopUp. 
        /// </summary>
        /// <param name="policy">new policy name to be added</param>
        private void AppendPolicyList(string policy)
        {
            if(policy!=null)
                policyList.Items.Add(policy);
        }
        /// <summary>
        /// Uses the stored information in previousletter.text to set the values of the textbox and droplist to what they were the previous time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageFile manip = new ManageFile();
            bool fileExist = true;
            string Values = manip.ReadFile(@"c:\test\previousletter.txt",ref fileExist);
            List<string> previousValues = ParseStringsToList(Values);
            if (fileExist)
            {
                if (previousValues.Count() > 0)
                {
                    nameBox.Text = previousValues[0];
                    addressBox.Text = previousValues[1] + Environment.NewLine + previousValues[2];
                    dateBox.Text = previousValues[3];
                    amountBox.Text = previousValues[4];
                    policyBox.Text = previousValues[5];
                    policyList.Text = previousValues[6];
                }
                else
                {
                    MessageBox.Show("There is no previous letter");
                }
            }
            else
            {
                MessageBox.Show("There is no previous letter");
            }
        }


    }
}

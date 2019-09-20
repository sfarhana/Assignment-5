using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo
{
    public partial class Student : Form
    {
        List<string> IDs = new List<string>();
        List<string> Names = new List<string>();
        List<string> Mobiles = new List<string>();
        List<int> Ages = new List<int>();
        List<string> Addresses = new List<string>();
        List<double> GPAs = new List<double>();


        public Student()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string Id = txtID.Text;
            string Name = txtName.Text;
            string Mobile = txtMobile.Text;
            string Age = txtAge.Text;
            string Address = rtxtAddress.Text;
            string Gpa = txtGPA.Text;

            if (CheckRequired(Id))
            {
                MessageBox.Show("Id Value can not be empty");
                return;
            }
            if (CheckTxtLength(Id))
            {
                MessageBox.Show("ID must be 4 Char Length");
                return;
            }
            if (UniqueTest(Id, IDs))
            {
                MessageBox.Show("ID must be Unique");
                return;
            }

            if (CheckRequired(Name))
            {
                MessageBox.Show("Name Value can not be empty");
                return;
            }
            if (NameLength(Name))
            {
                MessageBox.Show("Max Char Length of name should be 30,Please follow this");
                return;
            }

            if (CheckRequired(Mobile))
            {
                MessageBox.Show("Contact Value can not be empty");
                return;
            }

            if (CheckTxtLength(Mobile))
            {
                MessageBox.Show("Contact must be 4 Char Length");
                return;
            }


            if (UniqueTest(Mobile, Mobiles))
            {
                MessageBox.Show("Mobile no. must be Unique");
                return;
            }
            if (GpaRange(Gpa))
            {
                MessageBox.Show("GPA value range should be 0-4");
                return;
            }
            IDs.Add(Id);
            Names.Add(Name);
            Mobiles.Add(Mobile);
            Ages.Add(Convert.ToInt16(Age));
            Addresses.Add(Address);
            GPAs.Add(Convert.ToDouble(Gpa));

            MessageBox.Show("Information Saved Sucessfully");

            rtxtshow.Text = "Last Saved Info is:\n" + "ID: " + Id + "\nName: " + Name + "\nMobile NO: " + Mobile + "\nAge: " + Age + "\nAddress: " +
                Address + "\nGPA Point: " + Gpa;

            ClearControls();

        }

        private bool CheckRequired(string tValue)
        {
            if (string.IsNullOrEmpty(tValue))
                return true;
            else
                return false;

        }


        public bool UniqueTest(string tValue, List<string> sList)
        {

            bool isDuplicate = false;

            foreach (string lv in sList)
            {
                if (lv == tValue)
                {
                    isDuplicate = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return isDuplicate;

        }
        private bool CheckTxtLength(string tValue)
        {
            if (tValue.Length != 4)
                return true;
            else
                return false;

        }
        private bool NameLength(string tvalue)
        {
            if (tvalue.Length > 30)
                return true;
            else
                return false;
        }
        private bool GpaRange(string tvalue)
        {

            if (Convert.ToDouble(tvalue) >= 0 && Convert.ToDouble(tvalue) <= 4)
                return false;
            else
                return true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ClearControls();

            string output = "";

            double MaxGPA = GPAs.Max();
            double MinGPA = GPAs.Min();

            int Maxindex = GPAs.IndexOf(MaxGPA);
            string MaxName = Names[Maxindex];

            int Minindex = GPAs.IndexOf(MinGPA);
            string MinName = Names[Minindex];

            double AvgGPA = GPAs.Average();
            for (int i = 0; i < IDs.Count(); i++)
            {
                output += "\nAll Saved Info is:\n" + "ID: " + IDs[i] + "\nName: " + Names[i] + "\nMobile NO: "
                    + Mobiles[i] + "\nAge: " + Ages[i] + "\nAddress: " + Addresses[i] + "\nGPA Point: " + GPAs[i];
            }

            rtxtshow.Text = output;
            txtMax.Text = MaxGPA.ToString();
            txtMaxname.Text = MaxName;
            txtMin.Text = MinGPA.ToString();
            txtMinname.Text = MinName;
            txtAverage.Text = AvgGPA.ToString();
            txtTotal.Text = (MaxGPA + MinGPA).ToString();

            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoID.Checked == true)
            {
                string id = txtID.Text;

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please put an id to Search");
                    return;
                }
                if (IDs.Contains(id))
                {
                    int i = IDs.IndexOf(id);
                    rtxtshow.Text = "Search Info for ID: " + id + "\nName: " + Names[i] + "\nMobile NO: "
                   + Mobiles[i] + "\nAge: " + Ages[i] + "\nAddress: " + Addresses[i] + "\nGPA Point: " + GPAs[i];
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

            }
            else if (rdoName.Checked == true)
            {
                string Name = txtName.Text;

                if (string.IsNullOrEmpty(Name))
                {
                    MessageBox.Show("Please put an Name to Search");
                    return;
                }
                if (Names.Contains(Name))
                {
                    int i = Names.IndexOf(Name);
                    rtxtshow.Text = "Search Info for Name: " + Name + "\n" + "ID: " + IDs[i] + "\nMobile NO: "
                   + Mobiles[i] + "\nAge: " + Ages[i] + "\nAddress: " + Addresses[i] + "\nGPA Point: " + GPAs[i];
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

            }
            if (rdoMobile.Checked == true)
            {
                string Mobile = txtMobile.Text;

                if (string.IsNullOrEmpty(Mobile))
                {
                    MessageBox.Show("Please put an Mobile no. to Search");
                    return;
                }
                if (Mobiles.Contains(Mobile))
                {
                    int i = Mobiles.IndexOf(Mobile);
                    rtxtshow.Text = "Search Info for Mobile: " + Mobile + "\nID: " + IDs[i] + "\nName: " + Names[i]
                        + "\nAge: " + Ages[i] + "\nAddress: " + Addresses[i] + "\nGPA Point: " + GPAs[i];
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

            }



        }
        public void ClearControls()
        {
           
            txtID.Text="";
            txtName.Text = "";
            txtMobile.Text = "";
            txtAge.Text = "";
            rtxtAddress.Text = "";
            txtGPA.Text = "";

            txtMax.Text = "";
            txtMaxname.Text = "";
            txtMin.Text = "";
            txtMinname.Text = "";
            txtAverage.Text = "";
            txtTotal.Text = "";

        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void rdoMobile_CheckedChanged(object sender, EventArgs e)
        {
            ClearControls();
        }


    }
}

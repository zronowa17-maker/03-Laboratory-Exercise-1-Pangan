using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (Exception)
            {
                _StudentNo = 0; 
            }
     
            finally
            {
                Console.WriteLine("Student Number parsing finished.");
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    _ContactNo = 0; 
                }
            }
            catch (Exception)
            {
                _ContactNo = 0;
            }
            finally
            {
                Console.WriteLine("Contact Number parsing finished.");
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") && Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + " " + MiddleInitial;
                }
                else
                {
                    _FullName = ""; 
                }
            }
            catch (Exception)
            {
                _FullName = "";
            }
            finally
            {
                Console.WriteLine("Full Name parsing finished.");
            }
            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    _Age = 0; 
                }
            }
            catch (Exception)
            {
                _Age = 0;
            }
            finally
            {
                Console.WriteLine("Age parsing finished.");
            }
            return _Age;
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                 "BS Information Technology",
                 "BS Computer Science",
                 "BS Information Systems",
                 "BS in Accountancy",
                 "BS in Hospitality Management",
                 "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentNumber(txtStudentNumber.Text);
            FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            Age(txtAge.Text);
            ContactNo(txtContactNo.Text);

            StudentInformationClass.SetFullName = _FullName;
            StudentInformationClass.SetStudentNumber = _StudentNo.ToString();
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = _ContactNo.ToString();
            StudentInformationClass.SetAge = _Age;
            StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();
        }
    }
}


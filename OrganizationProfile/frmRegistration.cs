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
                return _StudentNo;
            }
            catch (FormatException)
            {
                MessageBox.Show("Student Number must be a valid number.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Student Number is too large.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Student Number cannot be empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                    return _ContactNo;
                }
                else
                {
                    throw new FormatException("Contact No. must be 10 or 11 digits.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Contact No. is too large.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Contact No. cannot be empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
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
                    throw new ArgumentNullException("Name fields can only contain letters.");
                }
                return _FullName;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            catch (IndexOutOfRangeException)
            {
                
                MessageBox.Show("An array index was out of bounds.", "Array Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
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
                    throw new FormatException("Age must be between 1 to 3 digits.");
                }
                return _Age;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Age value is too large.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Age cannot be empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Registration_WeiweiGuo
{
    public partial class Form1 : Form
    {
        static FileStream fs;
        static StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

       //First name mandatory input
        private void FirstName_Mandatory_Input(object sender, EventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Please enter your first name!");
                return;
            }
        }

        //Last name mandatory input
        private void LastName_Mandatory_Input(object sender, EventArgs e)
        {
             if (txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Please enter your last name!");
                return;
            }          
        }

        //Email name mandatory input
        private void Email_Mandatory_Input(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please enter your email!");
                return;
            }
        }

        //Post code validation
        private void PostalCode_Validation(object sender, EventArgs e)
        {
            string postCodePattern = @"^\d{3}\s?\d{3}$";
            bool isPostCodeValid = Regex.IsMatch(txtPostalCode.Text, postCodePattern);
            if (!isPostCodeValid)
            {
                MessageBox.Show("Please enter a valid postal code");
            }
        }

        //Phone validation
        private void Phone_Validation(object sender, EventArgs e)
        {
            string phonePattern = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$";
            bool isPhoneValid = Regex.IsMatch(txtPhone.Text, phonePattern);
            if (!isPhoneValid)
            {
                MessageBox.Show("Please enter a valid phone code");
            }
        }

        //Click button reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        //Click button submit
        private void btnSubmit_Click(object sender, EventArgs e)
        {
           //show message
            MessageBox.Show(txtFirstName.Text + ", " + txtLastName.Text + ", " + txtEmail.Text + ", " 
                            + txtAddress.Text + ", " + txtCity.Text + ", " + txtPostalCode.Text + ", " 
                            + txtCountry.Text + ", " + txtPhone.Text);

       
            //write to file
            using (fs = new FileStream("registorInfo.txt", FileMode.Append, FileAccess.Write))
            {
                using (sw = new StreamWriter(fs))
                {
                    sw.WriteLine(txtFirstName.Text + ", " + txtLastName.Text + ", " + txtEmail.Text + ", "
                            + txtAddress.Text + ", " + txtCity.Text + ", " + txtPostalCode.Text + ", "
                            + txtCountry.Text + ", " + txtPhone.Text);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

                //clear input
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear(); 
                txtAddress.Clear(); 
                txtCity.Clear();
                txtPostalCode.Clear();
                txtCountry.Clear();
                txtPhone.Clear();
            }

            
        }

       

    }
}

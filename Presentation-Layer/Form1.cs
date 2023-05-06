using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business_Layer;

namespace Presentation_Layer
{
    public partial class Form1 : Form
    {
        public BusinessOperations objBusiness { get; set; }
        public Form1()
        {

            objBusiness = new BusinessOperations();
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
                     
            var lstResults = objBusiness.LoadAllInfo();
            foreach (var user in lstResults)
            {

            listBox1.Items.Add($"Name:{user.FirstName} Surname: {user.LastName} Gender: {user.Gender}");
            }
        }

       
        private void btnWrite_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastname.Text;
            string email = txtEmail.Text;
            string gender = txtGender.Text;
            string ip = txtIP.Text;

            objBusiness.WriteToDB(name, lastName, email, gender, ip);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastname.Text;
            string email = txtEmail.Text;
            string gender = txtGender.Text;
            string ip = txtIP.Text;

            objBusiness.UpdateCSV(name, lastName, email, gender, ip);

        }
    }
}

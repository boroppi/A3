using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _200383524_DataModel;

namespace _200383524
{
    public partial class AddRecord : Form
    {
        public event EventHandler<Person> PersonCreated;
        public AddRecord()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //try to create a person instance
            try
            {
                var person = new Person(txtFirstName.Text, txtLastName.Text, chkHasDriverLicence.Checked, txtEmail.Text);
                PersonCreated?.Invoke(this, person);
            }
            catch (Exception exception) // will catch validation errors and display on messagebox
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {

        }

        //exit the appliation if "X" button is clicked.
        protected override void OnFormClosing(FormClosingEventArgs e) 
        {
            Application.Exit();
        }

        //close the window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

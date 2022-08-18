using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Dashboard : Form
    {
        List<People> people = new List<People> ();
        public Dashboard()
        {
            InitializeComponent();
            peopleFoundListBox.DataSource = people;
            peopleFoundListBox.DisplayMember = "FullInfo";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            people = db.GetPeople(lastNameTextBox.Text);

            peopleFoundListBox.DataSource = people;
            peopleFoundListBox.DisplayMember = "FullInfo";
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess ();

            db.InsertPerson(FirstNameIns.Text, LastNameIns.Text, PhoneNumIns.Text, EmailAddressIns.Text);

            FirstNameIns.Text = "";
            LastNameIns.Text = "";
            PhoneNumIns.Text = "";
            EmailAddressIns.Text = "";

            peopleFoundListBox.DataSource = people;
            peopleFoundListBox.DisplayMember = "FullInfo";

        }
    }
}

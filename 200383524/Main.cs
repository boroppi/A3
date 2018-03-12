using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using _200383524_DataModel;

namespace _200383524
{
    public partial class Main : Form
    {
        private DataModel _dataModel;
        public Main()
        {
            InitializeComponent();
            if (_dataModel == null)
            {
                _dataModel = new DataModel
                {
                    People = new List<Person>()
                };

            }

            if (File.Exists("person.json"))
            {
                Debug.WriteLine("person.json exists");

                string json = File.ReadAllText("person.json");

                _dataModel = JsonConvert.DeserializeObject<DataModel>(json);
            }
        }

        /// <summary>
        /// Triggered when addbutton is clicked and initializes a new AddRecord form then
        /// subscribes to PersonCreated Event and shows the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var addRecord = new AddRecord();
            addRecord.PersonCreated += AddRecordOnPersonCreated;
            addRecord.Show();
        }

        /// <summary>
        /// Checks if the person parameter is not null and hides the sender form if so and adds 
        /// the person to datamodel then Serialize it and write to file person.json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="person"></param>
        private void AddRecordOnPersonCreated(object sender, Person person)
        {
            if (person != null) // check if person is not empty
            {
                ((Form)sender).Hide(); // hide the form that triggered the event
                _dataModel.People.Add(person);

                var json = JsonConvert.SerializeObject(_dataModel, Formatting.Indented);

                File.WriteAllText("person.json", json);
                txtNumOfRecords.Text = _dataModel.People.Count.ToString();
            }
        }

        /// <summary>
        /// After form load it check if the datamodel is not null and then assigns number of people to txtNumOfRecords textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            if (_dataModel.People.Count >= 0)
            {
                txtNumOfRecords.Text = _dataModel.People.Count.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

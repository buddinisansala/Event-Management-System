using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABC_EMS
{
    public partial class AddEvent : Form
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void AddEvent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define a variable. so that we have a way to store food preference
            //just like auth level of Add User :)

            string food = "";

            if (rdbVeg.Checked == true)
            {
                food = "Veg";
            }
            else if (rdbNonveg.Checked == true)
            {
                food = "Non Veg";
            }
            else if (rdbBoth.Checked == true)
            {
                food = "Both";
            }
            else
            {
                //if no option is selected, a warning message will pop up
                MessageBox.Show("Plese select a food preference", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //checking wheather the all field is EMPTY or not. (to Add a record, all fields must be filled)
            if (txtId.Text == "" || txtName.Text == "" || txtOrganizer.Text == "" || txtParticipants.Text == "" || 
                txtPrice.Text == "" || txtVenue.Text == "" )
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("One or More required fields are Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //creating new 'Connection Object'
                SqlConnection com = new SqlConnection(conn);

                //opening the conection
                com.Open();

                if (com.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        //the Query for inserting data
                        String q = "insert into Events (id,name,description,organizer,venue,date,participant,price,food) values ('" + txtId.Text + "','" + txtName.Text + "','" + rtbDescription.Text + "','" + txtOrganizer.Text + "','" + txtVenue.Text + "','" + dtpDate.Value.Date.ToString("yyyyMMdd") + "','" + txtParticipants.Text + "','" + txtPrice.Text + "','" + food + "')";

                        //Executing the query
                        SqlCommand cmd = new SqlCommand(q, com);
                        cmd.ExecuteNonQuery();

                        //show complete dialog
                        MessageBox.Show("Event added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Data is in incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                //closing the connection
                com.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtId.Text = "";
            txtName.Text = "";
            txtOrganizer.Text = "";
            txtParticipants.Text = "";
            txtPrice.Text = "";
            txtVenue.Text = "";
            rtbDescription.Text = "";
        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            ManageEvents me = new ManageEvents();
            me.Show();
            this.Hide();
        }
         * */
    }
}

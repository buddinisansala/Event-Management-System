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
    public partial class ManageEvents : Form
    {
        public ManageEvents()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //check for the id field is empty or not
            if (cmbName.Text == "")
            {
                MessageBox.Show("Please enter the Event's Name first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //ID field is not empty. so the Query will be run and the data  will be inserted to table.
                SqlConnection com = new SqlConnection(conn);
                com.Open();

                //if eny error occured in query execution, this try catch block will return is as an error message.
                //instead of crashing the programm
                try
                {
                    //SQL SELECT query
                    String q = "select * from Events where name = '" + cmbName.Text + "'";

                    SqlCommand cmd = new SqlCommand(q, com);

                    //executing the query and assign the result to a Data Reader Object
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    //this if statement will execute, only if the data reader object is not empty(only when a record is found :) )
                    if (sdr.Read())
                    {
                        //setting valuse for Text boxes and other data fields
                        txtId.Text = sdr.GetString(0);
                        rtbDescription.Text = sdr.GetString(2);
                        txtOrganizer.Text = sdr.GetString(3);
                        txtVenue.Text = sdr.GetString(4);
                        dtpDate.Text = sdr.GetDateTime(5).ToShortDateString();
                        txtParticipant.Text = (sdr["participant"].ToString());
                        txtPrice.Text = (sdr["price"].ToString());

                        //define an String to retrive the food preference
                        String food = sdr.GetString(8);

                        if (food == "Veg")
                        {
                            //if food preference is Veg, Veg radion button will be marked
                            rdbVeg.Checked = true;
                        }
                        else if (food == "Non Veg")
                        {
                            //if food preference is Non - Veg, Non-Veg radion button will be marked
                            rdbNonveg.Checked = true;
                        }
                        else if (food == "Both")
                        {
                            //if food preference is "Both", "Both" radion button will be marked
                            rdbBoth.Checked = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No Event found under provided Name", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //closing the connection
                com.Close();
            }
        }

        private void ManageEvents_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String q = "select name from Events";

                SqlDataReader dr = new SqlCommand(q, con).ExecuteReader();

                while (dr.Read())
                {
                    cmbName.Items.Add(dr.GetString(0).ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtOrganizer.Text == "" || txtParticipant.Text == "" || txtPrice.Text == ""
                || txtVenue.Text == "" || dtpDate.Text == "" || cmbName.Text == "" ||
                (rdbVeg.Checked == false && rdbNonveg.Checked == false && rdbBoth.Checked == false))
            {
                MessageBox.Show("One or more fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String food = "";

                if (rdbVeg.Checked == true)
                {
                    //if food preference is Veg, Veg radion button will be marked
                    food = "Veg";
                }
                else if (rdbNonveg.Checked == true)
                {
                    //if food preference is Non - Veg, Non-Veg radion button will be marked
                    food = "Non Veg";
                }
                else if (rdbBoth.Checked = true)
                {
                    //if food preference is "Both", "Both" radion button will be marked
                    food = "Both";
                }

                //now all fields are filled. so the query will run, and the record will be updated.
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update Events set description=@description, organizer=@organizer, venue=@venue, date=@date, participant=@participant, price=@price, food=@food where name=@name", con);
                    cmd.Parameters.Add("@name", cmbName.Text);
                    cmd.Parameters.Add("@description", rtbDescription.Text);
                    cmd.Parameters.Add("@organizer", txtOrganizer.Text);
                    cmd.Parameters.Add("@venue", txtVenue.Text);
                    cmd.Parameters.Add("@date", dtpDate.Value.Date.ToString("yyyyMMdd"));
                    cmd.Parameters.Add("@participant", txtParticipant.Text);
                    cmd.Parameters.Add("@price", txtPrice.Text);
                    cmd.Parameters.Add("@food", food);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //checking wheather the all field is EMPTY or not. (to delete a record, all fields must be filled)
            //it means "Do Search Befor Delete"
            if (cmbName.Text == "")
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("Cannot Delete. Plese select the Event's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete from Events where name=@name", con);
                cmd.Parameters.Add("@name", cmbName.Text);


                //now all fileds are filled. it's  asking wheather you wanna delete or not. if "Yes", record will be deleted.
                DialogResult dlgr = MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgr == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                txtId.Text = "";
                txtOrganizer.Text = "";
                txtParticipant.Text = "";
                txtPrice.Text = "";
                txtVenue.Text = "";
                rtbDescription.Text = "";
                cmbName.Text = "";
            }
        }
    }
}

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
    public partial class ManageParticipants : Form
    {
        public ManageParticipants()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageParticipants_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String q = "select organization from Participants";

                SqlDataReader dr = new SqlCommand(q, con).ExecuteReader();

                while (dr.Read())
                {
                    cmbOrg.Items.Add(dr.GetString(0).ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //check for the id field is empty or not
            if (cmbOrg.Text == "")
            {
                MessageBox.Show("Please enter the Organization's Name first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //if eny error occured in query execution, this try catch block will return is as an error message.
                //instead of crashing the programm
                try
                {

                    //ID field is not empty. so the Query will be run and the data  will be inserted to table.
                    SqlConnection com = new SqlConnection(conn);
                    com.Open();

                    //SQL SELECT query
                    String q = "select * from Participants where organization = '" + cmbOrg.Text + "'";

                    SqlCommand cmd = new SqlCommand(q, com);

                    //executing the query and assign the result to a Data Reader Object
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    //this if statement will execute, only if the data reader object is not empty(only when a record is found :) )
                    if (sdr.Read())
                    {
                        //setting valuse for Text boxes and other data fields
                        txtId.Text = sdr.GetString(1);
                        cmbService.Text = sdr.GetString(2);
                        txtPrice.Text = (sdr["price"].ToString());
                        rtbAddress.Text = sdr.GetString(4);
                        txtWebsite.Text = sdr.GetString(5);
                        txtContact.Text = sdr.GetString(6);

                    }
                    else
                    {
                        MessageBox.Show("No Participant found under provided Name", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                    //closing the connection
                    com.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "" || txtId.Text == "" || cmbOrg.Text == ""
                || txtPrice.Text == "" || cmbService.Text == "" || rtbAddress.Text == "")
            {
                MessageBox.Show("One or more fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //now all fields are filled. so the query will run, and the record will be updated.
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update Participants set organization=@org, id=@id, service=@service, price=@price, address=@address, website=@website, contact=@contact where organization=@org", con);
                    cmd.Parameters.Add("@org", cmbOrg.Text);
                    cmd.Parameters.Add("@id", txtId.Text);
                    cmd.Parameters.Add("@service", cmbService.Text);
                    cmd.Parameters.Add("@price", float.Parse(txtPrice.Text));
                    cmd.Parameters.Add("@address", rtbAddress.Text);
                    cmd.Parameters.Add("@website", txtWebsite.Text);
                    cmd.Parameters.Add("@contact", txtContact.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Participant updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (cmbOrg.Text == "")
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("Cannot Delete. Plese select the Participant's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete from Events where name=@name", con);
                cmd.Parameters.Add("@name", cmbOrg.Text);


                //now all fileds are filled. it's  asking wheather you wanna delete or not. if "Yes", record will be deleted.
                DialogResult dlgr = MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgr == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Participant Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                txtId.Text = "";
                txtContact.Text = "";
                txtPrice.Text = "";
                txtWebsite.Text = "";
                cmbOrg.Text = "";
                cmbService.Text = "";
                rtbAddress.Text = "";
            }
        }
    }
}

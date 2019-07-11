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
    public partial class AddParticipant : Form
    {
        public AddParticipant()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //Add Participation Button
        private void button1_Click(object sender, EventArgs e)
        {
            //checking wheather the all field is EMPTY or not. (to Add a record, all fields must be filled)
            if (txtContact.Text == "" || txtId.Text == "" || txtOrganization.Text == "" 
                || txtPrice.Text == "" || cmbService.Text == "" || rtbAddress.Text == "")
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("One or More required fields are Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //creating new 'Connection Object'
                    SqlConnection com = new SqlConnection(conn);

                    //opening the conection
                    com.Open();


                    //Executing the query
                    SqlCommand cmd = new SqlCommand("insert into Participants (organization,id,service,price,address,website,contact) values (@org,@id,@service,@price,@address,@website,@contact)", com);

                    //Adding Values in the text box, to parameters to run the query
                    cmd.Parameters.Add("@org", txtOrganization.Text);
                    cmd.Parameters.Add("@id", txtId.Text);
                    cmd.Parameters.Add("@service", cmbService.Text);
                    cmd.Parameters.Add("@price", float.Parse(txtPrice.Text));
                    cmd.Parameters.Add("@address", rtbAddress.Text);
                    cmd.Parameters.Add("@website", txtWebsite.Text);
                    cmd.Parameters.Add("@contact", txtContact.Text);

                    //execute the query
                    cmd.ExecuteNonQuery();

                    //show complete dialog
                    MessageBox.Show("Participant added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //closing the connection
                    com.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //empting the text fields
            txtContact.Text = "";
            txtId.Text = "";
            txtOrganization.Text = "";
            txtPrice.Text = "";
            txtWebsite.Text = "";
            rtbAddress.Text = "";
            cmbService.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageParticipants mp = new ManageParticipants();
            mp.Show();
        }
    }
}

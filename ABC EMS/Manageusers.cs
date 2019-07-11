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
    public partial class Manageusers : Form
    {
        public Manageusers()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void Manageusers_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String q = "select name from Users";

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //check for the id field is empty or not
            if (cmbName.Text == "")
            {
                MessageBox.Show("Please enter the User's Name first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //ID field is not empty.

                //if eny error occured in query execution, this try catch block will return is as an error message.
                //instead of crashing the programm
                try
                {

                    SqlConnection com = new SqlConnection(conn);
                    com.Open();

                    //SQL SELECT query
                    String q = "select * from Users where name = '" + cmbName.Text + "'";

                    SqlCommand cmd = new SqlCommand(q, com);

                    //executing the query and assign the result to a Data Reader Object
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    //this if statement will execute, only if the data reader object is not empty(only when a record is found :) )
                    if (sdr.Read())
                    {
                        //setting valuse for Text boxes and other data fields
                        txtEmail.Text = sdr.GetString(1);
                        lblUsername.Text = sdr.GetString(2);


                        //define an int to retrive the auth type
                        int auth = sdr.GetInt32(4);

                        if (auth == 1)
                        {
                            //if auth type is 1, it's an admin
                            lblUsertype.Text = "Admin";
                        }
                        else if (auth == 2)
                        {
                            //if auth type is 2, it's an Manager
                            lblUsertype.Text = "Manager";
                        }
                        else if (auth == 3)
                        {
                            //if auth type is 3, it's an Customer
                            lblUsertype.Text = "Customer";
                        }

                    }
                    else
                    {
                        MessageBox.Show("No User found under provided Name", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
            if (txtEmail.Text=="" || cmbName.Text=="")
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

                    SqlCommand cmd = new SqlCommand("update Users set name=@name, email=@email where name=@name", con);
                    cmd.Parameters.Add("@name", cmbName.Text);
                    cmd.Parameters.Add("@email", txtEmail.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

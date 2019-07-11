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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";


        // Search User Button
        private void btnSerach_Click(object sender, EventArgs e)
        {
            //checking wheather the Email field is EMPTY or not.
            if (cmbName.Text == "")
            {
                //Email field is empty. so an error message will pop up.
                MessageBox.Show("Please Enter or select a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Email field is not empty. so the Query will be run and the data  will be inserted to table.
                SqlConnection com = new SqlConnection(conn);
                com.Open();

                //if eny error occured in query execution, this try catch block will return is as an error message.
                //instead of crashing the programm
                try
                {
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
                        txtUsername.Text = sdr.GetString(2);
                        txtPassword.Text = sdr.GetString(3).ToString();

                        //define an integer to retrive the auth level
                        int auth = sdr.GetInt32(4);

                        if (auth == 1) 
                        {
                            //if auth level is 1, it means this is a Admin. so the corresponding radio btn will be marked
                            rdbAdmin.Checked = true;
                        }
                        else if (auth == 2) 
                        {
                            //if auth level is 2, it means this is a manager. so the corresponding radio btn will be marked
                            rdbManager.Checked = true;
                        }
                        else if (auth == 3) 
                        {
                            //if auth level is 3, it means this is a customer. so the corresponding radio btn will be marked
                            rdbCustomer.Checked = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No User found under provided name", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex) 
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("An error occurd while searching", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                //closing the connection
                com.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //checking wheather the all field is EMPTY or not. (to update a record, all fields must be filled)
            //it means "Do Search Befor Update"
            if (txtEmail.Text == "" || cmbName.Text == "" || txtPassword.Text == "" || txtUsername.Text == "")
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("One or More required fields are Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int auth = 0;
                if (rdbAdmin.Checked == true) 
                {
                    auth = 1;
                }
                else if (rdbManager.Checked == true) 
                {
                    auth = 2;
                }
                else if (rdbCustomer.Checked == true) 
                {
                    auth = 3;
                }

                //now all fields are filled. so the query will run, and the record will be updated.
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update Users set name=@name, username=@username, password=@password, auth_level=@auth where email=@email", con);
                    cmd.Parameters.Add("@name", cmbName.Text);
                    cmd.Parameters.Add("@username", txtUsername.Text);
                    cmd.Parameters.Add("@password", txtPassword.Text);
                    cmd.Parameters.Add("@auth", auth);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //checking wheather the all field is EMPTY or not. (to delete a record, all fields must be filled)
            //it means "Do Search Befor Delete"
            if (txtEmail.Text == "" || cmbName.Text == "" || txtPassword.Text == "" || txtUsername.Text == "")
            {
                //now all or one fields are empty. so a warning message will popup
                MessageBox.Show("Cannot Delete. some information are missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete from Users where email=@email", con);
                cmd.Parameters.Add("@email", txtEmail.Text);


                //now all fileds are filled. it's  asking wheather you wanna delete or not. if "Yes", record will be deleted.
                DialogResult dlgr = MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgr == DialogResult.Yes) 
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                txtEmail.Text = "";
                cmbName.Text = "";
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
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
    }
}

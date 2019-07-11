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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }



        //Search, Update, Delete buttons will take you to another page, which is capable of those options.
        
        private void btnSearchuser_Click(object sender, EventArgs e)
        {
            ManageUser mu = new ManageUser();
            mu.Show();
        }

        /*
        private void btnDeleteuser_Click(object sender, EventArgs e)
        {
            ManageUser mu = new ManageUser();
            mu.Show();
        }


        // Update User Button
        private void btnUpdateuser_Click(object sender, EventArgs e)
        {
            ManageUser mu = new ManageUser();
            mu.Show();
        }
        */



        // Add User Button
        private void btnAdduser_Click(object sender, EventArgs e)
        {
            //define a variable. so that we have a way to store auth level
            //auth level = 1, for admins
            //auth level = 2, for managers
            //auth level = 3, for customers

            //this will help us to redirect the corresponding login for each type of users.
            int auth = 0;

            if (rdoAdmin.Checked == true) 
            {
                auth = 1;
            }
            else if (rdoManager.Checked == true)
            {
                auth = 2;
            }
            else if (rdoCustomer.Checked == true)
            {
                auth = 3;
            }
            else 
            {
                //if no option is selected, a warning message will pop up
                MessageBox.Show("Plese select an authonication level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //checking wheather the all field is EMPTY or not. (to Add a record, all fields must be filled)
            if (txtEmail.Text == "" || txtName.Text == "" || txtPassword.Text == "" || txtUsername.Text == "")
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
                    //the Query for inserting data
                    String q = "insert into Users (name,email,username,password,auth_level) values ('" + txtName.Text + "','" + txtEmail.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + auth + "')";
                    
                    //Executing the query
                    SqlCommand cmd = new SqlCommand(q,com);
                    cmd.ExecuteNonQuery();

                    //show complete dialog
                    MessageBox.Show("User added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                //closing the connection
                com.Close();
                txtEmail.Text = "";
                txtName.Text = "";
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }



        
    }
}

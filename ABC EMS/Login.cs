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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";



        //Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check wheather the username field & password field are empty
            if(txtUsername.Text == "" && txtPassword.Text == ""){
                //ckeck only the username filed is empty or not
                MessageBox.Show("Please enter the username and password");
            }
            else if (txtPassword.Text == "") {
                //ckeck only the password filed is empty or not
                MessageBox.Show("Please enter the password");
            }
            else if (txtUsername.Text == "")
            {
                //ckeck both username and the password fileds are empty or not
                MessageBox.Show("Please enter the username");
            }
            else 
            { 
                //if username and password fields are filled, you will be logged in using the query
                try
                {
                    SqlConnection con = new SqlConnection(conn);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("select * from users where username=@username and password=@password", con);
                    cmd.Parameters.Add("@username", txtUsername.Text);
                    cmd.Parameters.Add("@password", txtPassword.Text);

                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {

                        //define an integer to retrive the auth level
                        int auth = sdr.GetInt32(4);

                        if (auth == 1)
                        {
                            //if auth level is 1, it means this is a Admin. so Admin Panel will be loaded
                            Form1 f1 = new Form1();
                            f1.Show();
                            this.Hide();

                        }
                        else if (auth == 2)
                        {
                            //if auth level is 2, it means this is a manager. so Manager's Dashboard will be loaded
                            ManagerDashboard md = new ManagerDashboard();
                            md.Show();
                            this.Hide();
                        }
                        else if (auth == 3)
                        {
                            //if auth level is 3, it means this is a customer. so Customer's Dashboard will be loaded
                            CustomerDashboard cd = new CustomerDashboard();
                            cd.Show();
                            this.Hide();

                        }

                    }
                    else
                    {
                        MessageBox.Show("Email or password not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
            }

        }
    }
}

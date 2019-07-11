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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";


        //Add user Button
        private void btnAdduser_Click(object sender, EventArgs e)
        {
            AddUser AU = new AddUser();
            AU.Show();
        }


        //logut Button
        private void button1_Click(object sender, EventArgs e)
        {
            Login ff = new Login();
            ff.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Loading Data in Users table to the data grid view
        private void btnLoaduser_Click(object sender, EventArgs e)
        {
            //creating the connection
            SqlConnection com = new SqlConnection(conn);

            //opening the connection
            com.Open();

            //execute the query and get the result 
            SqlDataAdapter sda = new SqlDataAdapter("select * from Users", conn);

            //create new data table
            DataTable dt = new DataTable();

            sda.Fill(dt);

            //load data to data grid view
            dgvUserlist.DataSource = dt;
        }


    }
}

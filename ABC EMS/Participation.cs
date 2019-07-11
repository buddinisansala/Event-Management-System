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
    public partial class Participation : Form
    {
        public Participation()
        {
            InitializeComponent();
        }

        public String conn = "Data Source=DESKTOP-AQQM6FL;Initial Catalog=EMS;Integrated Security=True";

        private void Participation_Load(object sender, EventArgs e)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}

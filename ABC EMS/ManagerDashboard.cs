using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_EMS
{
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            AddEvent ae = new AddEvent();
            ae.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //ParticipationEnrollment pe = new ParticipationEnrollment();
            //pe.Show();
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnManageusers_Click(object sender, EventArgs e)
        {
            Manageusers mu = new Manageusers();
            mu.Show();
        }
    }
}

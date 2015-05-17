using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentalSystem
{
    public partial class Form1 : Form
    {
        private RentManager rm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rm = new RentManager();
            dataGridView1.DataSource = rm.select();
            if (rm.message != "")
            {
                MessageBox.Show(rm.message );
                rm.message = "";
            }
        }

    }
}

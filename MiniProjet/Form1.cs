using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjet
{
    public partial class Form1 : Form
    {   
       
       
        public Form1()
        {
            InitializeComponent();
            Formloader(new home());
        }
        public void Formloader(object Form)
        {
            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }

        

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Formloader(new steg());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogo_Click(object sender, EventArgs e)
        {
            Formloader(new home());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Formloader(new comp());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Formloader(new fileenc());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Formloader(new filedec());
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

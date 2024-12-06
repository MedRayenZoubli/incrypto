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
    public partial class comp : Form
    {
        public comp()
        {
            InitializeComponent();
        }

        private void comp_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filepath = new OpenFileDialog();
            filepath.Title = "Select File";
            filepath.InitialDirectory = @"C:\";
            filepath.Filter = "All files (*.*)|*.*";
            filepath.Multiselect = true;
            filepath.FilterIndex = 1;
            filepath.ShowDialog();
            foreach (String file in filepath.FileNames)
            {
                listBox1.Items.Add(file);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                var bytes = System.IO.File.ReadAllBytes(opf.FileName);
                int L1 = bytes.Length;
                bytes = MiniProjet.GZipCompressor.CompressBytes(bytes);
                int L2 = bytes.Length;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "GZip File|*.gzip";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(sfd.FileName, bytes);
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "GZip File|*.gzip";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                var bytes = System.IO.File.ReadAllBytes(opf.FileName);
                int L1 = bytes.Length;
                bytes = MiniProjet.GZipCompressor.DecompressBytes(bytes);
                int L2 = bytes.Length;

                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(sfd.FileName, bytes);
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }
    }
}

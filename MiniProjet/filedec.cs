using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Collections;

namespace MiniProjet
{
    public partial class filedec : Form
    {
        public filedec()
        {
            InitializeComponent();
        }

        private void filedec_Load(object sender, EventArgs e)
        {

        }
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int i;
            for (i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
            }

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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
        private void DecryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch { }
        }
        char[] mychar = { '!', '.', 'L', 'O', 'C', 'K', 'E', 'D' };
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 8)
            {
                MessageBox.Show("Password must have 8 characters!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listBox1.Items.Count > 0)
            {
                for (int num = 0; num < listBox1.Items.Count; num++)
                {
                    string e_file = "" + listBox1.Items[num];
                    if (e_file.Trim().EndsWith(".!LOCKED") && File.Exists(e_file))
                    {
                        DecryptFile(e_file, e_file.TrimEnd(mychar), textBox1.Text);
                        File.Delete(e_file);
                    }
                }
            }
           
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;

namespace MiniProjet
{
    public partial class fileenc : Form
    {
        public fileenc()
        {
            InitializeComponent();
        }

        private void fileenc_Load(object sender, EventArgs e)
        {

        }
        private ArrayList passwordList = new ArrayList();
        private void ShowPasswords()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var password in passwordList)
            {
                sb.AppendLine(password.ToString());
            }
            MessageBox.Show(sb.ToString(), "Stored Passwords", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int i;
            for(i=0; i < files.Length; i++)
            {
                listBox1.Items.Add(files[i]);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void EncryptFile(string inputFile, string outputFile, string password)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch { }
        }

        
        private void iconButton3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length < 8)
            {
                MessageBox.Show("Password must have 8 characters!", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            passwordList.Add(textBox1.Text);

            if (listBox1.Items.Count > 0)
            {
                for (int num = 0; num < listBox1.Items.Count; num++)
                {
                    string e_file = "" + listBox1.Items[num];
                    if (!e_file.Trim().EndsWith(".!LOCKED") && File.Exists(e_file))
                    {
                        EncryptFile("" + listBox1.Items[num], "" + listBox1.Items[num] + ".!LOCKED", textBox1.Text);
                        File.Delete("" + listBox1.Items[num]);
                    }
                }
            }            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ShowPasswords();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // colorDialog1.HelpRequest += ColorDialog1_HelpRequest;
        }

        private void ColorDialog1_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("Help");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            //label2.Font = fontDialog1.Font;
            //label2.ForeColor = fontDialog1.Color;


            foreach (var item in this.Controls)
            {
                if (item is Button bt)
                {
                    bt.Font = fontDialog1.Font;
                }
                else if (item is Label lb)
                {
                    lb.Font = fontDialog1.Font;
                }
            }

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt ||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader reader = new StreamReader(open.FileName))
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }

            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.FileName))
                {
                    writer.Write(richTextBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //textBox1.Text = folderBrowserDialog1.SelectedPath;
                //textBox1.Text = folderBrowserDialog1.RootFolder.ToString();
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
}

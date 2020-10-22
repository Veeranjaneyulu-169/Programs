using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMenuDemo
{
    public partial class Form1 : Form
    {
        private readonly string fileFilter = "Rich Text Format (.rtf)|*.rtf|Plain Text Format (.txt)|*.txt";
        private readonly string intialDirectory = @"D:\\Presidency\\2020_aug_sem\\c#";
        public Form1()
        {
            InitializeComponent();
        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.ClickedItem.ToString();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem newMenuitem = sender as ToolStripMenuItem;
            toolStripStatusLabel1.Text = newMenuitem.Text;
            richTextBox1.Clear();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = intialDirectory;
            saveFileDialog1.Filter = fileFilter;
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != null)
            {
                if (saveFileDialog1.Filter.Contains(".txt"))
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                else
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = fileFilter;
            openFileDialog1.InitialDirectory = intialDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    if (openFileDialog1.FileName.Contains(".txt"))
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    else
                        richTextBox1.LoadFile(openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("Empty file name", "Error");
                }
            }
        }
    }
}
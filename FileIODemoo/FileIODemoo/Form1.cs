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

namespace FileIODemoo
{
    public partial class Form1 : Form
    {
        private readonly string initialDirectory = "E:\\Presidency\\C#\\Programs";
        private readonly string fileFilter = "c program (*.txt)|*.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = fileFilter;
            openFileDialog1.InitialDirectory = initialDirectory;
            StreamReader reader = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    reader = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = reader.ReadToEnd();
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("File Not found!!", "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = initialDirectory;
            saveFileDialog1.Filter = fileFilter;
            saveFileDialog1.ShowDialog();
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(saveFileDialog1.FileName);
                writer.Write(textBox1.Text);
            }
            catch(DirectoryNotFoundException ex)
            {
                MessageBox.Show("File Not Found","Error");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}

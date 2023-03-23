using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        string sourcefolderPath = null;
        string destinationPath = null;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                {
                    MessageBox.Show("Select atleast any one option");
                }
                //Desktop Copy
                if (checkBox1.Checked)
                {
                    sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (destinationPath != null)
                    {
                        string sourceDir = sourcefolderPath;
                        string destDir = destinationPath;
                        string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                        string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                        // Copy the files
                        foreach (string file in files)
                        {
                            string relPath = file.Substring(sourceDir.Length + 1);
                            string destFile = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                            File.Copy(file, destFile, true);
                        }

                        // Copy the directories
                        foreach (string subDir in subDirs)
                        {
                            string relPath = subDir.Substring(sourceDir.Length + 1);
                            string destSubDir = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(destSubDir);
                        }
                        MessageBox.Show("data copied successfully from-" + sourcefolderPath + " to-" + destinationPath);
                    }
                    else
                    {
                        MessageBox.Show("Select Destination Folder");
                    }
                }
                //Download Copy
                if (checkBox2.Checked)
                {
                    sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                    if (destinationPath != null)
                    {

                        string sourceDir = sourcefolderPath;
                        string destDir = destinationPath;
                        string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                        string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                        // Copy the files
                        foreach (string file in files)
                        {
                            string relPath = file.Substring(sourceDir.Length + 1);
                            string destFile = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                            File.Copy(file, destFile, true);
                        }

                        // Copy the directories
                        foreach (string subDir in subDirs)
                        {
                            string relPath = subDir.Substring(sourceDir.Length + 1);
                            string destSubDir = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(destSubDir);
                        }
                        MessageBox.Show("data copied successfully from-" + sourcefolderPath + " to-" + destinationPath);
                    }
                    else
                    {
                        MessageBox.Show("Select Destination Folder");
                    }
                }
                //Documents Copy
                if (checkBox3.Checked)
                {
                    sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    if (destinationPath != null)
                    {
                        string sourceDir = sourcefolderPath;
                        string destDir = destinationPath;
                        string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                        string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                        // Copy the files
                        foreach (string file in files)
                        {
                            string relPath = file.Substring(sourceDir.Length + 1);
                            string destFile = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                            File.Copy(file, destFile, true);
                        }

                        // Copy the directories
                        foreach (string subDir in subDirs)
                        {
                            string relPath = subDir.Substring(sourceDir.Length + 1);
                            string destSubDir = Path.Combine(destDir, relPath);
                            Directory.CreateDirectory(destSubDir);
                        }
                        MessageBox.Show("data copied successfully from-" + sourcefolderPath + " to-" + destinationPath);
                    }
                    else
                    {
                        MessageBox.Show("Select Destination Folder");
                    }
                }
            }
            else if (radioButton2.Checked)
            {

                if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                {
                    MessageBox.Show("Select atleast any one option");
                }
                //Desktop move
                if (checkBox1.Checked)
                {
                    try
                    {
                        sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        if (destinationPath != null && sourcefolderPath != null)
                        {


                            string sourceDir = sourcefolderPath;
                            string destDir = destinationPath;
                            string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                            string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                            // Copy the files
                            foreach (string file in files)
                            {
                                string relPath = file.Substring(sourceDir.Length + 1);
                                string destFile = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                                File.Copy(file, destFile, true);
                                File.Delete(file);
                            }

                            // Copy the directories
                            foreach (string subDir in subDirs)
                            {
                                string relPath = subDir.Substring(sourceDir.Length + 1);
                                string destSubDir = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(destSubDir);
                               // Directory.Delete(subDir);
                            }
                            foreach (string subDir in subDirs)
                            {
                                if (Directory.GetFiles(subDir).Length == 0 && Directory.GetDirectories(subDir).Length == 0)
                                {
                                    Directory.Delete(subDir);
                                }
                            }

                            MessageBox.Show("data moved successfully from-" + sourcefolderPath + " to-" + destinationPath);
                        }
                        else
                        {
                            MessageBox.Show("Select Destination Folder");
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Download Move
                if (checkBox2.Checked)
                {
                    try
                    {
                        sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                        if (destinationPath != null && sourcefolderPath != null)
                        {


                            string sourceDir = sourcefolderPath;
                            string destDir = destinationPath;
                            string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                            string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                            // Copy the files
                            foreach (string file in files)
                            {
                                string relPath = file.Substring(sourceDir.Length + 1);
                                string destFile = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                                File.Copy(file, destFile, true);
                                File.Delete(file);
                            }

                            // Copy the directories
                            foreach (string subDir in subDirs)
                            {
                                string relPath = subDir.Substring(sourceDir.Length + 1);
                                string destSubDir = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(destSubDir);
                                //Directory.Delete(subDir);
                            }
                            foreach (string subDir in subDirs)
                            {
                                if (Directory.GetFiles(subDir).Length == 0 && Directory.GetDirectories(subDir).Length == 0)
                                {
                                    Directory.Delete(subDir);
                                }
                            }

                            MessageBox.Show("data moved successfully from-" + sourcefolderPath + " to-" + destinationPath);
                        }
                        else
                        {
                            MessageBox.Show("Select Destination Folder");
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Documents Move
                if (checkBox3.Checked)
                {
                    sourcefolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    try
                    {
                        if (destinationPath != null && sourcefolderPath != null)
                        {


                            string sourceDir = sourcefolderPath;
                            string destDir = destinationPath;
                            string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
                            string[] subDirs = Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories);

                            // Copy the files
                            foreach (string file in files)
                            {
                                string relPath = file.Substring(sourceDir.Length + 1);
                                string destFile = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                                File.Copy(file, destFile, true);
                                File.Delete(file);
                            }

                            // Copy the directories
                            foreach (string subDir in subDirs)
                            {
                                string relPath = subDir.Substring(sourceDir.Length + 1);
                                string destSubDir = Path.Combine(destDir, relPath);
                                Directory.CreateDirectory(destSubDir);
                                //Directory.Delete(subDir);
                            }
                            foreach (string subDir in subDirs)
                            {
                                if (Directory.GetFiles(subDir).Length == 0 && Directory.GetDirectories(subDir).Length == 0)
                                {
                                    Directory.Delete(subDir);
                                }
                            }
                            MessageBox.Show("data moved successfully from-" + sourcefolderPath + " to-" + destinationPath);
                        }
                        else
                        {
                            MessageBox.Show("Select Destination Folder");
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }





            }
            else
            {
                MessageBox.Show("Select Copy or Move");
            }
            ClearForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select a folder.";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                // Do something with the folder path...
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select a folder to move data.";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourcefolderPath = folderBrowserDialog1.SelectedPath;
                // Do something with the folder path...
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select a folder to move data.";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                destinationPath = folderBrowserDialog1.SelectedPath;
                // Do something with the folder path...
            }
            button3.BackColor = Color.Gray;
            button3.ForeColor = Color.White;
        }
        private void ClearForm()
        {
            foreach (Control c in Controls)
            {
               
                button3.ForeColor = Color.Black;
              
                button3.BackColor = Color.White;

                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                // Add other control types as needed
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace SWMM2PEST
{
    public partial class RunForm : Form
    {
        string inputFile;

        public RunForm(string inputFileName)
        {
            InitializeComponent();
            inputFile = inputFileName;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            /* .dat file read
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "dat files (*.dat)|*.dat";
            openFileDialog1.Title = "Open Input file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                obsFileTxtBx.Text = fileName;
            }
            */
            

        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            runSWMM2PEST();
        }

        private void runSWMM2PEST()
        {
            
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", ""); ;
            
            string fileName = inputFile.Split('\\').Last();
            fileName = fileName.Remove(fileName.Length - 4);
            string temp = "/k cd " + baseDirectory+ "\\runfiles";
            
            temp += "\n\"" + baseDirectory + "\\swmm5.exe\" " + inputFile + " " + fileName + ".rpt " + fileName + ".out";
            Console.WriteLine(temp);
            System.Diagnostics.Process.Start("CMD.exe", temp );
        }

        //https://www.delftstack.com/howto/csharp/delete-files-from-a-directory-in-csharp/
        private void clearFolder(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete(); 
            }
            
        }
    }
}

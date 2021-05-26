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
    public partial class Form1 : Form
    {

        List<Subcatchments> subs;
        string[] lids;
        string fileName;
        public Form1()
        {
            InitializeComponent();
            createComponentsTree();
            subs = new List<Subcatchments>();
            
        }



        private void createComponentsTree()
        {
            treeView1.Nodes.Clear();
            if (subs != null)
            { 
                TreeNode[] nodeSubs = new TreeNode[subs.Count];
                for (int x = 0; x < subs.Count; x++)
                {
                    nodeSubs[x] = new TreeNode(subs[x].getName());
                }
                /*
                TreeNode[] nodeLID = new TreeNode[lids.Length];
                for (int x = 0; x < lids.Length; x++)
                {
                    nodeLID[x] = new TreeNode(lids[x]);
                }
                */

                TreeNode subcatchment = new TreeNode("Subcatchments", nodeSubs);
                //TreeNode LID_Controls = new TreeNode("LID Controls", nodeLID);
                TreeNode[] Hydrology = new TreeNode[] { subcatchment };
                TreeNode treeNode = new TreeNode("Hydrology", Hydrology);
                treeView1.Nodes.Add(treeNode);
            }
        }
        /*
        private void testData()
        {
            string lid1 = "lid1";
            string lid2 = "lid2";
            string lid3 = "lid3";
            string lid4 = "lid4";
            lids = new string[] { lid1, lid2, lid3, lid4 };

            string sub1 = "sub1";
            string sub2 = "sub2";
            subs = new string[] { sub1, sub2 };         
        }
        */

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "inp files (*.inp)|*.inp";
            openFileDialog1.Title = "Open Input file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                ReadInputFile rif = new ReadInputFile(fileName);
                subs = rif.GetSubcatchments();

            }
            createComponentsTree();
        }
    }
}

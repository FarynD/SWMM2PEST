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
        private void createParameterEditSub(Subcatchments sub)
        {
            Label areaLabel = new Label();
            Label widthLabel = new Label();
            Label percentSlopeLabel = new Label();
            Label percentImpervLabel = new Label();
            Label NImpervLabel = new Label();
            Label NPervLabel = new Label();
            Label SImpervLabel = new Label();
            Label SPervLabel = new Label();
            Label PercentZeroImpervLabel = new Label();
            Label suctionLabel = new Label();
            Label ksatLabel = new Label();
            Label IMDLabel = new Label();

            areaLabel.Text = "Area";
            widthLabel.Text = "Width";
            percentSlopeLabel.Text = "Percent Slope";
            percentImpervLabel.Text = "Percent Impervious";
            NImpervLabel.Text = "Impervious Area Roughness";
            NPervLabel.Text = "Pervious Area Roughness";
            SImpervLabel.Text = "Impervious Area Depression Storage";
            SPervLabel.Text = "Pervious Area Depression Storage";
            PercentZeroImpervLabel.Text = "Percent of Impervious Area with No Depression Storage";
            suctionLabel.Text = "Suction";
            ksatLabel.Text = "Hydraulic Conductivitiy";
            IMDLabel.Text = "Initial Moisture Deficiet";

            TextBox areaTextBox = new TextBox();
            TextBox widthTextBox = new TextBox();
            TextBox percentSlopeTextBox = new TextBox();
            TextBox percentImpervTextBox = new TextBox();
            TextBox NImpervTextBox = new TextBox();
            TextBox NPervTextBox = new TextBox();
            TextBox SImpervTextBox = new TextBox();
            TextBox SPervTextBox = new TextBox();
            TextBox PercentZeroImpervTextBox = new TextBox();
            TextBox suctionTextBox = new TextBox();
            TextBox ksatTextBox = new TextBox();
            TextBox IMDTextBox = new TextBox();

            areaTextBox.Enabled = false;
            widthTextBox.Enabled = false;
            percentSlopeTextBox.Enabled = false;
            percentImpervTextBox.Enabled = false;
            NImpervTextBox.Enabled = false;
            NPervTextBox.Enabled = false;
            SImpervTextBox.Enabled = false;
            SPervTextBox.Enabled = false;
            PercentZeroImpervTextBox.Enabled = false;
            suctionTextBox.Enabled = false;
            ksatTextBox.Enabled = false;
            IMDTextBox.Enabled = false;

            areaTextBox.Text = Convert.ToString(sub.getArea());
            widthTextBox.Text = Convert.ToString(sub.getWidth());
            percentSlopeTextBox.Text = Convert.ToString(sub.getPercentSlope());
            percentImpervTextBox.Text = Convert.ToString(sub.getPercentImperv());
            NImpervTextBox.Text = Convert.ToString(sub.getNImperv());
            NPervTextBox.Text = Convert.ToString(sub.getNPerv());
            SImpervTextBox.Text = Convert.ToString(sub.getSImperv());
            SPervTextBox.Text = Convert.ToString(sub.getSPerv());
            PercentZeroImpervTextBox.Text = Convert.ToString(sub.getPercentZeroImperv());
            suctionTextBox.Text = Convert.ToString(sub.getSuction());
            ksatTextBox.Text = Convert.ToString(sub.getKsat());
            IMDTextBox.Text = Convert.ToString(sub.getIMD());

            Console.WriteLine("panel");
            flowLayoutPanel1.Controls.Add(areaLabel);
            flowLayoutPanel1.Controls.Add(areaTextBox);
            //flowLayoutPanel1.Update();

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

        //-------------------------------------------
        //Events
        //-------------------------------------------

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine(e.Node.Text); //what node has been clicked on.
            if (e.Node.Parent != null)
            {
                Console.WriteLine(e.Node.Parent.Text); //Parent Node.
                if (e.Node.Parent.Text == "Subcatchments")
                {
                    Subcatchments currentsub = subs.Find(subs => subs.getName() == e.Node.Text);
                    createParameterEditSub(currentsub);
                }
            }
            
        }
    }
}

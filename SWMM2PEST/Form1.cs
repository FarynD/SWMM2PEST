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
        List<LID_Controls> lids;
        List<Curves> curves;
        List<Parameter> parameters;
        string fileName;
        List<Parameter> currentChecked;
        List<Parameter> lastChecked;
        public Form1()
        {
            InitializeComponent();
            createComponentsTree();
            subs = new List<Subcatchments>();
            lids = new List<LID_Controls>();
            curves = new List<Curves>();
            parameters = new List<Parameter>();
            currentChecked = new List<Parameter>();
            lastChecked = new List<Parameter>();



        }

        private void surfaceParameterEdit(LID_Controls lid)
        {
            Label surfaceLbl = new Label();
            Label storHtLbl = new Label();
            Label vegFracLbl = new Label();
            Label roughLbl = new Label();
            Label slopeLbl = new Label();
            Label xSlopeLbl = new Label();

            surfaceLbl.Text = "Surface";
            storHtLbl.Text = "Storht";
            vegFracLbl.Text = "VegFrac";
            roughLbl.Text = "Rough";
            slopeLbl.Text = "Slope";
            xSlopeLbl.Text = "xSlope";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(storHtLbl, "Storage Height");
            tooltip1.SetToolTip(vegFracLbl, "fraction of the surface storage volume that is filled with vegetation");
            tooltip1.SetToolTip(roughLbl, "Manning's n for overland flow over surface soil cover, pavement, roof surface or a vegetative swale.Use 0 for other types of LIDs");
            tooltip1.SetToolTip(slopeLbl, "slope of a roof surface, pavement surface or vegetative swale (percent). Use 0 for other types of LIDs.");
            tooltip1.SetToolTip(xSlopeLbl, "slope (run over rise) of the side walls of a vegetative swale's cross section.Use 0 for other types of LIDs.");

            TextBox storHtTxtBx = new TextBox();
            TextBox vegFracTxtBx = new TextBox();
            TextBox roughTxtBx = new TextBox();
            TextBox slopeTxtBx = new TextBox();
            TextBox xSlopeTxtBx = new TextBox();

            storHtTxtBx.Enabled = false;
            vegFracTxtBx.Enabled = false;
            roughTxtBx.Enabled = false;
            slopeTxtBx.Enabled = false;
            xSlopeTxtBx.Enabled = false;

            storHtTxtBx.Text = Convert.ToString(lid.getSurface()[0].getValue());
            vegFracTxtBx.Text = Convert.ToString(lid.getSurface()[1].getValue());
            roughTxtBx.Text = Convert.ToString(lid.getSurface()[2].getValue());
            slopeTxtBx.Text = Convert.ToString(lid.getSurface()[3].getValue());
            xSlopeTxtBx.Text = Convert.ToString(lid.getSurface()[4].getValue());

            CheckBox storHtCheck;
            if (lid.getSurface()[0].getCheckBox() == null)
            {
                storHtCheck = new CheckBox();
                parameters.Add(lid.getSurface()[0]);
                storHtCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSurface()[0].setCheckBox(storHtCheck);
            }
            else 
            { storHtCheck = lid.getSurface()[0].getCheckBox();}
            
            

            CheckBox vegFracCheck;
            if (lid.getSurface()[1].getCheckBox() == null)
            {
                vegFracCheck = new CheckBox();
                parameters.Add(lid.getSurface()[1]);
                vegFracCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSurface()[1].setCheckBox(vegFracCheck);
            }
            else{ vegFracCheck = lid.getSurface()[1].getCheckBox(); }               
                      

            CheckBox roughCheck;
            if (lid.getSurface()[2].getCheckBox() == null)
            {
                roughCheck = new CheckBox();
                parameters.Add(lid.getSurface()[2]);
                roughCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSurface()[2].setCheckBox(roughCheck);
            }
            else{ roughCheck = lid.getSurface()[2].getCheckBox();}

            CheckBox slopeCheck;
            if (lid.getSurface()[3].getCheckBox() == null)
            {
                slopeCheck = new CheckBox();

                parameters.Add(lid.getSurface()[3]);
                slopeCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSurface()[3].setCheckBox(slopeCheck);
            }
            else { slopeCheck = lid.getSurface()[3].getCheckBox(); }

            CheckBox xSlopeCheck;
            if (lid.getSurface()[4].getCheckBox() == null)
            {
                xSlopeCheck = new CheckBox();
                parameters.Add(lid.getSurface()[4]);
                xSlopeCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSurface()[4].setCheckBox(xSlopeCheck);
            }
            else { xSlopeCheck = lid.getSurface()[4].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(surfaceLbl);
            flowLayoutPanel1.SetFlowBreak(surfaceLbl, true);

            
            flowLayoutPanel1.Controls.Add(storHtLbl);
            flowLayoutPanel1.Controls.Add(storHtTxtBx);
            flowLayoutPanel1.Controls.Add(storHtCheck);
            flowLayoutPanel1.SetFlowBreak(storHtCheck, true);




            flowLayoutPanel1.Controls.Add(vegFracLbl);
            flowLayoutPanel1.Controls.Add(vegFracTxtBx);
            flowLayoutPanel1.Controls.Add(vegFracCheck);
            flowLayoutPanel1.SetFlowBreak(vegFracCheck, true);

            


            flowLayoutPanel1.Controls.Add(roughLbl);
            flowLayoutPanel1.Controls.Add(roughTxtBx);
            flowLayoutPanel1.Controls.Add(roughCheck);
            flowLayoutPanel1.SetFlowBreak(roughCheck, true);

            flowLayoutPanel1.Controls.Add(slopeLbl);
            flowLayoutPanel1.Controls.Add(slopeTxtBx);
            flowLayoutPanel1.Controls.Add(slopeCheck);
            flowLayoutPanel1.SetFlowBreak(slopeCheck, true);

            flowLayoutPanel1.Controls.Add(xSlopeLbl);
            flowLayoutPanel1.Controls.Add(xSlopeTxtBx);
            flowLayoutPanel1.Controls.Add(xSlopeCheck);
            flowLayoutPanel1.SetFlowBreak(xSlopeCheck, true);
            

            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

            if (storHtCheck.Checked) { addMinMaxBox(lid.getSurface()[0]); }
            if (vegFracCheck.Checked) { addMinMaxBox(lid.getSurface()[1]); }
            if (roughCheck.Checked) { addMinMaxBox(lid.getSurface()[2]); }
            if (slopeCheck.Checked) { addMinMaxBox(lid.getSurface()[3]); }
            if (xSlopeCheck.Checked) { addMinMaxBox(lid.getSurface()[4]); }

        }

        private void soilParameterEdit(LID_Controls lid)
        {
            Label soilLbl = new Label();
            Label thickLbl = new Label();
            Label porLbl = new Label();
            Label fcLbl = new Label();
            Label wpLbl = new Label();
            Label ksatLbl = new Label();
            Label kcoeffLbl = new Label();
            Label suctLbl = new Label();

            soilLbl.Text = "Soil";
            thickLbl.Text = "Thick";
            porLbl.Text = "Por";
            fcLbl.Text = "FC";
            wpLbl.Text = "WP";
            ksatLbl.Text = "ksat";
            kcoeffLbl.Text = "kcoeff";
            suctLbl.Text = "suct";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(thickLbl, "thickness of the soil layer (inches or mm).");
            tooltip1.SetToolTip(porLbl, "soil porosity (volume of pore space relative to total volume).");
            tooltip1.SetToolTip(fcLbl, "soil field capacity (volume of pore water relative to total volume after the soil has been allowed to drain fully).");
            tooltip1.SetToolTip(wpLbl, "soil wilting point (volume of pore water relative to total volume for a well dried soil where only bound water remains).");
            tooltip1.SetToolTip(ksatLbl, "soil’s saturated hydraulic conductivity (in/hr or mm/hr).");
            tooltip1.SetToolTip(kcoeffLbl, "slope of the curve of log(conductivity) versus soil moisture content(dimensionless).");
            tooltip1.SetToolTip(suctLbl, "soil capillary suction (in or mm).");


            TextBox thickTxtBx = new TextBox();
            TextBox porTxtBx = new TextBox();
            TextBox fcTxtBx = new TextBox();
            TextBox wpTxtBx = new TextBox();
            TextBox ksatTxtBx = new TextBox();
            TextBox kcoeffTxtBx = new TextBox();
            TextBox suctTxtBx = new TextBox();

            thickTxtBx.Enabled = false;
            porTxtBx.Enabled = false;
            fcTxtBx.Enabled = false;
            wpTxtBx.Enabled = false;
            ksatTxtBx.Enabled = false;
            kcoeffTxtBx.Enabled = false;
            suctTxtBx.Enabled = false;

            thickTxtBx.Text = Convert.ToString(lid.getSoil()[0].getValue());
            porTxtBx.Text = Convert.ToString(lid.getSoil()[1].getValue());
            fcTxtBx.Text = Convert.ToString(lid.getSoil()[2].getValue());
            wpTxtBx.Text = Convert.ToString(lid.getSoil()[3].getValue());
            ksatTxtBx.Text = Convert.ToString(lid.getSoil()[4].getValue());
            kcoeffTxtBx.Text = Convert.ToString(lid.getSoil()[5].getValue());
            suctTxtBx.Text = Convert.ToString(lid.getSoil()[6].getValue());

            CheckBox thickCheck;
            if (lid.getSoil()[0].getCheckBox() == null)
            {
                thickCheck = new CheckBox();
                parameters.Add(lid.getSoil()[0]);
                thickCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[0].setCheckBox(thickCheck);
            }
            else { thickCheck = lid.getSoil()[0].getCheckBox(); }

            CheckBox porCheck;
            if (lid.getSoil()[1].getCheckBox() == null)
            {
                porCheck = new CheckBox();
                parameters.Add(lid.getSoil()[1]);
                porCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[1].setCheckBox(porCheck);
            }
            else { porCheck = lid.getSoil()[1].getCheckBox(); }

            CheckBox fcCheck;
            if (lid.getSoil()[2].getCheckBox() == null)
            {
                fcCheck = new CheckBox();
                parameters.Add(lid.getSoil()[2]);
                fcCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[2].setCheckBox(fcCheck);
            }
            else { fcCheck = lid.getSoil()[2].getCheckBox(); }

            CheckBox wpCheck;
            if (lid.getSoil()[3].getCheckBox() == null)
            {
                wpCheck = new CheckBox();
                parameters.Add(lid.getSoil()[3]);
                wpCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[3].setCheckBox(wpCheck);
            }
            else { wpCheck = lid.getSoil()[3].getCheckBox(); }

            CheckBox ksatCheck;
            if (lid.getSoil()[4].getCheckBox() == null)
            {
                ksatCheck = new CheckBox();
                parameters.Add(lid.getSoil()[4]);
                ksatCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[4].setCheckBox(ksatCheck);
            }
            else { ksatCheck = lid.getSoil()[4].getCheckBox(); }

            CheckBox kcoeffCheck = new CheckBox();
            if (lid.getSoil()[5].getCheckBox() == null)
            {
                kcoeffCheck = new CheckBox();
                parameters.Add(lid.getSoil()[5]);
                kcoeffCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[5].setCheckBox(kcoeffCheck);
            }
            else { kcoeffCheck = lid.getSoil()[5].getCheckBox(); }


            CheckBox suctCheck;
            if (lid.getSoil()[6].getCheckBox() == null)
            {
                suctCheck = new CheckBox();
                parameters.Add(lid.getSoil()[6]);
                suctCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getSoil()[6].setCheckBox(suctCheck);
            }
            else { suctCheck = lid.getSoil()[6].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(soilLbl);
            flowLayoutPanel1.SetFlowBreak(soilLbl, true);

            flowLayoutPanel1.Controls.Add(thickLbl);
            flowLayoutPanel1.Controls.Add(thickTxtBx);
            flowLayoutPanel1.Controls.Add(thickCheck);
            flowLayoutPanel1.SetFlowBreak(thickCheck, true);

            flowLayoutPanel1.Controls.Add(porLbl);
            flowLayoutPanel1.Controls.Add(porTxtBx);
            flowLayoutPanel1.Controls.Add(porCheck);
            flowLayoutPanel1.SetFlowBreak(porCheck, true);

            flowLayoutPanel1.Controls.Add(fcLbl);
            flowLayoutPanel1.Controls.Add(fcTxtBx);
            flowLayoutPanel1.Controls.Add(fcCheck);
            flowLayoutPanel1.SetFlowBreak(fcCheck, true);

            flowLayoutPanel1.Controls.Add(wpLbl);
            flowLayoutPanel1.Controls.Add(wpTxtBx);
            flowLayoutPanel1.Controls.Add(wpCheck);
            flowLayoutPanel1.SetFlowBreak(wpCheck, true);

            flowLayoutPanel1.Controls.Add(ksatLbl);
            flowLayoutPanel1.Controls.Add(ksatTxtBx);
            flowLayoutPanel1.Controls.Add(ksatCheck);
            flowLayoutPanel1.SetFlowBreak(ksatCheck, true);

            flowLayoutPanel1.Controls.Add(kcoeffLbl);
            flowLayoutPanel1.Controls.Add(kcoeffTxtBx);
            flowLayoutPanel1.Controls.Add(kcoeffCheck);
            flowLayoutPanel1.SetFlowBreak(kcoeffCheck, true);

            flowLayoutPanel1.Controls.Add(suctLbl);
            flowLayoutPanel1.Controls.Add(suctTxtBx);
            flowLayoutPanel1.Controls.Add(suctCheck);
            flowLayoutPanel1.SetFlowBreak(suctCheck, true);

            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

            if (thickCheck.Checked) { addMinMaxBox(lid.getSoil()[0]); }
            if (porCheck.Checked) { addMinMaxBox(lid.getSoil()[1]); }
            if(fcCheck.Checked) { addMinMaxBox(lid.getSoil()[2]); }
            if(wpCheck.Checked) { addMinMaxBox(lid.getSoil()[3]); }
            if (ksatCheck.Checked) { addMinMaxBox(lid.getSoil()[4]); }
            if(kcoeffCheck.Checked) { addMinMaxBox(lid.getSoil()[5]); }
            if(suctCheck.Checked) { addMinMaxBox(lid.getSoil()[6]); }

        }
        private void pavementParameterEdit(LID_Controls lid)
        {
            Label pavLbl = new Label();
            Label thickLbl = new Label();
            Label vRatioLbl = new Label();
            Label fracImpLbl = new Label();
            Label permLbl = new Label();
            Label vclogLbl = new Label();

            pavLbl.Text = "Pavement";
            thickLbl.Text = "Thick";
            vRatioLbl.Text = "Vratio";
            fracImpLbl.Text = "FracImp";
            permLbl.Text = "Perm";
            vclogLbl.Text = "Vclog";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(thickLbl, "thickness of the pavement layer (inches or mm).");
            tooltip1.SetToolTip(vRatioLbl, "void ratio (volume of void space relative to the volume of solids in the pavement for continuous systems or for the fill material used in modular systems).Note that porosity = void ratio / (1 + void ratio).");
            tooltip1.SetToolTip(fracImpLbl, "ratio of impervious paver material to total area for modular systems; 0 for continuous porous pavement systems.");
            tooltip1.SetToolTip(permLbl, "permeability of the concrete or asphalt used in continuous systems or hydraulic conductivity of the fill material(gravel or sand) used in modular systems(in/ hr or mm / hr).");
            tooltip1.SetToolTip(vclogLbl, "number of pavement layer void volumes of runoff treated it takes to completely clog the pavement.Use a value of 0 to ignore clogging.");

            TextBox thickTxtBx = new TextBox();
            TextBox vRatioTxtBx = new TextBox();
            TextBox fracImpTxtBx = new TextBox();
            TextBox permTxtBx = new TextBox();
            TextBox vclogTxtBx = new TextBox();

            thickTxtBx.Enabled = false;
            vRatioTxtBx.Enabled = false;
            fracImpTxtBx.Enabled = false;
            permTxtBx.Enabled = false;
            vclogTxtBx.Enabled = false;

            thickTxtBx.Text = Convert.ToString(lid.getPavement()[0].getValue());
            vRatioTxtBx.Text = Convert.ToString(lid.getPavement()[1].getValue());
            fracImpTxtBx.Text = Convert.ToString(lid.getPavement()[2].getValue());
            permTxtBx.Text = Convert.ToString(lid.getPavement()[3].getValue());
            vclogTxtBx.Text = Convert.ToString(lid.getPavement()[4].getValue());

            CheckBox thickCheck;
            if (lid.getPavement()[0].getCheckBox() == null)
            {
                thickCheck = new CheckBox();
                parameters.Add(lid.getPavement()[0]);
                thickCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getPavement()[0].setCheckBox(thickCheck);
            }
            else { thickCheck = lid.getPavement()[0].getCheckBox(); }

            CheckBox vRatioCheck;
            if (lid.getPavement()[1].getCheckBox() == null)
            {
                vRatioCheck = new CheckBox();    
                parameters.Add(lid.getPavement()[1]);
                vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getPavement()[1].setCheckBox(vRatioCheck);
            }
            else { vRatioCheck = lid.getPavement()[1].getCheckBox(); }

            CheckBox fracImpCheck;
            if (lid.getPavement()[2].getCheckBox() == null)
            {
                fracImpCheck = new CheckBox();
                parameters.Add(lid.getPavement()[2]);
                fracImpCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getPavement()[2].setCheckBox(fracImpCheck);
            }
            else { fracImpCheck = lid.getPavement()[2].getCheckBox(); }

            CheckBox permCheck;
            if (lid.getPavement()[3].getCheckBox() == null)
            {
                permCheck = new CheckBox();
                parameters.Add(lid.getPavement()[3]);
                permCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getPavement()[3].setCheckBox(permCheck);
            }
            else { permCheck = lid.getPavement()[3].getCheckBox(); }

            CheckBox vclogCheck;
            if (lid.getPavement()[4].getCheckBox() == null)
            {
                vclogCheck = new CheckBox();
                parameters.Add(lid.getPavement()[4]);
                vclogCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getPavement()[4].setCheckBox(vclogCheck);
            }
            else { vclogCheck = lid.getPavement()[4].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(pavLbl);
            flowLayoutPanel1.SetFlowBreak(pavLbl, true);

            flowLayoutPanel1.Controls.Add(thickLbl);
            flowLayoutPanel1.Controls.Add(thickTxtBx);
            flowLayoutPanel1.Controls.Add(thickCheck);
            flowLayoutPanel1.SetFlowBreak(thickCheck, true);

            flowLayoutPanel1.Controls.Add(vRatioLbl);
            flowLayoutPanel1.Controls.Add(vRatioTxtBx);
            flowLayoutPanel1.Controls.Add(vRatioCheck);
            flowLayoutPanel1.SetFlowBreak(vRatioCheck, true);

            flowLayoutPanel1.Controls.Add(fracImpLbl);
            flowLayoutPanel1.Controls.Add(fracImpTxtBx);
            flowLayoutPanel1.Controls.Add(fracImpCheck);
            flowLayoutPanel1.SetFlowBreak(fracImpCheck, true);

            flowLayoutPanel1.Controls.Add(permLbl);
            flowLayoutPanel1.Controls.Add(permTxtBx);
            flowLayoutPanel1.Controls.Add(permCheck);
            flowLayoutPanel1.SetFlowBreak(permCheck, true);

            flowLayoutPanel1.Controls.Add(vclogLbl);
            flowLayoutPanel1.Controls.Add(vclogTxtBx);
            flowLayoutPanel1.Controls.Add(vclogCheck);
            flowLayoutPanel1.SetFlowBreak(vclogCheck, true);

            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

            if (thickCheck.Checked) { addMinMaxBox(lid.getPavement()[0]); }
            if(vRatioCheck.Checked) { addMinMaxBox(lid.getPavement()[1]); }
            if(fracImpCheck.Checked) { addMinMaxBox(lid.getPavement()[2]); }
            if(permCheck.Checked) { addMinMaxBox(lid.getPavement()[3]); }
            if(vclogCheck.Checked) { addMinMaxBox(lid.getPavement()[4]); }
        }

        private void storageParameterEdit(LID_Controls lid)
        {
            Label storLbl = new Label();
            Label heightLbl = new Label();
            Label vRatioLbl = new Label();
            Label seepageLbl = new Label();
            Label vclogLbl = new Label();

            storLbl.Text = "Storage";
            heightLbl.Text = "height";
            vRatioLbl.Text = "Vratio";
            seepageLbl.Text = "Seepage";
            vclogLbl.Text = "Vclog";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(heightLbl, "thickness of the storage layer or height of a rain barrel (inches or mm).");
            tooltip1.SetToolTip(vRatioLbl, "void ratio (volume of void space relative to the volume of solids in the layer).Note that porosity = void ratio / (1 + void ratio).");
            tooltip1.SetToolTip(seepageLbl, "the rate at which water seeps from the layer into the underlying native soil when first constructed(in/ hr or mm / hr).If there is an impermeable floor or liner below the layer then use a value of 0.");
            tooltip1.SetToolTip(vclogLbl, "number of storage layer void volumes of runoff treated it takes to completely clog the layer.Use a value of 0 to ignore clogging.");

            TextBox heightTxtBx = new TextBox();
            TextBox vRatioTxtBx = new TextBox();
            TextBox seepageTxtBx = new TextBox();
            TextBox vclogTxtBx = new TextBox();

            heightTxtBx.Enabled = false;
            vRatioTxtBx.Enabled = false;
            seepageTxtBx.Enabled = false;
            vclogTxtBx.Enabled = false;

            heightTxtBx.Text = Convert.ToString(lid.getStorage()[0].getValue());
            vRatioTxtBx.Text = Convert.ToString(lid.getStorage()[1].getValue());
            seepageTxtBx.Text = Convert.ToString(lid.getStorage()[2].getValue());
            vclogTxtBx.Text = Convert.ToString(lid.getStorage()[3].getValue());


            CheckBox heightCheck;
            if (lid.getStorage()[0].getCheckBox() == null)
            {
                heightCheck = new CheckBox();
                parameters.Add(lid.getStorage()[0]);
                heightCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getStorage()[0].setCheckBox(heightCheck);
            }
            else { heightCheck = lid.getStorage()[0].getCheckBox(); }

            CheckBox vRatioCheck;
            if (lid.getStorage()[1].getCheckBox() == null)
            {
                vRatioCheck = new CheckBox();
                parameters.Add(lid.getStorage()[1]);
                vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getStorage()[1].setCheckBox(vRatioCheck);
            }
            else { vRatioCheck = lid.getStorage()[1].getCheckBox(); }

            CheckBox seepageCheck;
            if (lid.getStorage()[2].getCheckBox() == null)
            {
                seepageCheck = new CheckBox();
                parameters.Add(lid.getStorage()[2]);
                seepageCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getStorage()[2].setCheckBox(seepageCheck);
            }
            else { seepageCheck = lid.getStorage()[2].getCheckBox(); }

            CheckBox vclogCheck;
            if (lid.getStorage()[3].getCheckBox() == null)
            {
                vclogCheck = new CheckBox();
                parameters.Add(lid.getStorage()[3]);
                vclogCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getStorage()[3].setCheckBox(vclogCheck);
            }
            else { vclogCheck = lid.getStorage()[3].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(storLbl);
            flowLayoutPanel1.SetFlowBreak(storLbl, true);

            flowLayoutPanel1.Controls.Add(heightLbl);
            flowLayoutPanel1.Controls.Add(heightTxtBx);
            flowLayoutPanel1.Controls.Add(heightCheck);
            flowLayoutPanel1.SetFlowBreak(heightCheck, true);

            flowLayoutPanel1.Controls.Add(vRatioLbl); ;
            flowLayoutPanel1.Controls.Add(vRatioTxtBx);
            flowLayoutPanel1.Controls.Add(vRatioCheck);
            flowLayoutPanel1.SetFlowBreak(vRatioCheck, true);

            flowLayoutPanel1.Controls.Add(seepageLbl);
            flowLayoutPanel1.Controls.Add(seepageTxtBx);
            flowLayoutPanel1.Controls.Add(seepageCheck);
            flowLayoutPanel1.SetFlowBreak(seepageCheck, true);

            flowLayoutPanel1.Controls.Add(vclogLbl);
            flowLayoutPanel1.Controls.Add(vclogTxtBx);
            flowLayoutPanel1.Controls.Add(vclogCheck);
            flowLayoutPanel1.SetFlowBreak(vclogCheck, true);

            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

            if(heightCheck.Checked) { addMinMaxBox(lid.getStorage()[0]); }
            if(vRatioCheck.Checked) { addMinMaxBox(lid.getStorage()[1]); }
            if(seepageCheck.Checked) { addMinMaxBox(lid.getStorage()[2]); }
            if(seepageCheck.Checked) { addMinMaxBox(lid.getStorage()[3]); }

        }

        private void drainParameterEdit(LID_Controls lid)
        {
            bool hasDelay = false; //only rainbarrel use drain delay
            bool hasOpenClose = false; // older swmm files don't have open level or closed level
            bool hasCurve = false;
            if (lid.getCurveName() != "") { hasCurve = true; }
            if (lid.getDrain().Length == 5) { hasOpenClose = true; }
            Label drainLbl = new Label();
            Label coeffLbl = new Label();
            Label exponLbl = new Label();
            Label offsetLbl = new Label();

            drainLbl.Text = "Drain";
            coeffLbl.Text = "coeff";
            exponLbl.Text = "expon";
            offsetLbl.Text = "offset";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(coeffLbl, "coefficient C that determines the rate of flow through the drain as a function of height of stored water above the drain bottom.For Rooftop Disconnection it is the maximum flow rate(in inches / hour or mm / hour) that the roof’s gutters and downspouts can handle before overflowing.");
            tooltip1.SetToolTip(exponLbl, "exponent n that determines the rate of flow through the drain as a function of height of stored water above the drain outlet.");
            tooltip1.SetToolTip(offsetLbl, "height of the drain line above the bottom of the storage layer or rain barrel(inches or mm).");

            TextBox coeffTxtBx = new TextBox();
            TextBox exponTxtBx = new TextBox();
            TextBox offsetTxtBx = new TextBox();

            coeffTxtBx.Enabled = false;
            exponTxtBx.Enabled = false;
            offsetTxtBx.Enabled = false;

            coeffTxtBx.Text = Convert.ToString(lid.getDrain()[0].getValue());
            exponTxtBx.Text = Convert.ToString(lid.getDrain()[1].getValue());
            offsetTxtBx.Text = Convert.ToString(lid.getDrain()[2].getValue());

            CheckBox coeffCheck;
            if (lid.getDrain()[0].getCheckBox() == null)
            {
                coeffCheck = new CheckBox();
                parameters.Add(lid.getDrain()[0]);
                coeffCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrain()[0].setCheckBox(coeffCheck);
            }
            else { coeffCheck = lid.getDrain()[0].getCheckBox(); }

            CheckBox exponCheck;
            if (lid.getDrain()[1].getCheckBox() == null)
            {
                exponCheck = new CheckBox();
                parameters.Add(lid.getDrain()[1]);
                exponCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrain()[1].setCheckBox(exponCheck);
            }
            else { exponCheck = lid.getDrain()[1].getCheckBox(); }

            CheckBox offsetCheck;
            if (lid.getDrain()[2].getCheckBox() == null)
            {
                offsetCheck = new CheckBox();
                parameters.Add(lid.getDrain()[2]);
                offsetCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrain()[2].setCheckBox(offsetCheck);
            }
            else { offsetCheck = lid.getDrain()[2].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(drainLbl);
            flowLayoutPanel1.SetFlowBreak(drainLbl, true);

            flowLayoutPanel1.Controls.Add(coeffLbl);
            flowLayoutPanel1.Controls.Add(coeffTxtBx);
            flowLayoutPanel1.Controls.Add(coeffCheck);
            flowLayoutPanel1.SetFlowBreak(coeffCheck, true);

            flowLayoutPanel1.Controls.Add(exponLbl);
            flowLayoutPanel1.Controls.Add(exponTxtBx);
            flowLayoutPanel1.Controls.Add(exponCheck);
            flowLayoutPanel1.SetFlowBreak(exponCheck, true);

            flowLayoutPanel1.Controls.Add(offsetLbl);
            flowLayoutPanel1.Controls.Add(offsetTxtBx);
            flowLayoutPanel1.Controls.Add(offsetCheck);
            flowLayoutPanel1.SetFlowBreak(offsetCheck, true);

            if (coeffCheck.Checked) { addMinMaxBox(lid.getDrain()[0]); }
            if (exponCheck.Checked) { addMinMaxBox(lid.getDrain()[1]); }
            if (offsetCheck.Checked) { addMinMaxBox(lid.getDrain()[2]); }

            if (hasOpenClose)
            {
                Label openLbl = new Label();
                Label closedLbl = new Label();
                openLbl.Text = "Open Level";
                closedLbl.Text = "Closed Level";
                tooltip1.SetToolTip(openLbl, "The height (in inches or mm) in the drain's Storage Layer that causes the drain to automatically open when the water level rises above it. ");
                tooltip1.SetToolTip(openLbl, "The height (in inches or mm) in the drain's Storage Layer that causes the drain to automatically close when the water level falls below it. ");
                TextBox openTxt = new TextBox();
                TextBox closedTxt = new TextBox();
                openTxt.Enabled = false;
                closedTxt.Enabled = false;
                openTxt.Text = Convert.ToString(lid.getDrain()[3].getValue());
                closedTxt.Text = Convert.ToString(lid.getDrain()[4].getValue());

                CheckBox openCheck;
                if (lid.getDrain()[3].getCheckBox() == null)
                {
                    openCheck = new CheckBox();
                    parameters.Add(lid.getDrain()[3]);
                    openCheck.CheckedChanged += new EventHandler(checkChecked);
                    lid.getDrain()[3].setCheckBox(openCheck);
                }
                else { openCheck = lid.getDrain()[3].getCheckBox(); }

                CheckBox closeCheck;
                if (lid.getDrain()[4].getCheckBox() == null)
                {
                    closeCheck = new CheckBox();
                    parameters.Add(lid.getDrain()[4]);
                    closeCheck.CheckedChanged += new EventHandler(checkChecked);
                    lid.getDrain()[4].setCheckBox(closeCheck);
                }
                else { closeCheck = lid.getDrain()[4].getCheckBox(); }


                flowLayoutPanel1.Controls.Add(openLbl);
                flowLayoutPanel1.Controls.Add(openTxt);
                flowLayoutPanel1.Controls.Add(openCheck);
                flowLayoutPanel1.SetFlowBreak(openCheck, true);

                flowLayoutPanel1.Controls.Add(closedLbl);
                flowLayoutPanel1.Controls.Add(closedTxt);
                flowLayoutPanel1.Controls.Add(closeCheck);
                flowLayoutPanel1.SetFlowBreak(closeCheck, true);

                if(openCheck.Checked) { addMinMaxBox(lid.getDrain()[3]); }
                if(closeCheck.Checked) { addMinMaxBox(lid.getDrain()[4]); }
            }
            else
            {
                Label delayLbl = new Label();
                delayLbl.Text = "delay";
                tooltip1.SetToolTip(delayLbl, "number of dry weather hours that must elapse before the drain line in a rain barrel is opened(the line is assumed to be closed once rainfall begins).A value of 0 signifies that the barrel's drain line is always open and drains continuously.This parameter is ignored for other types of LIDs.");
                TextBox delayTxtBx = new TextBox();
                delayTxtBx.Enabled = false;
                delayTxtBx.Text = Convert.ToString(lid.getDrain()[3].getValue());

                CheckBox delayCheck;
                if (lid.getDrain()[3].getCheckBox() == null)
                {
                    delayCheck = new CheckBox();
                    parameters.Add(lid.getDrain()[3]);
                    delayCheck.CheckedChanged += new EventHandler(checkChecked);
                    lid.getDrain()[3].setCheckBox(delayCheck);
                }
                else { delayCheck = lid.getDrain()[3].getCheckBox(); }


                flowLayoutPanel1.Controls.Add(delayLbl);
                flowLayoutPanel1.Controls.Add(delayTxtBx);
                flowLayoutPanel1.Controls.Add(delayCheck);
                flowLayoutPanel1.SetFlowBreak(delayCheck, true);

                if(delayCheck.Checked) { addMinMaxBox(lid.getDrain()[3]); }

            }


            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

        }

        private void drainmatParameterEdit(LID_Controls lid)
        {
            Label drainmLbl = new Label();
            Label thickLbl = new Label();
            Label vRatioLbl = new Label();
            Label roughLbl = new Label();

            drainmLbl.Text = "Drainmat";
            thickLbl.Text = "thick";
            vRatioLbl.Text = "vRatio";
            roughLbl.Text = "rough";

            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(thickLbl, "thickness of the drainage mat (inches or mm).");
            tooltip1.SetToolTip(vRatioLbl, "ratio of void volume to total volume in the mat.");
            tooltip1.SetToolTip(roughLbl, "Manning's n constant used to compute the horizontal flow rate of drained water through the mat.");

            TextBox thickTxtBx = new TextBox();
            TextBox vRatioTxtBx = new TextBox();
            TextBox roughTxtBx = new TextBox();

            thickTxtBx.Enabled = false;
            vRatioTxtBx.Enabled = false;
            roughTxtBx.Enabled = false;

            thickTxtBx.Text = Convert.ToString(lid.getDrainmat()[0].getValue());
            vRatioTxtBx.Text = Convert.ToString(lid.getDrainmat()[1].getValue());
            roughTxtBx.Text = Convert.ToString(lid.getDrainmat()[2].getValue());

            CheckBox thickCheck;
            if (lid.getDrainmat()[0].getCheckBox() == null)
            {
                thickCheck = new CheckBox();
                parameters.Add(lid.getDrainmat()[0]);
                thickCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrainmat()[0].setCheckBox(thickCheck);
            }else { thickCheck = lid.getDrainmat()[0].getCheckBox(); }


            CheckBox vRatioCheck;
            if (lid.getDrainmat()[1].getCheckBox() == null)
            {
                vRatioCheck = new CheckBox();
                parameters.Add(lid.getDrainmat()[1]);
                vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrainmat()[1].setCheckBox(vRatioCheck);
            }else { vRatioCheck = lid.getDrainmat()[1].getCheckBox(); }


            CheckBox roughCheck;
            if (lid.getDrainmat()[2].getCheckBox() == null)
            {
                roughCheck = new CheckBox();
                parameters.Add(lid.getDrainmat()[2]);
                roughCheck.CheckedChanged += new EventHandler(checkChecked);
                lid.getDrainmat()[2].setCheckBox(roughCheck);
            }else { roughCheck = lid.getDrainmat()[2].getCheckBox(); }

            flowLayoutPanel1.Controls.Add(drainmLbl);
            flowLayoutPanel1.SetFlowBreak(drainmLbl, true);

            flowLayoutPanel1.Controls.Add(thickLbl);
            flowLayoutPanel1.Controls.Add(thickTxtBx);
            flowLayoutPanel1.Controls.Add(thickCheck);
            flowLayoutPanel1.SetFlowBreak(thickCheck, true);

            flowLayoutPanel1.Controls.Add(vRatioLbl);
            flowLayoutPanel1.Controls.Add(vRatioTxtBx);
            flowLayoutPanel1.Controls.Add(vRatioCheck);
            flowLayoutPanel1.SetFlowBreak(vRatioCheck, true);

            flowLayoutPanel1.Controls.Add(roughLbl);
            flowLayoutPanel1.Controls.Add(roughTxtBx);
            flowLayoutPanel1.Controls.Add(roughCheck);
            flowLayoutPanel1.SetFlowBreak(roughCheck, true);

            Label blankLbl = new Label();
            blankLbl.Text = " ";
            flowLayoutPanel1.Controls.Add(blankLbl);
            flowLayoutPanel1.SetFlowBreak(blankLbl, true);

            if(thickCheck.Checked) { addMinMaxBox(lid.getDrainmat()[0]); }
            if(vRatioCheck.Checked) { addMinMaxBox(lid.getDrainmat()[1]); }
            if(roughCheck.Checked) { addMinMaxBox(lid.getDrainmat()[2]); }

        }

        private void createParameterEditLID(LID_Controls lid)
        {

            flowLayoutPanel1.Controls.Clear();

            if (lid.getType() == "BC")
            {
                surfaceParameterEdit(lid);
                soilParameterEdit(lid);
                storageParameterEdit(lid);
                drainParameterEdit(lid);
            }
            else if (lid.getType() == "RG")
            {
                surfaceParameterEdit(lid);
                soilParameterEdit(lid);
                storageParameterEdit(lid);
            }
            else if (lid.getType() == "GR")
            {
                surfaceParameterEdit(lid);
                soilParameterEdit(lid);
                drainmatParameterEdit(lid);
            }
            else if (lid.getType() == "IT")
            {
                surfaceParameterEdit(lid);
                storageParameterEdit(lid);
                drainParameterEdit(lid);

            }
            else if (lid.getType() == "PP")
            {
                surfaceParameterEdit(lid);
                pavementParameterEdit(lid);
                soilParameterEdit(lid);
                storageParameterEdit(lid);
                drainParameterEdit(lid);
            }
            else if (lid.getType() == "RB")
            {
                storageParameterEdit(lid);
                drainParameterEdit(lid);
            }
            else if (lid.getType() == "RD")
            {
                surfaceParameterEdit(lid);
                drainParameterEdit(lid);
            }
            else if (lid.getType() == "VS")
            {
                surfaceParameterEdit(lid);
            }

        }
        private void createParameterEditSub(Subcatchments sub)
        {
            flowLayoutPanel1.Controls.Clear();

            Label areaLabel = new Label();
            Label widthLabel = new Label();
            Label percentSlopeLabel = new Label();
            Label percentImpervLabel = new Label();
            Label NImpervLabel = new Label();
            Label NPervLabel = new Label();
            Label SImpervLabel = new Label();
            Label SPervLabel = new Label();
            Label percentZeroImpervLabel = new Label();
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
            percentZeroImpervLabel.Text = "Percent of Impervious Area with No Depression Storage";
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
            TextBox percentZeroImpervTextBox = new TextBox();
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
            percentZeroImpervTextBox.Enabled = false;
            suctionTextBox.Enabled = false;
            ksatTextBox.Enabled = false;
            IMDTextBox.Enabled = false;

            areaTextBox.Text = Convert.ToString(sub.getArea().getValue());
            widthTextBox.Text = Convert.ToString(sub.getWidth().getValue());
            percentSlopeTextBox.Text = Convert.ToString(sub.getPercentSlope().getValue());
            percentImpervTextBox.Text = Convert.ToString(sub.getPercentImperv().getValue());
            NImpervTextBox.Text = Convert.ToString(sub.getNImperv().getValue());
            NPervTextBox.Text = Convert.ToString(sub.getNPerv().getValue());
            SImpervTextBox.Text = Convert.ToString(sub.getSImperv().getValue());
            SPervTextBox.Text = Convert.ToString(sub.getSPerv().getValue());
            percentZeroImpervTextBox.Text = Convert.ToString(sub.getPercentZeroImperv().getValue());
            suctionTextBox.Text = Convert.ToString(sub.getSuction().getValue());
            ksatTextBox.Text = Convert.ToString(sub.getKsat().getValue());
            IMDTextBox.Text = Convert.ToString(sub.getIMD().getValue());

            

            CheckBox areaCheck;
            if (sub.getArea().getCheckBox() == null)
            {
                areaCheck = new CheckBox();
                parameters.Add(sub.getArea());
                areaCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getArea().setCheckBox(areaCheck);
            }else { areaCheck = sub.getArea().getCheckBox(); }

            CheckBox widthCheck;
            if (sub.getWidth().getCheckBox() == null)
            {
                widthCheck = new CheckBox();
                parameters.Add(sub.getWidth());
                widthCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getWidth().setCheckBox(widthCheck);
            }else { widthCheck = sub.getWidth().getCheckBox(); }

            CheckBox percentSlopeCheck;
            if (sub.getPercentSlope().getCheckBox() == null)
            {
                percentSlopeCheck = new CheckBox();
                parameters.Add(sub.getPercentSlope());
                percentSlopeCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getPercentSlope().setCheckBox(percentSlopeCheck);
            }else { percentSlopeCheck = sub.getPercentSlope().getCheckBox(); }

            CheckBox percentImpervCheck;
            if (sub.getPercentImperv().getCheckBox() == null)
            {
                percentImpervCheck = new CheckBox();
                parameters.Add(sub.getPercentImperv());
                percentImpervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getPercentImperv().setCheckBox(percentImpervCheck);
            }else { percentImpervCheck = sub.getPercentImperv().getCheckBox(); }

            CheckBox NImpervCheck;
            if (sub.getNImperv().getCheckBox() == null)
            {
                NImpervCheck = new CheckBox();
                parameters.Add(sub.getNImperv());
                NImpervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getNImperv().setCheckBox(NImpervCheck);
            } else { NImpervCheck = sub.getNImperv().getCheckBox(); }

            CheckBox NPervCheck;
            if (sub.getNPerv().getCheckBox() == null)
            {
                NPervCheck = new CheckBox();
                parameters.Add(sub.getNPerv());
                NPervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getNPerv().setCheckBox(NPervCheck);
            }else { NPervCheck = sub.getNPerv().getCheckBox(); }

            CheckBox SImpervCheck;
            if (sub.getSImperv().getCheckBox() == null)
            {
                SImpervCheck = new CheckBox();
                parameters.Add(sub.getSImperv());
                SImpervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getSImperv().setCheckBox(SImpervCheck);
            }else { SImpervCheck = sub.getSImperv().getCheckBox(); }

            CheckBox SPervCheck;
            if (sub.getSPerv().getCheckBox() == null)
            {
                SPervCheck = new CheckBox();
                parameters.Add(sub.getSPerv());
                SPervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getSPerv().setCheckBox(SPervCheck);
            }else { SPervCheck = sub.getSPerv().getCheckBox(); }

            CheckBox percentZeroImpervCheck;
            if (sub.getPercentZeroImperv().getCheckBox() == null)
            {
                percentZeroImpervCheck = new CheckBox();
                parameters.Add(sub.getPercentZeroImperv());
                percentZeroImpervCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getPercentZeroImperv().setCheckBox(percentZeroImpervCheck);
            }
            else {
                percentZeroImpervCheck = sub.getPercentZeroImperv().getCheckBox(); }

            CheckBox suctionCheck;
            if (sub.getSuction().getCheckBox() == null)
            {
                suctionCheck = new CheckBox();
                parameters.Add(sub.getSuction());
                suctionCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getSuction().setCheckBox(suctionCheck);
            }else {
                suctionCheck = sub.getSuction().getCheckBox(); }

            CheckBox ksatCheck;
            if (sub.getKsat().getCheckBox() == null)
            {
                ksatCheck = new CheckBox();
                parameters.Add(sub.getKsat());
                ksatCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getKsat().setCheckBox(ksatCheck);
            }else { ksatCheck = sub.getKsat().getCheckBox(); }

            
            CheckBox IMDCheck;
            if (sub.getIMD().getCheckBox() == null)
            {
                IMDCheck = new CheckBox();
                parameters.Add(sub.getIMD());
                IMDCheck.CheckedChanged += new EventHandler(checkChecked);
                sub.getIMD().setCheckBox(IMDCheck);
            }else { IMDCheck = sub.getIMD().getCheckBox(); }

            

            flowLayoutPanel1.Controls.Add(areaLabel);
            flowLayoutPanel1.Controls.Add(areaTextBox);
            flowLayoutPanel1.Controls.Add(areaCheck);
            flowLayoutPanel1.SetFlowBreak(areaCheck, true);

            flowLayoutPanel1.Controls.Add(widthLabel);
            flowLayoutPanel1.Controls.Add(widthTextBox);
            flowLayoutPanel1.Controls.Add(widthCheck);
            flowLayoutPanel1.SetFlowBreak(widthCheck, true);

            flowLayoutPanel1.Controls.Add(percentSlopeLabel);
            flowLayoutPanel1.Controls.Add(percentSlopeTextBox);
            flowLayoutPanel1.Controls.Add(percentSlopeCheck);
            flowLayoutPanel1.SetFlowBreak(percentSlopeCheck, true);

            flowLayoutPanel1.Controls.Add(percentImpervLabel);
            flowLayoutPanel1.Controls.Add(percentImpervTextBox);
            flowLayoutPanel1.Controls.Add(percentImpervCheck);
            flowLayoutPanel1.SetFlowBreak(percentImpervCheck, true);

            
            flowLayoutPanel1.Controls.Add(NImpervLabel);
            flowLayoutPanel1.Controls.Add(NImpervTextBox);
            flowLayoutPanel1.Controls.Add(NImpervCheck);
            flowLayoutPanel1.SetFlowBreak(NImpervCheck, true);

            flowLayoutPanel1.Controls.Add(NPervLabel);
            flowLayoutPanel1.Controls.Add(NPervTextBox);
            flowLayoutPanel1.Controls.Add(NPervCheck);
            flowLayoutPanel1.SetFlowBreak(NPervCheck, true);
            
            flowLayoutPanel1.Controls.Add(SImpervLabel);
            flowLayoutPanel1.Controls.Add(SImpervTextBox);
            flowLayoutPanel1.Controls.Add(SImpervCheck);
            flowLayoutPanel1.SetFlowBreak(SImpervCheck, true);
            
            flowLayoutPanel1.Controls.Add(SPervLabel);
            flowLayoutPanel1.Controls.Add(SPervTextBox);
            flowLayoutPanel1.Controls.Add(SPervCheck);
            flowLayoutPanel1.SetFlowBreak(SPervCheck, true);
            
            flowLayoutPanel1.Controls.Add(percentZeroImpervLabel);
            flowLayoutPanel1.Controls.Add(percentZeroImpervTextBox);
            flowLayoutPanel1.Controls.Add(percentZeroImpervCheck);
            flowLayoutPanel1.SetFlowBreak(percentZeroImpervCheck, true);
            
            flowLayoutPanel1.Controls.Add(suctionLabel);
            flowLayoutPanel1.Controls.Add(suctionTextBox);
            flowLayoutPanel1.Controls.Add(suctionCheck);
            flowLayoutPanel1.SetFlowBreak(suctionCheck, true);

            flowLayoutPanel1.Controls.Add(ksatLabel);
            flowLayoutPanel1.Controls.Add(ksatTextBox);
            flowLayoutPanel1.Controls.Add(ksatCheck);
            flowLayoutPanel1.SetFlowBreak(ksatCheck, true);

            flowLayoutPanel1.Controls.Add(IMDLabel);
            flowLayoutPanel1.Controls.Add(IMDTextBox);
            flowLayoutPanel1.Controls.Add(IMDCheck);
            flowLayoutPanel1.SetFlowBreak(IMDCheck, true);
            

            
            if (areaCheck.Checked) { addMinMaxBox(sub.getArea()); }
            if (widthCheck.Checked) { addMinMaxBox(sub.getWidth()); }
            if (percentSlopeCheck.Checked) { addMinMaxBox(sub.getPercentSlope()); }
            if (percentImpervCheck.Checked) { addMinMaxBox(sub.getPercentImperv()); }
            if (NImpervCheck.Checked) { addMinMaxBox(sub.getNImperv()); }
            if (NPervCheck.Checked) { addMinMaxBox(sub.getNPerv()); }
            if (SImpervCheck.Checked) { addMinMaxBox(sub.getSImperv()); }
            if (SPervCheck.Checked) { addMinMaxBox(sub.getSPerv()); }
            if (suctionCheck.Checked) { addMinMaxBox(sub.getSuction()); }
            if (ksatCheck.Checked) { addMinMaxBox(sub.getKsat()); }
            if (IMDCheck.Checked) { addMinMaxBox(sub.getIMD()); }
            





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

                TreeNode[] nodeLID = new TreeNode[lids.Count];
                for (int x = 0; x < lids.Count; x++)
                {
                    nodeLID[x] = new TreeNode(lids[x].getName());
                }

                TreeNode[] nodeCurves = new TreeNode[curves.Count];
                for (int x = 0; x < curves.Count; x++)
                {
                    nodeCurves[x] = new TreeNode(curves[x].getName());
                }


                TreeNode subcatchment = new TreeNode("Subcatchments", nodeSubs);
                TreeNode LID = new TreeNode("LID Controls", nodeLID);
                TreeNode hydrology = new TreeNode("Hydrology", new TreeNode[] { subcatchment, LID });
                TreeNode curveNode = new TreeNode("Curves", nodeCurves);
                treeView1.Nodes.Add(hydrology);
                treeView1.Nodes.Add(curveNode);
            }
        }

        private void clearAll()
        {
            flowLayoutPanel1.Controls.Clear();
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
                clearAll();
                fileName = openFileDialog1.FileName;
                ReadInputFile rif = new ReadInputFile(fileName);
                subs = rif.GetSubcatchments();
                lids = rif.getLIDs();
                curves = rif.getCurves();
            }
            createComponentsTree();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Console.WriteLine(e.Node.Text); //what node has been clicked on.
            if (e.Node.Parent != null)
            {
                //Console.WriteLine(e.Node.Parent.Text); //Parent Node.
                if (e.Node.Parent.Text == "Subcatchments")
                {
                    Subcatchments currentsub = subs.Find(subs => subs.getName() == e.Node.Text);

                    createParameterEditSub(currentsub);
                }
                else if (e.Node.Parent.Text == "LID Controls")
                {
                    LID_Controls currentLID = lids.Find(lids => lids.getName() == e.Node.Text);

                    createParameterEditLID(currentLID);
                }
            }

        }

        private void checkChecked (object sender, EventArgs e)
        {
            //gets the current checked checkboxes
            currentChecked.Clear();
            for (int x = 0; x < parameters.Count; x++)
            {
                if (parameters[x].getCheckBox() != null && parameters[x].getCheckBox().Checked)
                {
                    currentChecked.Add(parameters[x]);
                }
                if (parameters[x].getCheckBox() == null)
                {
                    Console.WriteLine(x + ":" + parameters[x].getValue());
                }
            }

            if(currentChecked.Count > lastChecked.Count)
            {
                List<Parameter> justchecked = currentChecked.Except(lastChecked).ToList();
                
                addMinMaxBox(justchecked[0]);
            }
            else
            {
                List<Parameter> justUnChecked = lastChecked.Except(currentChecked).ToList();
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.GetChildIndex(justUnChecked[0].getCheckBox()) + 1);
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.GetChildIndex(justUnChecked[0].getCheckBox()) + 1);
            }
            
            lastChecked = new List<Parameter>(currentChecked);
            
            
        }

        private void addMinMaxBox(Parameter childPara)
        {
            Console.WriteLine(childPara.getValue());
            TextBox min = new TextBox();
            TextBox max = new TextBox();
            
            min.Text = "Min";
            max.Text = "Max";

            flowLayoutPanel1.Controls.Add(min);
            flowLayoutPanel1.Controls.Add(max);

           
            flowLayoutPanel1.Controls.SetChildIndex(min, flowLayoutPanel1.Controls.GetChildIndex(childPara.getCheckBox())+ 1);
            flowLayoutPanel1.Controls.SetChildIndex(max, flowLayoutPanel1.Controls.GetChildIndex(min)+ 1);
            flowLayoutPanel1.SetFlowBreak(max, true);
        }
    }
}

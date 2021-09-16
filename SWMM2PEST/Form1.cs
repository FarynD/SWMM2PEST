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
        List<CheckBox> cBoxes;
        string fileName;
        List<CheckBox> currentChecked;
        List<CheckBox> lastChecked;
        public Form1()
        {
            InitializeComponent();
            createComponentsTree();
            subs = new List<Subcatchments>();
            lids = new List<LID_Controls>();
            curves = new List<Curves>();
            cBoxes = new List<CheckBox>();
            currentChecked = new List<CheckBox>();
            lastChecked = new List<CheckBox>();



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

            storHtTxtBx.Text = Convert.ToString(lid.getSurface()[0]);
            vegFracTxtBx.Text = Convert.ToString(lid.getSurface()[1]);
            roughTxtBx.Text = Convert.ToString(lid.getSurface()[2]);
            slopeTxtBx.Text = Convert.ToString(lid.getSurface()[3]);
            xSlopeTxtBx.Text = Convert.ToString(lid.getSurface()[4]);

            CheckBox storHtCheck = new CheckBox();
            storHtCheck.Name = "StorHtCheck";
            cBoxes.Add(storHtCheck);
            storHtCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vegFracCheck = new CheckBox();
            vegFracCheck.Name = "VegFracCheck";
            cBoxes.Add(vegFracCheck);
            vegFracCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox roughCheck = new CheckBox();
            roughCheck.Name = "RoughCheck";
            cBoxes.Add(roughCheck);
            roughCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox slopeCheck = new CheckBox();
            slopeCheck.Name = "SlopeCheck";
            cBoxes.Add(slopeCheck);
            slopeCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox xSlopeCheck = new CheckBox();
            xSlopeCheck.Name = "XSlopeCheck";
            cBoxes.Add(xSlopeCheck);
            xSlopeCheck.CheckedChanged += new EventHandler(checkChecked);


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

            thickTxtBx.Text = Convert.ToString(lid.getSoil()[0]);
            porTxtBx.Text = Convert.ToString(lid.getSoil()[1]);
            fcTxtBx.Text = Convert.ToString(lid.getSoil()[2]);
            wpTxtBx.Text = Convert.ToString(lid.getSoil()[3]);
            ksatTxtBx.Text = Convert.ToString(lid.getSoil()[4]);
            kcoeffTxtBx.Text = Convert.ToString(lid.getSoil()[5]);
            suctTxtBx.Text = Convert.ToString(lid.getSoil()[6]);

            CheckBox thickCheck = new CheckBox();
            thickCheck.Name = "SoilThickCheck";
            cBoxes.Add(thickCheck);
            thickCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox porCheck = new CheckBox();
            porCheck.Name = "PorCheck";
            cBoxes.Add(porCheck);
            porCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox fcCheck = new CheckBox();
            fcCheck.Name = "FcCheck";
            cBoxes.Add(fcCheck);
            fcCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox wpCheck = new CheckBox();
            wpCheck.Name = "WpCheck";
            cBoxes.Add(wpCheck);
            wpCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox ksatCheck = new CheckBox();
            ksatCheck.Name = "KsatCheck";
            cBoxes.Add(ksatCheck);
            ksatCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox kcoeffCheck = new CheckBox();
            kcoeffCheck.Name = "KcoeffCheck";
            cBoxes.Add(kcoeffCheck);
            kcoeffCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox suctCheck = new CheckBox();
            suctCheck.Name = "SuctCheck";
            cBoxes.Add(suctCheck);
            suctCheck.CheckedChanged += new EventHandler(checkChecked);

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

            thickTxtBx.Text = Convert.ToString(lid.getPavement()[0]);
            vRatioTxtBx.Text = Convert.ToString(lid.getPavement()[1]);
            fracImpTxtBx.Text = Convert.ToString(lid.getPavement()[2]);
            permTxtBx.Text = Convert.ToString(lid.getPavement()[3]);
            vclogTxtBx.Text = Convert.ToString(lid.getPavement()[4]);

            CheckBox thickCheck = new CheckBox();
            thickCheck.Name = "PavementThickCheck";
            cBoxes.Add(thickCheck);
            thickCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vRatioCheck = new CheckBox();
            thickCheck.Name = "VRatioCheck";
            cBoxes.Add(vRatioCheck);
            vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox fracImpCheck = new CheckBox();
            fracImpCheck.Name = "FracImpCheck";
            cBoxes.Add(fracImpCheck);
            fracImpCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox permCheck = new CheckBox();
            permCheck.Name = "PermCheck";
            cBoxes.Add(permCheck);
            permCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vclogCheck = new CheckBox();
            vclogCheck.Name = "VclogCheck";
            cBoxes.Add(vclogCheck);
            vclogCheck.CheckedChanged += new EventHandler(checkChecked);

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

            heightTxtBx.Text = Convert.ToString(lid.getStorage()[0]);
            vRatioTxtBx.Text = Convert.ToString(lid.getStorage()[1]);
            seepageTxtBx.Text = Convert.ToString(lid.getStorage()[2]);
            vclogTxtBx.Text = Convert.ToString(lid.getStorage()[3]);

            CheckBox heightCheck = new CheckBox();
            heightCheck.Name = "heightCheck";
            cBoxes.Add(heightCheck);
            heightCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vRatioCheck = new CheckBox();
            vRatioCheck.Name = "VRatioCheck";
            cBoxes.Add(vRatioCheck);
            vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox seepageCheck = new CheckBox();
            seepageCheck.Name = "SeepageCheck";
            cBoxes.Add(seepageCheck);
            seepageCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vclogCheck = new CheckBox();
            vclogCheck.Name = "vclogCheck";
            cBoxes.Add(vclogCheck);
            vclogCheck.CheckedChanged += new EventHandler(checkChecked);

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

            coeffTxtBx.Text = Convert.ToString(lid.getDrain()[0]);
            exponTxtBx.Text = Convert.ToString(lid.getDrain()[1]);
            offsetTxtBx.Text = Convert.ToString(lid.getDrain()[2]);

            CheckBox coeffCheck = new CheckBox();
            coeffCheck.Name = "CoeffCheck";
            cBoxes.Add(coeffCheck);
            coeffCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox exponCheck = new CheckBox();
            exponCheck.Name = "ExponCheck";
            cBoxes.Add(exponCheck);
            exponCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox offsetCheck = new CheckBox();
            offsetCheck.Name = "OffsetCheck";
            cBoxes.Add(offsetCheck);
            offsetCheck.CheckedChanged += new EventHandler(checkChecked);

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
                openTxt.Text = Convert.ToString(lid.getDrain()[3]);
                closedTxt.Text = Convert.ToString(lid.getDrain()[4]);

                CheckBox openCheck = new CheckBox();
                openCheck.Name = "OpenCheck";
                cBoxes.Add(openCheck);
                openCheck.CheckedChanged += new EventHandler(checkChecked);
                CheckBox closeCheck = new CheckBox();
                closeCheck.Name = "CloseCheck";
                cBoxes.Add(closeCheck);
                closeCheck.CheckedChanged += new EventHandler(checkChecked);

                flowLayoutPanel1.Controls.Add(openLbl);
                flowLayoutPanel1.Controls.Add(openTxt);
                flowLayoutPanel1.Controls.Add(openCheck);
                flowLayoutPanel1.SetFlowBreak(openCheck, true);

                flowLayoutPanel1.Controls.Add(closedLbl);
                flowLayoutPanel1.Controls.Add(closedTxt);
                flowLayoutPanel1.Controls.Add(closeCheck);
                flowLayoutPanel1.SetFlowBreak(closeCheck, true);
            }
            else
            {
                Label delayLbl = new Label();
                delayLbl.Text = "delay";
                tooltip1.SetToolTip(delayLbl, "number of dry weather hours that must elapse before the drain line in a rain barrel is opened(the line is assumed to be closed once rainfall begins).A value of 0 signifies that the barrel's drain line is always open and drains continuously.This parameter is ignored for other types of LIDs.");
                TextBox delayTxtBx = new TextBox();
                delayTxtBx.Enabled = false;
                delayTxtBx.Text = Convert.ToString(lid.getDrain()[3]);

                CheckBox delayCheck = new CheckBox();
                delayCheck.Name = "DelayCheck";
                cBoxes.Add(delayCheck);
                delayCheck.CheckedChanged += new EventHandler(checkChecked);

                flowLayoutPanel1.Controls.Add(delayLbl);
                flowLayoutPanel1.Controls.Add(delayTxtBx);
                flowLayoutPanel1.Controls.Add(delayCheck);
                flowLayoutPanel1.SetFlowBreak(delayCheck, true);

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

            thickTxtBx.Text = Convert.ToString(lid.getDrainmat()[0]);
            vRatioTxtBx.Text = Convert.ToString(lid.getDrainmat()[1]);
            roughTxtBx.Text = Convert.ToString(lid.getDrainmat()[2]);

            CheckBox thickCheck = new CheckBox();
            thickCheck.Name = "DrainmatThickCheck";
            cBoxes.Add(thickCheck);
            thickCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox vRatioCheck = new CheckBox();
            vRatioCheck.Name = "DrainmatVRatioCheck";
            cBoxes.Add(vRatioCheck);
            vRatioCheck.CheckedChanged += new EventHandler(checkChecked);
            CheckBox roughCheck = new CheckBox();
            roughCheck.Name = "DrainmatRoughCheck";
            cBoxes.Add(roughCheck);
            roughCheck.CheckedChanged += new EventHandler(checkChecked);




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

            CheckBox areaCheck = new CheckBox();
            areaCheck.Name = "SubAreaCheck";
            cBoxes.Add(areaCheck);
            CheckBox widthCheck = new CheckBox();
            widthCheck.Name = "SubWidthCheck";
            cBoxes.Add(widthCheck);


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
            flowLayoutPanel1.SetFlowBreak(percentSlopeTextBox, true);

            flowLayoutPanel1.Controls.Add(percentImpervLabel);
            flowLayoutPanel1.Controls.Add(percentImpervTextBox);
            flowLayoutPanel1.SetFlowBreak(percentImpervTextBox, true);

            flowLayoutPanel1.Controls.Add(NImpervLabel);
            flowLayoutPanel1.Controls.Add(NImpervTextBox);
            flowLayoutPanel1.SetFlowBreak(NImpervTextBox, true);

            flowLayoutPanel1.Controls.Add(NPervLabel);
            flowLayoutPanel1.Controls.Add(NPervTextBox);
            flowLayoutPanel1.SetFlowBreak(NPervTextBox, true);

            flowLayoutPanel1.Controls.Add(SImpervLabel);
            flowLayoutPanel1.Controls.Add(SImpervTextBox);
            flowLayoutPanel1.SetFlowBreak(SImpervTextBox, true);

            flowLayoutPanel1.Controls.Add(SPervLabel);
            flowLayoutPanel1.Controls.Add(SPervTextBox);
            flowLayoutPanel1.SetFlowBreak(SPervTextBox, true);

            flowLayoutPanel1.Controls.Add(PercentZeroImpervLabel);
            flowLayoutPanel1.Controls.Add(PercentZeroImpervTextBox);
            flowLayoutPanel1.SetFlowBreak(PercentZeroImpervTextBox, true);

            flowLayoutPanel1.Controls.Add(suctionLabel);
            flowLayoutPanel1.Controls.Add(suctionTextBox);
            flowLayoutPanel1.SetFlowBreak(suctionTextBox, true);

            flowLayoutPanel1.Controls.Add(ksatLabel);
            flowLayoutPanel1.Controls.Add(ksatTextBox);
            flowLayoutPanel1.SetFlowBreak(ksatTextBox, true);

            flowLayoutPanel1.Controls.Add(IMDLabel);
            flowLayoutPanel1.Controls.Add(IMDTextBox);
            flowLayoutPanel1.SetFlowBreak(IMDTextBox, true);


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
            Console.WriteLine("check");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SWMM2PEST
{
    class Subcatchments
    {
        //Subcatchments
        string name;
        double area;
        double width;
        int percentSlope;
        //Subareas
        double percentImperv;
        double NImperv; //Impervious area roughness
        double NPerv; //Pervious area roughness
        double SImperv; //Impervious area depression storage
        double SPerv; //Pervious Area Depression Storage
        double percentZeroImperv; //% of impervious area with no depression storage
        //Infiltration
        double suction;
        double ksat; //Hydraulic Conductivity
        int IMD; //Initial moisture deficiet
        //LIDS
        ArrayList LIDs;
        public Subcatchments(string aName, double aArea, double aWidth, int aPercentSlope, double aPercentImperv, double aNImperv, double aNPerv, double aSImperv, double aSPerv, double aPercentZeroImperv, double aSuction, double aKsat, int aIMD)
        {
            name = aName;
            area = aArea;
            width = aWidth;
            percentSlope = aPercentSlope;
            percentImperv = aPercentImperv;
            NImperv = aNImperv;
            SImperv = aSImperv;
            SPerv = aSPerv;
            percentZeroImperv = aPercentZeroImperv;
            suction = aSuction;
            ksat = aKsat;
            IMD = aIMD;
            LIDs = new ArrayList();
        }

        public string Name { get => name; }
        public double Area { get => area; }
        public double Width { get => width; }
        public int PercentSlope { get => percentSlope; }
        public double PercentImperv { get => percentImperv; }
        public double NImperv1 { get => NImperv; }
        public double NPerv1 { get => NPerv; }
        public double SImperv1 { get => SImperv; }
        public double SPerv1 { get => SPerv; }
        public double PercentZeroImperv { get => percentZeroImperv; }
        public double Suction { get => suction; }
        public double Ksat { get => ksat; }
        public int IMD1 { get => IMD; }
        public ArrayList LIDs1 { get => LIDs; }

        public void addLID(LID_Controls LID)
        {
            LIDs.Add(LID);
        }

        




    }
}

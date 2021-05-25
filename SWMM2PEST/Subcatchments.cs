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
        double percentSlope;
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
        public Subcatchments(string aName, double aArea, double aWidth, double aPercentSlope, double aPercentImperv, double aNImperv, double aNPerv, double aSImperv, double aSPerv, double aPercentZeroImperv, double aSuction, double aKsat, int aIMD)
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

        public Subcatchments()
        {

        }


        public string getName() { return name; }
        public double getArea() { return area; }
        public double getWidth() { return width; }
        public double getPercentSlope() { return percentSlope; }
        public double getPercentImperv() { return percentImperv; }
        public double getNImperv() { return NImperv; }
        public double getNPerv() { return NPerv; }
        public double getSImperv() { return SImperv; }
        public double getSPerv() { return SPerv; }
        public double getPercentZeroImperv() { return percentZeroImperv; }
        public double getSuction() { return suction; }
        public double getKsat() { return ksat; }
        public double getIMD() { return IMD; }
        public ArrayList getLIDs() { return LIDs; }

        public void setName(string aName) { name = aName; }
        public void setArea(double aArea) { aArea = area; }
        public void setWidth(double aWidth) { width = aWidth; }
        public void setPercentSlope(double aPercentSlope) { percentSlope= aPercentSlope; }
        public void setPercentImperv(double aPercentImperv) { percentImperv = aPercentImperv; }
        public void setNImperv(double aNImperv) { NImperv = aNImperv; }
        public void setNPerv(double aNPerv) { NPerv = aNPerv; }
        public void setSImperv(double aSImperv) { SImperv = aSImperv; }
        public void setSPerv(double aSPerv) {  SPerv = aSPerv; }
        public void setPercentZeroImperv(double aPercentZeroImperv) {  percentZeroImperv = aPercentZeroImperv; }
        public void setSuction(double aSuction) {  suction = aSuction; }
        public void setKsat(double aKsat) {  ksat = aKsat; }
        public void setIMD(int aIMD) { IMD = aIMD; }
       
        public void addLID(LID_Controls LID)
        {
            LIDs.Add(LID);
        }

        




    }
}

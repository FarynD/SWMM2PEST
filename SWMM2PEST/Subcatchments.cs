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
        Parameter area;
        Parameter width;
        Parameter percentSlope;
        //Subareas
        Parameter percentImperv;
        Parameter NImperv; //Impervious area roughness
        Parameter NPerv; //Pervious area roughness
        Parameter SImperv; //Impervious area depression storage
        Parameter SPerv; //Pervious Area Depression Storage
        Parameter percentZeroImperv; //% of impervious area with no depression storage
        //Infiltration
        Parameter suction;
        Parameter ksat; //Hydraulic Conductivity
        Parameter IMD; //Initial moisture deficiet
        //LIDS
        ArrayList LIDs;

        


        
        public string getName() { return name; }
        public Parameter getArea() { return area; }
        public Parameter getWidth() { return width; }
        public Parameter getPercentSlope() { return percentSlope; }
        public Parameter getPercentImperv() { return percentImperv; }
        public Parameter getNImperv() { return NImperv; }
        public Parameter getNPerv() { return NPerv; }
        public Parameter getSImperv() { return SImperv; }
        public Parameter getSPerv() { return SPerv; }
        public Parameter getPercentZeroImperv() { return percentZeroImperv; }
        public Parameter getSuction() { return suction; }
        public Parameter getKsat() { return ksat; }
        public Parameter getIMD() { return IMD; }
        public ArrayList getLIDs() { return LIDs; }

        public void setName(string aName) { name = aName; }
        public void setArea(Parameter aArea) { area = aArea; }
        public void setWidth(Parameter aWidth) { width = aWidth; }
        public void setPercentSlope(Parameter aPercentSlope) { percentSlope= aPercentSlope; }
        public void setPercentImperv(Parameter aPercentImperv) { percentImperv = aPercentImperv; }
        public void setNImperv(Parameter aNImperv) { NImperv = aNImperv; }
        public void setNPerv(Parameter aNPerv) { NPerv = aNPerv; }
        public void setSImperv(Parameter aSImperv) { SImperv = aSImperv; }
        public void setSPerv(Parameter aSPerv) {  SPerv = aSPerv; }
        public void setPercentZeroImperv(Parameter aPercentZeroImperv) {  percentZeroImperv = aPercentZeroImperv; }
        public void setSuction(Parameter aSuction) {  suction = aSuction; }
        public void setKsat(Parameter aKsat) {  ksat = aKsat; }
        public void setIMD(Parameter aIMD) { IMD = aIMD; }
       
        public void addLID(LID_Controls LID)
        {
            LIDs.Add(LID);
        }

        




    }
}

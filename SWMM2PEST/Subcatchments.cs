using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        
        


        public Subcatchments()
        {

        }
    }
}

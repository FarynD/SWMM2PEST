using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWMM2PEST
{
    class LID_Controls
    {
        // parameters from page 291 of "Storm Water Management Model User's Manual Version 5"
        double[] surface; //Arr holding all surface parameters: [StorHt, VegFrac, Rough, Slope, Xslope] 
        double[] soil; //Arr holding all soil parameters: [Thick, Vration,FracImp,Perm, Vclog]
        double[] pavement; //arr holding all pavement parameters: [Thick, Vration, FracImp, Perm, Vclog]
        double[] storage; //Arr holding all storage parameters: [Height, Vratio, Seepage, Vclog]
        double[] drain; //Arr holding all Drain parameters: [Coeff, Expon, offset, Delay]
        double[] drainmat; //Arr holding all drainmat parameters: [Thick, Vratio, Rough]
        //LID usage
        double[] LIDUsage; //Arr holding all LID Usage parameters: [number, area, width, 
        int number;
        double area;
        double width;
        double initSatur;// Percent initially saturated
        double toPerv; //Send Outflow Pervious Area

        public LID_Controls()
        {
            double nullNum = -1; //if the input file does not have info on
            surface = new double[] { nullNum, nullNum, nullNum, nullNum, nullNum};
            soil = new double[] { nullNum, nullNum, nullNum, nullNum, nullNum};
            pavement = new double[] { nullNum, nullNum, nullNum, nullNum, nullNum };
            storage = new double[] { nullNum, nullNum, nullNum, nullNum};
            drain = new double[] { nullNum, nullNum, nullNum, nullNum};
            drainmat = new double[] { nullNum, nullNum, nullNum};
        }

        public double[] getSurface()
        {
            return surface;
        }
        public double[] getSoil()
        {
            return soil;
        }

        public double[] getPavement()
        {
            return pavement;
        }

        public double[] getStorage()
        {
            return storage;
        }

        public double[] getDrain()
        {
            return drain;
        }

        public double[] getDrainmat()
        {
            return drainmat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SWMM2PEST
{
    class LID_Controls
    {
        string name;
        //Parameters from page 291 of "Storm Water Management Model User's Manual Version 5"
        double[] surface; //Arr holding all surface parameters: [StorHt, VegFrac, Rough, Slope, Xslope] 
        double[] soil; //Arr holding all soil parameters: [Thick, Por, FC, WP, ksat, kcoeff, suct ]
        double[] pavement; //arr holding all pavement parameters: [Thick, Vratio, FracImp, Perm, Vclog]
        double[] storage; //Arr holding all storage parameters: [Height, Vratio, Seepage, Vclog]
        double[] drain; //Arr holding all Drain parameters: [Coeff, Expon, offset, Delay]
        //For drain older files have coeff, expon, offset,delay
        double[] drainmat; //Arr holding all drainmat parameters: [Thick, Vratio, Rough]
        //LID usage. Parameters taken from Swmm input files.
        double[] LIDUsage; //Arr holding all LID Usage parameters : [subcatchmentName, number, area, width, initSat, toPerv]
        string type;
        /* types:
         * BC = BioRetention
         * RG = Rain Garden
         * GR = GreenRoof
         * IT = InfiltrationTrench
         * PP = Permeable Pavement
         * RB = Rain Barrel
         * RD = Rooftop Disconnection
         * VS = Vegetative Swale
         */

        public string getName() { return name; }
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

        public double[] getLIDUsage()
        {
            return LIDUsage;
        }

        public string getType() { return type; }

        public bool haveLIDUsage()
        { 
            if( LIDUsage == null) { return false; }
            return true;
        }

        public void setName(string aName) { name = aName; }

        public void setSurface(double[] aSurface) { surface = aSurface; }

        public void  setSoil(double[] aSoil) { soil = aSoil; }

        public void setPavement(double[] aPavement) { pavement = aPavement; }

        public void setStorage(double[] aStorage) { storage = aStorage; }

        public void setDrain(double[] aDrain) { drain = aDrain; }

        public void setDrainmat(double[] aDrainmat) { drainmat = aDrainmat; }

        public void setLIDUsage(double[] aLIDUsage) { LIDUsage = aLIDUsage; }

        public void setType(string aType) { type = aType; }
    }

    

}

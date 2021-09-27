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
        Parameter[] surface; //Arr holding all surface parameters: [StorHt, VegFrac, Rough, Slope, Xslope] 
        Parameter[] soil; //Arr holding all soil parameters: [Thick, Por, FC, WP, ksat, kcoeff, suct ]
        Parameter[] pavement; //arr holding all pavement parameters: [Thick, Vratio, FracImp, Perm, Vclog]
        Parameter[] storage; //Arr holding all storage parameters: [Height, Vratio, Seepage, Vclog]
        Parameter[] drain; //Arr holding all Drain parameters: [Coeff, Expon, offset, Delay, open level (newer version of swmm only), closed level (newer version of swmm only)]
        //For drain older files have coeff, expon, offset,delay
        Parameter[] drainmat; //Arr holding all drainmat parameters: [Thick, Vratio, Rough]
        //LID usage. Parameters taken from Swmm input files.
        Parameter[] LIDUsage; //Arr holding all LID Usage parameters: [number, area, width, initSat, toPerv]
        string curve;
        string type;
        List<string> checkedParas;

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
        public Parameter[] getSurface()
        {
            return surface;
        }
        public Parameter[] getSoil()
        {
            return soil;
        }

        public Parameter[] getPavement()
        {
            return pavement;
        }

        public Parameter[] getStorage()
        {
            return storage;
        }

        public Parameter[] getDrain()
        {
            return drain;
        }

        public Parameter[] getDrainmat()
        {
            return drainmat;
        }

        public Parameter[] getLIDUsage()
        {
            return LIDUsage;
        }

        public string getCurveName() { return curve; }

        public string getType() { return type; }

        public bool haveLIDUsage()
        {
            if (LIDUsage == null) { return false; }
            return true;
        }

        public void setName(string aName) { name = aName; }

        public void setSurface(Parameter[] aSurface) { surface = aSurface; }

        public void setSoil(Parameter[] aSoil) { soil = aSoil; }

        public void setPavement(Parameter[] aPavement) { pavement = aPavement; }

        public void setStorage(Parameter[] aStorage) { storage = aStorage; }

        public void setDrain(Parameter[] aDrain) { drain = aDrain; }

        public void setDrainmat(Parameter[] aDrainmat) { drainmat = aDrainmat; }

        public void setLIDUsage(Parameter[] aLIDUsage) { LIDUsage = aLIDUsage; }

        public void setCurveName(string aCurve) { curve = aCurve; }
        public void setType(string aType) { type = aType; }

        public bool addCheckedParameter(string aParaName)
        {
            if (checkedParas.Contains(aParaName)) { return false; }
            checkedParas.Add(aParaName);
            return true;
        }
    }

    

}

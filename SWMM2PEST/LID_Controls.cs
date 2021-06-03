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
        double[] soil; //Arr holding all soil parameters: [Thick, Vration,FracImp,Perm, Vclog]
        double[] pavement; //arr holding all pavement parameters: [Thick, Vration, FracImp, Perm, Vclog]
        double[] storage; //Arr holding all storage parameters: [Height, Vratio, Seepage, Vclog]
        double[] drain; //Arr holding all Drain parameters: [Coeff, Expon, offset, Delay]
        double[] drainmat; //Arr holding all drainmat parameters: [Thick, Vratio, Rough]
        //LID usage. Parameters taken from Swmm input files.
        double[] LIDUsage; //Arr holding all LID Usage parameters: [number, area, width, initSat, toPerv]
        string type;

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

    /*
    class BioRetention : LID_Controls
    {
        public BioRetention(double[] aSurface, double[] aSoil, double[] aStorage, double[] aDrain)
        {
            surface = aSurface;
            soil = aSoil;
            storage = aStorage;
            drain = aDrain;
        }
        public BioRetention(double[] aLIDUsage,double[] aSurface, double[] aSoil, double[] aStorage, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            soil = aSoil;
            storage = aStorage;
            drain = aDrain;
        }
    }

    class RainGarden : LID_Controls
    {
        public RainGarden(double[] aSurface, double[] aSoil, double[] aStorage)
        {
            surface = aSurface;
            soil = aSoil;
            storage = aStorage;
        }
        public RainGarden(double[] aLIDUsage, double[] aSurface, double[] aSoil, double[] aStorage)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            soil = aSoil;
            storage = aStorage;
        }
    }

    class GreenRoof : LID_Controls
    {
        public GreenRoof(double[] aSurface, double[] aSoil, double[] aDrainmat)
        {
            surface = aSurface;
            soil = aSoil;
            drainmat = aDrainmat;
        }
        public GreenRoof(double[] aLIDUsage, double[] aSurface, double[] aSoil, double[] aDrainMat)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            soil = aSoil;
            drainmat = aDrainMat;
        }
    }

    class InfiltrationTrench : LID_Controls
    {
        public InfiltrationTrench(double[] aSurface, double[] aStorage, double[] aDrain)
        {
            surface = aSurface;
            storage = aStorage;
            drain = aDrain;
        }
        public InfiltrationTrench(double[] aLIDUsage, double[] aSurface, double[] aStorage, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            storage = aStorage;
            drain = aDrain;
        }
    }

    class PermeablePavement : LID_Controls
    {
        public PermeablePavement(double[] aSurface, double[] aPavement, double[] aSoil, double[] aStorage, double[] aDrain)
        {
            surface = aSurface;
            pavement = aPavement;
            soil = aSoil;
            storage = aStorage;
            drain = aDrain;
        }
        public PermeablePavement(double[] aLIDUsage, double[] aPavement, double[] aSurface, double[] aSoil, double[] aStorage, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            pavement = aPavement;
            soil = aSoil;
            storage = aStorage;
            drain = aDrain;
        }
    }

    class RainBarrel : LID_Controls
    {
        public RainBarrel(double[] aStorage, double[] aDrain)
        {
            storage = aStorage;
            drain = aDrain;
        }
        public RainBarrel(double[] aLIDUsage, double[] aStorage, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            storage = aStorage;
            drain = aDrain;
        }
    }

    class RooftopDisconnection : LID_Controls
    {
        public RooftopDisconnection(double[] aSurface, double[] aDrain)
        {
            surface = aSurface;
            drain = aDrain;
        }
        public RooftopDisconnection(double[] aLIDUsage, double[] aSurface, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            drain = aDrain;
        }
    }

    class VegetativeSwale : LID_Controls
    {
        public VegetativeSwale(double[] aSurface, double[] aDrain)
        {
            surface = aSurface;
            drain = aDrain;
        }
        public VegetativeSwale(double[] aLIDUsage, double[] aSurface, double[] aDrain)
        {
            LIDUsage = aLIDUsage;
            surface = aSurface;
            drain = aDrain;
        }
    }

    */

}

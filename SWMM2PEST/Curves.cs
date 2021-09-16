using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWMM2PEST
{
    class Curves
    {
        string name;
        string type;
        List<int> x;
        List<int> y;

        public Curves()
        {
            x = new List<int>();
            y = new List<int>();
        }
        public string getName() { return name; } 
        public string getType() { return type; }
        public int[] getX() { return x.ToArray(); }
        public int[] getY() { return y.ToArray(); }
        public void setName(string aName) { name = aName; }
        public void setType(string aType) { type = aType; }

        public void addX (int aX) { x.Add(aX); }
        public void addY (int aY) { y.Add(aY); }

    }
}

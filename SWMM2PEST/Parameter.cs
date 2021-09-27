using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWMM2PEST
{
    class Parameter
    {
        double value;
        bool isChecked;
        double min;
        double max;
        public Parameter(double aValue)
        {
            value = aValue;
        }

        public void setCheck(bool aIsCheck){ isChecked = aIsCheck; }

        public void setMin(double aMin) { min = aMin; }

        public void setMax (double aMax) { max = aMax; }

        public double getValue() { return value; }

        public bool getCheck() { return isChecked; }

        public double getMin() { return min; }

        public double getMax() { return max; }
    }
}

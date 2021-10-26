using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWMM2PEST
{
    class Parameter
    {
        string name;
        double value;
        double min;
        double max;
        CheckBox paraCheck;
        
        public Parameter(double aValue, string aName)
        {
            value = aValue;
            name = aName;
        }

        public void setCheckBox(CheckBox aCheckbox){ paraCheck = aCheckbox; }

        public void setMin(double aMin) { min = aMin; }

        public void setMax (double aMax) { max = aMax; }

        public double getValue() { return value; }

        public CheckBox getCheckBox() { return paraCheck; }

        public double getMin() { return min; }

        public double getMax() { return max; }
    }
}

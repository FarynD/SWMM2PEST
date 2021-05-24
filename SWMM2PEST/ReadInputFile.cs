using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWMM2PEST
{
    class ReadInputFile
    {
        string fileLocation;
        ArrayList subcatchments;
        ArrayList LIDs;
        public ReadInputFile(string aFileLocation)
        {
            fileLocation = aFileLocation;
            subcatchments = new ArrayList();
            LIDs = new ArrayList();
        }

        private void readFile()
        {
            string[] lines = File.ReadAllLines(fileLocation);

            int num = 0;

            while (!lines[num].Contains("[SUBCATCHMENTS]") && num < lines.Length) { num++; }

            if (num < lines.Length)
            {
                string subName = lines[num + 3].Split(' ')[0];
            }


        }


    }
}

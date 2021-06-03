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
        List<Subcatchments> subcatchments;
        List <LID_Controls>LIDs;
        public ReadInputFile(string aFileLocation)
        {
            fileLocation = aFileLocation;
            subcatchments = new List<Subcatchments>();
            LIDs = new List<LID_Controls>();
            readFile();
        }

        public List<Subcatchments> GetSubcatchments() { return subcatchments; }

        private void readFile()
        {

            StreamReader sr = new StreamReader(fileLocation);


            string line = sr.ReadLine();
            string[] splitLine;
            int num = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "[SUBCATCHMENTS]")
                {
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine(); //skip down two lines
                    
                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');
                        subcatchments.Add(new Subcatchments());
                        subcatchments[num].setName(splitLine[0]);
                        subcatchments[num].setArea(Convert.ToDouble(splitLine[3]));
                        subcatchments[num].setPercentImperv(Convert.ToDouble(splitLine[4]));
                        subcatchments[num].setWidth(Convert.ToDouble(splitLine[5]));
                        subcatchments[num].setPercentSlope(Convert.ToDouble(splitLine[6]));
                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[SUBAREAS]")
                {                   
                    line = sr.ReadLine();                    
                    line = sr.ReadLine();                    
                    line = sr.ReadLine(); //skip down two lines
                    num = 0;  

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');

                        Console.WriteLine(splitLine[0]);
                        
                        subcatchments[num].setNImperv(Convert.ToDouble(splitLine[1]));
                        subcatchments[num].setNPerv(Convert.ToDouble(splitLine[2]));
                        subcatchments[num].setSImperv(Convert.ToDouble(splitLine[3]));
                        subcatchments[num].setSPerv(Convert.ToDouble(splitLine[4]));
                        subcatchments[num].setPercentZeroImperv(Convert.ToDouble(splitLine[5]));
                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[INFILTRATION]")
                {
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine(); //skip down two lines
                    num = 0;

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');

                        
                        subcatchments[num].setSuction(Convert.ToDouble(splitLine[1]));
                        subcatchments[num].setKsat(Convert.ToDouble(splitLine[2]));
                        subcatchments[num].setIMD(Convert.ToInt32(splitLine[3]));
                        
                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[LID_CONTROLS]")
                {
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                    line = sr.ReadLine(); //skip down two lines
                    num = 0;

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');
                        if (splitLine.Length == 2)
                        {
                            LIDs[num].setName(splitLine[0]);
                            LIDs[num].setType(splitLine[1]);
                        }
                        else if (splitLine[1] == "BC") //BioRetention
                        {

                        }
                        else if (splitLine[1] == "RG") //Rain Garden
                        { 
                        
                        }
                        else if (splitLine[1] == "GR") //GreenRoof
                        {

                        }
                        else if (splitLine[1] == "IT") //InfiltrationTrench
                        {

                        }
                        else if (splitLine[1] == "PP") //Permeable Pavement
                        {

                        }
                        else if (splitLine[1] == "RB") //Rain Barrel
                        {

                        }
                        else if (splitLine[1] == "RD") //Rooftop Disconnection
                        {

                        }
                        else if (splitLine[1] == "VS") //Vegetative Swale
                        {

                        }


                        line = sr.ReadLine();
                        num++;
                    }
                }
            }

        }

        public string[] splitString(string s, char delim)
        {
            char currentChar = s[0];

            int num = 0;
            while (num < s.Length)
            {
                while (num + 1 < s.Length && s[num] == delim && s[num + 1] == delim)
                {
                    s = s.Remove(num, 1);
                }
                num++;
            }
            return s.Split(delim);
        }


    }
}

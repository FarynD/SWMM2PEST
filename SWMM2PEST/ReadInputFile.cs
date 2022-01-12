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
        List<LID_Controls> LIDs;
        List<Curves> curves;
        public ReadInputFile(string aFileLocation)
        {
            fileLocation = aFileLocation;
            subcatchments = new List<Subcatchments>();
            LIDs = new List<LID_Controls>();
            curves = new List<Curves>();
            readFile();
        }
        /// <summary>
        /// returns list of subcatchments
        /// </summary>
        /// <returns>subcatchments</returns>
        public List<Subcatchments> GetSubcatchments() { return subcatchments; }

        public List<LID_Controls> getLIDs() { return LIDs; }

        public List<Curves> getCurves() { return curves; }

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
                    while (line.Contains(";;"))
                    {
                        line = sr.ReadLine();
                    }

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');
                        subcatchments.Add(new Subcatchments());
                        subcatchments[num].setName(splitLine[0]);
                        subcatchments[num].setArea(new Parameter( Convert.ToDouble(splitLine[3])));
                        subcatchments[num].setPercentImperv(new Parameter(Convert.ToDouble(splitLine[4])));
                        subcatchments[num].setWidth(new Parameter(Convert.ToDouble(splitLine[5])));
                        subcatchments[num].setPercentSlope(new Parameter(Convert.ToDouble(splitLine[6])));
                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[SUBAREAS]")
                {
                    line = sr.ReadLine();
                    while (line.Contains(";;"))
                    {
                        line = sr.ReadLine();
                    }
                    num = 0;

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');

                        

                        subcatchments[num].setNImperv(new Parameter(Convert.ToDouble(splitLine[1])));
                        subcatchments[num].setNPerv(new Parameter(Convert.ToDouble(splitLine[2])));
                        subcatchments[num].setSImperv(new Parameter(Convert.ToDouble(splitLine[3])));
                        subcatchments[num].setSPerv(new Parameter(Convert.ToDouble(splitLine[4])));
                        subcatchments[num].setPercentZeroImperv(new Parameter(Convert.ToDouble(splitLine[5])));
                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[INFILTRATION]")
                {
                    line = sr.ReadLine();
                    while (line.Contains(";;"))
                    {
                        line = sr.ReadLine();
                    }
                    num = 0;

                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');


                        subcatchments[num].setSuction(new Parameter(Convert.ToDouble(splitLine[1])));
                        subcatchments[num].setKsat(new Parameter(Convert.ToDouble(splitLine[2])));
                        subcatchments[num].setIMD(new Parameter(Convert.ToDouble(splitLine[3])));

                        line = sr.ReadLine();
                        num++;
                    }
                }
                if (line == "[LID_CONTROLS]")
                {

                    line = sr.ReadLine();
                    while (line.Contains(";;"))
                    {
                        line = sr.ReadLine();
                    }

                    num = 0;

                    while (splitString(line, ' ').Length != 1)
                    {

                        splitLine = splitString(line, ' ');
                        if (splitLine.Length != 0)
                        {
                            if (splitLine.Length == 2) //name
                            {
                               
                                LIDs.Add(new LID_Controls());
                                LIDs[num].setName(splitLine[0]);
                                LIDs[num].setType(splitLine[1]);
                            }
                            if (splitLine[1] == "BC") //BioRetention
                            {

                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSoil(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setStorage(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrain(createParaArr(splitString(line, ' ')));
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setCurveName(drainCurve(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "RG") //Rain Garden
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSoil(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setStorage(createParaArr(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "GR") //GreenRoof
                            {

                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSoil(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrainmat(createParaArr(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "IT") //InfiltrationTrench
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setStorage(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrain(createParaArr(splitString(line, ' ')));
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setCurveName(drainCurve(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "PP") //Permeable Pavement
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setPavement(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSoil(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setStorage(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrain(createParaArr(splitString(line, ' ')));
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setCurveName(drainCurve(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "RB") //Rain Barrel
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setStorage(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrain(createParaArr(splitString(line, ' ')));
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setCurveName(drainCurve(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "RD") //Rooftop Disconnection
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setDrain(createParaArr(splitString(line, ' ')));
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setCurveName(drainCurve(splitString(line, ' ')));
                            }
                            else if (splitLine[1] == "VS") //Vegetative Swale
                            {
                                line = sr.ReadLine();
                                if (line.Contains(";;")) { line = sr.ReadLine(); }
                                LIDs[num].setSurface(createParaArr(splitString(line, ' ')));
                            }
                            num++;
                        }
                        line = sr.ReadLine();

                    }
                }
                if (line == "[CURVES]")
                {
                    line = sr.ReadLine();
                    while (line.Contains(";;"))
                    {
                        line = sr.ReadLine();
                    }

                    num = 0;
                    while (line != " " && line != "")
                    {
                        splitLine = splitString(line, ' ');
                        if (splitLine.Length <= 4) // name type x y
                        {
                            
                            if (splitLine.Length == 4)
                            {
                                
                                Curves c = new Curves();
                                curves.Add(c);
                                
                                curves[num].setName(splitLine[0]);
                                Console.WriteLine("name: " + curves[num].getName());
                                curves[num].setType(splitLine[1]);
                                Console.WriteLine("type:" + curves[num].getType());
                                curves[num].addX(Convert.ToInt32(splitLine[2]));
                                curves[num].addY(Convert.ToInt32(splitLine[3]));
                                num++;
                            }
                            else
                            {
                                curves[num-1].addX(Convert.ToInt32(splitLine[1]));
                                curves[num-1].addY(Convert.ToInt32(splitLine[2]));
                            }
                            

                        }
                        else
                        {
                            
                        }
                        line = sr.ReadLine();

                        

                    }
                }
            }

        }

        private string[] splitString(string s, char delim)
        {
            if (s != "" && s != " ")
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
                
                

                
                string[] newS = s.Split(delim);
                newS = newS.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Console.WriteLine("Size: " + newS.Count() + " / SplitString: " + s);
                return newS;
            }
            return new string[0];
        }

        private Parameter[] createParaArr(string[] data)
        {
            Parameter[] paraArr = new Parameter[data.Length - 2];
            int num = 0;
            for (int x = 0; x < data.Length; x++)
            {
                if (double.TryParse(data[x], out double n))
                {
                    paraArr[num] = new Parameter(n);
                    num++;
                }
            }
            return paraArr;
        }

        private string drainCurve(string[] data)
        {
            if (data.Length >= 9)
            {
                return data[8];
            }
            return "";
        }

        
    }
}




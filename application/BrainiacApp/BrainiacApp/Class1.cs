using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.IO;
using System.Text;
using System.Globalization;
namespace BrainiacApp
{
    public class TestCleaning
    {
        int testNo;
        ArrayList test1=new ArrayList();
        ArrayList test2=new ArrayList();    
        ArrayList test3=new ArrayList();
        ArrayList test4=new ArrayList();
        ArrayList test5=new ArrayList();

        ArrayList test1Values=new ArrayList();  
        ArrayList test2Values=new ArrayList();
        ArrayList test4Values=new ArrayList();
        ArrayList test5Values=new ArrayList();
        public TestCleaning(String fileName)
        {
            for(int i=0; i<4; i++)
            {
                test1.Add(new ArrayList());
                test2.Add(new ArrayList());
                test3.Add(new ArrayList());
                test4.Add(new ArrayList());
                test5.Add(new ArrayList());
            }
            
            StreamReader file = new StreamReader(fileName);
            string ln;
            while ((ln = file.ReadLine()) != null)
            {
                ArrayList values=new ArrayList();
                Console.WriteLine(ln);
                string[] temp = ln.Split(';');
                Console.WriteLine("temp.length = " + temp.Length);
                if (temp.Length==5)
                {
                    values.Add(int.Parse(temp[1]));    
                    values.Add(int.Parse(temp[2]));
                    values.Add(int.Parse(temp[3]));
                    //values.Add(int.Parse(temp[4]));
                    temp[4].TrimEnd('\n');
                    values.Add(int.Parse(temp[4]));
                    if(temp[0]=="1")
                    {
                        Console.WriteLine("temp1");
                        int counter = 0;
                        foreach(ArrayList i in test1)
                        {
                            i.Add(values[counter]);
                            counter++;
                        }
                    }
                    if (temp[0] == "2")
                    {
                        Console.WriteLine("temp2");
                        int counter = 0;
                        foreach (ArrayList i in test2)
                        {
                            i.Add(values[counter]);
                            counter++;
                        }
                    }
                    if (temp[0] == "3")
                    {
                        Console.WriteLine("temp3");
                        int counter = 0;
                        foreach (ArrayList i in test3)
                        {
                            i.Add(values[counter]);
                            counter++;
                        }
                    }
                    if (temp[0] == "4")
                    {
                        Console.WriteLine("temp4");
                        int counter = 0;
                        foreach (ArrayList i in test4)
                        {
                            i.Add(values[counter]);
                            counter++;
                        }
                    }
                    if (temp[0] == "5")
                    {
                        Console.WriteLine("temp5");
                        int counter = 0;
                        foreach (ArrayList i in test5)
                        {
                            i.Add(values[counter]);
                            counter++;
                        }
                    }
                }

            }
            Console.WriteLine("CleanTest1");
            cleanTest(test1, test1Values);
            foreach (ArrayList i in test3)
                test2.Add(i);
            Console.WriteLine("CleanTest2");
            cleanTest(test2, test2Values);
            Console.WriteLine("CleanTest4");
            cleanTest(test4, test4Values);
            Console.WriteLine("CleanTest5");
            cleanTest(test5, test5Values);
            Console.WriteLine("test1.length = " + test1Values.Count);
            Console.WriteLine("test2.length = " + test2Values.Count);
            Console.WriteLine("test4.length = " + test4Values.Count);
            Console.WriteLine("test5.length = " + test5Values.Count);

            intervalFinder();

        }
        public void cleanTest(ArrayList array, ArrayList testArray)
        {
            ArrayList temp = new ArrayList();
            foreach (ArrayList i in array)
            {
                ArrayList cleanValues = new ArrayList();
                int dev = standardCalc(i);
                int mean = meanCalc(i);

                if (dev < 1250)
                    cleanValues.Add(i);
                else
                {
                    foreach(int j in i)
                      if (Math.Abs(mean - j) > dev)
                          i.Remove(j);
                }
                temp.Add(meanCalc(i));
            }
            testArray.Add(meanCalc(temp)); //Her sütunun hesaplanmış değerleri toplamda 4
        }

        public int standardCalc(ArrayList array)
        {
            double mean = meanCalc(array);
            double temp = 0;

            foreach (int i in array)
            {
                int val = i;

                double squrDiffToMean = Math.Pow(val - mean, 2);

                temp += squrDiffToMean;
            }

            double meanOfDiffs = (double)temp / (double)(array.Count);

            return (int)Math.Sqrt(meanOfDiffs);
        }

        public int meanCalc(ArrayList array)
        {
            int total = 0;
            foreach (int i in array)
                total += i;
            return total/ array.Count;  
        }
        public void intervalFinder()
        {
            StreamWriter sw = new StreamWriter("results.csv");

            int i = 0;

            for (i = 0; i < 4; i++)
            {
                if (i < 2) {
                    testNo = i + 1;
                }
                else {
                    testNo = i + 2;
                }

                StreamReader sr = new StreamReader("test" + testNo.ToString() + "_histogram.csv");

                ArrayList ch1 = new ArrayList();
                ArrayList ch2 = new ArrayList();
                ArrayList ch3 = new ArrayList();
                ArrayList ch4 = new ArrayList();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.Compare(line, "\n") != 0)
                    {
                        string[] words = line.Split(',');
                        ch1.Add(words[0]);
                        ch2.Add(words[1]);
                        ch3.Add(words[2]);
                        ch4.Add(words[3]);
                    }
                }
                sr.Close();

                Console.WriteLine("CH3 count:" + ch3.Count);
                int j = 0;
                for (j = 0; j < ch3.Count; j++)
                {
                    string interval = (string)ch3[j];

                    string[] intervals = interval.Split('-');

                    ArrayList testval = new ArrayList();

                    if (testNo == 1)
                    {
                        for(int m = 0; m < test1Values.Count; m++)
                        {
                            testval.Add(test1Values[m]);
                        }
                    }
                    if (testNo == 2)
                    {
                        for (int m = 0; m < test2Values.Count; m++)
                        {
                            testval.Add(test2Values[m]);
                        }
                    }
                    if (testNo == 4)
                    {
                        for (int m = 0; m < test4Values.Count; m++)
                        {
                            testval.Add(test4Values[m]);
                        }
                    }
                    if (testNo == 5)
                    {
                        for (int m = 0; m < test5Values.Count; m++)
                        {
                            testval.Add(test5Values[m]);
                        }
                    }
                    Console.WriteLine("Length test val: " + ((ArrayList)testval).Count);
                    ArrayList test1floatval = new ArrayList();

                    int k = 0;
                    for (k = 0; k < testval.Count; k++)
                    {
                        test1floatval.Add(Convert.ToDouble(testval[k]));
                    }

                    var floatinterval1 = Convert.ToDouble(intervals[0]);
                    var floatinterval2 = Convert.ToDouble(intervals[1]);

                    if ((double)test1floatval[0] >= floatinterval1 && (double)test1floatval[0] < floatinterval2)
                    {
                        Console.WriteLine("if");
                        sw.Write(ch2[j].ToString());
                        sw.Write(",");
                        sw.Write(floatinterval1.ToString("0.000"));
                        sw.Write("-");
                        sw.Write(floatinterval2.ToString("0.000"));
                        sw.Write("\n");
                    }
                }
            }
            sw.Close();
        }
    }
}

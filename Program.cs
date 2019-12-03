using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace changerange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Change Objects ID Range...");
            Console.WriteLine("GetCurrentDirectory: " + Directory.GetCurrentDirectory());

            string objtablesubstr = "OBJECT Table ";
            string objcodeunitsubstr = "OBJECT Codeunit ";
            string objpagesubstr = "OBJECT Page ";
            string objxlmsubstr = "OBJECT XMLport ";
            string objreportsubstr = "OBJECT Report ";

            List<CrossID> TablesCrossesID = new List<CrossID>();
            List<CrossID> CodeunitsCrossesID = new List<CrossID>();
            List<CrossID> PagesCrossesID = new List<CrossID>();
            List<CrossID> XMLPortsCrossesID = new List<CrossID>();
            List<CrossID> ReportsCrossesID = new List<CrossID>();

            string filename = "";

            int selector = 0;

            int codeunitbeginrange = 0;
            int pagebeginrange = 0;
            int tablebeginrange = 0;
            int reportsbeginrange = 0;
            int xmlportbeginrange = 0;
            int minrange = 0;
            int maxrange = 0;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-f":
                        selector = 1;
                        break;
                    case "-cnewrange":
                        selector = 2;
                        break;
                    case "-pnewrange":
                        selector = 3;
                        break;
                    case "-tnewrange":
                        selector = 4;
                        break;
                    case "-xnewrange":
                        selector = 5;
                        break;
                    case "-rnewrange":
                        selector = 6;
                        break;
                    case "-selectrange":
                        selector = 7;
                        break;
                    default:
                        switch (selector)
                        {
                            case 1:
                                filename = args[i];
                                break;
                            case 2:
                                int.TryParse(args[i], out codeunitbeginrange);
                                break;
                            case 3:
                                int.TryParse(args[i], out pagebeginrange);
                                break;
                            case 4:
                                int.TryParse(args[i], out tablebeginrange);
                                break;
                            case 5:
                                int.TryParse(args[i], out xmlportbeginrange);
                                break;
                            case 6:
                                int.TryParse(args[i], out reportsbeginrange);
                                break;
                            case 7:
                                if (minrange == 0)
                                {
                                    int.TryParse(args[i], out minrange);
                                }
                                else
                                {
                                    int.TryParse(args[i], out maxrange);
                                }
                                break;
                        }
                        break;
                }
            }

            filename = Path.Combine(Directory.GetCurrentDirectory(), filename);
            if (!File.Exists(filename))
            {
                Console.WriteLine("File {0} not found!", filename);
                Console.ReadKey();
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.IndexOf(objtablesubstr) == 0)
                        {
                            if (tablebeginrange != 0)
                            {

                                string[] words = line.Split(' ');
                                int id = int.Parse(words[2]);
                                if (id >= minrange && id <= maxrange)
                                {
                                    Console.WriteLine(line + " - New ID " + tablebeginrange.ToString());
                                    TablesCrossesID.Add(new CrossID()
                                    {
                                        OldID = id,
                                        NewID = tablebeginrange
                                    });
                                    tablebeginrange++;
                                }
                            }
                        }
                        if (line.IndexOf(objcodeunitsubstr) == 0)
                        {
                            if (codeunitbeginrange != 0)
                            {
                                string[] words = line.Split(' ');
                                int id = int.Parse(words[2]);
                                if (id >= minrange && id <= maxrange)
                                {
                                    Console.WriteLine(line + " - New ID " + codeunitbeginrange.ToString());
                                    CodeunitsCrossesID.Add(new CrossID()
                                    {
                                        OldID = int.Parse(words[2]),
                                        NewID = codeunitbeginrange
                                    });
                                    codeunitbeginrange++;
                                }
                            }
                        }
                        if (line.IndexOf(objpagesubstr) == 0)
                        {
                            if (pagebeginrange != 0)
                            {
                                string[] words = line.Split(' ');
                                int id = int.Parse(words[2]);
                                if (id >= minrange && id <= maxrange)
                                {
                                    Console.WriteLine(line + " - New ID " + pagebeginrange.ToString());
                                    PagesCrossesID.Add(new CrossID()
                                    {
                                        OldID = int.Parse(words[2]),
                                        NewID = pagebeginrange
                                    });
                                    pagebeginrange++;
                                }
                            }
                        }
                        if (line.IndexOf(objxlmsubstr) == 0)
                        {
                            if (xmlportbeginrange != 0)
                            {
                                string[] words = line.Split(' ');
                                int id = int.Parse(words[2]);
                                if (id >= minrange && id <= maxrange)
                                {
                                    Console.WriteLine(line + " - New ID " + xmlportbeginrange.ToString());
                                    XMLPortsCrossesID.Add(new CrossID()
                                    {
                                        OldID = int.Parse(words[2]),
                                        NewID = xmlportbeginrange
                                    });
                                    xmlportbeginrange++;
                                }
                            }
                        }
                        if (line.IndexOf(objreportsubstr) == 0)
                        {
                            if (reportsbeginrange != 0)
                            {
                                string[] words = line.Split(' ');
                                int id = int.Parse(words[2]);
                                if (id >= minrange && id <= maxrange)
                                {
                                    Console.WriteLine(line + " - New ID " + reportsbeginrange.ToString());
                                    ReportsCrossesID.Add(new CrossID()
                                    {
                                        OldID = int.Parse(words[2]),
                                        NewID = reportsbeginrange
                                    });
                                    reportsbeginrange++;
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Magic...");

            string text = new StreamReader(filename, Encoding.GetEncoding(437)).ReadToEnd();
            
            string objtabletext = "OBJECT Table ";
            string recordtext = " : Record ";
            string sourcetabletext = "SourceTable=Table";

            foreach (CrossID cid in TablesCrossesID)
            {
                text = ReplaceText(text, objtabletext, " ", cid);
                text = ReplaceText(text, recordtext, "", cid);
                text = ReplaceText(text, sourcetabletext, ";", cid);
             }

            //changed text
            string objcutext = "OBJECT Codeunit ";
            string cutext = " : Codeunit ";
            foreach (CrossID cid in CodeunitsCrossesID)
            {
                text = ReplaceText(text, objcutext, " ", cid);
                text = ReplaceText(text, cutext, "", cid);
            }

            string objpagetext = "OBJECT Page ";
            string lookuptext = "LookupPageID=Page";
            string drilldowntext = "DrillDownPageID=Page";
            string pagetext = " : Page ";
            string runobjecttext = "RunObject=Page ";
            string pageparttext = "PagePartID=Page";
            string pageruntext = "PAGE.RUN(";

            foreach (CrossID cid in PagesCrossesID)
            {
                text = ReplaceText(text, objpagetext, " ", cid);
                text = ReplaceText(text, lookuptext, ";", cid);
                text = ReplaceText(text, drilldowntext, ";", cid);
                text = ReplaceText(text, pagetext, "", cid);
                text = ReplaceText(text, runobjecttext, ";", cid);
                text = ReplaceText(text, pageparttext, ";", cid);
                text = ReplaceText(text, pageruntext, ";", cid);
            }

            string objxmltext = "OBJECT XMLport ";
            string xmlporttext = ": XMLport ";
            foreach (CrossID cid in XMLPortsCrossesID)
            {
                text = ReplaceText(text, objxmltext, " ", cid);
                text = ReplaceText(text, xmlporttext, "", cid);
            }

            string objporttext = "OBJECT Report ";
            string reporttext = ": Report ";
            string reportruntext = ": Report ";

            foreach (CrossID cid in ReportsCrossesID)
            {
                text = ReplaceText(text, objporttext, " ", cid);
                text = ReplaceText(text, reporttext, "", cid);
                text = ReplaceText(text, reportruntext, "", cid);
            }


            try
            {
                string newfilename = filename + "2";
                if (File.Exists(newfilename))
                {
                    File.Delete(newfilename);
                }
                FileStream stream = new FileStream(newfilename, FileMode.CreateNew);
                using (StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(437)))
                {
                    writer.Write(text);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

            Console.WriteLine("Done");
            Console.ReadKey();


            string ReplaceText(String text1, string pattern, string suffix, CrossID cid)
            {
                return text1.Replace(pattern + cid.OldID.ToString() + suffix, pattern + cid.NewID.ToString() + suffix);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LangLib
{
    public class LangLibrary
    {
        private List<string> appLangStrings = new List<string>();
        public LangLibrary(string rootDir, string Lang)
        {
            try
            {
            using (StreamReader sr = new StreamReader(rootDir + "/lang/" + Lang + "/strings.ini")) //To allow for easy disposal of object when we are done. 
            {
                int index = 0;
                while(!sr.EndOfStream) 
                { 
                    string line = sr.ReadLine(); // Read a line from the language file 
                    try 
                    { 
                        appLangStrings[index] = line.Replace("{" + index + "}=", ""); // Strip the identifier key out of the string and add it to the language string list 
                    } 
                    catch 
                    { 
                        //we have hit an error
                        sr.Close();
                        break; 
                    } 
                } 
            } 
            }
            catch
            {
                //The file does not exist
                throw new Exception("LangLib-0x001");
            }
        }
        public string getById(int id)
        {
            try
            {
                return appLangStrings[id];
            }
            catch
            {
                throw new Exception("LangLib-0x002");
            }
        }
        public static string getVersion()
        {
            getVersion("n vT, c");
        }
        public static string getVersion(string paramString)
        {
            paramString = paramString.Replace("n", "LangLib");
            paramString = paramString.Replace("v", "1.1");
            paramString = paramString.Replace("t", "Stable");
            paramString = paramString.Replace("T", "S");
            paramString = paramString.Replace("c", "Copyright 2015 Joshua Zenn);
            paramString = paramString.Replace("a", "Joshua Zenn");
            paramString = paramString.Replace("y", "2015");
            return paramString;
        }
    }
}

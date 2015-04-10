﻿using System;
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
        public string getById(int id)
        {
            try
            {
                return appLangStrings[id];
            }
            catch
            {
                throw;
            }
        }
    }
}

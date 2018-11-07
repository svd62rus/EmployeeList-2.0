using System;
using System.Collections.Generic;
using System.IO;

namespace ExportManager
{
    public class Export
    {
        private string txtExtension = ".txt";
        private string nameOfExportFile;
        private List<string> text;

        public Export(string nameOfExportFile, List<string> text)
        {
            this.nameOfExportFile = nameOfExportFile;
            this.text = text;
        }

        public Exception WriteFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(nameOfExportFile + txtExtension, false);
                sw.WriteLine(nameOfExportFile);
                foreach (var elem in text)
                {
                    sw.WriteLine(elem);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;

        }
    }
}

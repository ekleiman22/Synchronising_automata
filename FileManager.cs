using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyDFA
{


    public class FileManager
    {
        private StreamReader streamReader { get; set; }
        private StreamWriter streamWriter { get; set; }

        public static string inputDataPath = Application.StartupPath + "\\InputData";
        public static string outputDataPath = Application.StartupPath + "\\OutputData";
        public FileManager(string path)
        {
            streamReader = new StreamReader(path);
        }
        public FileManager(string fileName, int mode)
        {
            if (mode == 1)
                streamReader = new StreamReader(inputDataPath + "\\" + fileName);
            else
                streamWriter = new StreamWriter(outputDataPath + "\\" + fileName);

        }

        public string readLine()
        {
            string line = null;
            try
            {
                if (!streamReader.EndOfStream)
                    line = streamReader.ReadLine();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return line;
        }

        public void writeLine(string line)
        {

            try
            {
                streamWriter.WriteLine(line);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void closeStream()
        {
            streamReader.Dispose();

        }

    }
}


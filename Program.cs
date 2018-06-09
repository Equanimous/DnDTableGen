using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTableGen
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            List<string> fileList = new List<string>();
            List<string> dataList = new List<string>();
            Random random = new Random();

            //pick folder to fetch files from
            //store file names in array or list
            fileList = fileIO.filePicker();

            //read \n delimited data to data list
            dataList = fileIO.readFromFiles(fileList);

            //randomize data in list (simple solution, can be built on)
            for (int i = 0; i < dataList.Count; i++)
            {
                string tmpData = dataList[i];
                int randInd = random.Next(i, dataList.Count);
                dataList[i] = dataList[randInd];
                dataList[randInd] = tmpData;
            }

            //based on number of data items, determine how to assign probability to each object -- could use strategy pattern if program is extended


            //write data out to file in the form of {probability} {\t} {data object} {\n}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTableGen
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            List<string> dataList = new List<string>();

            //pick folder to fetch files from
            //store file names in array or list
            dataList = fileIO.filePicker();

            //read \n-separated data to data list (do not allow duplicates)
            //randomize data in list
            //based on number of data items, determine how to assign probability to each object -- could use strategy pattern if program is extended
            //write data out to file in the form of {probability} {\t} {data object} {\n}
        }
    }
}

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
            //store file names in list
            fileList = fileIO.filePicker();

            //read \n delimited data to data list
            //need to add logic in readFromFiles to handle when multiple files are selected
            dataList = fileIO.readFromFiles(fileList);

            //randomize data in list (simple solution, can be built on)
            for (int i = 0; i < dataList.Count; i++)
            {
                string tmpData = dataList[i];
                int randInd = random.Next(i, dataList.Count);
                dataList[i] = dataList[randInd];
                dataList[randInd] = tmpData;
            }

            //based on number of data items, determine how to assign probability to each object
            int groupings;
            int currGrouping;
            if (dataList.Count >= 100)
            {
                //need to figure out a good way to handle this case.
                //what to do with extras?
                groupings = 1;
            }
            else
            {
                groupings = (int) Math.Ceiling((decimal)100 / dataList.Count);
            }

            currGrouping = 1;
            for (int i = 0; i < dataList.Count; i++)
            {
                if (groupings == 1)
                {
                    dataList[i] = "" + currGrouping + "\t" + dataList[i];
                }
                else if (100 % dataList.Count == 0)
                {
                    dataList[i] = "" + currGrouping + "-" + (currGrouping + groupings - 1) + "\t" + dataList[i];
                }
                else
                {
                    //this is a disaster.  desperately needs to be changed
                    //tries to ensure that the scale is from 1-100 (for the purposes of rolling d100)                    
                    if ((100 - currGrouping) % (dataList.Count - i) == 0)
                    {
                        dataList[i] = "" + currGrouping + "-" + (currGrouping + groupings - 1) + "\t" + dataList[i];
                        groupings = (100 - currGrouping) / (dataList.Count - i);
                        currGrouping++;
                    }
                    else
                    {
                        dataList[i] = "" + currGrouping + "-" + (currGrouping + groupings - 1) + "\t" + dataList[i];
                    }
                    
                }
                currGrouping += groupings;    
            }

            //write data out to file in the form of {probability} {\t} {data object} {\n}
            fileIO.writeToFiles(fileList, dataList);
        }
    }
}

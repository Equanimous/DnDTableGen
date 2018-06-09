using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDTableGen
{
    public class FileIO
    {
        public List<string> filePicker()
        {
            List<string> fileList = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = "C:\\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileList = new List<string>(openFileDialog.FileNames);
            }

            return fileList;
        }

        public List<string> readFromFiles(List<string> fileList)
        {
            List<string> dataList = new List<string>();

            foreach (string pathName in fileList)
            {
                string[] fileData = System.IO.File.ReadAllLines(pathName);

                for (int i = 0; i < fileData.Length; i++)
                {
                    dataList.Add(fileData[i]);
                }
            }

            return dataList;
        }
    }
}

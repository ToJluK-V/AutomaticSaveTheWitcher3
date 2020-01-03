using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SaveTheWitcher3
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
     
            //var sortedFiles1 = new DirectoryInfo(pathToDirectory1v).GetFiles()
            //                                      .OrderBy(f => f.LastWriteTime)
            //                                      .ToList();

            //var sortedFiles2 = new DirectoryInfo(pathToDirectory2p).GetFiles()
            //                                      .OrderBy(f => f.LastWriteTime)
            //                                      .ToList();

            //var sortedFiles3 = new DirectoryInfo(pathToGameSave).GetFiles()
            //                                      .OrderBy(f => f.LastWriteTime)
            //                                      .ToList();


            //Console.WriteLine("Последнее сохранение Вани: " + sortedFiles1[0].LastWriteTime.ToString());
            //Console.WriteLine();

            //Console.WriteLine("Последнее сохранение Паши: " + sortedFiles2[0].LastWriteTime.ToString());
            //Console.WriteLine();

            //Console.WriteLine("Последнее сохранение в игре: " + sortedFiles3[0].LastWriteTime.ToString());
            //Console.WriteLine();

            //------------------------------------------------------------------------------------
        }
    }
}
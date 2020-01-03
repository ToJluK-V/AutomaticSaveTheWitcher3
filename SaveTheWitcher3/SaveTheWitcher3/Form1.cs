using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;




namespace SaveTheWitcher3
{
    public partial class Form1 : Form
    {
        // Пути к папкам, с которыми работаем
        static string pathToDirectory1v = @"C:\Users\User\Documents\The Witcher 3" + @"\SaveVanya\";
        static string pathToDirectory2p = @"C:\Users\User\Documents\The Witcher 3" + @"\SavePasha\";
        static string pathToGameSave = @"C:\Users\User\Documents\The Witcher 3" + @"\gamesaves\";

        static string pathToFile = @"D:\Programs\TheWitcherSave\LastSave.txt";

        //------------------------------------------------------------------------------------
        // сохраняем названия всех файлов в переменную allFiles (массив строк)
        //static  DirectoryInfo dI1v = new DirectoryInfo(pathToDirectory1v);
        //FileInfo[] allFiles1v = dI1v.GetFiles();

        //static DirectoryInfo dI2p = new DirectoryInfo(pathToDirectory2p);
        //FileInfo[] allFiles2p = dI2p.GetFiles();
        //------------------------------------------------------------------------------------

        public static int i = 0;//переменная для запоминания кто последний раз сохранял

        public Form1()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)  // Первая кнопка(Загрузить для Вани)
        {
        
            DirectoryInfo dirInfo2p = new DirectoryInfo(pathToDirectory2p);
            DirectoryInfo dirInfoSave = new DirectoryInfo(pathToGameSave);
            DirectoryInfo dirInfo1v = new DirectoryInfo(pathToDirectory1v);

            foreach (var file in dirInfo2p.GetFiles())      //Удаление файлов из ВТОРОЙ(pathToDirectory2p) папки 
            {       
                file.Delete();
            }

            foreach (var file in dirInfoSave.GetFiles())    //Перемещение файлов из GameSave во ВТОРУЮ(pathToDirectory2p) папку
            {   
                file.CopyTo(pathToDirectory2p + @"\" + file.Name, true);
            }

            foreach (var file in dirInfoSave.GetFiles())//После очищаем Gamesave
            {
                file.Delete();
            }
   
            foreach (var file in dirInfo1v.GetFiles())       //Перемещение файлов из ПЕРВОЙ(pathToDirectory1v) папки в GameSave папку   
            {
                file.CopyTo(pathToGameSave + @"\" + file.Name, true);
            }

            MessageBox.Show("Загружено.");

            File.WriteAllText(pathToFile, "1");
        }

        private void Button2_Click(object sender, EventArgs e)  // Вторая кнопка(Загрузить для Паши)
        {
            
            DirectoryInfo dirInfo1v = new DirectoryInfo(pathToDirectory1v);
            DirectoryInfo dirInfoSave = new DirectoryInfo(pathToGameSave);
            DirectoryInfo dirInfo2p = new DirectoryInfo(pathToDirectory2p);

            foreach (FileInfo file in dirInfo1v.GetFiles())//Удаление файлов из ПЕРВОЙ(pathToDirectory1v) папки 
            {
                file.Delete();
            }

            foreach (var file in dirInfoSave.GetFiles()) //Перемещение файлов из GameSave в ПЕРВУЮ(pathToDirectory1v) папку
            {
                file.CopyTo(pathToDirectory1v + @"\" + file.Name, true);

            }

            foreach (FileInfo file in dirInfoSave.GetFiles()) //После очищаем Gamesave
            {
                file.Delete();
            }

            foreach (var file in dirInfo2p.GetFiles()) //Перемещение файлов из ВТОРОЙ(pathToDirectory2p) папки в GameSave папку
            {
                file.CopyTo(pathToGameSave + @"\" + file.Name, true);
            }

            MessageBox.Show("Загружено");

            File.WriteAllText(pathToFile, "2");
        }

        //Кнопка для проверки ласт сохр
        private void Button3_Click(object sender, EventArgs e)
        {
            string pathToFile = @"D:\Programs\TheWitcherSave\LastSave.txt";
            string readAllFile = File.ReadAllText(pathToFile);

            if (readAllFile == "1")
            MessageBox.Show("Ваня загружал в прошлый раз");
            if(readAllFile == "2")
                MessageBox.Show("Паша загружал в прошлый раз");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string pathToFile = @"D:\Programs\TheWitcherSave\LastSave.txt";
            string readAllFile = File.ReadAllText(pathToFile);

            if (readAllFile == "1")
                button1.Enabled = false;

            if (readAllFile == "2")
                button2.Enabled = false;
        }
    }
}

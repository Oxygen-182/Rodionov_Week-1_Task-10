using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp_10_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            if (!Directory.Exists("c:\\temp"))
            {
                Directory.CreateDirectory("c:\\temp");
            }

            Directory.CreateDirectory("c:\\temp\\K1");
            Directory.CreateDirectory("c:\\temp\\K2");

            StreamWriter sw = new StreamWriter("c:\\temp\\K1\\t1.txt");
            sw.Write("Родионов Юрий Русланович, 2004 года рождения, место жительства г. Владимир");
            sw.Close();

            sw = new StreamWriter("c:\\temp\\K1\\t2.txt");
            sw.Write("Заплаткие Юрий Александрович, 2004 года рождения, место жительства г. Владимир");
            sw.Close();

            sw = new StreamWriter("c:\\temp\\K2\\t3.txt");
            StreamReader sr = new StreamReader("c:\\temp\\K1\\t1.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();

            sr = new StreamReader("c:\\temp\\K1\\t2.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sw.Close();

            DirectoryInfo d1inf = new DirectoryInfo("c:\\temp\\K1");
            FileInfo[] f1inf = d1inf.GetFiles();
            DirectoryInfo d2inf = new DirectoryInfo("c:\\temp\\K2");
            FileInfo[] f2inf = d2inf.GetFiles();

            textBox1.Text += "Информация о файлах в папке К1:" + Environment.NewLine;
            foreach (FileInfo f1i in f1inf)
            {
                textBox1.Text += Environment.NewLine + "Полный путь файла: " + f1i.FullName + Environment.NewLine + "Время создания: " + f1i.CreationTime + Environment.NewLine
                    + "Время последнего изменения: " + f1i.LastWriteTime + Environment.NewLine + "Объём файла в байтах: " + f1i.Length + Environment.NewLine;
            }

            textBox1.Text += Environment.NewLine + "Информация о файлах в папке К2:\n" + Environment.NewLine;
            foreach (FileInfo f2i in f2inf)
            {
                textBox1.Text += Environment.NewLine + "Полный путь файла: " + f2i.FullName + Environment.NewLine + "Время создания: " + f2i.CreationTime + Environment.NewLine 
                    + "\nВремя последнего изменения: " + f2i.LastWriteTime + Environment.NewLine + "Объём файла в байтах: " + f2i.Length + Environment.NewLine;
            }

            File.Move("c:\\temp\\K1\\t2.txt", "c:\\temp\\K2\\t2.txt");
            File.Copy("c:\\temp\\K1\\t1.txt", "c:\\temp\\K2\\t1.txt");

            Directory.Move("c:\\temp\\K2", "c:\\temp\\ALL");
            Directory.Delete("c:\\temp\\K1", true);

            DirectoryInfo dinf = new DirectoryInfo("c:\\temp\\ALL");
            FileInfo[] finf = dinf.GetFiles();

            textBox1.Text += Environment.NewLine + "Информация о файлах в папке ALL:" + Environment.NewLine;
            foreach (FileInfo fi in finf)
            {
                textBox1.Text += Environment.NewLine + "Полный путь файла: " + fi.FullName + Environment.NewLine + "Время создания: " + fi.CreationTime + Environment.NewLine 
                    + "Время последнего изменения: " + fi.LastWriteTime + Environment.NewLine + "Объём файла в байтах: " + fi.Length + Environment.NewLine;
            }
        }
    }
}

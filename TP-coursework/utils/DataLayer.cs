using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_coursework.utils
{
    class DataLayer
    {
        // Это поле данных о студенте нужно для дальнейшего сохранения в файл
        public static string studentInfoToSave { get; set; }
        // Поле данных опроса
        public static string quizInfoToSave { get; set; }
        // Путь до файла
        public static string pathfile = "data.txt";

        // Метод сохраняет данные из полей (кроме pathfile) в файл
        public static void saveToFile()
        {
            // Проверяем есть ли файл, то добавляем в конец файла, иначе создаём новый
            var file = File.Exists(pathfile) ? File.Open(pathfile, FileMode.Append) : File.Open(pathfile, FileMode.CreateNew);
            file.Close();
            StreamWriter writer = File.AppendText(pathfile);
            writer.WriteLine(studentInfoToSave + quizInfoToSave);
            writer.Close();
        }

        public static List<string> loadFromFileQuiz(string univer) 
        {
            var file = File.Exists(pathfile) ? File.Open(pathfile, FileMode.Append) : File.Open(pathfile, FileMode.CreateNew);
            file.Close();
            StreamReader reader = new StreamReader(pathfile);
            string line;
            List<string> data = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                if (univer == line.Split(';')[5])
                {
                    for(int i = 6; i <= 13; i++)
                    {
                        data.Add(line.Split(';')[i]);
                    }
                }
            }

            return data;
        }
    }
}

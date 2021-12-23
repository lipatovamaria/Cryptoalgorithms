using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows;


namespace practic
{
    public interface IFileService
    {
        string Text { get; set; }
        void Open(string filename);
        void Save(string filename, string text);
    }

    public class TXTFileService: IFileService
    {
        public string Text { get; set; }
        public void Open(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    Text = reader.ReadToEnd();
                }
                string caption = "Файл открыт!";
                string message = "Файл успешно открыт.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            catch
            {
                string caption = "Файл не существует!";
                string message = "Введите корректное имя файла.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
        }

        public void Save(string filename, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write(text);
                }
                string caption = "Файл сохранен!";
                string message = "Файл успешно сохранен.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            catch
            {
                string message = "Файл не существует!";
                string caption = "Введите корректное имя файла.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }            
        }
    }
}
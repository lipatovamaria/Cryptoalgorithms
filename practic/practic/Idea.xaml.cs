using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CryptographyClassLybrary;

namespace practic
{
    public partial class Idea : Window
    {
        public Idea()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (selectEncryption.Visibility == Visibility.Collapsed)
            {
                Environment.Exit(0);
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public SelectEncryption selectEncryption;
        public MainWindow mainWindow;

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Key.Clear();
            Key.FontSize = 14;
            Key.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            selectEncryption.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Saving saving = new Saving();
            saving.Show();
            saving.mainWindow = mainWindow;
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if ((Key.Text == "Введите ключ") || (Key.Text == ""))
            {
                string caption = "Некорректный ключ!";
                string message = "Введите корректный ключ для выполнения процедуры шифрования/дешифрования.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    mainWindow.cryptText.Text = IDEAEncryptor.IDEAEncryption(mainWindow.sourceText.Text, Key.Text);
                    Text.Foreground = new SolidColorBrush(Colors.Black);
                    Text.FontSize = 14;
                    Text.Text = mainWindow.cryptText.Text;
                }
                catch
                {
                    string caption = "Что-то пошло не так!";
                    string mess = "Введите корректные данные для выполнения процедуры шифрования/дешифрования.";
                    MessageBox.Show(mess, caption, MessageBoxButton.OK);
                }                
            }
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Key.Text == "Введите ключ") || (Key.Text == ""))
                {

                    string caption = "Некорректный ключ!";
                    string message = "Введите корректный ключ для процедуры шифрования/дешифрования.";
                    MessageBox.Show(message, caption, MessageBoxButton.OK);
                }
                else
                {
                    mainWindow.cryptText.Text = IDEAEncryptor.IDEADecryption(mainWindow.sourceText.Text, Key.Text);
                    Text.Foreground = new SolidColorBrush(Colors.Black);
                    Text.FontSize = 14;
                    Text.Text = mainWindow.cryptText.Text;
                }
            }
            catch
            {
                string caption = "Что-то пошло не так!";
                string mess = "Введите корректные данные для выполнения процедуры шифрования/дешифрования.";
                MessageBox.Show(mess, caption, MessageBoxButton.OK);
            }            
        }
    }
}

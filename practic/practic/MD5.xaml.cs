using System;
using System.Windows;
using System.Windows.Media;
using CryptographyClassLybrary;


namespace practic
{
    public partial class MD5 : Window
    {
        public MD5()
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
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        public SelectEncryption selectEncryption;
        public MainWindow mainWindow;

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            selectEncryption.Show();
            this.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if ((Text.Text == "Дешифрованный/Зашифрованный текст")||(Text.Text == ""))
            {
                string caption = "Некорректное сохранение!";
                string message = "Выполните шифрование/дешифрование.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                Saving saving = new Saving();
                saving.Show();
                saving.mainWindow = mainWindow;
            }
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.cryptText.Text = MD5Encryptor.MD5Encryption(mainWindow.sourceText.Text);
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
}

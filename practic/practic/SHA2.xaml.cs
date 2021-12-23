using System;
using System.Windows;
using System.Windows.Media;
using CryptographyClassLybrary;

namespace practic
{
    public partial class SHA2 : Window
    {
        public SHA2()
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
            try
            {
                mainWindow.cryptText.Text = SHA_2Encryptor.SHA_256Encryption(mainWindow.sourceText.Text);
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

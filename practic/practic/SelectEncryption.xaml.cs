using System;
using System.Windows;

namespace practic
{
    public partial class SelectEncryption : Window
    {
        public SelectEncryption()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        public MainWindow mainWindow;

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void MD5_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = new MD5();
            md5.Show();
            md5.selectEncryption = this;
            md5.mainWindow = mainWindow;
            this.Visibility = Visibility.Collapsed;
        }

        private void SHA2_Click(object sender, RoutedEventArgs e)
        {
            SHA2 sha2 = new SHA2();
            sha2.Show();
            sha2.selectEncryption = this;
            sha2.mainWindow = this.mainWindow;
            this.Visibility = Visibility.Collapsed;
        }

        private void Serpent_Click(object sender, RoutedEventArgs e)
        {
            Serpent serpent = new Serpent();
            serpent.Show();
            serpent.selectEncryption = this;
            serpent.mainWindow = this.mainWindow;
            this.Visibility = Visibility.Collapsed;
        }

        private void Idea_Click(object sender, RoutedEventArgs e)
        {
            Idea idea = new Idea();
            idea.Show();
            idea.selectEncryption = this;
            idea.mainWindow = this.mainWindow;
            this.Visibility = Visibility.Collapsed;
        }

        private void RSA_Click(object sender, RoutedEventArgs e)
        {
            RSA rsa = new RSA();
            rsa.Show();
            rsa.selectEncryption = this;
            rsa.mainWindow = this.mainWindow;
            this.Visibility = Visibility.Collapsed;
        }
    }
}

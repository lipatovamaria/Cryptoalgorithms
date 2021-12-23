using System.Windows;
using System.Windows.Media;
using System.IO;

namespace practic
{
    public partial class LoadKeysWindow : Window
    {
        public LoadKeysWindow()
        {
            InitializeComponent();
        }
        public RSA rsa;
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            if (OpenFileName_TextBox.Text != "")
            {
                string publicKey = "";
                string secretKey = "";
                string sessionKey = "";
                using (StreamReader streamReader = new StreamReader(OpenFileName_TextBox.Text))
                {
                    publicKey = streamReader.ReadLine();
                    secretKey = streamReader.ReadLine();
                    sessionKey = streamReader.ReadLine();
                }
                rsa.publicKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
                rsa.publicKey_TextBox.FontSize = 14;
                rsa.publicKey_TextBox.Text = publicKey;
                rsa.secretKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
                rsa.secretKey_TextBox.FontSize = 14;
                rsa.secretKey_TextBox.Text = secretKey;
                rsa.sessionKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
                rsa.sessionKey_TextBox.FontSize = 14;
                rsa.sessionKey_TextBox.Text = sessionKey;
                string caption = "Ключи загружены!";
                string message = "Ключи успешно загружены в файл.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                string message = "Файл не существует!";
                string caption = "Введите корректное имя файла.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
        }
    }
}

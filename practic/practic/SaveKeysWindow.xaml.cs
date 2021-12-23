using System.Windows;
using System.IO;

namespace practic
{
    public partial class SaveKeysWindow : Window
    {
        public SaveKeysWindow()
        {
            InitializeComponent();
        }
        public RSA rsa;

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SaveFileName_TextBox.Text != "")
            {
                string publicKey = rsa.publicKey_TextBox.Text;
                string secretKey = rsa.secretKey_TextBox.Text;
                string sessionKey = rsa.sessionKey_TextBox.Text;
                using (StreamWriter writer = new StreamWriter(SaveFileName_TextBox.Text))
                {
                    writer.WriteLine(publicKey);
                    writer.WriteLine(secretKey);
                    writer.WriteLine(sessionKey);
                }
                MessageBox.Show("Ключи успешно сохранены!", "Ключи сохранены", MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно введено имя файла!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}

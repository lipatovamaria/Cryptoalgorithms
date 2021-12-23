using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CryptographyClassLybrary;

namespace practic
{
    public partial class RSA : Window
    {
        public RSA()
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

        public SelectEncryption selectEncryption;
        public MainWindow mainWindow;
        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            publicKey_TextBox.Clear();
            publicKey_TextBox.FontSize = 14;
            publicKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);

            secretKey_TextBox.Clear();
            secretKey_TextBox.FontSize = 14;
            secretKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);

            sessionKey_TextBox.Clear();
            sessionKey_TextBox.FontSize = 14;
            sessionKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
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

        private void GenerateKeys_Click(object sender, RoutedEventArgs e)
        {
            ulong publicExponent = 0;
            ulong secretExponent = 0;
            ulong modulus = 0;
            RSAEncryptor.GenerateKeys(ref publicExponent, ref secretExponent, ref modulus);

            publicKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
            publicKey_TextBox.FontSize = 14;
            publicKey_TextBox.Text = $"{publicExponent} {modulus}";
            secretKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
            secretKey_TextBox.FontSize = 14;
            secretKey_TextBox.Text = $"{secretExponent} {modulus}";
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if ((secretKey_TextBox.Text == "Введите ключ") || (publicKey_TextBox.Text == "") || (publicKey_TextBox.Text == "Введите ключ") || (secretKey_TextBox.Text == ""))
            {
                string caption = "Некорректные ключи!";
                string message = "Введите корректные ключи для процедуры шифрования/дешифрования.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    string message = mainWindow.sourceText.Text;
                    string publicKey = publicKey_TextBox.Text;
                    string publicExponentSentence = "";
                    for (int i = 0; i < publicKey.Length; i++)
                    {
                        if (publicKey[i] == ' ')
                        {
                            publicKey = publicKey.Substring(i + 1);
                            break;
                        }
                        publicExponentSentence += publicKey[i];
                    }
                    ulong publicExponent = Convert.ToUInt64(publicExponentSentence);
                    string modulusSentence = publicKey;
                    ulong modulus = Convert.ToUInt64(modulusSentence);
                    Tuple<string, string> encryptedPair = RSAEncryptor.RSAEncryption(message, publicExponent, modulus);
                    sessionKey_TextBox.Foreground = new SolidColorBrush(Colors.Black);
                    sessionKey_TextBox.FontSize = 14;
                    sessionKey_TextBox.Text = encryptedPair.Item1;
                    mainWindow.cryptText.Text = encryptedPair.Item2;
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
            if ((secretKey_TextBox.Text == "Введите ключ") || (publicKey_TextBox.Text == "") || (publicKey_TextBox.Text == "Введите ключ") || (secretKey_TextBox.Text == "") || (sessionKey_TextBox.Text == "Введите ключ") || (sessionKey_TextBox.Text == ""))
            {
                string caption = "Некорректные ключи!";
                string message = "Введите корректные ключи для процедуры шифрования/дешифрования.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    string message = mainWindow.sourceText.Text;
                    string secretKey = secretKey_TextBox.Text;
                    string secretExponentSentence = "";
                    for (int i = 0; i < secretKey.Length; i++)
                    {
                        if (secretKey[i] == ' ')
                        {
                            secretKey = secretKey.Substring(i + 1);
                            break;
                        }
                        secretExponentSentence += secretKey[i];
                    }
                    ulong secretExponent = Convert.ToUInt64(secretExponentSentence);
                    string modulusSentence = secretKey;
                    ulong modulus = Convert.ToUInt64(modulusSentence);
                    string sessionKey = sessionKey_TextBox.Text;
                    string decryptedMessage = RSAEncryptor.RSADecryption(new Tuple<string, string>(sessionKey, message),
                        secretExponent, modulus);
                    mainWindow.cryptText.Text = decryptedMessage;
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

        private void SaveKeys_Click(object sender, RoutedEventArgs e)
        {
            if ((secretKey_TextBox.Text == "Введите ключ") || (publicKey_TextBox.Text == "")||(publicKey_TextBox.Text == "Введите ключ") || (secretKey_TextBox.Text == "") || (sessionKey_TextBox.Text == "Введите ключ") || (sessionKey_TextBox.Text == ""))
            {
                string caption = "Некорректные ключи!";
                string message = "Введите корректные ключи для процедуры шифрования/дешифрования.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                SaveKeysWindow saveKeysWindow = new SaveKeysWindow();
                saveKeysWindow.rsa = this;
                saveKeysWindow.Show();
            }
        }

        private void LoadKeys_Click(object sender, RoutedEventArgs e)
        {
            LoadKeysWindow loadKeysWindow = new LoadKeysWindow();
            loadKeysWindow.rsa = this;
            loadKeysWindow.Show();
        }
    }
}

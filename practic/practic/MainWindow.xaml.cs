using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace practic
{    
    public partial class MainWindow : Window
    {
        public TXTFileService sourceText = new TXTFileService();
        public TXTFileService cryptText = new TXTFileService();
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Text.Clear();
            Text.Foreground = new SolidColorBrush(Colors.Black);
            Text.FontSize = 14;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if ((Text.Text == "")||(Text.Text == "Введите текст или откройте файл"))
            {
                string caption = "Некорректный текст!";
                string message = "Введите корректный текст для выполнения процедуры шифрования/дешифрования.";
                MessageBox.Show(message, caption, MessageBoxButton.OK);
            }
            else
            {
                sourceText.Text = Text.Text;
                SelectEncryption selectEncryption = new SelectEncryption();
                selectEncryption.mainWindow = this;
                selectEncryption.Show();
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            Text.Clear();
            Text.Foreground = new SolidColorBrush(Colors.Black);
            Text.FontSize = 14;
            DialogWindow dialogWindow = new DialogWindow();
            dialogWindow.mainWindow = this;
            dialogWindow.Show();
        }
    }
}

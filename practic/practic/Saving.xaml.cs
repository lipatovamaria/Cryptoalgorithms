using System.Windows;

namespace practic
{
    /// <summary>
    /// Логика взаимодействия для Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        public Saving()
        {
            InitializeComponent();
        }
        public MainWindow mainWindow;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.cryptText.Save(SaveFileName.Text, mainWindow.cryptText.Text);
            this.Close();
        }
    }
}

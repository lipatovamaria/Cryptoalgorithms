using System.Windows;


namespace practic
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public MainWindow mainWindow;

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.sourceText.Open(OpenFileName.Text);
            mainWindow.Text.Text = mainWindow.sourceText.Text;
            this.Close();
        }            
    }
}

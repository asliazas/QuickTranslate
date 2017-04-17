using System.Windows;
using System.Windows.Input;
using QuickTranslate.App.ViewModel;

namespace QuickTranslate.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainViewModel ViewModel
        {
            get { return _viewModel; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnWindowLoaded;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            e.Cancel = true;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
            _viewModel = DataContext as MainViewModel;
        }

    }
}

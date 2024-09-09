using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestAirport._Repositories.Implementations;
using TestAirport._Services.Implementations;
using TestAirport._Services.Interfaces;
using TestAirport.ViewModel;

namespace TestAirport.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ILoadSaveService loadSaveService)
        {
            InitializeComponent();
            DataContext = new MainVM(loadSaveService);
        }
    }
}
using System.Windows;
using Dashboard.ViewModels;

namespace Dashboard;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(ViewModelLocater viewModelLocator)
    {
        InitializeComponent();
        this.DataContext = viewModelLocator.HousingMarketFactorsViewModel;
    }
}

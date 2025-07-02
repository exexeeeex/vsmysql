using InterfaceDB.View;
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

namespace InterfaceDB;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowPassesList_Click(object sender, RoutedEventArgs e)
    {
        var passesListWindow = new PassList();

        passesListWindow.Show();
    }

    private void ShowVisitsList_Click(object sender, RoutedEventArgs e)
    {
        var visitsList = new VisitsList();

        visitsList.Show();
    }

    private void ShowPassManager_Click(object sender, RoutedEventArgs e)
    {
        var passManager = new PassManage();

        passManager.Show();
    }
}
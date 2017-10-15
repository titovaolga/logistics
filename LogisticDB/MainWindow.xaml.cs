using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LogisticDB
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    LogisticData db;
        
    public MainWindow()
    {
      InitializeComponent();
      db = new LogisticData();
    }

    /*private void GetCitiesButton_Click(object sender, RoutedEventArgs e)
    {
     // var strs = new string[] {"a", "b" };
     // var num = new [] { 1, 2 };
     
      CitiesListView.ItemsSource = db.GetCities();
    }*/

    private void BuyCarButton_Click(object sender, RoutedEventArgs e)
    {
        BuyCarWindow.ShowBuyDialog(db);
    }

    private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
    {
        MakeOrderWindow.ShowMakeOrderDialog(db);
    }
  }
}









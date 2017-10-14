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
using System.Windows.Shapes;

namespace LogisticDB
{
    /// <summary>
    /// Логика взаимодействия для BuyCarWindow.xaml
    /// </summary>
    public partial class BuyCarWindow : Window
    {
        LogisticData db;
        BuyCarWindow()
        {
            InitializeComponent();
        }

        public static void ShowBuyDialog(LogisticData db)
        {
            var win = new BuyCarWindow();
            win.db = db;
            win.CitiesComboBox.ItemsSource = db.GetCities();
            win.CarTypeComboBox.ItemsSource = db.GetCarTypes();
            win.ShowDialog();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;
            if (CitiesComboBox.SelectedItem == null || CarTypeComboBox.SelectedItem == null ||
                !double.TryParse(CostTextBox.Text, out cost) || string.IsNullOrWhiteSpace(NumberTextBox.Text))
            {
                MessageBox.Show("Check input data", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                db.BuyCar(CitiesComboBox.SelectedItem as City, 
                    CarTypeComboBox.SelectedItem as CarType, 
                    DateCalender.DisplayDate,
                    cost,
                    NumberTextBox.Text);

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

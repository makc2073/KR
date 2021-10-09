using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PR10ROMEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new PR10ROMEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridRegistrations.ItemsSource = context.Order.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newRegistration = new Order();
            context.Order.Add(newRegistration);
            var win = new WindowAdd(context, newRegistration);
            win.ShowDialog();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridRegistrations.SelectedItem as Order;
            if (row == null)
            {
                MessageBox.Show("Удалено");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Уверены что хотите удалить?", "Подтверждание удаления",  MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Order.Remove(row);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = sender as Button;
            var currentRegistration = btnEdit.DataContext as Order;
            var win = new WindowAdd(context, currentRegistration);
            win.ShowDialog();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            ShowTable();
        }
    }
}

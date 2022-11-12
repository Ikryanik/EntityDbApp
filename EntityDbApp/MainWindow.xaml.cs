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
using EntityDbApp.Models;

namespace EntityDbApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userDataGrid.ItemsSource = App.Entity.User.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserWindow();
            userWindow.ShowDialog();

            userDataGrid.ItemsSource = App.Entity.User.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = userDataGrid.SelectedItem as User;

            if (item != null)
            {
                var userWindow = new UserWindow(item);
                userWindow.ShowDialog();

                userDataGrid.ItemsSource = App.Entity.User.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = userDataGrid.SelectedItem as User;

            var item = App.Entity.User.FirstOrDefault(x => x.Id == result.Id);

            if (item != null)
            {
                App.Entity.User.Remove(item);
                App.Entity.SaveChanges();
                userDataGrid.ItemsSource = App.Entity.User.ToList();
            }

        }
    }
}

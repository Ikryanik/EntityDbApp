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
using System.Windows.Shapes;
using EntityDbApp.Models;

namespace EntityDbApp
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private User user = new User();
        private bool isAdd = true;
        public UserWindow(User userFromGrid = null)
        {
            InitializeComponent();

            if (userFromGrid != null)
            {
                user = userFromGrid;
                isAdd = false;
            }

            grid1.DataContext = user;

            idRoleComboBox.ItemsSource = App.Entity.Role.ToList();
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isAdd)
                {
                    if (App.user.IdRole == 2 && user.IdRole == 1)
                    {
                        MessageBox.Show("Недостаточно прав");
                        return;
                    }
                    App.Entity.User.Add(user);
                }
                
                App.Entity.SaveChanges();

                Close();
            }
            catch
            {
                MessageBox.Show("Неверные данные");
            }

        }
    }
}

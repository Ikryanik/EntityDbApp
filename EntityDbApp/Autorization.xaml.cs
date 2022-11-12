﻿using System;
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

namespace EntityDbApp
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var pass = tbPass.Text;

            var result = App.Entity.User.FirstOrDefault(x => x.Login == login && x.Password == pass);

            if (result != null)
            {
                App.user = result;

                var window = new MainWindow();
                window.Show();
                Close();
            }
        }
    }
}

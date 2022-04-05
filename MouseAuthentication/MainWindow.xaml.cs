using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using MouseAuthentication.Authentication.Models;
using MouseAuthentication.Authentication.Repository;
using MouseAuthentication.Signature;
using MouseAuthentication.Signature.Models;

namespace MouseAuthentication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click( object sender, RoutedEventArgs e )
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            loginWindow.Left = 200;
            loginWindow.Top = 200;
            loginWindow.Show();
            //this.Hide();
        }

        private void RegisterButton_Click( object sender, RoutedEventArgs e )
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Owner = this;
            registerWindow.Left = 400;
            registerWindow.Top = 200;
            registerWindow.Show();
            //this.Hide();
        }
    }
}

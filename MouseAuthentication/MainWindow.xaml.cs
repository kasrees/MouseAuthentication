using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using MouseAuthentication.Signature;
using MouseAuthentication.Signature.Models;

namespace MouseAuthentication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Point> _points = new List<Point>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InkCanvas_MouseMove( object sender, MouseEventArgs e )
        {
            if ( e.MouseDevice.LeftButton == MouseButtonState.Pressed )
            {
                _points.Add( Mouse.GetPosition( Application.Current.MainWindow ) );
            }
        }

        private void Login_Click( object sender, RoutedEventArgs e )
        {
            string signature = SignatureRecognition.GetSignature(_points);
            loginBox.Text = signature;
        }

        private void Reset_Click( object sender, RoutedEventArgs e )
        {
            _points.Clear();
            InkCanvas.Strokes.Clear();
        }
    }
}

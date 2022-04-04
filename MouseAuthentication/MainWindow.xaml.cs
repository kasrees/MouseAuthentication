using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MouseAuthentication.Models;
using MouseAuthentication.Services;

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
            foreach(var point in _points)
            {
                listBox.Items.Add( point.ToString() );
            }
            MovementDetection movementDetection = new MovementDetection(_points);
            List<Movement> movements = new List<Movement>();
            movements = movementDetection.Get();

            label.Content = $"{movements.Sum( x => x.DiffX )}, {movements.Sum( y => y.DiffY )}";
            

            foreach (var movement in movements )
            {
                listBox1.Items.Add( movement.ToString() );
            }
        }

        private void Reset_Click( object sender, RoutedEventArgs e )
        {
            _points.Clear();
            listBox.Items.Clear();
            listBox1.Items.Clear();
            label.Content = "";
        }
    }
}

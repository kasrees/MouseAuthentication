using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using MouseAuthentication.Authentication;
using MouseAuthentication.Signature;

namespace MouseAuthentication
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private List<Point> _points = new List<Point>();
        private UserService _userService = new UserService();

        public RegisterWindow()
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

        private void Register_Click( object sender, RoutedEventArgs e )
        {
            string signature = SignatureRecognition.GetSignature( _points );

            bool isRegister = _userService.Register( loginBox.Text, signature );

            Trace.WriteLine($"{loginBox.Text}, {signature}");

            if ( isRegister )
            {
                loginBox.Text = "Success";
                this.Owner.Show();
                this.Owner.Left = 200;
                this.Owner.Top = 200;
                this.Close();
            }
            loginBox.Text = "Fail";
        }

        private void Reset_Click( object sender, RoutedEventArgs e )
        {
            _points.Clear();
            InkCanvas.Strokes.Clear();
        }
    }
}

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
using Fortune.Navigate;

namespace Fortune
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseFrame.Navigate(new Pages.LoginPage());
            Manager.MainFrame = BaseFrame;
        }

        private void BaseFrame_ContentRendered(object sender, EventArgs e)
        {
                if (BaseFrame.CanGoBack)
                {
                    ResizeMode = ResizeMode.CanResize;
                    BtnBack.Visibility = Visibility.Visible;
            }
                else
                {
                    ResizeMode = ResizeMode.NoResize;
                    BtnBack.Visibility = Visibility.Hidden;
                }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}

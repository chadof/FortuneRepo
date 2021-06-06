using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Fortune.DB;
using Fortune.Navigate;
using System.Xml;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.IO.Packaging;

namespace Fortune.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrintPage.xaml
    /// </summary>
    public partial class PrintPage : Page
    {
        public PrintPage()
        {
            InitializeComponent();
            List<Order> currentOrder = FortuneDBEntities.GetContext().Order.ToList();
            currentOrder = currentOrder.Where(p => p.Status==true).ToList();
            ordersGrid.ItemsSource = currentOrder;
        }
        private void Button_saveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XPS Files (.xps)|.xps";
            if (sfd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(sfd.FileName, FileAccess.Write);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                writer.Write(documentViewer.Document as FixedDocument);
                doc.Close();
            }
        }
    }
}

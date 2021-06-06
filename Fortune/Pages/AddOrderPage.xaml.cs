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
using Fortune.DB;
using Fortune.Navigate;

namespace Fortune.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order newOrder = new Order();
        public AddOrderPage(Order selectedOrder)
        {
            if (selectedOrder != null)
                newOrder = selectedOrder;
            DataContext = newOrder;
            InitializeComponent();
            listVService.ItemsSource = FortuneDBEntities.GetContext().Service.ToList();
            cbClient.ItemsSource = FortuneDBEntities.GetContext().Client.ToList();
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            var arrayService = listVService.SelectedItems.Cast<Service>().ToList();
            newOrder.DateOfCreation = DateTime.Today;
            newOrder.Status = false;

            StringBuilder errors = new StringBuilder();
            if (newOrder.Client==null)
                errors.AppendLine("Укажите Клиента");
            if (newOrder.Service == null)
                errors.AppendLine("Укажите Услуги");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (newOrder.Id == 0)
            {
                try
                {
                    for (int i = 0; i < arrayService.Count; i++)
                    {
                        newOrder.ServiceId = arrayService[i].Id;

                        FortuneDBEntities.GetContext().Order.Add(newOrder);
                        FortuneDBEntities.GetContext().SaveChanges();
                    }
                    MessageBox.Show("Данные успешно сохранены");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            Manager.MainFrame.GoBack();
        }

    }
}

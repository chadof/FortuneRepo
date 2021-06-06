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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            UpdateService();
            UpdateClient();
            UpdateOrder();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            clientsGrid.Visibility = Visibility.Hidden;
            ordersGrid.Visibility = Visibility.Visible;
            serviceGrid.Visibility = Visibility.Hidden;

            btnAddClient.Visibility = Visibility.Hidden;
            btnAddOrder.Visibility = Visibility.Visible;
            btnAddService.Visibility = Visibility.Hidden;

            btnDeleteClient.Visibility = Visibility.Hidden;
            btnDeleteOrder.Visibility = Visibility.Visible;
            btnDeleteService.Visibility = Visibility.Hidden;
            btnSuccessful.Visibility = Visibility.Visible;

            btnPrint.Visibility = Visibility.Visible;

            searchClients.Visibility = Visibility.Hidden;
            searchOrders.Visibility = Visibility.Visible;
            searchService.Visibility = Visibility.Hidden;

        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            clientsGrid.Visibility = Visibility.Visible;
            ordersGrid.Visibility = Visibility.Hidden;
            serviceGrid.Visibility = Visibility.Hidden;

            btnAddClient.Visibility = Visibility.Visible;
            btnAddOrder.Visibility = Visibility.Hidden;
            btnAddService.Visibility = Visibility.Hidden;

            btnDeleteClient.Visibility = Visibility.Visible;
            btnDeleteOrder.Visibility = Visibility.Hidden;
            btnDeleteService.Visibility = Visibility.Hidden;
            btnSuccessful.Visibility = Visibility.Hidden;

            btnPrint.Visibility = Visibility.Hidden;

            searchClients.Visibility = Visibility.Visible;
            searchOrders.Visibility = Visibility.Hidden;
            searchService.Visibility = Visibility.Hidden;
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            clientsGrid.Visibility = Visibility.Hidden;
            ordersGrid.Visibility = Visibility.Hidden;
            serviceGrid.Visibility = Visibility.Visible;

            btnAddClient.Visibility = Visibility.Hidden;
            btnAddOrder.Visibility = Visibility.Hidden;
            btnAddService.Visibility = Visibility.Visible;

            btnDeleteClient.Visibility = Visibility.Hidden;
            btnDeleteOrder.Visibility = Visibility.Hidden;
            btnDeleteService.Visibility = Visibility.Visible;
            btnSuccessful.Visibility = Visibility.Hidden;

            btnPrint.Visibility = Visibility.Hidden;

            searchClients.Visibility = Visibility.Hidden;
            searchOrders.Visibility = Visibility.Hidden;
            searchService.Visibility = Visibility.Visible;
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderForRemoving = ordersGrid.SelectedItems.Cast<Order>().ToList();
            if (orderForRemoving.Count > 0)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующие {orderForRemoving.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FortuneDBEntities.GetContext().Order.RemoveRange(orderForRemoving);
                        FortuneDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        UpdateOrder();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddOrderPage(null));
        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            var serviceForRemoving = serviceGrid.SelectedItems.Cast<Service>().ToList();
            if (serviceForRemoving.Count > 0)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующие {serviceForRemoving.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FortuneDBEntities.GetContext().Service.RemoveRange(serviceForRemoving);
                        FortuneDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        UpdateService();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddServicePage(null));
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = clientsGrid.SelectedItems.Cast<Client>().ToList();
            if (clientForRemoving.Count > 0)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForRemoving.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FortuneDBEntities.GetContext().Client.RemoveRange(clientForRemoving);
                        FortuneDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        UpdateClient();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddClientPage(null));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FortuneDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                UpdateClient();
                UpdateService();
                UpdateOrder();
            }
        }
        private void UpdateClient()
        {
            List<Client> currentClient = FortuneDBEntities.GetContext().Client.ToList();
            currentClient = currentClient.Where(p => p.LastName.ToLower().Contains(searchClients.Text.ToLower()) || p.NumberOfTheCar.ToLower().Contains(searchClients.Text.ToLower())).ToList();
            clientsGrid.ItemsSource = currentClient;
        }
        private void UpdateService()
        {
            List<Service> currentService = FortuneDBEntities.GetContext().Service.ToList();
            currentService = currentService.Where(p => p.Name.ToLower().Contains(searchService.Text.ToLower()) ).ToList();
            serviceGrid.ItemsSource = currentService;
        }
        private void UpdateOrder()
        {
            List<Order> currentOrder = FortuneDBEntities.GetContext().Order.ToList();
            currentOrder = currentOrder.Where(p => p.Client.LastName.ToLower().Contains(searchOrders.Text.ToLower()) ).ToList();
            ordersGrid.ItemsSource = currentOrder;
        }
        private void btnSuccessful_Click(object sender, RoutedEventArgs e)
        {
            var orderForSuccsess = ordersGrid.SelectedItems.Cast<Order>().ToList();
            try
            {
                for (int i = 0; i < orderForSuccsess.Count; i++)
                {
                    DataContext = orderForSuccsess[i];
                    orderForSuccsess[i].Status = true;
                    FortuneDBEntities.GetContext().SaveChanges();
                }
                MessageBox.Show("Данные успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            UpdateOrder();
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddOrderPage((sender as Button).DataContext as Order));
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddServicePage((sender as Button).DataContext as Service));
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddClientPage((sender as Button).DataContext as Client));
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.PrintPage());
        }

        private void searchOrders_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOrder();
        }

        private void searchService_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateService();
        }

        private void searchClients_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClient();
        }
    }
}

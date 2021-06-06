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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        private Service newService = new Service();

        public AddServicePage(Service selectedService)
        {
            InitializeComponent();
            if (selectedService != null)
                newService = selectedService;
            DataContext = newService;
        }

        private void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(newService.Name))
                errors.AppendLine("Укажите название");
            if (newService.Cost==0)
                errors.AppendLine("Укажите стоимость услуги");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (newService.Id == 0)
                FortuneDBEntities.GetContext().Service.Add(newService);

            try
            {
                FortuneDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Manager.MainFrame.GoBack();
        }
    }
}

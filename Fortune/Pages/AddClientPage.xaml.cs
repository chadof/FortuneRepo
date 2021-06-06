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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private Client newClient = new Client();
        public AddClientPage(Client selectedClient)
        {
            if (selectedClient != null)
                newClient = selectedClient;
            InitializeComponent();
            cbGender.ItemsSource = FortuneDBEntities.GetContext().Gender.ToList();
            DataContext = newClient;
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(newClient.FirstName))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(newClient.LastName))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(newClient.Phone))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(newClient.NumberOfTheCar))
                errors.AppendLine("Укажите номер машины");
            if (newClient.Birthday==null)
                errors.AppendLine("Укажите дату рождения");
            if (newClient.Gender==null)
                errors.AppendLine("Укажите пол");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (newClient.Id == 0)
                FortuneDBEntities.GetContext().Client.Add(newClient);
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

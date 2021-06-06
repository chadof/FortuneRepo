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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private Users newUser = new Users();
        public bool isAdd;
        public AddUserPage(Users selectedUser)
        {
            if (selectedUser != null)
            {
                isAdd = false;
                txtbLogin.IsEnabled = false;
                newUser = selectedUser;
            }
            InitializeComponent();
            cbRole.ItemsSource = FortuneDBEntities.GetContext().Role.ToList();
            DataContext = newUser;
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e) 
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(newUser.FirstName))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(newUser.LastName))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(newUser.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(newUser.Password))
                errors.AppendLine("Укажите пароль");
            if (newUser.Role == null)
                errors.AppendLine("Укажите роль");


            if (errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (isAdd)
            {
                FortuneDBEntities.GetContext().Users.Add(newUser);
            }
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

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
using Fortune.DB;

namespace Fortune.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            UpdateUser();
            UpdateHistory(); 
        }

        private void btnLoginHistory_Click(object sender, RoutedEventArgs e)
        {
            loginHistoryGrid.Visibility = Visibility.Visible;
            usersGrid.Visibility = Visibility.Hidden;
            btnAddUser.Visibility = Visibility.Hidden;
            btnDeleteUser.Visibility = Visibility.Hidden;
            searchUsers.Visibility = Visibility.Hidden;
            searchLoginHistory.Visibility = Visibility.Visible;

        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            usersGrid.Visibility = Visibility.Visible;
            loginHistoryGrid.Visibility = Visibility.Hidden;
            btnAddUser.Visibility = Visibility.Visible;
            btnDeleteUser.Visibility = Visibility.Visible;
            searchUsers.Visibility = Visibility.Visible;
            searchLoginHistory.Visibility = Visibility.Hidden;
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var userForRemoving= usersGrid.SelectedItems.Cast<Users>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {userForRemoving.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FortuneDBEntities.GetContext().Users.RemoveRange(userForRemoving);
                        FortuneDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        UpdateUser();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddUserPage(null));
        }
        private void UpdateUser()
        {
            List<Users> currentUser = FortuneDBEntities.GetContext().Users.ToList();
            currentUser = currentUser.Where(p => p.LastName.ToLower().Contains(searchUsers.Text.ToLower()) || p.Login.ToLower().Contains(searchUsers.Text.ToLower())).ToList();
            usersGrid.ItemsSource = currentUser;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FortuneDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                UpdateUser();
                UpdateHistory();
            }
        }
        private void searchUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUser();
        }

        private void UpdateHistory()
        {
            List<LoginHistory> currentHistory = FortuneDBEntities.GetContext().LoginHistory.ToList();
            currentHistory = currentHistory.Where(p => p.Login.ToLower().Contains(searchLoginHistory.Text.ToLower())).ToList();
            loginHistoryGrid.ItemsSource = currentHistory;
        }
        private void searchLoginHistory_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateHistory();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUserPage((sender as Button).DataContext as Users));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fortune.Pages;
using Fortune.Navigate;
using System.Windows.Controls;
using System.Windows;
using Fortune.DB;
using Fortune.History;

namespace Fortune.Navigate
{
    public class Login
    {
        public static void Autorisatoin(string pass, string login)
        {
            int i = 0;
            foreach (var user in FortuneDBEntities.GetContext().Users)
            {
                if (login == user.Login && pass == user.Password)
                {
                    if (user.RoleId == 1)
                    {
                        Manager.MainFrame.Navigate(new Pages.ManagerPage());
                        HistoryLog.HistoryRecord(login, true);
                        MessageBox.Show("Вы успешно авторизовались как Менеджер");
                        i = 1;
                    }
                    else if (user.RoleId == 2)
                    {
                        Manager.MainFrame.Navigate(new Pages.AdminPage());
                        HistoryLog.HistoryRecord(login, true);
                        MessageBox.Show("Вы успешно авторизовались как Администратор");
                        i = 1;
                    }

                }
                if (login == user.Login && pass != user.Password)
                {
                    HistoryLog.HistoryRecord(login, false);
                }

            }
            if (i == 0)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            try
            {
                FortuneDBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

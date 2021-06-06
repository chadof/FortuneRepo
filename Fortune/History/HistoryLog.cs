using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fortune.DB;
using System.Windows;
using Fortune.Navigate;

namespace Fortune.History
{
    public class HistoryLog
    {
        public static void HistoryRecord(string login, bool access)
        { 
           // try
           // {
                LoginHistory historyEnter = new LoginHistory();
                historyEnter.Login = login;
                historyEnter.Date = DateTime.Now;
                historyEnter.Successful = access;
                FortuneDBEntities.GetContext().LoginHistory.Add(historyEnter);
           // }
            //catch (Exception ex)
           // {
            //    Console.WriteLine(ex.Message.ToString());
           // }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using AID.Models;

namespace AID
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        public ObservableCollection<Models.login> logi;
        string user;
        string pass;
        int id;

        public UserInfo()
        {
            InitializeComponent();
            logi = new ObservableCollection<Models.login>(Data.GetLogin());
            user = logi[0].username;
            pass = logi[0].password;
            id = logi[0].Id;
            txtUIUsername.DefText = user;
            txtUIPassword.DefText = pass;
        }

        private void btnUIOK_Click(object sender, RoutedEventArgs e)
        {
            Data.UpdateUserInfo(id,txtUIUsername.Text,txtUIPassword.Text);
            this.Close();
        }

        private void btnUICancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

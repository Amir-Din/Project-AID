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
    public partial class login : Window
    {
        public ObservableCollection<Models.login> logi;
        string user;
        string pass;

        public login()
        {
            InitializeComponent();
            logi = new ObservableCollection<Models.login>(Data.GetLogin());
            user = logi[0].username;
            pass = logi[0].password;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chbxPass_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chbxPass_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool status;

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (user == txtUser.Text && pass == txtPass.Text)
            {
                status = true;
                this.Close();
            }
            else
            {
                txstar1.Visibility = Visibility.Visible;
                txstar2.Visibility = Visibility.Visible;
                bortxError.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

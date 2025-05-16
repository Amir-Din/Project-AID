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
    /// Interaction logic for CharityMange.xaml
    /// </summary>
    public partial class CharityMange : Window
    {
        public ObservableCollection<charity> Charity;
        int charityId;
        bool s = true;

        public CharityMange()
        {
            InitializeComponent();

            Charity = new ObservableCollection<charity>(Data.GetCharities());

            for(int i = 0; i < Charity.Count; i++)
            {
                lstCharity.Items.Add(Charity[i].title);
            }
        }
        
        private void Refresh()
        {
            s = false;
            Charity = new ObservableCollection<charity>(Data.GetCharities());
            lstCharity.Items.Clear();
            for(int i = 0; i < Charity.Count; i++)
            {
                lstCharity.Items.Add(Charity[i].title);
            }
            txtCharity.Text = "";
            s = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCharity.Text))
            {
                charity cha = new charity
                {
                    title = txtCharity.Text
                };

                Data.AddCharity(cha);
                Refresh();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCharity.Text))
            {
                Data.UpdateCharity(charityId, txtCharity.Text);
                Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCharity.Text))
            {
                Data.DeleteCharity(charityId);
                Refresh();
            }
        }

        private void lstCharity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (s)
            {
                charityId = Charity[lstCharity.SelectedIndex].id;
                txtCharity.Text = Charity[lstCharity.SelectedIndex].title;
            }
        }
    }
}

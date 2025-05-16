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
    public partial class CharitySearch : Window
    {
        public CharitySearch()
        {
            InitializeComponent();
        }

        private void btnSearchCharityCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public ObservableCollection<charity> charities;
        public bool chsearch;
        public string CharityName;
        private void btnSearchCharityOK_Click(object sender, RoutedEventArgs e)
        {
            chsearch = true;
            this.Close();
        }

        private void txtCharitySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Height = 235;
            lstsearch.Items.Clear();
            lstsearch.Height = 0;
            if (!string.IsNullOrEmpty(txtCharitySearch.Text))
            {
                charities = new ObservableCollection<charity>(Data.SearchCharity(txtCharitySearch.Text));
                for (int i = 0; i < charities.Count; i++)
                {
                    lstsearch.Items.Add(charities[i].title);
                    lstsearch.Height += 35;
                }
                if (lstsearch.Items.Count == 1)
                    lstsearch.Height = 50;
            }
            this.Height += lstsearch.Height;
        }

        private void lstsearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstsearch.SelectedItem != null)
            {
                CharityName = lstsearch.SelectedItem.ToString();
                txtCharitySearch.Text = CharityName;
            }
        }
    }
}

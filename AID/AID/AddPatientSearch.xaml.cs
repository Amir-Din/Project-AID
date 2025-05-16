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
    public partial class AddPatientSearch : Window
    {
        public AddPatientSearch()
        {
            InitializeComponent();
        }
        public bool apsStatus;
        public int patd;
        public ObservableCollection<patient> patients;
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            apsStatus = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstsearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patd = patients[lstsearch.SelectedIndex].Id;
        }

        public void txtPatientSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Height = 235;
            lstsearch.Items.Clear();
            lstsearch.Height = 0;
            if (!string.IsNullOrEmpty(txtPatientSearch.Text))
            {
                patients = new ObservableCollection<patient>(Data.SearchPatient(txtPatientSearch.Text));
                for (int i = 0; i < patients.Count; i++)
                {
                    lstsearch.Items.Add(patients[i].Name+" " + patients[i].NationalCode);
                    lstsearch.Height += 30;
                }
                if (lstsearch.Items.Count == 1)
                    lstsearch.Height = 50;
            }
            this.Height += lstsearch.Height;
        }
    }
}

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
    public partial class AddPatient : Window
    {
        public string visTim;
        public AddPatient()
        {
            InitializeComponent();
        }

        private static int GetInsurType(string selec)
        {
            switch (selec)
            {
                case "آزاد":
                    return 0;
                case "بیمه تامین اجتماعی":
                    return 1;
                case "بیمه خدمات درمانی":
                    return 2;
                case "بیمه نیرو های مسلح":
                    return 3;
                case "گردشگری":
                    return 4;
                case "عکس و آزمایش":
                    return 5;
                case "تجدید نسخه":
                    return 6;
                case "رایگان":
                    return 7;
                case "تخفیف پزشک":
                    return 8;
                case "قرارداد خیریه":
                    return 9;
                case "سایر":
                    return 10;
                default: 
                    return 0;
            }
        }

        public ObservableCollection<patient> Patients;
        public ObservableCollection<visit> Visits;
        public bool apstatus;
        public DateTime dt;

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (checkVisiSearch.IsChecked == false)
            {
                patient pat = new patient
                {
                    Name = txtNF.Text,
                    NationalCode = txtID.Text,
                    PhoneNumber = txtPN.Text,
                    Address = txtAddress.Text
                };
                Data.AddPatients(pat);

                Patients = new ObservableCollection<patient>(Data.GetPatients());

                visit vis = new visit
                {
                    patientId = Patients[Patients.Count - 1].Id,
                    insurance = GetInsurType(comboInsur.Text),
                    visitDateTime = dt,
                    visitTime = visTim,
                    status = 1,
                    discountValue = "0"
                };
                Data.AddVisits(vis);
            }
            else
            {
                visit vi = new visit
                {
                    patientId = pati,
                    insurance = GetInsurType(comboInsur.Text),
                    visitDateTime = dt,
                    visitTime = visTim,
                    status = 1,
                    discountValue = "0"
                };
                Data.AddVisits(vi);
            }

            apstatus = true;
            this.Close();
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public ObservableCollection<patient> pt;
        public int pati;
        private void checkVisiSearch_Checked(object sender, RoutedEventArgs e)
        {
            AddPatientSearch adp = new AddPatientSearch();
            adp.ShowDialog();
            if (adp.apsStatus == true)
            {
                pt = new ObservableCollection<patient>(Data.GetPatients());
                int k = 0;
                k = adp.patd - 1;
                txtNF.Text = pt[k].Name;
                txtID.Text = pt[k].NationalCode;
                txtPN.Text = pt[k].PhoneNumber;
                txtAddress.Text = pt[k].Address;
                checkVisiSearch.IsChecked = true;
                pati = pt[k].Id;
            }
            else
                checkVisiSearch.IsChecked = false;

        }

        private void checkVisiSearch_Unchecked(object sender, RoutedEventArgs e)
        {
            txtNF.Text = "";
            txtID.Text = "";
            txtPN.Text = "";
            txtAddress.Text = "";
            checkVisiSearch.IsChecked = false;
        }

        private void coItemCharity_Selected(object sender, RoutedEventArgs e)
        {
            CharitySearch CS = new CharitySearch();
            CS.ShowDialog();
            if (CS.chsearch == true)
            {
                txCharity.Text = CS.CharityName;
                txCharity.Visibility = Visibility.Visible;
            }
        }

        private void coItemCharity_Unselected(object sender, RoutedEventArgs e)
        {
            txCharity.Visibility = Visibility.Hidden;
        }

        private void coItemOthers_Selected(object sender, RoutedEventArgs e)
        {
            OthersEx OE = new OthersEx();
            OE.ShowDialog();
        }

        private void coItemOthers_Unselected(object sender, RoutedEventArgs e)
        {
        }
    }
}

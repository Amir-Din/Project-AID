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
    public partial class ViewVisit : Window
    {
        public ObservableCollection<patient> patients;
        public ObservableCollection<visit> visits;
        public int vid;

        public ViewVisit()
        {
            InitializeComponent();
        }

        private void btnCancelVis_Click(object sender, RoutedEventArgs e)
        {
            patients = new ObservableCollection<patient>(Data.GetPatients());
            visits = new ObservableCollection<visit>(Data.GetVisits());
            var vis = visits[0];
            for (int i = 0; i < visits.Count; i++)
            {
                if (visits[i].id == vid)
                {
                    vis = visits[i];
                    break;
                }
            }            vis.status = 3;
            Data.UpdateVisits(vis.id, vis.patientId, vis.charityId, vis.visitTime, vis.discountValue, vis.insurance, vis.status, vis.visitDateTime);
            this.Close();
        }

        private void btnAccVis_Click(object sender, RoutedEventArgs e)
        {
            patients = new ObservableCollection<patient>(Data.GetPatients());
            visits = new ObservableCollection<visit>(Data.GetVisits());
            var vis = visits[0];
            var pat = patients[0];
            for (int i = 0; i < visits.Count; i++)
            {
                if (visits[i].id == vid)
                {
                    vis = visits[i];
                    break;
                }
            }
            vis.status = 2;
            Data.UpdateVisits(vis.id, vis.patientId, vis.charityId, vis.visitTime, vis.discountValue, vis.insurance, vis.status, vis.visitDateTime);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            patients = new ObservableCollection<patient>(Data.GetPatients());
            visits = new ObservableCollection<visit>(Data.GetVisits());
            var vis = visits[0];
            var pat = patients[0];
            for (int i = 0; i < visits.Count; i++)
            {
                if (visits[i].id == vid)
                {
                    vis = visits[i];
                    break;
                }
            }
            for(int l = 0; l < patients.Count; l++)
            {
                if(vis.patientId == patients[l].Id)
                {
                    pat = patients[l];
                    break;
                }
            }
            txVtime.Text = vis.visitTime;
            txVnamefam.Text = pat.Name;
            txVphone.Text = pat.PhoneNumber;
            txVid.Text = pat.NationalCode;
            txVinsure.Text = GetInsurType(vis.insurance);
        }

        private static string GetInsurType(int selec)
        {
            if (selec == 0)
                return "آزاد";
            if (selec == 1)
                return "بیمه تامین اجتماعی";
            if (selec == 2)
                return "بیمه خدمات درمانی";
            if (selec == 3)
                return "بیمه نیرو های مسلح";
            if (selec == 4)
                return "گردشگری";
            if (selec == 5)
                return "عکس و آزمایش";
            if (selec == 6)
                return "تجدید نسخه";
            if (selec == 7)
                return "رایگان";
            if (selec == 8)
                return "تخفیف پزشک";
            if (selec == 9)
                return "قرارداد خیریه";
            if (selec == 10)
                return "سایر";
            return "آزاد";
        }

    }
}

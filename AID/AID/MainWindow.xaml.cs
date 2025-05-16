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
using System.Windows.Threading;
using System.Drawing;
using System.Collections.ObjectModel;
using AID.Models;

namespace AID
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<config> Con;
        public ObservableCollection<patient> Patients;
        public ObservableCollection<visit> visits;
        string ost, vp, vc;
        public MainWindow()
        {
            login logi = new login();
            logi.ShowDialog();
            if (logi.status == false)
                this.Close();
            InitializeComponent();
            Con = new ObservableCollection<config>(Data.GetConfigs());
            ost = Con[0].OfficeStartTime;
            vp = Con[0].VisitPeriod;
            vc = Con[0].VisitCount;
            dateNow.SelectedDate = DateTime.Now.Date;
            loadMainWindow();
            RefreshVis();
        }

        private void loadMainWindow()
        {
            int p = 0;
            for (int i = 0; i < stkmom.Children.Count; i++)
            {
                if (stkmom.Children[i] is StackPanel)
                {
                    var stkch = (StackPanel)stkmom.Children[i];
                    for (int n = 0; n < stkch.Children.Count; n++)
                    {
                        if (stkch.Children[n] is Button)
                        {
                            p++;
                            var btn = (Button)stkch.Children[n];
                            if (btn.Content is StackPanel)
                            {
                                var btstk = (StackPanel)btn.Content;
                                if (btstk.Children[1] is TextBlock)
                                {
                                    var timtext = (TextBlock)btstk.Children[1];
                                    if (n != 0)
                                    {
                                        timtext.Text = OfficeStartTimeControl(ost, vp);
                                        ost = OfficeStartTimeControl(ost, vp);
                                    }
                                    else
                                        timtext.Text = ost;
                                }
                            }
                            if (p <= (int.Parse(vc)))
                                btn.Visibility = Visibility.Visible;
                            else
                                btn.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }

        private void RefreshVis()
        {
            clockNum = 0;
            acceptNum = 0;
            crossNum = 0;
            Patients = new ObservableCollection<patient>(Data.GetPatients());
            visits = new ObservableCollection<visit>(Data.GetVisits());
            int p = 0;
            for (int b = 0; b < visits.Count; b++)
            {
                visstat[b] = false;
            }
            for (int i = 0; i < stkmom.Children.Count; i++)
            {
                if (stkmom.Children[i] is StackPanel)
                {
                    var stkch = (StackPanel)stkmom.Children[i];
                    for (int n = 0; n < stkch.Children.Count; n++)
                    {
                        if (stkch.Children[n] is Button)
                        {
                            p++;
                            var btn = (Button)stkch.Children[n];
                            if (btn.Content is StackPanel)
                            {
                                var btstk = (StackPanel)btn.Content;
                                if (btstk.Children[0] is System.Windows.Controls.Image)
                                {
                                    var img = (System.Windows.Controls.Image)btstk.Children[0];
                                    img.Source = null;
                                }
                                if (btstk.Children[2] is TextBlock)
                                {
                                    var namtext = (TextBlock)btstk.Children[2];
                                    namtext.Text = "";
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < stkmom.Children.Count; i++)
            {
                if (stkmom.Children[i] is StackPanel)
                {
                    var stkch = (StackPanel)stkmom.Children[i];
                    for (int n = 0; n < stkch.Children.Count; n++)
                    {
                        if (stkch.Children[n] is Button)
                        {
                            var btn = (Button)stkch.Children[n];
                            if (btn.Content is StackPanel)
                            {
                                var btstk = (StackPanel)btn.Content;
                                if (btstk.Children[1] is TextBlock)
                                {
                                    var timtext = (TextBlock)btstk.Children[1];

                                    for (int l = 0; l < visits.Count; l++)
                                    {
                                        var vis = visits[l];
                                        if (vis.visitTime == timtext.Text && vis.visitDateTime.Day == dateNow.SelectedDate.Value.Day)
                                        {
                                            if (i == 0)
                                            {
                                                visstat[n] = true;
                                                visid[n] = vis.id;
                                            }
                                            else
                                            {
                                                visstat[(n + 8)] = true;
                                                visid[(n + 8)] = vis.id;
                                            }
                                            for (int r = 0; r < Patients.Count; r++)
                                            {
                                                if (vis.patientId == Patients[r].Id)
                                                {
                                                    if (btstk.Children[2] is TextBlock)
                                                    {
                                                        var nametext = (TextBlock)btstk.Children[2];
                                                        if (Patients[r].Name.Length > 12)
                                                        {
                                                            nametext.FontSize = 16;
                                                        }
                                                        nametext.Text = Patients[r].Name;
                                                    }
                                                }
                                            }
                                            if (btstk.Children[0] is System.Windows.Controls.Image)
                                            {
                                                var img = (System.Windows.Controls.Image)btstk.Children[0];
                                                if (vis.status == 1)
                                                {
                                                    clockNum++;
                                                    img.Source = new BitmapImage(new Uri(@"/wall-clock.png", UriKind.Relative));
                                                }
                                                if (vis.status == 2)
                                                {
                                                    acceptNum++;
                                                    img.Source = new BitmapImage(new Uri(@"/accept.png", UriKind.Relative));
                                                }
                                                if (vis.status == 3)
                                                {
                                                    crossNum++;
                                                    img.Source = new BitmapImage(new Uri(@"/cross.png", UriKind.Relative));
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            txCancel.Text = crossNum.ToString();
            txSuccess.Text = acceptNum.ToString();
            txWait.Text = clockNum.ToString();
        }

        public bool[] visstat = new bool[16];
        public int[] visid = new int[16];

        private string OfficeStartTimeControl(string OST, string VP)
        {
            int sHou, sMin, visp;
            string res, min = "", hou = "";
            hou += OST[0].ToString();
            hou += OST[1].ToString();
            min += OST[3].ToString();
            min += OST[4].ToString();
            sHou = int.Parse(hou);
            sMin = int.Parse(min);
            visp = int.Parse(VP);
            if ((sMin + visp) < 60)
                sMin += visp;
            else
            {
                sMin += visp;
                sMin -= 60;
                sHou++;
            }
            if (sHou == 24)
            {
                sHou = 0;
            }

            if (sMin < 10 && sHou < 10)
                res = "0" + sHou.ToString() + ":0" + sMin.ToString();
            else if (sMin < 10)
                res = sHou.ToString() + ":0" + sMin.ToString();
            else if (sHou < 10)
                res = "0" + sHou.ToString() + ":" + sMin.ToString();
            else
                res = sHou.ToString() + ":" + sMin.ToString();
            return res;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Tim;
            timer.Start();
        }

        public int crossNum = 0;
        public int acceptNum = 0;
        public int clockNum = 0;

        private void Tim(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("yyyy" + "/" + "M" + "/" + "d" + "  " + "H:mm:ss");
        }

        private void txtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                placeHold.Visibility = Visibility.Hidden;
            }
        }

        private void txtSerch_GotFocus(object sender, RoutedEventArgs e)
        {
            placeHold.Visibility = Visibility.Hidden;
        }

        private void txtSerch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                placeHold.Visibility = Visibility.Visible;
            }
        }

        public string visTim;
        private void p1_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[0] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime1.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[0];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings st = new Settings();
            st.ShowDialog();
            Con = new ObservableCollection<config>(Data.GetConfigs());
            ost = Con[0].OfficeStartTime;
            vp = Con[0].VisitPeriod;
            vc = Con[0].VisitCount;
            loadMainWindow();
            RefreshVis();
        }

        private void p2_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[1] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime2.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[1];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p3_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[2] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime3.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[2];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p4_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[3] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime4.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[3];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p5_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[4] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime5.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[4];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p6_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[5] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime6.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[5];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p7_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[6] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime7.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[6];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p8_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[7] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime8.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[7];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p9_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[8] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime9.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[8];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p10_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[9] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime10.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[9];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p11_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[10] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime11.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[10];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p12_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[11] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime12.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[11];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p13_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[12] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime13.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[12];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p14_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[13] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime14.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[13];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            dateNow.SelectedDate = dateNow.SelectedDate.Value.AddDays(1);
            RefreshVis();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            dateNow.SelectedDate = dateNow.SelectedDate.Value.AddDays(-1);
            RefreshVis();
        }

        private void dateNow_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshVis();
        }

        private void btnNextVis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void p15_Click(object sender, RoutedEventArgs e)
        {
            if (visstat[14] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime15.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[14];
                vv.ShowDialog();
            }
            RefreshVis();
        }

        private void p16_Click(object sender, RoutedEventArgs e)

        {
            if (visstat[15] == false)
            {
                AddPatient AP = new AddPatient();
                AP.visTim = txTime16.Text;
                AP.dt = dateNow.SelectedDate.Value;
                AP.ShowDialog();
            }
            else
            {
                ViewVisit vv = new ViewVisit();
                vv.vid = visid[15];
                vv.ShowDialog();
            }
            RefreshVis();
        }
    }
}

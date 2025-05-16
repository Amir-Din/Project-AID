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
using System.Windows.Shapes;
using System.Windows.Forms;
using AID.Models;
using System.Collections.ObjectModel;

namespace AID
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public ObservableCollection<config> Configs;
        string Hou, Min, DeSe;
        public Settings()
        {
            InitializeComponent();
            Configs = new ObservableCollection<config>(Data.GetConfigs());
            Hou += Configs[0].OfficeStartTime[0];
            Hou += Configs[0].OfficeStartTime[1];
            Min += Configs[0].OfficeStartTime[3];
            Min += Configs[0].OfficeStartTime[4];
            comTimStartHou.Text = Hou;
            comTimStartMin.Text = Min;
            NumPosVisDur.Text = Configs[0].VisitPeriod;
            NumVisNum.Text = Configs[0].VisitCount;
            DeSe = Configs[0].CloseWeekDays;
            CheckingCWD();
        }
        public string SerRes, Res, starttime, visitPersiod, visitCount;
        public string[] DeSer = new string[7];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckCloseWeekDays();
            Res = Serialize(DeSer);
            starttime = comTimStartHou.Text + ":" + comTimStartMin.Text;
            visitPersiod = NumPosVisDur.Text;
            visitCount = NumVisNum.Text;
            Data.UpdateConfigs(1, Res, Configs[0].CloseYearDays, starttime, visitPersiod, visitCount);

            this.Close();
        }

        private string Serialize(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                SerRes += str[i];
            }
            return SerRes;
        }

        private void CheckingCWD()
        {
            if (DeSe[0] == Convert.ToChar("1"))
                chbxSat.IsChecked = true;

            if (DeSe[1] == Convert.ToChar("2"))
                chbxSun.IsChecked = true;

            if (DeSe[2] == Convert.ToChar("3"))
                chbxMon.IsChecked = true;

            if (DeSe[3] == Convert.ToChar("4"))
                chbxTue.IsChecked = true;

            if (DeSe[4] == Convert.ToChar("5"))
                chbxWed.IsChecked = true;

            if (DeSe[5] == Convert.ToChar("6"))
                chbxThu.IsChecked = true;

            if (DeSe[6] == Convert.ToChar("7"))
                chbxFri.IsChecked = true;
        }

        private void CheckCloseWeekDays()
        {
            if (chbxSat.IsChecked == true)
                DeSer[0] = "1";
            else
                DeSer[0] = "X";
            if (chbxSun.IsChecked == true)
                DeSer[1] = "2";
            else
                DeSer[1] = "X";
            if (chbxMon.IsChecked == true)
                DeSer[2] = "3";
            else
                DeSer[2] = "X";
            if (chbxTue.IsChecked == true)
                DeSer[3] = "4";
            else
                DeSer[3] = "X";
            if (chbxWed.IsChecked == true)
                DeSer[4] = "5";
            else
                DeSer[4] = "X";
            if (chbxThu.IsChecked == true)
                DeSer[5] = "6";
            else
                DeSer[5] = "X";
            if (chbxFri.IsChecked == true)
                DeSer[6] = "7";
            else
                DeSer[6] = "X";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void comDaysOff_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btnSetCharity_Click(object sender, RoutedEventArgs e)
        {
            CharityMange cm = new CharityMange();
            cm.ShowDialog();
        }

        private void btnDaysOff_Click(object sender, RoutedEventArgs e)
        {
            DaysOffYear DOY = new DaysOffYear();
            DOY.ShowDialog();
        }

        private void comDaysOff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comDaysOff.SelectedItem = null;
        }

        private void btnSetUserInfo_Click(object sender, RoutedEventArgs e)
        {
            UserInfo UInfo = new UserInfo();
            UInfo.ShowDialog();
        }
    }
}

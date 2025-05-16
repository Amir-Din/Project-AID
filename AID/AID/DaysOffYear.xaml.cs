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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AID
{
    public partial class DaysOffYear : Window
    {
        public ObservableCollection<config> Configs;
        string[] init;
        string h;
        public DaysOffYear()
        {
            InitializeComponent();
            Configs = new ObservableCollection<config>(Data.GetConfigs());
            h = Configs[0].CloseYearDays;
            if (!string.IsNullOrEmpty(h))
                init = JsonSerializer.Deserialize<string[]>(h);
            int j = 0;
            for (int k = 1; k <= 12; k++)
            {
                if (grd.Children[k] is StackPanel)
                {
                    var stk = (StackPanel)grd.Children[k];
                    for (int i = 2; i < stk.Children.Count; i += 2)
                    {
                        if (stk.Children[i] is CheckBox)
                        {
                            var chk = stk.Children[i] as CheckBox;
                            foreach (string b in init)
                            {
                                if (int.Parse(b) == j + 1)
                                {
                                    chk.IsChecked = true;
                                }
                            }
                        }
                        j++;
                    }
                }
            }
        }

        string[] doy = new string[365]; string s;

        private void btnDOY_Click(object sender, RoutedEventArgs e)
        {
            int j = 0, m = 0;
            for (int k = 1; k <= 12; k++)
            {
                if (grd.Children[k] is StackPanel)
                {
                    var stk = (StackPanel)grd.Children[k];
                    for (int i = 2; i < stk.Children.Count; i += 2)
                    {
                        if (stk.Children[i] is CheckBox)
                        {
                            var chk = stk.Children[i] as CheckBox;
                            if (chk.IsChecked == true)
                            {
                                doy[j] = (j + 1).ToString();
                            }
                        }
                        j++;
                    }
                }
            }
            foreach (string t in doy)
            {
                if (!string.IsNullOrEmpty(t))
                    m++;
            }
            string[] OffDay = new string[m];
            int p = 0;
            foreach (string n in doy)
            {
                if (!string.IsNullOrEmpty(n))
                {
                    OffDay[p] = n;
                    p++;
                }
            }
            s = JsonSerializer.Serialize(OffDay);
            Data.UpdateConfigs(1, Configs[0].CloseWeekDays, s, Configs[0].OfficeStartTime, Configs[0].VisitPeriod, Configs[0].VisitCount);
            this.Close();
        }
    }
}

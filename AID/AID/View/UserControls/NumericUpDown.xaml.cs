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

namespace AID.View.UserControls
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }
        private int num;

        public int Number
        {
            get { return num; }
            set { num = value; }
        }

        private int con;

        public int Conten
        {
            get { return con; }
            set
            {
                con = value;
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                txNumricUpDown.Text = text;
                text = txNumricUpDown.Text;
            }
        }

        private int maxnum;

        public int MaxNum
        {
            get { return maxnum; }
            set { maxnum = value; }
        }


        private void NumricUp_Click(object sender, RoutedEventArgs e)
        {
            
            int Num = int.Parse(txNumricUpDown.Text);
            if (Num < MaxNum)
            {
                if (Num >= num)
                {
                    Num += num;
                    txNumricUpDown.Text = Convert.ToString(Num);
                }
                if (Num >= 10)
                {
                    txNumricUpDown.Text = Num.ToString();
                    txNumricUpDown.Margin = new Thickness(35, 0, 35, 0);
                }
            }
            text = txNumricUpDown.Text;
        }
        private void NumricDown_Click(object sender, RoutedEventArgs e)
        {
            
            int Num = int.Parse(txNumricUpDown.Text);
            if (Num != num && Num > num)
            {
                Num -= num;
                txNumricUpDown.Text = Convert.ToString(Num);
            }
            if (Num < 10)
            {
                txNumricUpDown.Text = Num.ToString();
                txNumricUpDown.Margin = new Thickness(40, 0, 40, 0);
            }
            text = txNumricUpDown.Text;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            int Num = int.Parse(txNumricUpDown.Text);
            if (Num < 10)
            {
                txNumricUpDown.Margin = new Thickness(40, 0, 40, 0);
            }
            if (Num >= 10)
            {
                txNumricUpDown.Margin = new Thickness(35, 0, 35, 0);
            }
            txNumricUpDown.Text = text;
        }
    }
}

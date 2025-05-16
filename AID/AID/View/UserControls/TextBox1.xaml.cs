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
    /// Interaction logic for TextBox1.xaml
    /// </summary>
    public partial class TextBox1 : UserControl
    {
        public TextBox1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
        }

        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                txPlaceHolder.Text = placeholder;
            }
        }
        private bool passcheck;

        public bool Passcheck
        {
            get { return passcheck; }
            set { passcheck = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                txtInput.Text = text;
            }
        }

        private string deftext;

        public string DefText
        {
            get { return deftext; }
            set
            {
                deftext = value;
                txtInput.Text = deftext;
            }
        }

        private int maxlen;

        public int MaxLen
        {
            get { return maxlen; }
            set
            {
                maxlen = value;
                txtInput.MaxLength = maxlen;
            }
        }

        private string rtol;

        public string RtoL
        {
            get { return rtol; }
            set
            {
                rtol = value;
                txtInput.HorizontalContentAlignment = HorizontalAlignment.Right;
            }
        }

        public string password, password2;
        public int passwordLength1 = 0, passwordLength2 = 0;

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                txPlaceHolder.Visibility = Visibility.Hidden;
            }
            else
                txPlaceHolder.Visibility = Visibility.Visible;
            text = txtInput.Text;
        }

        private void txtInput_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

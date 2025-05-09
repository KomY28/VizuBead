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
using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_WPF
{
    /// <summary> 
    /// Interaction logic for MainWindow.xaml 
    /// </summary> 
    public partial class MainWindow : Window
    {
        private cnTelefonszamok cnTelefonszamok;
        public MainWindow()
        {
            InitializeComponent();
            cnTelefonszamok = new cnTelefonszamok();
        }

        private void miMentes_Click(object sender, RoutedEventArgs e)
        {
            cnTelefonszamok.SaveChanges();
        }
        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void miHelysegek_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
            dgAdatracs.Visibility = Visibility.Visible;
            var er = (from x in cnTelefonszamok.enHelysegSet
                      select new { x.Nev, x.Irsz }).ToList();
            dgAdatracs.ItemsSource = er;
        }
        private void btRogzit_Click(object sender, RoutedEventArgs e)
        {
            var enAktualis = cbIrsz.SelectedItem as enHelyseg;
            if (!btUjHelyseg.IsEnabled)
            {
                enAktualis = new enHelyseg();
                cnTelefonszamok.enHelysegSet.Add(enAktualis);
            }
            enAktualis.Irsz = Int16.Parse(tbIrsz.Text);
            enAktualis.Nev = tbHelysegnev.Text;
            grHelyseg.Visibility = Visibility.Hidden;
        }
        private void btUjHelyseg_Click(object sender, RoutedEventArgs e)
        {
            Beallit(false);
            tbIrsz.Text = "";
            tbHelysegnev.Text = "";
        }
        private void Beallit(bool b)
        {
            btUjHelyseg.IsEnabled = b;
            cbIrsz.IsEnabled = b;
            cbHelysegnev.IsEnabled = b;
        }
        private void btVissza_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
        }
        private void miFajl_Click(object sender, RoutedEventArgs e)
        {
        }
        private void miMindenAdat_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
            dgAdatracs.Visibility = Visibility.Visible;
            var er = new List<SzemelyesAdatok>();
            foreach (var x in cnTelefonszamok.enSzemelyek)
            {
                er.Add(new SzemelyesAdatok()
                {
                    Vezeteknev = x.Vezeteknev,
                    Utonev = x.Utonev,
                    Helysegnev = x.enHelyseg.Nev,
                    Irsz = x.enHelyseg.Irsz,
                    Lakcim = x.Lakcim,
                    Telefonszamok = x.Telefonszamok
                });
            }
            dgAdatracs.ItemsSource = er;
        }
        private void miHelysegekAM_Click(object sender, RoutedEventArgs e)
        {
            dgAdatracs.Visibility = Visibility.Collapsed;
            grHelyseg.Visibility = Visibility.Visible; grHelyseg.DataContext = cnTelefonszamok.enHelysegSet.ToList();
            cbIrsz.SelectedItem = 0;
        }
        private void cbIrsz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var enAktualis = ((ComboBox)sender).SelectedItem as enHelyseg;
            cbHelysegnev.SelectedItem = enAktualis;
            tbIrsz.Text = enAktualis.Irsz.ToString();
            tbHelysegnev.Text = enAktualis.Nev;
        }


        private void miMidenAdat_Click(object sender, RoutedEventArgs e)
        {
            var er = (from x in cnTelefonszamok.enSzemelyek
                      orderby x.Vezeteknev
                      select new
                      {
                          x.Vezeteknev,
                          x.Utonev,
                          x.enHelyseg.Irsz,
                          x.enHelyseg.Nev,
                          x.Lakcim,
                          x.Telefonszamok
                      }).ToList();
        }
    }


}

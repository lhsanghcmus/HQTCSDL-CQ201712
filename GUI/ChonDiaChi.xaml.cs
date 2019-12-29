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

namespace GUI
{
    /// <summary>
    /// Interaction logic for DatDon.xaml
    /// </summary>
    public partial class DatDon : Window
    {
        public DatDon()
        {
            InitializeComponent();
            chooseCity.IsEnabled = false;
            chooseDistrict.IsEnabled = false;
            chooseWard.IsEnabled = false;
            //note.SelectTionS
        }

        private void ChooseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = chooseType.SelectedIndex;
            switch (index)
            {
                case 0:
                    chooseCity.IsEnabled = false;
                    chooseDistrict.IsEnabled = false;
                    chooseWard.IsEnabled = false;
                    break;
                case 1:
                    chooseCity.IsEnabled = true;
                    chooseDistrict.IsEnabled = true;
                    chooseWard.IsEnabled = true;
                    break;
            }
        }

        private void DongGiaoDien(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}

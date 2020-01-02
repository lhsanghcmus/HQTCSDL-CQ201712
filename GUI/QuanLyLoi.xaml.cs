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

namespace GUI
{
    /// <summary>
    /// Interaction logic for QuanLyLoi.xaml
    /// </summary>
    public partial class QuanLyLoi : Page
    {
        public QuanLyLoi()
        {
            InitializeComponent();
        }

        private void FixTruySuat_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                DTO.Global.fixTruySuatDongThoi = true;
            } else
            {
                DTO.Global.fixTruySuatDongThoi = false;
            }
        }

        private void FixDeadlock_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                DTO.Global.fixDeadlock = true;
            }
            else
            {
                DTO.Global.fixDeadlock = false;
            }
        }
    }
}

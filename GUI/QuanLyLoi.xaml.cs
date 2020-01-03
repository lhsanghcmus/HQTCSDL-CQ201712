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

        private void FixLostUpdate_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                DTO.Global.fixLostUpdate = true;
                fixPhantom.IsChecked = false;
                fixUnrepeatableRead.IsChecked = false;
                fixDirtyRead.IsChecked = false;
                DTO.Global.fixDirtyRead = false;
                DTO.Global.fixUnrepeatableRead = false;
                DTO.Global.fixPhantom = false;
       
            } else
            {
                DTO.Global.fixLostUpdate = false;
            }
        }

        private void FixDeadlock_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                DTO.Global.fixDeadlock = true;
                DTO.Global.fixLostUpdate = true;
                fixPhantom.IsChecked = false;
                fixUnrepeatableRead.IsChecked = false;
                fixDirtyRead.IsChecked = false;
                fixLostUpdate.IsChecked = true;
                DTO.Global.fixDirtyRead = false;
                DTO.Global.fixUnrepeatableRead = false;
                DTO.Global.fixPhantom = false;
            }
            else
            {
                DTO.Global.fixDeadlock = false;
            }
        }

        private void FixDirtyRead_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                fixPhantom.IsChecked = false;
                fixUnrepeatableRead.IsChecked = false;
                fixLostUpdate.IsChecked = false;
                DTO.Global.fixPhantom = false;
                DTO.Global.fixUnrepeatableRead = false;
                DTO.Global.fixLostUpdate = false;
                DTO.Global.fixDirtyRead = true;


                DTO.Global.fixDeadlock = false;
                fixDeadlock.IsChecked = false;


            }
            else
            {
                DTO.Global.fixDirtyRead = false;
            }
        }

        private void FixUnrepeatableRead_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                fixDirtyRead.IsChecked = false;
                fixLostUpdate.IsChecked = false;
                fixPhantom.IsChecked = false;
                DTO.Global.fixDirtyRead = false;
                DTO.Global.fixLostUpdate = false;
                DTO.Global.fixPhantom = false;
                DTO.Global.fixUnrepeatableRead = true;


                DTO.Global.fixDeadlock = false;
                fixDeadlock.IsChecked = false;


            }
            else
            {
                DTO.Global.fixUnrepeatableRead = false;
            }
        }

        private void FixPhantom_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            if (ckb.IsChecked == true)
            {
                fixUnrepeatableRead.IsChecked = false;
                fixDirtyRead.IsChecked = false;
                fixLostUpdate.IsChecked = false;
                DTO.Global.fixUnrepeatableRead = false;
                DTO.Global.fixDirtyRead = false;
                DTO.Global.fixLostUpdate = false;
                DTO.Global.fixPhantom = true;

                DTO.Global.fixDeadlock = false;
                fixDeadlock.IsChecked = false;

            } else
            {
                DTO.Global.fixPhantom = false;
            }
        }
    }
}

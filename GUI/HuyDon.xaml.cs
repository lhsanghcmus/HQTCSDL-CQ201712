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
    /// Interaction logic for HuyDon.xaml
    /// </summary>
    public partial class HuyDon : Window
    {
        public DTO.ThongTinDonHang ThongTinDonHang = null; 
        public HuyDon()
        {
            InitializeComponent();
        }

        private void HuyThaoTac_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void HuyDonHang_Click(object sender, RoutedEventArgs e)
        {
            string MsgLoi = BUS.Action.HuyDonHang(ThongTinDonHang.MaDonHang);
            if (MsgLoi == "")
            {
                MessageBox.Show("Hủy đơn hàng thành công", "Thông báo", MessageBoxButton.OK);
                DonHang d = (DonHang)DTO.Global.ScreenMapping["Don Hang"];
                d.reloadData();
                Visibility = Visibility.Collapsed;
            } else
            {
                MessageBox.Show(MsgLoi, "Thông báo", MessageBoxButton.OK);
            } 
        }
    }
}

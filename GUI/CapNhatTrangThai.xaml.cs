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
    /// Interaction logic for CapNhatTrangThai.xaml
    /// </summary>
    public partial class CapNhatTrangThai : Window
    {
        public DTO.ThongTinDonHang info;
        public CapNhatTrangThai()
        {
            InitializeComponent();
            btnHuyDonHang.Visibility = Visibility.Collapsed;
        }
        public void initData(DTO.ThongTinDonHang info)
        {
            this.info = info;
            txtMaDonHang.Content = info.MaDonHang.ToString();
            txtTongTien.Content = info.TongTien.ToString();
            string trangThai = info.TrangThai;
            txtTrangThai.Content = trangThai;
            if (trangThai == "Tiếp nhận")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Green);
                btnHuyDonHang.Visibility = Visibility.Visible;
            } else if (trangThai == "Đang chuẩn bị")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Orange);
                btnHuyDonHang.Visibility = Visibility.Collapsed;
            } else if (trangThai == "Đang giao")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Red);
                btnHuyDonHang.Visibility = Visibility.Collapsed;
            } else
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Green);
                btnHuyDonHang.Visibility = Visibility.Collapsed;
            }
            txtDiaChiDat.Content = info.DiaChiDat;
            txtDiaChiNhan.Content = info.DiaChiNhan;
        }

        private void HuyThaoTac_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }

        private void CapNhat_Click(object sender, RoutedEventArgs e)
        {
            string trangThai = txtTrangThai.Content.ToString();
            if (trangThai == "Hoàn tất")
            {
                MessageBox.Show("Trạng thái hoàn tất không thể cập nhật thành trạng thái khác", "Thông báo", MessageBoxButton.OK);
            } else
            {
                int index = chooseStatus.SelectedIndex;
                string MsgLoi = BUS.Action.CapNhatTrangThaiDonhang(info.MaDonHang, index + 1);
                if (MsgLoi == "")
                {
                    MessageBox.Show("Cập nhật trạng thái đơn hàng thành công", "Thông báo", MessageBoxButton.OK);
                    DonHang d = (DonHang)DTO.Global.ScreenMapping["Don Hang"];
                    d.reloadData();
                    this.Visibility = Visibility.Collapsed;

                } else 
                {
                    MessageBox.Show(MsgLoi, "Thông báo", MessageBoxButton.OK);
                }
            }
        }

        private void BtnHuyDonHang_Click(object sender, RoutedEventArgs e)
        {
            string MsgLoi = BUS.Action.HuyDonHang(info.MaDonHang);
            if (MsgLoi == "")
            {
                MessageBox.Show("Hủy đơn hàng thành công", "Thông báo", MessageBoxButton.OK);
                DonHang d = (DonHang)DTO.Global.ScreenMapping["Don Hang"];
                d.reloadData();
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show(MsgLoi, "Thông báo", MessageBoxButton.OK);
            }
           
        }
    }
}

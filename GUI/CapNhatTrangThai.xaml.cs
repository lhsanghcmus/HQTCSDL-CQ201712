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
        public CapNhatTrangThai()
        {
            InitializeComponent();
        }
        public void initData(DTO.ThongTinDonHang info)
        {
            txtMaDonHang.Content = info.MaDonHang.ToString();
            txtTongTien.Content = info.TongTien.ToString();
            string trangThai = info.TrangThai;
            txtTrangThai.Content = trangThai;
            if (trangThai == "Tiếp nhận")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Green);
            } else if (trangThai == "Đang chuẩn bị")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Orange);
            } else if (trangThai == "Đang giao")
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Red);
            } else
            {
                txtTrangThai.Foreground = new SolidColorBrush(Colors.Green);
            }
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

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for XacNhanCapNhatThucDon.xaml
    /// </summary>
    public partial class XacNhanCapNhatThucDon : Window
    {
        private DTO.MonAn info;
        public XacNhanCapNhatThucDon()
        {
            InitializeComponent();
        }
        public void initData(DTO.MonAn info)
        {
            this.info = info;
            txtMaMon.Content = info.MaMon;
            txtTenMon.Text = info.TenMon;
            txtDonGia.Text = info.DonGia.ToString();
            txtSoLuongConLai.Content = info.SoLuong;
            txtSoLuongMoi.Text = info.SoLuong.ToString();

            if (DTO.Global.NhanVienQuanLy != null)
            {
                txtTenMon.IsEnabled = true;
                txtDonGia.IsEnabled = true;
            } else
            {
                txtTenMon.IsEnabled = false;
                txtDonGia.IsEnabled = false;
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void CapNhat_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            string sSoLuongMoi = txtSoLuongMoi.Text;
            int iSoLuongMoi = 0;
            if (sSoLuongMoi.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng mới", "Thông báo", MessageBoxButton.OK);
                return;
            }
            
            if (!regex.IsMatch(sSoLuongMoi))
            {
                 MessageBox.Show("Số lượng mới không hợp lệ", "Thông báo", MessageBoxButton.OK);
                    return;
            } 
            iSoLuongMoi = int.Parse(sSoLuongMoi);
            
            if (DTO.Global.NhanVienQuanLy == null)
            {
                int MaLoi = BUS.Action.CapNhatMonAn(info.MaMon, DTO.Global.MaChiNhanh, -1, "", iSoLuongMoi);
                if (MaLoi == 0)
                {
                    MessageBox.Show("Cập nhật số lượng món ăn thành công", "Thông báo", MessageBoxButton.OK);
                    ThucDon t = (ThucDon)DTO.Global.ScreenMapping["Thuc Don"];
                    t.resetData();
                    CapNhatThucDon c = (CapNhatThucDon)DTO.Global.ScreenMapping["Cap Nhat Thuc Don"];
                    c.reloadData();
                    Visibility = Visibility.Collapsed;
                } else if (MaLoi == 1)
                {
                    MessageBox.Show("Cập nhật số lượng món ăn thất bại", "Thông báo", MessageBoxButton.OK);
                }
            } else
            {
                string sDonGia = txtDonGia.Text;
                if (sDonGia.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đơn giá", "Thông báo", MessageBoxButton.OK);
                    return;
                }
                if (!regex.IsMatch(sDonGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ", "Thông báo", MessageBoxButton.OK);
                    return;
                }
                double dDonGia = double.Parse(sDonGia);
                string sTenMon = txtTenMon.Text;
                if (sTenMon.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButton.OK);
                    return;
                }
                int MaLoi = BUS.Action.CapNhatMonAn(info.MaMon, DTO.Global.MaChiNhanh, dDonGia, sTenMon, iSoLuongMoi);
                if (MaLoi == 0)
                {
                    MessageBox.Show("Cập nhật món ăn thành công", "Thông báo", MessageBoxButton.OK);
                    ThucDon t = (ThucDon)DTO.Global.ScreenMapping["Thuc Don"];
                    t.resetData();
                    CapNhatThucDon c = (CapNhatThucDon)DTO.Global.ScreenMapping["Cap Nhat Thuc Don"];
                    c.reloadData();
                    Visibility = Visibility.Collapsed;
                }
                else if (MaLoi == 1)
                {
                    MessageBox.Show("Cập nhật món ăn thất bại", "Thông báo", MessageBoxButton.OK);
                }
            }
            
        }

        private void RemoveMonAn_Click(object sender, RoutedEventArgs e)
        {
            int MaLoi = BUS.Action.XoaMonKhoiChiNhanh(info.MaMon, DTO.Global.MaChiNhanh);
            if (MaLoi == 0)
            {
                MessageBox.Show("Xóa món ăn khỏi chi nhánh thành công", "Thông báo", MessageBoxButton.OK);
                ThucDon t = (ThucDon)DTO.Global.ScreenMapping["Thuc Don"];
                t.resetData();
                CapNhatThucDon c = (CapNhatThucDon)DTO.Global.ScreenMapping["Cap Nhat Thuc Don"];
                c.reloadData();
                Visibility = Visibility.Collapsed;
            } else
            {
                MessageBox.Show("Xóa món ăn khỏi chi nhánh thất bại", "Thông báo", MessageBoxButton.OK);
            }
        }
    }
}

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
    /// Interaction logic for DonHang.xaml
    /// </summary>
    public partial class DonHang : Page
    {
        public DonHang()
        {
            InitializeComponent();
        }

        private void ListViewDonHang_Loaded(object sender, RoutedEventArgs e)
        {
            if (DTO.Global.NhanVien != null)
            {
                listViewDonHang.ItemsSource = BUS.Action.GetDanhSachDonHang(DTO.Global.NhanVien.MaChiNhanh);
            }
            else if (DTO.Global.NhanVienQuanLy != null)
            {
                listViewDonHang.ItemsSource = BUS.Action.GetDanhSachDonHang(0);
            }
            else if (DTO.Global.ThanhVien != null)
            {
                listViewDonHang.ItemsSource = BUS.Action.GetDanhSachDonHang(DTO.Global.ThanhVien.MaThanhVien);
            }
        }

        private void ListViewDonHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DTO.Global.ThanhVien != null)
            {
                DTO.ThongTinDonHang info = (DTO.ThongTinDonHang)listViewDonHang.SelectedValue;
                if (info != null && info.TrangThai == "Tiếp nhận")
                {
                    if (DTO.Global.ScreenMapping.ContainsKey("Xac Nhan Huy Don"))
                    {
                        HuyDon h = (HuyDon)DTO.Global.ScreenMapping["Xac Nhan Huy Don"];
                        h.ShowDialog();
                    } else
                    {
                        HuyDon h = new HuyDon();
                        h.ThongTinDonHang = info;
                        DTO.Global.ScreenMapping.Add("Xac Nhan Huy Don", h);
                        h.ShowDialog();
                    }
                }
            } else
            {
                DTO.ThongTinDonHang info = (DTO.ThongTinDonHang)listViewDonHang.SelectedValue;
                if (DTO.Global.ScreenMapping.ContainsKey("Cap Nhat Trang Thai"))
                {
                    CapNhatTrangThai c = (CapNhatTrangThai)DTO.Global.ScreenMapping["Cap Nhat Trang Thai"];
                    if (info != null)
                    {
                        c.initData(info);
                        c.ShowDialog();
                    }
                   
                } else
                {
                    CapNhatTrangThai c = new CapNhatTrangThai();
                    if (info != null)
                    {
                        c.initData(info);
                        c.ShowDialog();
                    }
                    DTO.Global.ScreenMapping.Add("Cap Nhat Trang Thai", c);
                }
            }
        }
    }
}

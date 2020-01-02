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
    /// Interaction logic for ThemMonAnMoi.xaml
    /// </summary>
    public partial class ThemMonAnMoi : Window
    {
        private HashSet<int> MaMonDuocChon = new HashSet<int>();
        public ThemMonAnMoi()
        {
            InitializeComponent();
        }
        public void initData()
        {
            listViewMonAn.ItemsSource = BUS.Action.LayMonAnChuaCoTrongChiNhanh(DTO.Global.MaChiNhanh);
        }

        private void DongGiaoDien_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            MaMonDuocChon.Clear();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ckb = (CheckBox) sender;
            DTO.MonAn monAn = (DTO.MonAn)ckb.DataContext;
            if (ckb.IsChecked == true)
            {
                MaMonDuocChon.Add(monAn.MaMon);
            } else
            {
                MaMonDuocChon.Remove(monAn.MaMon);
            }
        }

        private void ThemMon_Click(object sender, RoutedEventArgs e)
        {
            List<int> DanhSachMaLoi = new List<int>();
            foreach (var item in MaMonDuocChon)
            {
                int MaLoi = BUS.Action.ThemMonVaoChiNhanh(item, DTO.Global.MaChiNhanh, 0);
                if (MaLoi != 0)
                {
                    DanhSachMaLoi.Add(item);
                }
            }
            if (DanhSachMaLoi.Count == 0)
            {
                MessageBox.Show("Thêm món ăn vào chi nhánh thành công", "Thông báo", MessageBoxButton.OK);
                ThucDon t = (ThucDon)DTO.Global.ScreenMapping["Thuc Don"];
                t.resetData();
                CapNhatThucDon c = (CapNhatThucDon)DTO.Global.ScreenMapping["Cap Nhat Thuc Don"];
                c.reloadData();
                Visibility = Visibility.Collapsed;
                MaMonDuocChon.Clear();

            } else
            {
                string DanhSachLoi = "";
                int n = DanhSachMaLoi.Count;
                for (int i=0;i<n;i++)
                {
                    DanhSachLoi += "["+DanhSachMaLoi[i] + "] ";
                }
                MessageBox.Show(DanhSachLoi, "Danh sách mã món ăn không thêm được", MessageBoxButton.OK);
            }
        }
    }
}

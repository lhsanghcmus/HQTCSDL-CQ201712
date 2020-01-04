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
    /// Interaction logic for ChiTietMonAn.xaml
    /// </summary>
    public partial class ChiTietMonAn : Window
    {
        public ChiTietMonAn()
        {
            InitializeComponent();
        }

        internal void initData(DTO.MonAn info)
        {
            img.Source = info.HinhAnh;
            txtMaMon.Text = info.MaMon.ToString();
            txtTenMon.Text = info.TenMon;
            txtLoaiMon.Text = info.TenLoai;
            txtGiaban.Text = info.DonGia.ToString();
            txtSoLuong.Text = info.SoLuong.ToString();
        }

        private void DongForm_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}

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
using DTO;
using BUS;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DTO.ChiNhanh> listChiNhanh;
        DTO.ThanhVien thanhVien;
        DTO.NhanVien nhanVien;
        DTO.NhanVienQuanLy nhanVienQuanLy;

        private int typeUser;
        public MainWindow()
        {
            InitializeComponent();
            //this.FontFamily = new FontFamily("Montserrat");
            listChiNhanh = BUS.ChiNhanh.LoadDSChiNhanh();
            typeUser = 0;
            setTypeUser(0);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        internal void setUserInfo(DTO.ThanhVien result)
        {
            this.thanhVien = result;
            customerName.Content = this.thanhVien.HoTen;
            customerPoint.Text = this.thanhVien.DiemTichLuy.ToString();
            nameBranch.Text = this.thanhVien.MaChiNhanh.ToString();
        }
        internal void setUserInfo2(DTO.NhanVien result) // nhân viên 1 chi nhánh
        {
            this.nhanVien = result;
            customerPoint.Text = null;
            customerName.Content = this.nhanVien.HoTen;
            nameBranch.Text = this.nhanVien.TenChiNhanh.ToString();

        }
        internal void setUserInfo3(DTO.NhanVienQuanLy result) // nhân viên toàn chi nhánh
        {
            this.nhanVienQuanLy = result;
            customerPoint.Text = null;
            customerName.Content = this.nhanVienQuanLy.HoTen;
            nameBranch.Text = null;
        }
        private void loadChiNhanh(object sender, RoutedEventArgs e)
        {
            cmbChiNhanh.ItemsSource = listChiNhanh;
            cmbChiNhanh.SelectedIndex = 0;
        }

        private void CmbChiNhanh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show(listChiNhanh[cmbChiNhanh.SelectedIndex].MaChiNhanh.ToString());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var window = new Login();
            window.Show();
            this.Close();
        }
        public void setTypeUser(int type)
        {
            this.typeUser = type;
            if (this.typeUser == 1) // thành viên
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
            } else if (this.typeUser == 0) // sai hoặc chưa login
            {
                notLogin.Visibility = Visibility.Visible;
                customerLogin.Visibility = Visibility.Collapsed;
            }
            else if (this.typeUser == 2) // nhân viên 1 chi nhánh
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
            }
            else if (this.typeUser == 3) // nhân viên toàn chi nhánh
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index) {
                case 0:
                    GridPrincipal.Content = new ThucDon();
                    break;
                case 1:
                    GridPrincipal.Content = new DonHang();
                    break;
            }
        }
    }
}

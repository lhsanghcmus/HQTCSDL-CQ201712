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
        private int typeUser;
        public MainWindow()
        {
            InitializeComponent();
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
        }
    }
}

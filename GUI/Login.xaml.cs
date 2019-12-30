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
using DTO;
namespace GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cancelLogin(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            string userName = txtUser.Text;
            string passWord = txtPassWord.Password;

            DTO.NhanVien NhanVienData = BUS.NhanVien.GetNhanVien(userName, passWord);
          
            if (NhanVienData != null)
            {
                Global.MaChiNhanh = NhanVienData.MaChiNhanh;
                 var window = new MainWindow();
                 window.setTypeUser(2);
                 window.setNhanVienInfo(NhanVienData);
                 window.Show();
                 this.Close();   
            }
            else
            {
                DTO.ThanhVien ThanhVienData = BUS.ThanhVien.GetThanhVien(userName, passWord);
                if (ThanhVienData != null)
                {
                    var window = new MainWindow();
                    window.setTypeUser(1);
                    window.setThanhVienInfo(ThanhVienData);
                    Global.ThanhVien = ThanhVienData;
                    window.Show();
                    this.Close();
                }
                else
                {
                    DTO.NhanVienQuanLy NhanVienQuanLyData = BUS.NhanVienQuanLy.GetNhanVienQuanLy(userName, passWord);
                    if (NhanVienQuanLyData != null)
                    {
                        Global.MaChiNhanh = 0;
                       var window = new MainWindow();
                       window.setTypeUser(3);
                       window.setQuanlyInfo(NhanVienQuanLyData);
                       window.Show();
                       this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButton.OK);
                    }
                }
            }
        }
    }
}
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
                Global.NhanVien = NhanVienData;
                Global.ThanhVien = null;
                Global.NhanVienQuanLy = null;

                if (Global.ScreenMapping.ContainsKey("Chon Dia Chi"))
                {
                    ChonDiaChi tmp = (ChonDiaChi)Global.ScreenMapping["Chon Dia Chi"];
                    tmp.loadDataUser();
                }
                else
                {
                    ChonDiaChi tmp = new ChonDiaChi();
                    tmp.loadDataUser();
                    Global.ScreenMapping.Add("Chon Dia Chi", tmp);
                }

                if (Global.ScreenMapping.ContainsKey("Main Window"))
                {
                    MainWindow window = (MainWindow)Global.ScreenMapping["Main Window"];
                    window.reloadData();
                    window.setTypeUser(2);
                    window.setNhanVienInfo(NhanVienData);
                    window.Show();
                    this.Close();
                } else
                {
                    MainWindow window = new MainWindow();
                    window.setTypeUser(2);
                    window.setNhanVienInfo(NhanVienData);
                    Global.ScreenMapping.Add("Main Window", window);
                    window.Show();
                    this.Close();
                }
                
            }
            else
            {
                DTO.ThanhVien ThanhVienData = BUS.ThanhVien.GetThanhVien(userName, passWord);
                if (ThanhVienData != null)
                {
                    Global.MaChiNhanh = 0;
                    Global.ThanhVien = ThanhVienData;
                    Global.NhanVien = null;
                    Global.NhanVienQuanLy = null;
                    if (Global.ScreenMapping.ContainsKey("Chon Dia Chi"))
                    {
                        ChonDiaChi tmp = (ChonDiaChi)Global.ScreenMapping["Chon Dia Chi"];
                        tmp.loadDataUser();
                    } else
                    {
                        ChonDiaChi tmp = new ChonDiaChi();
                        tmp.loadDataUser();
                        Global.ScreenMapping.Add("Chon Dia Chi", tmp);
                    }
                    
                    if (Global.ScreenMapping.ContainsKey("Main Window"))
                    {
                        MainWindow window = (MainWindow)Global.ScreenMapping["Main Window"];
                        window.reloadData();
                        window.setTypeUser(1);
                        window.setThanhVienInfo(ThanhVienData);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        MainWindow window = new MainWindow();
                        window.setTypeUser(1);
                        window.setThanhVienInfo(ThanhVienData);
                        Global.ScreenMapping.Add("Main Window", window);
                        window.Show();
                        this.Close();
                    }

                    this.Close();
                }
                else
                {
                    DTO.NhanVienQuanLy NhanVienQuanLyData = BUS.NhanVienQuanLy.GetNhanVienQuanLy(userName, passWord);
                    if (NhanVienQuanLyData != null)
                    {
                        Global.MaChiNhanh = 0;
                        Global.NhanVienQuanLy = NhanVienQuanLyData;
                        Global.NhanVien = null;
                        Global.ThanhVien = null;
                      

                        if (Global.ScreenMapping.ContainsKey("Main Window"))
                        {
                            MainWindow window = (MainWindow)Global.ScreenMapping["Main Window"];
                            window.reloadData();
                            window.setTypeUser(3);
                            window.setQuanlyInfo(NhanVienQuanLyData);
                            window.Show();
                            this.Close();
                        }
                        else
                        {
                            MainWindow window = new MainWindow();
                            window.setTypeUser(3);
                            window.setQuanlyInfo(NhanVienQuanLyData);
                            Global.ScreenMapping.Add("Main Window", window);
                            window.Show();
                            this.Close();
                        }

                        
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
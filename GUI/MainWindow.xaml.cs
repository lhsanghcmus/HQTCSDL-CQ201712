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
            if (Global.MaChiNhanh != 0)
            {
                int n = listChiNhanh.Count;
                for (int i=0;i<n;i++)
                {
                    if (listChiNhanh[i].MaChiNhanh == Global.MaChiNhanh)
                    {
                        DTO.ChiNhanh tmp = listChiNhanh[i];
                        Global.ChiNhanh = tmp;
                        listChiNhanh.Clear();
                        listChiNhanh.Add(tmp);
                        break;
                    }
                }
            }
            typeUser = 0;
            setTypeUser(0);
            if (Global.NhanVien != null || Global.NhanVienQuanLy != null)
            {
                ft_CapNhatThucDon.Visibility = Visibility.Visible;
            }
            else
            {
                ft_CapNhatThucDon.Visibility = Visibility.Hidden;
            }
            if (!Global.ScreenMapping.ContainsKey("Main Window"))
            {
                Global.ScreenMapping.Add("Main Window", this);
            }
         
        }

        public void reloadData()
        {
            listChiNhanh = BUS.ChiNhanh.LoadDSChiNhanh();
            if (Global.MaChiNhanh != 0)
            {
                int n = listChiNhanh.Count;
                for (int i = 0; i < n; i++)
                {
                    if (listChiNhanh[i].MaChiNhanh == Global.MaChiNhanh)
                    {
                        DTO.ChiNhanh tmp = listChiNhanh[i];
                        Global.ChiNhanh = tmp;
                        listChiNhanh.Clear();
                        listChiNhanh.Add(tmp);
                        break;
                    }
                }
            }
            if (Global.NhanVien != null || Global.NhanVienQuanLy != null)
            {
                ft_CapNhatThucDon.Visibility = Visibility.Visible;
            } else
            {
                ft_CapNhatThucDon.Visibility = Visibility.Hidden;
            }
            cmbChiNhanh.ItemsSource = listChiNhanh;
            cmbChiNhanh.SelectedIndex = 0;
            Global.ChiNhanh = listChiNhanh[cmbChiNhanh.SelectedIndex];
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Global.MaChiNhanh = 0;
            thanhVien = null;
            nhanVien = null;
            nhanVienQuanLy = null;
            DTO.Global.ThanhVien = null;
            DTO.Global.NhanVien = null;
            DTO.Global.NhanVienQuanLy = null;
            GC.Collect();
            var window = new Login();
            window.Show();
            this.Visibility = Visibility.Collapsed;

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

        internal void setThanhVienInfo(DTO.ThanhVien result)
        {
            this.thanhVien = result;
            customerName.Content = this.thanhVien.HoTen;
            customerPoint.Text = this.thanhVien.DiemTichLuy.ToString();
            nameBranch.Text = null;
        }
        internal void setNhanVienInfo(DTO.NhanVien result) // nhân viên 1 chi nhánh
        {
            this.nhanVien = result;
            customerPoint.Text = null;
            customerName.Content = this.nhanVien.HoTen;
            nameBranch.Text = this.nhanVien.TenChiNhanh.ToString();

        }
        internal void setQuanlyInfo(DTO.NhanVienQuanLy result) // nhân viên toàn chi nhánh
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
            Global.ChiNhanh = listChiNhanh[cmbChiNhanh.SelectedIndex];
        }

        private void CmbChiNhanh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChiNhanh.SelectedIndex != -1)
            {
                Global.MaChiNhanh = int.Parse(listChiNhanh[cmbChiNhanh.SelectedIndex].MaChiNhanh.ToString());
                Global.ChiNhanh = listChiNhanh[cmbChiNhanh.SelectedIndex];
                if (Global.ScreenMapping.ContainsKey("Chon Dia Chi"))
                {
                    ChonDiaChi t = (ChonDiaChi)Global.ScreenMapping["Chon Dia Chi"];
                    t.loadDataUser();
                    t.listMonAnDuocChon = null;
                }
                else
                {
                    ChonDiaChi t = new ChonDiaChi();
                    t.listMonAnDuocChon = null;
                    GC.Collect();
                    t.loadDataUser();
                    Global.ScreenMapping.Add("Chon Dia Chi", t);
                }
                if (Global.ScreenMapping.ContainsKey("Thuc Don"))
                {
                    ThucDon t = (ThucDon)Global.ScreenMapping["Thuc Don"];
                    t.resetData();
                }
            }
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DTO.Global.ThanhVien = null;
            DTO.Global.NhanVien = null;
            DTO.Global.NhanVienQuanLy = null;
            var window = new Login();
            window.Show();
            this.Visibility = Visibility.Collapsed;
        }
        public void setTypeUser(int type)
        {
            this.typeUser = type;
            if (this.typeUser == 1) // thành viên
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
                Global.MaChiNhanh = 0;
            } else if (this.typeUser == 0) // sai hoặc chưa login
            {
                Global.MaChiNhanh = 0;
                notLogin.Visibility = Visibility.Visible;
                customerLogin.Visibility = Visibility.Collapsed;
                nhanVien = null;
                thanhVien = null;
                nhanVienQuanLy = null;
                GC.Collect();
            }
            else if (this.typeUser == 2) // nhân viên 1 chi nhánh
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
                Global.MaChiNhanh = nhanVien.MaChiNhanh;
            }
            else if (this.typeUser == 3) // nhân viên toàn chi nhánh
            {
                customerLogin.Visibility = Visibility.Visible;
                notLogin.Visibility = Visibility.Collapsed;
                Global.MaChiNhanh = 0;
            }
            Global.LoaiUser = this.typeUser;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index) {
                case 0:
                    if (Global.ScreenMapping.ContainsKey("Thuc Don"))
                    {
                        GridPrincipal.Content = Global.ScreenMapping["Thuc Don"];
                    } else
                    {
                        Global.ScreenMapping.Add("Thuc Don", new ThucDon());
                        GridPrincipal.Content = Global.ScreenMapping["Thuc Don"];
                    }
                    break;
                case 1:
                    if (Global.ScreenMapping.ContainsKey("Don Hang"))
                    {
                        GridPrincipal.Content = Global.ScreenMapping["Don Hang"];
                    }
                    else
                    {
                        Global.ScreenMapping.Add("Don Hang", new DonHang());
                        GridPrincipal.Content = Global.ScreenMapping["Don Hang"];
                    }
                    break;
                case 2:
                    if (Global.ScreenMapping.ContainsKey("Cap Nhat Thuc Don"))
                    {
                        GridPrincipal.Content = Global.ScreenMapping["Cap Nhat Thuc Don"];
                    } else
                    {
                        Global.ScreenMapping.Add("Cap Nhat Thuc Don", new CapNhatThucDon());
                        GridPrincipal.Content = Global.ScreenMapping["Cap Nhat Thuc Don"];
                    }
                    break;
                case 4:
                    if (Global.ScreenMapping.ContainsKey("Quan Ly Loi"))
                    {
                        GridPrincipal.Content = Global.ScreenMapping["Quan Ly Loi"];
                    } else
                    {
                        Global.ScreenMapping.Add("Quan Ly Loi", new QuanLyLoi());
                        GridPrincipal.Content = Global.ScreenMapping["Quan Ly Loi"];
                    }
                    break;
                case 3:
                    if (Global.ScreenMapping.ContainsKey("Thong Ke Doanh Thu"))
                    {
                        GridPrincipal.Content = Global.ScreenMapping["Thong Ke Doanh Thu"];
                    } else
                    {
                        Global.ScreenMapping.Add("Thong Ke Doanh Thu", new ThongKeDoanhThu());
                        GridPrincipal.Content = Global.ScreenMapping["Thong Ke Doanh Thu"];
                    }
                    break;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

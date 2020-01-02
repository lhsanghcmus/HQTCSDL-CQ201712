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
namespace GUI
{
    /// <summary>
    /// Interaction logic for CapNhatThucDon.xaml
    /// </summary>
    public partial class CapNhatThucDon : Page
    {
        public CapNhatThucDon()
        {
            InitializeComponent();
        }

        private void ListViewThucDon_Loaded(object sender, RoutedEventArgs e)
        {
            listViewThucDon.ItemsSource = DTO.Global.DanhSachMonAn;
        }

        private void ListViewThucDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DTO.MonAn info = (DTO.MonAn)listViewThucDon.SelectedValue;
            if (info != null)
            {
                if (DTO.Global.ScreenMapping.ContainsKey("Xac Nhan Cap Nhat Thuc Don"))
                {
                    XacNhanCapNhatThucDon c = (XacNhanCapNhatThucDon)DTO.Global.ScreenMapping["Xac Nhan Cap Nhat Thuc Don"];
                    c.initData(info);
                    c.Visibility = Visibility.Visible;
                } else
                {
                    XacNhanCapNhatThucDon c = new XacNhanCapNhatThucDon();
                    c.initData(info);
                    DTO.Global.ScreenMapping.Add("Xac Nhan Cap Nhat Thuc Don", c);
                    c.Visibility = Visibility.Visible;
                }
            }
        }
        public void reloadData()
        {
            listViewThucDon.ItemsSource = null;
            listViewThucDon.ItemsSource = DTO.Global.DanhSachMonAn;
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            if (Global.ScreenMapping.ContainsKey("Them Mon An Moi"))
            {
                ThemMonAnMoi t = (ThemMonAnMoi)Global.ScreenMapping["Them Mon An Moi"];
                t.initData();
                t.Visibility = Visibility.Visible;
                
            } else
            {
                ThemMonAnMoi t = new ThemMonAnMoi();
                t.initData();
                Global.ScreenMapping.Add("Them Mon An Moi", t);
                t.Visibility = Visibility.Visible;
            }
        }
    }
}

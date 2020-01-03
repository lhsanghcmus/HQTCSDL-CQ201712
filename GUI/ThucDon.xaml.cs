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
    /// Interaction logic for ThucDon.xaml
    /// </summary>
    public partial class ThucDon : Page
    {
        private DTO.MonAn[] listMonAn;
        private int count = 0;
        private string baseString = "Đã chọn: ";
        public ThucDon()
        {
            InitializeComponent();
        }

        private void TangSoLuong(object sender, RoutedEventArgs e)
        {
            DTO.MonAn monAn = (DTO.MonAn)((Button)sender).DataContext;
            int n = listMonAn.Length;
            int index = 0;
          
            for (int i = 0; i < n; i++)
            {
                if (monAn.MaMon == listMonAn[i].MaMon)
                {
                   index = i;
                   break;
                }
            }
            
           
            if (listMonAn[index].SoLuongDuocChon < Global.DanhSachMonAn[index].SoLuong)
            {
                listMonAn[index].SoLuong--;
                listMonAn[index].SoLuongDuocChon++;
                itemListView.ItemsSource = null;
                GC.Collect();
                itemListView.ItemsSource = listMonAn;
                count++;
                countSelected.Content = baseString + count.ToString();
            }
         
        }

        private void GiamSoLuong(object sender, RoutedEventArgs e)
        {
            DTO.MonAn monAn = (DTO.MonAn)((Button)sender).DataContext;
            int n = listMonAn.Length;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (monAn.MaMon == listMonAn[i].MaMon)
                {
                    index = i;
                    break;
                }
            }
           
            if (listMonAn[index].SoLuongDuocChon > 0)
            {
                listMonAn[index].SoLuongDuocChon--;
                listMonAn[index].SoLuong++;
                count--;
                itemListView.ItemsSource = null;
                GC.Collect();
                itemListView.ItemsSource = listMonAn;
                countSelected.Content = baseString + count.ToString();
            }
        }

        public DTO.MonAn[] GetMonAnDuocChon()
        {
            int n = listMonAn.Length;
            List<DTO.MonAn> result = new List<DTO.MonAn>();
            for (int i=0;i<n;i++)
            {
                if (listMonAn[i].SoLuongDuocChon > 0)
                {
                    result.Add(listMonAn[i]);
                }
            }
            return result.ToArray();
        }

        private void CountSelected_Click(object sender, RoutedEventArgs e)
        {
            if (Global.ScreenMapping.ContainsKey("Chon Dia Chi"))
            {
                ChonDiaChi tmp = (ChonDiaChi)Global.ScreenMapping["Chon Dia Chi"];
                DTO.MonAn[] ListMonAnDuocChon = GetMonAnDuocChon();
                tmp.listMonAnDuocChon = ListMonAnDuocChon;
                tmp.ShowDialog();
                
            } else
            {
                ChonDiaChi tmp = new ChonDiaChi();
                Global.ScreenMapping.Add("Chon Dia Chi", tmp);
                DTO.MonAn[] ListMonAnDuocChon = GetMonAnDuocChon();
                tmp.listMonAnDuocChon = ListMonAnDuocChon;
                tmp.ShowDialog();
            }
        }
        public void resetData()
        {
            count = 0;
            listMonAn = null;
            GC.Collect();
            listMonAn = BUS.MonAn.GetThucDon(Global.MaChiNhanh, 0, 0);
            DTO.Global.DanhSachMonAn = Array.ConvertAll(listMonAn, a => a.Clone());
            itemListView.ItemsSource = null;
            itemListView.ItemsSource = listMonAn;
            countSelected.Content = "Đã chọn: 0";
        }

        private void ItemListView_Loaded(object sender, RoutedEventArgs e)
        {
            listMonAn = null;
            GC.Collect();
            listMonAn = BUS.MonAn.GetThucDon(1, 0, 0);
            DTO.Global.DanhSachMonAn = Array.ConvertAll(listMonAn, a => a.Clone());
            itemListView.ItemsSource = listMonAn;
            countSelected.Content = "Đã chọn: 0";
            count = 0;
        }
    }
}

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
        private List<DTO.MonAn> listMonAn;
        private int count = 0;
        public ThucDon()
        {
            InitializeComponent();
            listMonAn = BUS.MonAn.GetThucDon(1, 0, 0);
            itemListView.ItemsSource = listMonAn;
            countSelected.Content = "Đã chọn: 0";
        }

        private void TangSoLuong(object sender, RoutedEventArgs e)
        {
            DTO.MonAn monAn = (DTO.MonAn)((Button)sender).DataContext;
            int n = listMonAn.Count;
            int index = 0;
            for (int i=0;i<n;i++)
            {
                if (monAn == listMonAn[i])
                {
                    index = i;
                    break;
                }
            }
            listMonAn[index].SoLuongDuocChon++;
            itemListView.ItemsSource = new List<DTO.MonAn>();
            itemListView.ItemsSource = listMonAn;
            count++;
            countSelected.Content = "Đã chọn: " + count.ToString();
        }

        private void GiamSoLuong(object sender, RoutedEventArgs e)
        {
            DTO.MonAn monAn = (DTO.MonAn)((Button)sender).DataContext;
            int n = listMonAn.Count;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (monAn == listMonAn[i])
                {
                    index = i;
                    break;
                }
            }
            if (listMonAn[index].SoLuongDuocChon > 0)
            {
                listMonAn[index].SoLuongDuocChon--;
                count--;
            }
            itemListView.ItemsSource = new List<DTO.MonAn>();
            itemListView.ItemsSource = listMonAn;

            countSelected.Content = "Đã chọn: " + count.ToString();
        }
    }
}

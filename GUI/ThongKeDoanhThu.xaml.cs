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

namespace GUI
{
    /// <summary>
    /// Interaction logic for ThongKeDoanhThu.xaml
    /// </summary>
    public partial class ThongKeDoanhThu : Page
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ListViewChiNhanh_Loaded(object sender, RoutedEventArgs e)
        {
            DTO.DoanhThu[] result = BUS.Action.ThongKeDoanhThu();
            if (result != null && result.Length > 0)
            {
                listViewChiNhanh.ItemsSource = result;
                txtTongDoanhThu.Text = result[0].TongDoanhThu.ToString();
            }
        }
    }
}

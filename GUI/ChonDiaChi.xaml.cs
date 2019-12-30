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
    /// Interaction logic for DatDon.xaml
    /// </summary>
    public partial class ChonDiaChi : Window
    {
        public DTO.MonAn[] listMonAnDuocChon;
        public ChonDiaChi()
        {
            InitializeComponent();
            chooseCity.IsEnabled = false;
            chooseDistrict.IsEnabled = false;
            chooseWard.IsEnabled = false;
            if (DTO.Global.ThanhVien != null)
            {
                txtTenNguoiDat.Text = DTO.Global.ThanhVien.HoTen;
                txtSdtLienLac.Text = DTO.Global.ThanhVien.Sdt;
                txtTenNguoiDat.IsEnabled = false;
                txtSdtLienLac.IsEnabled = false;
            }
            //note.SelectTionS
        }

        private void ChooseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = chooseType.SelectedIndex;
            switch (index)
            {
                case 0:
                    chooseCity.IsEnabled = false;
                    chooseDistrict.IsEnabled = false;
                    chooseWard.IsEnabled = false;
                    break;
                default:
                    chooseCity.IsEnabled = true;
                    chooseDistrict.IsEnabled = true;
                    chooseWard.IsEnabled = true;
                    break;
            }
        }

        private void DongGiaoDien(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        private void MoGiaoDienTinhTien(object sender, RoutedEventArgs e)
        {
            TinhTien t = new TinhTien();
            t.ListMonAnDuocChon = listMonAnDuocChon;
            int index = chooseType.SelectedIndex;
            if (index == -1)
            {
                t.ThongTinThanhToan.HinhThuc = 1;
            } else
            {
                t.ThongTinThanhToan.HinhThuc = index + 1;
            }
            
            t.ThongTinThanhToan.TenDuong = StringFromRichTextBox(note);
            t.ThongTinThanhToan.TenPhuong = chooseWard.SelectionBoxItem.ToString();
            t.ThongTinThanhToan.TenQuan = chooseDistrict.SelectionBoxItem.ToString();
            t.ThongTinThanhToan.TenThanhPho = chooseCity.SelectionBoxItem.ToString();
            t.ThongTinThanhToan.TenNguoiNhan = txtTenNguoiNhan.Text;
            t.ThongTinThanhToan.TenNguoiDat = txtTenNguoiDat.Text;
            t.ThongTinThanhToan.SdtLienLac = txtSdtLienLac.Text;
            if (DTO.Global.ThanhVien != null)
            {
                t.ThongTinThanhToan.MaThanhVien = DTO.Global.ThanhVien.MaThanhVien;
                t.ThongTinThanhToan.Loai = 2;
            } else
            {
                t.ThongTinThanhToan.Loai = 1;
            }
            t.ThongTinThanhToan.MaChiNhanh = DTO.Global.MaChiNhanh;
            t.ThongTinThanhToan.MaKhuyenMai = txtMaKhuyenMai.Text;
            t.ThongTinThanhToan.ListMonAnDuocChon = listMonAnDuocChon;
            t.ShowThongTinTien();
            this.Visibility = Visibility.Hidden;
            t.ShowDialog();
        }
    }
}

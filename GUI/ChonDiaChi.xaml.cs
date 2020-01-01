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
        private bool loaded = false;
        public ChonDiaChi()
        {
            InitializeComponent();
            chooseCity.IsEnabled = false;
            chooseDistrict.IsEnabled = false;
            chooseWard.IsEnabled = false;
            loaded = true;
            //note.SelectTionS
        }

        private void ChooseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loaded)
            {
                int index = chooseType.SelectedIndex;
                switch (index)
                {
                    case 0:
                        chooseCity.IsEnabled = false;
                        chooseDistrict.IsEnabled = false;
                        chooseWard.IsEnabled = false;
                        chooseCity.Visibility = Visibility.Collapsed;
                        txtTenThanhPho.Visibility = Visibility.Visible;
                        txtTenThanhPho.IsEnabled = false;
                        txtTenThanhPho.Text = DTO.Global.ChiNhanh.TenThanhPho;

                        chooseDistrict.Visibility = Visibility.Collapsed;
                        txtTenQuan.Visibility = Visibility.Visible;
                        txtTenQuan.IsEnabled = false;
                        txtTenQuan.Text = DTO.Global.ChiNhanh.TenQuan;

                        chooseWard.Visibility = Visibility.Collapsed;
                        txtTenPhuong.Visibility = Visibility.Visible;
                        txtTenPhuong.IsEnabled = false;
                        txtTenPhuong.Text = DTO.Global.ChiNhanh.TenPhuong;

                        FlowDocument flow = new FlowDocument();
                        flow.Blocks.Add(new Paragraph(new Run(DTO.Global.ChiNhanh.TenDuong)));
                        note.Document = flow;
                        note.IsEnabled = false;

                        break;
                    default:
                        chooseCity.IsEnabled = true;
                        chooseDistrict.IsEnabled = true;
                        chooseWard.IsEnabled = true;

                        chooseCity.Visibility = Visibility.Visible;
                        txtTenThanhPho.Visibility = Visibility.Collapsed;

                        chooseDistrict.Visibility = Visibility.Visible;
                        txtTenQuan.Visibility = Visibility.Collapsed;

                        chooseWard.Visibility = Visibility.Visible;
                        txtTenPhuong.Visibility = Visibility.Collapsed;
                        note.IsEnabled = true;
                        txtTenNguoiNhan.IsEnabled = true;
                        break;
                }
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
                t.ThongTinThanhToan.HinhThuc = 2;
            } else
            {
                if (index == 0)
                {
                    t.ThongTinThanhToan.HinhThuc = 2;
                } else if (index == 1)
                {
                    t.ThongTinThanhToan.HinhThuc = 1;
                } else
                {
                    t.ThongTinThanhToan.HinhThuc = 3;
                }
            }
            
            t.ThongTinThanhToan.TenDuong = StringFromRichTextBox(note);
            if (t.ThongTinThanhToan.HinhThuc != 2)
            {
                t.ThongTinThanhToan.TenPhuong = chooseWard.SelectionBoxItem.ToString();
                t.ThongTinThanhToan.TenQuan = chooseDistrict.SelectionBoxItem.ToString();
                t.ThongTinThanhToan.TenThanhPho = chooseCity.SelectionBoxItem.ToString();
            } else
            {
                t.ThongTinThanhToan.TenPhuong = txtTenPhuong.Text;
                t.ThongTinThanhToan.TenQuan = txtTenQuan.Text;
                t.ThongTinThanhToan.TenThanhPho = txtTenThanhPho.Text;
            }
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

       public void loadDataUser()
        {
            if (DTO.Global.ThanhVien != null)
            {
                txtTenNguoiDat.Text = DTO.Global.ThanhVien.HoTen;
                txtSdtLienLac.Text = DTO.Global.ThanhVien.Sdt;
                txtTenNguoiDat.IsEnabled = false;
                txtSdtLienLac.IsEnabled = false;
                

            } else if (DTO.Global.NhanVien != null)
            {
                txtTenNguoiDat.IsEnabled = true;
                txtSdtLienLac.IsEnabled = true;

            } else if (DTO.Global.NhanVienQuanLy != null)
            {
               
                txtTenNguoiDat.IsEnabled = true;
                txtSdtLienLac.IsEnabled = true;

            }

            int index = chooseType.SelectedIndex;
            if (index != 0)
            {
                chooseCity.Visibility = Visibility.Visible;
                txtTenThanhPho.Visibility = Visibility.Collapsed;

                chooseDistrict.Visibility = Visibility.Visible;
                txtTenQuan.Visibility = Visibility.Collapsed;

                chooseWard.Visibility = Visibility.Visible;
                txtTenPhuong.Visibility = Visibility.Collapsed;
                note.IsEnabled = true;
            }
            else
            {
                chooseCity.Visibility = Visibility.Collapsed;
                txtTenThanhPho.Visibility = Visibility.Visible;
                txtTenThanhPho.IsEnabled = false;
                txtTenThanhPho.Text = DTO.Global.ChiNhanh.TenThanhPho;

                chooseDistrict.Visibility = Visibility.Collapsed;
                txtTenQuan.Visibility = Visibility.Visible;
                txtTenQuan.IsEnabled = false;
                txtTenQuan.Text = DTO.Global.ChiNhanh.TenQuan;

                chooseWard.Visibility = Visibility.Collapsed;
                txtTenPhuong.Visibility = Visibility.Visible;
                txtTenPhuong.IsEnabled = false;
                txtTenPhuong.Text = DTO.Global.ChiNhanh.TenPhuong;

                FlowDocument flow = new FlowDocument();
                flow.Blocks.Add(new Paragraph(new Run(DTO.Global.ChiNhanh.TenDuong)));
                note.Document = flow;
                note.IsEnabled = false;

                if (DTO.Global.ThanhVien != null)
                {
                    txtTenNguoiNhan.Text = DTO.Global.ThanhVien.HoTen;
                    txtTenNguoiNhan.IsEnabled = false;
                } else
                {
                    txtTenNguoiNhan.Text = "";
                    txtTenNguoiNhan.IsEnabled = true;
                }

            }
        }
    }
}

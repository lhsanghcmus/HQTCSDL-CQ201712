﻿using System;
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
    /// Interaction logic for TinhTien.xaml
    /// </summary>
    public partial class TinhTien : Window
    {
        public DTO.MonAn[] ListMonAnDuocChon;
        public DTO.ThongTinThanhToan ThongTinThanhToan;
        public DTO.ThongTinTien ThongTinTien;
        public TinhTien()
        {
            InitializeComponent();
            ThongTinThanhToan = new DTO.ThongTinThanhToan();
        }

        private void ListViewItemSelected_Loaded(object sender, RoutedEventArgs e)
        {
            int n = ListMonAnDuocChon.Length;
            for (int i=0;i<n;i++)
            {
                ListMonAnDuocChon[i].TongTien = ListMonAnDuocChon[i].DonGia * ListMonAnDuocChon[i].SoLuongDuocChon;
            }
            listViewItemSelected.ItemsSource = ListMonAnDuocChon;
            
        }

        public void ShowThongTinTien()
        {
            ThongTinTien = BUS.ThongTinThanhToan.GetThongTinTien(ThongTinThanhToan);
            txtGiamGia.Text = ThongTinTien.GiamGia.ToString();
            txtPhiVanChuyen.Text = ThongTinTien.PhiVanChuyen.ToString();
            txtTongTamTinh.Text = ThongTinTien.TongTamTinh.ToString();
            txtTongTien.Text = ThongTinTien.TongTien.ToString();
        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            ChonDiaChi tmp = (ChonDiaChi)DTO.Global.ScreenMapping["Chon Dia Chi"];
            Visibility = Visibility.Hidden;
            tmp.ShowDialog();
          
        }

        private void DatMon_Click(object sender, RoutedEventArgs e)
        {
            int MaLoi = BUS.Action.DatMon(ThongTinTien);
            if (MaLoi == 0)
            {
                MessageBox.Show("Thành công");
            } else
            {
                MessageBox.Show("Lỗi: " + MaLoi.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DTO
{
    public class MonAn
    {
        private int maMon;
        private string tenMon;
        private int maLoai;
        private double donGia;
        private int soLuong;
        private BitmapImage hinhAnh;
        private int soLuongDuocChon;
        private double tongTien;

        public int MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public BitmapImage HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int SoLuongDuocChon { get => soLuongDuocChon; set => soLuongDuocChon = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }

        public static BitmapImage BitmapImageFromBytes(byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        public MonAn()
        {
            MaMon = MaLoai = SoLuong = SoLuongDuocChon = 0;
            TenMon = "";
            DonGia = 0;
            TongTien = 0;
        }
        public MonAn Clone()
        {
            MonAn t = new MonAn();
            t.soLuong = this.soLuong;
            t.SoLuongDuocChon = this.SoLuongDuocChon;
            t.maMon = this.maMon;
            t.tenMon = this.tenMon;
            t.donGia = this.donGia;
            return t;
        }
    }
}

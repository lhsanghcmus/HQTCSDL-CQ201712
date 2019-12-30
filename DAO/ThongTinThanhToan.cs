using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThongTinThanhToan
    {
        public static DTO.ThongTinTien GetThongTinTien(DTO.ThongTinThanhToan info)
        {
            DataTable danhSach = new DataTable();
            danhSach.Columns.Add("MAMON", typeof(int));
            danhSach.Columns.Add("SOLUONG", typeof(int));

            int n = info.ListMonAnDuocChon.Length;
            for (int i=0;i<n;i++)
            {
                DataRow row = danhSach.NewRow();
                row["MAMON"] = info.ListMonAnDuocChon[i].MaMon;
                row["SOLUONG"] = info.ListMonAnDuocChon[i].SoLuongDuocChon;
                danhSach.Rows.Add(row);
            }

            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("Sp_TinhToanChiPhi", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DanhSach", danhSach);
            cmd.Parameters.AddWithValue("@TenDuong", info.TenDuong);
            cmd.Parameters.AddWithValue("@TenPhuong", info.TenPhuong);
            cmd.Parameters.AddWithValue("@TenQuan", info.TenQuan);
            cmd.Parameters.AddWithValue("@TenThanhPho", info.TenThanhPho);
            cmd.Parameters.AddWithValue("@TenNguoiNhan", info.TenNguoiNhan);
            cmd.Parameters.AddWithValue("@TenNguoiDat", info.TenNguoiDat);
            cmd.Parameters.AddWithValue("@SDTLienLac", info.SdtLienLac);
            cmd.Parameters.AddWithValue("@MaThanhVien", info.MaThanhVien);
            cmd.Parameters.AddWithValue("@MaChiNhanh", info.MaChiNhanh);
            cmd.Parameters.AddWithValue("@HinhThuc", info.HinhThuc);
            cmd.Parameters.AddWithValue("@Loai", info.Loai);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", info.MaKhuyenMai);

            cmd.Parameters.AddWithValue("@TongTamTinh", 0);
            cmd.Parameters["@TongTamTinh"].Direction = ParameterDirection.Output;


            cmd.Parameters.AddWithValue("@PhiVanChuyen", 0);
            cmd.Parameters["@PhiVanChuyen"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@GiamGia", 0);
            cmd.Parameters["@GiamGia"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@TongTien", 0);
            cmd.Parameters["@TongTien"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@MaLoi", 0);
            cmd.Parameters["@MaLoi"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@MaDonCuoiCung", 0);
            cmd.Parameters["@MaDonCuoiCung"].Direction = ParameterDirection.Output;

            DTO.ThongTinTien result = null;
            try
            {
                cmd.ExecuteNonQuery();
                result = new DTO.ThongTinTien();

                result.TongTamTinh = double.Parse(cmd.Parameters["@TongTamTinh"].Value.ToString());
                result.PhiVanChuyen = double.Parse(cmd.Parameters["@PhiVanChuyen"].Value.ToString());
                result.GiamGia = double.Parse(cmd.Parameters["@GiamGia"].Value.ToString());
                result.TongTien = double.Parse(cmd.Parameters["@TongTien"].Value.ToString());
                result.MaLoi = int.Parse(cmd.Parameters["@MaLoi"].Value.ToString());
                result.MaDonCuoiCung = int.Parse(cmd.Parameters["@MaDonCuoiCung"].Value.ToString());

            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                Console.WriteLine(e);
            }
            DataProvider.CloseConnection(con);
            return result;
        }
    }
}

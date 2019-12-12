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
using DTO;
namespace GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cancelLogin(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            string userName = txtUser.Text;
            string passWord = txtPassWord.Password;

            DTO.NhanVien result = BUS.NhanVien.GetNhanVien(userName, passWord);
          // 
            if (result != null)
            {
                {
                    var window = new MainWindow();
                    window.setTypeUser(2);
                    window.setUserInfo2(result);
                    window.Show();
                    this.Close();
                }
                
            }
            else
            {
                DTO.ThanhVien result1 = BUS.ThanhVien.GetThanhVien(userName, passWord);
                if (result1 != null)
                {
                    {
                        var window = new MainWindow();
                        window.setTypeUser(1);
                        window.setUserInfo(result1);
                        window.Show();
                        this.Close();
                    }

                }
               // DTO.ThanhVien result1 = BUS.ThanhVien.GetThanhVien(userName, passWord);
               else
                MessageBox.Show("Đăng nhập thất bại","Thông báo",MessageBoxButton.OK);
                //  

                //else
                // {
               // if (result != null)
                                  

                //         if (result1 == null)
                //         {
                //             MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButton.OK);
                //         }
                //         else
                //         {
                //             
                //         }

                // }

            }


        }
    }
}

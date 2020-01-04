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
    /// Interaction logic for QuanLyLoi.xaml
    /// </summary>
    public partial class QuanLyLoi : Page
    {
        public QuanLyLoi()
        {
            InitializeComponent();
        }

        private void CkbLostUpdate1_Click(object sender, RoutedEventArgs e)
        {
          
            if (ckbLostUpdate1.IsChecked == true)
            {
                Global.typeOfErr = 1;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
            } else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbLostUpdate3_Click(object sender, RoutedEventArgs e)
        {
            if (ckbLostUpdate3.IsChecked == true)
            {
                Global.typeOfErr = 3;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbLostUpdate2_Click(object sender, RoutedEventArgs e)
        {
            if (ckbLostUpdate2.IsChecked == true)
            {
                Global.typeOfErr = 2;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbDirtyRead1_Click(object sender, RoutedEventArgs e)
        {
           // Global.typeOfErr = 7;
            if (ckbDirtyRead1.IsChecked == true)
            {
                Global.typeOfErr = 7;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;

                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;

            } else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbDirtyRead2_Click(object sender, RoutedEventArgs e)
        {
            if (ckbDirtyRead2.IsChecked == true)
            {
                Global.typeOfErr = 8;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;

                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbDirtyRead3_Click(object sender, RoutedEventArgs e)
        {
            if (ckbDirtyRead3.IsChecked == true)
            {
                Global.typeOfErr = 9;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;

                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbUnrepeatableRead1_Click(object sender, RoutedEventArgs e)
        {
           // Global.typeOfErr = 10;
            if (ckbUnrepeatableRead1.IsChecked == true)
            {
                Global.typeOfErr = 10;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
            } else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbUnrepeatableRead2_Click(object sender, RoutedEventArgs e)
        {
            if (ckbUnrepeatableRead2.IsChecked == true)
            {
                Global.typeOfErr = 11;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbUnrepeatableRead3_Click(object sender, RoutedEventArgs e)
        {
            if (ckbUnrepeatableRead3.IsChecked == true)
            {
                Global.typeOfErr = 12;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbPhantom1_Click(object sender, RoutedEventArgs e)
        {
           
            if (ckbPhantom1.IsChecked == true)
            {
                Global.typeOfErr = 4;

                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;

            } else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbPhantom2_Click(object sender, RoutedEventArgs e)
        {
           
            if (ckbPhantom2.IsChecked == true)
            {
                Global.typeOfErr = 5;

                ckbPhantom1.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void CkbPhantom3_Click(object sender, RoutedEventArgs e)
        {
            if (ckbPhantom3.IsChecked == true)
            {
                Global.typeOfErr = 6;

                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbDirtyRead1.IsChecked = false;
                ckbDirtyRead2.IsChecked = false;
                ckbDirtyRead3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;
                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void ClbDeadlock1_Click(object sender, RoutedEventArgs e)
        {
           // Global.typeOfErr = 13;
            if (clbDeadlock1.IsChecked == true)
            {
                Global.typeOfErr = 13;
                clbDeadlock2.IsChecked = false;
                clbDeadlock3.IsChecked = false;

                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;

            } else
            {
                Global.typeOfErr = 0;
            }
        }

        private void ClbDeadlock2_Click(object sender, RoutedEventArgs e)
        {
            if (clbDeadlock2.IsChecked == true)
            {
                Global.typeOfErr = 14;
                clbDeadlock1.IsChecked = false;
                clbDeadlock3.IsChecked = false;

                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void ClbDeadlock3_Click(object sender, RoutedEventArgs e)
        {
            if (clbDeadlock3.IsChecked == true)
            {
                Global.typeOfErr = 15;
                clbDeadlock1.IsChecked = false;
                clbDeadlock2.IsChecked = false;

                ckbLostUpdate1.IsChecked = false;
                ckbLostUpdate2.IsChecked = false;
                ckbLostUpdate3.IsChecked = false;
                ckbPhantom1.IsChecked = false;
                ckbPhantom2.IsChecked = false;
                ckbPhantom3.IsChecked = false;
                ckbUnrepeatableRead1.IsChecked = false;
                ckbUnrepeatableRead2.IsChecked = false;
                ckbUnrepeatableRead3.IsChecked = false;

            }
            else
            {
                Global.typeOfErr = 0;
            }
        }

        private void Fixed_Click(object sender, RoutedEventArgs e)
        {
          //  Global.isFixed = true;
            if (@fixed.IsChecked == true)
            {
                Global.isFixed = true;
                notFixed.IsChecked = false;
            } else
            {
                Global.isFixed = false;
               
            }
        }

        private void NotFixed_Click(object sender, RoutedEventArgs e)
        {
            //Global.isFixed = false;
            if (notFixed.IsChecked == true)
            {
                Global.isFixed = false;
                @fixed.IsChecked = false;
            } else
            {
                Global.isFixed = false;
            }
        }
    }
}

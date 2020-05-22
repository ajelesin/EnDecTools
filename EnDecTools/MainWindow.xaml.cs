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

namespace EnDecTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void B64toHexDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var src = B64toHexSrc.Text;
                string dst = string.Empty;

                if (string.IsNullOrWhiteSpace(src)) return;

                var bytes = Convert.FromBase64String(src);
                dst = ByteArrayToHexString(bytes);

                B64toHexDst.Text = dst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Hex2B64Do_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var src = Hex2B64Src.Text;
                string dst = string.Empty;

                if (string.IsNullOrWhiteSpace(src)) return;

                var bytes = HexStringToByteArray(src);                
                dst = Convert.ToBase64String(bytes);

                Hex2B64Dst.Text = dst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Txt2HexDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var src = Txt2HexSrc.Text;
                string dst = string.Empty;

                if (string.IsNullOrWhiteSpace(src)) return;

                var bytes = Encoding.UTF8.GetBytes(src);
                dst = ByteArrayToHexString(bytes);

                Txt2HexDst.Text = dst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Hex2TxtDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var src = Hex2TxtSrc.Text;
                string dst = string.Empty;

                if (string.IsNullOrWhiteSpace(src)) return;

                var bytes = HexStringToByteArray(src);
                dst = Encoding.UTF8.GetString(bytes);

                Hex2TxtDst.Text = dst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region utils
        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        #endregion
    }
}

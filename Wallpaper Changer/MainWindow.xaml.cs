using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wallpaper_Changer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 1;
        public const int SPIF_SENDCHANGE = 2;
        string wallpaper = string.Empty;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaper, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Images (*.png *.jpeg *.jpg *.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*\"";


            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                wallpaper = dlg.FileName;
                textBox1.Text = dlg.FileName;
                img.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
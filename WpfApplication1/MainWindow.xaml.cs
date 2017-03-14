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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SpisokTurnirov st = new SpisokTurnirov();
            st.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Soperniki s = new Soperniki();
            s.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Itog i = new Itog();
            i.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            FileStream fl = new FileStream("C:\\Users\\sevam\\Desktop\\turnir.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fl);


        }

    }
}

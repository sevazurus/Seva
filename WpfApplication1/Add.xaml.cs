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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
        private Igrok player = new Igrok();
        public Igrok Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }
        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text!="" && textBox1.Text!="" && textBox2.Text!="")
            {
                player.Surname = textBox.Text;
                player.Name = textBox1.Text;
                player.Rating = int.Parse(textBox2.Text);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

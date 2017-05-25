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
            FileStream fs = new FileStream("players.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                Igrok igrok = new Igrok();
                string[] line = new string[3];
                line = sr.ReadLine().Split(' ');
                igrok.Surname = line[0];
                igrok.Name = line[1];
                igrok.Rating = int.Parse(line[2]);
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream("games.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fs1);
            while (!sr1.EndOfStream)
            {
                Game game = new Game();
                Igrok igrok = new Igrok();
                Igrok igrok2 = new Igrok();
                game.Player1 = igrok;
                game.Player2 = igrok2;
                string[] line = new string[7];
                line = sr1.ReadLine().Split(' ');
                /*game.Player1.Rating = int.Parse(line[0]);
                game.Player1.Surname = line[1];
                game.Player1.Name = line[2];
                game.Score = line[3];
                game.Player2.Surname = line[4];
                game.Player2.Name = line[5];
                game.Player2.Rating = int.Parse(line[6]);*/
            }
            sr1.Close();
            fs1.Close();
            InitializeComponent();
        }
        private List<Igrok> players = new List<Igrok>();
        private List<Game> games = new List<Game>();

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            if (add.DialogResult==true)
            {
                players.Add(add.Player);
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            delete.ShowDialog();
            if (delete.DialogResult==true)
            {
                List<Igrok> newplayers = new List<Igrok>(0);
                foreach (Igrok player in players)
                {
                    if (player.Surname != delete.textBox.Text || player.Name != delete.textBox1.Text)
                    {
                        newplayers.Add(player);
                    }
                }
                players = newplayers;
            }
        }

        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
            if (search.DialogResult==true)
            {
                listBox.Items.Clear();
                bool ok = false;
                foreach (Game game in games)
                {
                    if (game.Player1.Surname == search.textBox.Text && game.Player1.Name == search.textBox1.Text)
                    {
                        listBox.Items.Add(game.Player1 + " " + game.Score + " " + game.Player2);
                        ok = true;
                    }
                    else if (game.Player2.Surname == search.textBox.Text && game.Player2.Name == search.textBox1.Text)
                    {
                        listBox.Items.Add(game.Player1 + " " + game.Score + " " + game.Player2);
                        ok = true;
                    }
                }
                if (ok==false)
                {
                    listBox.Items.Add("Ничего не найдено");
                }
            }
        }

        private void addgamebutton_Click(object sender, RoutedEventArgs e)
        {
            AddGame add = new AddGame();
            add.ShowDialog();
            if (add.DialogResult==true)
            {
                Game game = new Game();
                game.Player1.Surname = add.textBox.Text;
                game.Player1.Name = add.textBox1.Text;
                game.Player1.Rating = int.Parse(add.textBox2.Text);
                game.Player2.Surname = add.textBox3.Text;
                game.Player2.Name = add.textBox4.Text;
                game.Player2.Rating = int.Parse(add.textBox5.Text);
                game.Score = add.textBox6.Text;
                games.Add(game);
            }
        }

        private void searchgamebutton_Click(object sender, RoutedEventArgs e)
        {
            SearchGame search = new SearchGame();
            search.ShowDialog();
            bool ok = false;
            if (search.DialogResult==true)
            {
                listBox.Items.Clear();
                foreach (Game game in games)
                {
                    if (game.Player1.Surname == search.textBox.Text && game.Player1.Name == search.textBox1.Text && game.Player2.Surname==search.textBox2.Text && game.Player2.Name == search.textBox3.Text)
                    {
                        listBox.Items.Add(game.Player1.Rating + " " + game.Player1.Surname + " " + game.Player1.Name + " " + game.Score + " " + game.Player2.Surname + " " + game.Player2.Name + " " + game.Player2.Rating);
                        ok = true;
                    }
                }
            }
            if (ok == false)
            {
                listBox.Items.Add("Не найдено партий");
            }
        }
    }
}

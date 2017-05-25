using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Game
    {
        private Igrok player1 = new Igrok();
        public Igrok Player1
        {
            get
            {
                return player1;
            }
            set
            {
                player1 = value;
            }
        }
        private Igrok player2 = new Igrok();
        public Igrok Player2
        {
            get
            {
                return player2;
            }
            set
            {
                player2 = value;
            }
        }
        private string score;
        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
    }
}

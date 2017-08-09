using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kolobok : GameFiringObject
    {
        private int score = 0;

        public bool dead = false;

        public event Action OnScoreChanged;

        public int Score
        {
            set
            {
                this.score = value;
                OnScoreChanged?.Invoke();
            }
            get
            {
                return score;
            }
        }

        public override string ToString()
        {
            return "Kolobok";
        }
    }
}

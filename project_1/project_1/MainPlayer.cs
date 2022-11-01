using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    abstract class Participant
    {
        public int wins { get; set; }
        float _winRate;
        protected RockPaperScissors selection;

        protected float winRate
        {
            get
            {
                return _winRate;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("value cannot be less than 0 or greater than 100");
                }
                _winRate = value;
            }
        }
        public void PrintWinRate()
        {
            this.winRate = ((float)wins / Game.Info.GamesPlayed) * 100;
            string winRate = "win rate: " + this.winRate.ToString() + "%";
            Console.WriteLine(winRate.PadLeft(50));
        }

        public abstract RockPaperScissors Select();
    }

}

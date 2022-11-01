using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    class Computer : Participant
    {

        public override RockPaperScissors Select()
        {
            Random rand = new Random();
            selection = (RockPaperScissors)rand.Next(0, Enum.GetValues(typeof(RockPaperScissors)).Length);
            return selection;
        }
    }
}

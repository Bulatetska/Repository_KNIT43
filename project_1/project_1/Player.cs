using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    class Player : Participant
    {
        public override RockPaperScissors Select()
        {
            bool isValid;
            string input;

            do
            {
                Console.Write("Please enter a valid selection: ");
                input = Console.ReadLine().Trim();
                isValid = Enum.TryParse<RockPaperScissors>(input, true, out selection);
            } while (!isValid);

            return selection;
        }
    }
}

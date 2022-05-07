using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace SymfosDevTest_RockPaperScissors
{
    public class PlayGame
    {
        public static Moves MakeMove(string lastMove, string difficulty)
        {
            Moves move = Moves.Rock;

            Difficulty diff = Common.Enum.GetEnum<Difficulty>(difficulty);

            switch (diff)
            {
                case Difficulty.Begginer:
                    move = MakeBegginerMove(lastMove);
                    break;
                case Difficulty.Intermediate:
                    move = MakeIntermdeiateMove(lastMove);
                    break;
                case Difficulty.Advanced:
                    move = MakeAdvancedMove(lastMove);
                    break;
                default:
                    break;
            }

            return move;
        }

        private static Moves MakeBegginerMove(string lastMove)
        {
            return Moves.Rock;
        }

        private static Moves MakeIntermdeiateMove(string lastMove)
        {
            return Moves.Rock;
        }

        private static Moves MakeAdvancedMove(string lastMove)
        {
            return Moves.Rock;
        }
    }
}

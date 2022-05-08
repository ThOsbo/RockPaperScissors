using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SymfosDevTest_RockPaperScissors
{
    public class PlayGame
    {
        public static string MakeMove(string lastMove, string difficulty)
        {
            string move = default(Common.Moves).ToString();

            Common.Difficulty difficultyEnumValue;

            if (Common.Enum.TryGetEnum(difficulty, out difficultyEnumValue)) 
            {
                switch (difficultyEnumValue)
                {
                    case Common.Difficulty.Begginer:
                        move = MakeBegginerMove(lastMove);
                        break;
                    case Common.Difficulty.Intermediate:
                        move = MakeIntermdeiateMove(lastMove);
                        break;
                    case Common.Difficulty.Advanced:
                        move = MakeAdvancedMove(lastMove);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //makes a random move if an invalid difficulty is passed
                move = MakeRandomMove();
            }

            return move;
        }

        public static string MakeRandomMove()
        {
            return Enum.GetName(typeof(Common.Moves), new Random().Next() % 3);
        }

        private static string MakeBegginerMove(string lastMove)
        {
            return Common.Moves.Rock.ToString();
        }

        private static string MakeIntermdeiateMove(string lastMove)
        {
            return Common.Moves.Rock.ToString();
        }

        private static string MakeAdvancedMove(string lastMove)
        {
            return Common.Moves.Rock.ToString();
        }
    }
}

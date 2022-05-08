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

            Common.Moves lastMoveEnumValue;
            Common.Difficulty difficultyEnumValue;

            if (Common.Enum.TryGetEnum(difficulty, out difficultyEnumValue) && Common.Enum.TryGetEnum(lastMove, out lastMoveEnumValue)) 
            {
                switch (difficultyEnumValue)
                {
                    case Common.Difficulty.Begginer:
                        move = MakeBegginerMove(lastMoveEnumValue);
                        break;
                    case Common.Difficulty.Intermediate:
                        move = MakeIntermdeiateMove(lastMoveEnumValue);
                        break;
                    case Common.Difficulty.Advanced:
                        move = MakeAdvancedMove(lastMoveEnumValue);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //makes a random move if an invalid difficulty is passed or an invalid last move.
                //first move will always be random
                move = MakeRandomMove();
            }

            return move;
        }

        public static string MakeRandomMove()
        {
            return Enum.GetName(typeof(Common.Moves), new Random().Next() % 3);
        }

        private static string MakeBegginerMove(Common.Moves lastMove)
        {
            return Common.Moves.Rock.ToString();
        }

        private static string MakeIntermdeiateMove(Common.Moves lastMove)
        {
            return Common.Moves.Rock.ToString();
        }

        private static string MakeAdvancedMove(Common.Moves lastMove)
        {
            return Common.Moves.Rock.ToString();
        }
    }
}

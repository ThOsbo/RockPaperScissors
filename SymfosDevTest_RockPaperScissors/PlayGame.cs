using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SymfosDevTest_RockPaperScissors
{
    public class PlayGame
    {
        public static string MakeMove(string lastMove, int gamesPlayed, string difficulty)
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
                        move = MakeIntermdeiateMove(lastMoveEnumValue, gamesPlayed);
                        break;
                    case Common.Difficulty.Advanced:
                        move = MakeAdvancedMove(lastMoveEnumValue, gamesPlayed);
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
            //Strategy: returns the move that would beat the last move.
            string moveToReturn;

            switch (lastMove)
            {
                case Common.Moves.Rock:
                    moveToReturn = Common.Moves.Paper.ToString();
                    break;
                case Common.Moves.Paper:
                    moveToReturn = Common.Moves.Scissors.ToString();
                    break;
                case Common.Moves.Scissors:
                    moveToReturn = Common.Moves.Rock.ToString();
                    break;
                default:
                    moveToReturn = MakeRandomMove();
                    break;
            }

            return moveToReturn;
        }

        private static string MakeIntermdeiateMove(Common.Moves lastMove, int gamesPlayed)
        {
            string moveToReturn;

            switch (lastMove)
            {
                case Common.Moves.Rock:
                    moveToReturn = "";
                    break;
                case Common.Moves.Paper:
                    moveToReturn = "";
                    break;
                case Common.Moves.Scissors:
                    moveToReturn = "";
                    break;
                default:
                    moveToReturn = MakeRandomMove();
                    break;
            }

            return moveToReturn;
        }

        private static string MakeAdvancedMove(Common.Moves lastMove, int gamesPlayed)
        {
            string moveToReturn;

            switch (lastMove)
            {
                case Common.Moves.Rock:
                    moveToReturn = "";
                    break;
                case Common.Moves.Paper:
                    moveToReturn = "";
                    break;
                case Common.Moves.Scissors:
                    moveToReturn = "";
                    break;
                default:
                    moveToReturn = MakeRandomMove();
                    break;
            }

            return moveToReturn;
        }
    }
}

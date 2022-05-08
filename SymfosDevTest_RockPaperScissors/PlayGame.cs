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
            /*
             * Strategy:
             * returns the move that would beat the opponents last move.
             */

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
            /*
             * Strategy:
             * returns the move that would beat the opponents last move every odd turn, 
             * returns the same move as the opponents last move every even turn
             */

            string moveToReturn;

            switch (lastMove)
            {
                case Common.Moves.Rock:
                    moveToReturn = Common.Moves.Paper.ToString();
                    if (gamesPlayed % 2 == 0)
                    {
                        moveToReturn = Common.Moves.Rock.ToString();
                    }
                    break;
                case Common.Moves.Paper:
                    moveToReturn = Common.Moves.Scissors.ToString();
                    if (gamesPlayed % 2 == 0)
                    {
                        moveToReturn = Common.Moves.Paper.ToString();
                    }
                    break;
                case Common.Moves.Scissors:
                    moveToReturn = Common.Moves.Rock.ToString();
                    if (gamesPlayed % 2 == 0)
                    {
                        moveToReturn = Common.Moves.Scissors.ToString();
                    }
                    break;
                default:
                    moveToReturn = MakeRandomMove();
                    break;
            }

            return moveToReturn;
        }

        private static string MakeAdvancedMove(Common.Moves lastMove, int gamesPlayed)
        {
            /*
             * Strategy:
             * Makes the same move as the opponents last move for two turns
             * then on the third move choses the move that will lose to the opponents last move.
             * Every fourth turn makes a random move.
             */

            string moveToReturn;

            if (gamesPlayed % 4 == 0)
            {
                moveToReturn = MakeRandomMove();
            }
            else
            {
                switch (lastMove)
                {
                    case Common.Moves.Rock:
                        if (gamesPlayed % 3 < 2)
                        {
                            moveToReturn = Common.Moves.Rock.ToString();
                        }
                        else
                        {
                            moveToReturn = Common.Moves.Scissors.ToString();
                        }
                        break;
                    case Common.Moves.Paper:
                        if (gamesPlayed % 3 < 2)
                        {
                            moveToReturn = Common.Moves.Paper.ToString();
                        }
                        else
                        {
                            moveToReturn = Common.Moves.Rock.ToString();
                        }
                        break;
                    case Common.Moves.Scissors:
                        if (gamesPlayed % 3 < 2)
                        {
                            moveToReturn = Common.Moves.Scissors.ToString();
                        }
                        else
                        {
                            moveToReturn = Common.Moves.Paper.ToString();
                        }
                        break;
                    default:
                        moveToReturn = MakeRandomMove();
                        break;
                }
            }

            return moveToReturn;
        }
    }
}

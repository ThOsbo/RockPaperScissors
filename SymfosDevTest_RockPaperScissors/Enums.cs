using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public enum Difficulty
    {
        Begginer,
        Intermediate,
        Advanced
    }

    public enum PlayMode
    {
        PlayerVComputer,
        ComputerVComputer
    }

    public enum Moves
    {
        Rock,
        Paper,
        Scissors
    }

    public class Enum
    {
        public static bool TryGetEnum<T>(string value, out T enumValue)
        {
            //Converts a string to an enum
            bool isSuccess = false;
            enumValue = default(T);

            try
            {
                foreach (T item in System.Enum.GetValues(typeof(T)))
                {
                    if (item.ToString() == value)
                    {
                        enumValue = item;
                        isSuccess = true;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {

            }

            return isSuccess;
        }
    }
    
}

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
        public static T GetEnum<T>(string value)
        {
            //Converts a string to an enum
            T enumValue = default(T);

            foreach (T item in System.Enum.GetValues(typeof(T)))
            {
                if (item.ToString() == value)
                {
                    enumValue = item;
                    break;
                }
            }

            return enumValue;
        }
    }
    
}

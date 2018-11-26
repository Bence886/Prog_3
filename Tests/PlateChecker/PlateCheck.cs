using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateChecker
{
    public class PlateCheck
    {

        private static int plateLength = 7;
        private char separator = '-';
        private int separatorLocation = 3;

        public bool Check(string plate)
        {
            if (plate == null)
            {
                throw new ArgumentNullException("plate");
            }

            if (plate.Length != plateLength)
            {
                throw new ArgumentOutOfRangeException("Input text is not the correct length.");
            }

            if (plate[separatorLocation] != separator)
            {
                return false;
            }

            for (int i = 0; i < separatorLocation; i++)
            {
                if (!Char.IsLetter(plate[i]))
                {
                    return false;
                }
            }

            for (int i = separatorLocation + 1; i < plateLength; i++)
            {
                if (!Char.IsNumber(plate[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Convertion
    {
        public static string BytesToReadable(long length)
        {
            if (length < 1000)
            {
                return $"{length} B";
            }
            else if (length < 1_000_000)
            {
                return $"{Math.Round(length / 1_000.0d, 1)} KB";
            }
            else if (length < 100_000_000)
            {
                return $"{Math.Round(length / 100_000.0d, 1)} MB";
            }
            else if (length < 100_000_000_000)
            {
                return $"{Math.Round(length / 100_000_000.0d, 1)} GB";
            }
            else if (length < 100_000_000_000_000)
            {
                return $"{Math.Round(length / 100_000_000_000.0d, 1)} TB";
            }
            else if(length < 100_000_000_000_000_000)
            {
                return $"{Math.Round(length / 100_000_000_000_000.0d, 1)} PB";
            }
            return "";
        }
    }
}

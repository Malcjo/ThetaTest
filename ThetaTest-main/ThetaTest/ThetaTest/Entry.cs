using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThetaTest
{
    public class Entry
    {
        int day;
        int maxTemp;
        int minTemp;
        int diff;
        public Entry(int day, int max, int min)
        {
            this.day = day;
            this.maxTemp = max;
            this.minTemp = min;
            diff = Math.Abs(maxTemp - minTemp);
        }

        public int getDifference()
        {
            return diff;
        }

        public int getDay()
        {
            return day;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimulationProject.Classes.UtilClasses
{
    // SZ
    // this is used to debug the performance of the simulation
    internal class PerformanceClock
    {
        // performance check name
        public String name;

        // in miliseconds
        public long start;

        // in miliseconds - result of start - end
        public int lastEnd;

        // average since this object has been created
        public int finishedTimes = 1;
        public int average = 1;

        //counter
        public int count = 0;

        // color in which it is rendered
        public Color color;

        public void clearCount ()
        {
            count = 0;
        }

        public PerformanceClock (String name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public long getMiliseconds ()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public void startClock()
        {
            this.start = this.getMiliseconds();
        }

        public void endClock()
        {
            this.lastEnd = (int)Math.Floor((decimal)(this.getMiliseconds() - this.start));
            this.finishedTimes += 1;
            this.average += this.lastEnd;
        }

        public int getAverage ()
        {
            return this.average / this.finishedTimes;
        }
        public String getTextOutput()
        {
            return this.name + ": " + this.lastEnd+ "ms | " + this.getAverage() + "ms";
        }

        public String getTextOutputCount()
        {
            return this.name + ": " + this.count;
        }

    }
}

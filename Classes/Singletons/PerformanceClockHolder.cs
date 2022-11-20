using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationProject.Classes.UtilClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimulationProject.Classes.Singletons
{
    internal static class PerformanceClockHolder
    {
        public static PerformanceClock drawPerformance = new PerformanceClock("Draw Performance", Color.PaleVioletRed);
        public static PerformanceClock drawCountRenderObjInstance = new PerformanceClock("Draw RenderObj Instance", Color.IndianRed);
        public static PerformanceClock drawReuseRenderObj = new PerformanceClock("Draw RenderObj ReUsed", Color.IndianRed);
        public static PerformanceClock addToRenderer = new PerformanceClock("AddToRenderer Performance", Color.LightBlue);
        public static PerformanceClock updatePerformance = new PerformanceClock("Update Performance", Color.Yellow);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject.Classes.Singletons
{
    public static class Settings
    {
        public static int screenX = 1420;
        public static int screenY = 820;
        public static int pixelRatio = 1;

        public static int getScreenX()
        {
            return screenX * pixelRatio;
        }
        public static int getScreenY()
        {
            return screenY * pixelRatio;
        }
    }
}

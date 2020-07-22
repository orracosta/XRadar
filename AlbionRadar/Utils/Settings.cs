using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    public static class Settings
    {
        public static void saveSettings(Options form)
        {
            AppSettings s = new AppSettings();

            s.radarPosX = (int)form.radarPosX.Value;
            s.radarPosY = (int)form.radarPosY.Value;
            s.showRadar = form.showRadar.Checked;

            s.Save();

        }
        public static void loadSettings(Options form)
        {
            AppSettings s = new AppSettings();

            form.radarPosX.Value = s.radarPosX;
            form.radarPosY.Value = s.radarPosY;
            form.showRadar.Checked = s.showRadar;
        }
    }
}

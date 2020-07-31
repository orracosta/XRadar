using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar.UHWID
{
    public static class UHWID
    {
        public static string SimpleUid { get; private set; }

        static UHWID()
        {
            var volumeSerial = DiskId.GetDiskId();
            var cpuId = CpuId.GetCpuId();
            SimpleUid = volumeSerial + cpuId;
        }
    }
}

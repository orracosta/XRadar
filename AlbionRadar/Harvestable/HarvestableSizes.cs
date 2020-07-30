using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    public static class HarvestableSizes
    {
        public static readonly Dictionary<int, int> sizes = new Dictionary<int, int>
        {
            { 2, 9 },
            { 3, 9 },
            { 4, 6 },
            { 5, 5 },
            { 6, 5 },
            { 7, 3 },
            { 8, 2 }
        };

        public static readonly Dictionary<int, int> charges = new Dictionary<int, int>
        {
            { 2, 3 },
            { 3, 3 },
            { 4, 2 },
            { 5, 1 },
            { 6, 1 },
            { 7, 1 },
            { 8, 1 }
        };
    }
}

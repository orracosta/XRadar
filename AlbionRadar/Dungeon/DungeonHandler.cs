using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
{
    public class DungeonHandler
    {
        private ConcurrentDictionary<int, Dungeon> dungeonList;
        public DungeonHandler()
        {
            dungeonList = new ConcurrentDictionary<int, Dungeon>();
        }
        public void AddDungeon(int id, Single posX, Single posY, string type)
        {
            if (!dungeonList.Any(x => x.Key == id))
            {
                Dungeon d = new Dungeon(id, posX, posY, type);
                dungeonList.TryAdd(id, d);
            }
        }
        public bool RemoveDungeon(int id)
        {
            return dungeonList.TryRemove(id, out _);
        }
        internal ConcurrentDictionary<int, Dungeon> DungeonList
        {
            get { return dungeonList; }
        }
    }
}

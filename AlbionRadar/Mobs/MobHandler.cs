using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
{
    class MobsHandler
    {
        private ConcurrentDictionary<int, Mob> mobsList;

        public MobsHandler()
        {
            mobsList = new ConcurrentDictionary<int, Mob>();
        }

        public void AddMob(int id, int typeId, Single posX, Single posY, int health)
        {
            if (!mobsList.Any(x => x.Key == id))
            {
                Mob h = new Mob(id, typeId, posX, posY, health, 0);
                mobsList.TryAdd(id, h);
            }
        }
        public bool RemoveMob(int id)
        {
            return mobsList.TryRemove(id, out _);
        }

        internal ConcurrentDictionary<int, Mob> MobList
        {
            get { return mobsList; }
        }
        internal bool UpdateMobPosition(int id, float posX, float posY)
        {
            if (!mobsList.Any(x => x.Key == id))
                return false;

            mobsList[id].PosX = posX;
            mobsList[id].PosY = posY;

            return true;
        }
        internal void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
        {
            if (!mobsList.Any(x => x.Key == mobId))
                return;

            mobsList[mobId].EnchantmentLevel = enchantmentLevel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class MobsHandler
    {
        private List<Mob> mobsList;

        public MobsHandler()
        {
            mobsList = new List<Mob>();
        }

        public void AddMob(int id, int typeId, Single posX, Single posY, int health)
        {
            Mob h = new Mob(id, typeId, posX, posY, health, 0);
            if (!mobsList.Contains(h))
                mobsList.Add(h);
        }
        public bool RemoveMob(int id)
        {
            return mobsList.RemoveAll(x => x.Id == id) > 0;
        }

        internal List<Mob> MobList
        {
            get { return mobsList; }
        }
        internal bool UpdateMobPosition(int id, float posX, float posY)
        {
            Mob mob = mobsList.FirstOrDefault(x => x.Id == id);
            if(mob != null)
            {
                mob.PosX = posX;
                mob.PosY = posY;

                return true;
            }

            return false;
        }
        internal void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
        {
            Mob m = MobList.FirstOrDefault(x => x.Id == mobId);
            if(m != null)
                m.EnchantmentLevel = enchantmentLevel;
        }
    }
}

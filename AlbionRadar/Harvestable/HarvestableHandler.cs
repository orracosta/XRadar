using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class HarvestableHandler
    {
        private ConcurrentDictionary<int, Harvestable> harvestableList;

        public HarvestableHandler()
        {
            harvestableList = new ConcurrentDictionary<int, Harvestable>();
        }

        public void AddHarvestable(int id, byte type, byte tier, Single posX, Single posY, byte charges, byte size)
        {
            if (!harvestableList.Any(x => x.Key == id))
            {
                Harvestable h = new Harvestable(id, type, tier, posX, posY, charges, size);
                harvestableList.TryAdd(id, h);
            }
            else 
            {
                UpdateHarvestable(id, size, charges);
            }
        }
        public bool RemoveHarvestable(int id)
        {
            return harvestableList.TryRemove(id, out _);
        }
        internal ConcurrentDictionary<int, Harvestable> HarvestableList
        {
            get { return harvestableList; }
        }
        internal void UpdateHarvestable(int harvestableId, byte size, byte charges)
        {
            if (!harvestableList.Any(x => x.Key == harvestableId))
                return;

            harvestableList[harvestableId].Size = size;
            harvestableList[harvestableId].Charges = charges;
        }
    }
}

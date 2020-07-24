using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class HarvestableHandler
    {
        private List<Harvestable> harvestableList;

        public HarvestableHandler()
        {
            harvestableList = new List<Harvestable>();
        }

        public void AddHarvestable(int id, byte type, byte tier, Single posX, Single posY, byte charges, byte size)
        {
            Harvestable h = new Harvestable(id, type, tier, posX, posY, charges, size);
            if (!harvestableList.Contains(h))
            {
                harvestableList.Add(h);
            }
        }
        public bool RemoveHarvestable(int id)
        {
            return harvestableList.RemoveAll(x => x.Id == id) > 0;
        }
        internal List<Harvestable> HarvestableList
        {
            get { return harvestableList; }
        }


        internal void UpdateHarvestable(int harvestableId, byte count)
        {
            harvestableList.ForEach(h =>
            {
                if (h.Id == harvestableId)
                {

                }
            });

        }
    }
}

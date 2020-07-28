using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class MobInfo
    {

        public static List<MobInfo> mobsInfo = new List<MobInfo>();

        int id;
        byte tier;
        HarvestableType harvestableType;
        byte HarvestableTier;

        private MobInfo(int id, byte tier, HarvestableType harvestableType, byte HarvestableTier)
        {
            this.id = id;
            this.tier = tier;
            this.harvestableType = harvestableType;
            this.HarvestableTier = HarvestableTier;
        }
        public static void loadMobList()
        {
            int index = 0;
            dynamic jsonArray = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Properties.Resources.mobs));
            foreach (var item in jsonArray.Mobs)
            {
                if (item.Loot != null)
                {
                    if(item.Loot.Value != "" && item.Loot.Harvestable != null)
                    {
                        mobsInfo.Add(new MobInfo(index, (byte)item.tier, (HarvestableType)Enum.Parse(typeof(HarvestableType), (string)item.Loot.Harvestable.type), (byte)item.Loot.Harvestable.tier));
                    }
                }

                index++;
            }
            Console.WriteLine(mobsInfo.Count);
            Console.WriteLine(mobsInfo.Count);
        }
        public override string ToString()
        {
            return "id: " + id + " tier: " + tier;
        }
        public byte Tier
        {
            get { return tier; }
            set { tier = value; }
        }
        public HarvestableType HarvestableMobType
        {
            get { return harvestableType; }
            set { harvestableType = value; }
        }

        public static MobInfo getMobInfo(int mobId)
        {
            return mobsInfo.FirstOrDefault(m => m.id == mobId);
        }
        public string getMapInfo(int id)
        {
            MobInfo mob = mobsInfo.Find(x => x.id == id);

            if (mob == null)
                return "ERR";

            switch ((HarvestableType)mob.harvestableType)
            {
                case HarvestableType.WOOD:
                case HarvestableType.WOOD_GIANTTREE:
                case HarvestableType.WOOD_CRITTER_GREEN:
                case HarvestableType.WOOD_CRITTER_RED:
                case HarvestableType.WOOD_CRITTER_DEAD:
                case HarvestableType.WOOD_GUARDIAN_RED:
                    return "madeira";
                case HarvestableType.ROCK:
                case HarvestableType.ROCK_CRITTER_GREEN:
                case HarvestableType.ROCK_CRITTER_RED:
                case HarvestableType.ROCK_CRITTER_DEAD:
                case HarvestableType.ROCK_GUARDIAN_RED:
                    return "pedra";
                case HarvestableType.FIBER:
                case HarvestableType.FIBER_CRITTER:
                case HarvestableType.FIBER_GUARDIAN_RED:
                case HarvestableType.FIBER_GUARDIAN_DEAD:
                    return "fibra";
                case HarvestableType.HIDE:
                case HarvestableType.HIDE_FOREST:
                case HarvestableType.HIDE_STEPPE:
                case HarvestableType.HIDE_SWAMP:
                case HarvestableType.HIDE_MOUNTAIN:
                case HarvestableType.HIDE_HIGHLAND:
                case HarvestableType.HIDE_CRITTER:
                case HarvestableType.HIDE_GUARDIAN:
                    return "pelego";
                case HarvestableType.ORE:
                case HarvestableType.ORE_CRITTER_GREEN:
                case HarvestableType.ORE_CRITTER_RED:
                case HarvestableType.ORE_CRITTER_DEAD:
                case HarvestableType.ORE_GUARDIAN_RED:
                    return "minerio";
                case HarvestableType.DEADRAT:
                    return "DEAD_RAT";
                case HarvestableType.SILVERCOINS_NODE:
                case HarvestableType.SILVERCOINS_LOOT_STANDARD_TRASH:
                case HarvestableType.SILVERCOINS_LOOT_VETERAN_TRASH:
                case HarvestableType.SILVERCOINS_LOOT_ELITE_TRASH:
                case HarvestableType.SILVERCOINS_LOOT_ROAMING:
                case HarvestableType.SILVERCOINS_LOOT_ROAMING_MINIBOSS:
                case HarvestableType.SILVERCOINS_LOOT_ROAMING_BOSS:
                case HarvestableType.SILVERCOINS_LOOT_STANDARD:
                case HarvestableType.SILVERCOINS_LOOT_VETERAN:
                case HarvestableType.SILVERCOINS_LOOT_ELITE:
                case HarvestableType.SILVERCOINS_LOOT_STANDARD_MINIBOSS:
                case HarvestableType.SILVERCOINS_LOOT_VETERAN_MINIBOSS:
                case HarvestableType.SILVERCOINS_LOOT_ELITE_MINIBOSS:
                case HarvestableType.SILVERCOINS_LOOT_STANDARD_BOSS:
                case HarvestableType.SILVERCOINS_LOOT_VETERAN_BOSS:
                case HarvestableType.SILVERCOINS_LOOT_ELITE_BOSS:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_STANDARD:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_STANDARD_TRASH:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_VETERAN:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_DEMON:
                case HarvestableType.SILVERCOINS_LOOT_SARCOPHAGUS_STANDARD_MINIBOSS:
                    return "silver";
                case HarvestableType.CHEST_EXP_SILVERCOINS_LOOT_STANDARD:
                case HarvestableType.CHEST_EXP_SILVERCOINS_LOOT_VETERAN:
                    return "bau";
                default:
                    return "ERR";
            }
        }
    }
}

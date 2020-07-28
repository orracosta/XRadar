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
                case HarvestableType.WOOD_BIG:
                case HarvestableType.WOOD_GIANTTREE:
                case HarvestableType.WOOD_CRITTER_GREEN:
                case HarvestableType.WOOD_CRITTER_RED:
                case HarvestableType.WOOD_CRITTER_DEAD:
                case HarvestableType.WOOD_GUARDIAN_RED:
                case HarvestableType.WOOD_MINIGUARDIAN_RED:
                    return "madeira";
                case HarvestableType.ROCK:
                case HarvestableType.ROCK_BIG:
                case HarvestableType.ROCK_CRITTER_GREEN:
                case HarvestableType.ROCK_CRITTER_RED:
                case HarvestableType.ROCK_CRITTER_DEAD:
                case HarvestableType.ROCK_CRITTER_RANDOM_DUNGEON:
                case HarvestableType.ROCK_GUARDIAN_RED:
                case HarvestableType.ROCK_MINIGUARDIAN_RED:
                    return "pedra";
                case HarvestableType.FIBER:
                case HarvestableType.FIBER_BIG:
                case HarvestableType.FIBER_CRITTER:
                case HarvestableType.FIBER_GUARDIAN_RED:
                case HarvestableType.FIBER_GUARDIAN_DEAD:
                case HarvestableType.FIBER_MINIGUARDIAN_RED:
                    return "fibra";
                case HarvestableType.HIDE:
                case HarvestableType.HIDE_FOREST:
                case HarvestableType.HIDE_FOREST_SMALL:
                case HarvestableType.HIDE_STEPPE:
                case HarvestableType.HIDE_STEPPE_SMALL:
                case HarvestableType.HIDE_SWAMP:
                case HarvestableType.HIDE_MOUNTAIN:
                case HarvestableType.HIDE_HIGHLAND:
                case HarvestableType.HIDE_CRITTER:
                case HarvestableType.HIDE_GUARDIAN:
                case HarvestableType.HIDE_MINIGUARDIAN:
                case HarvestableType.HIDE_FOREST_BIG:
                case HarvestableType.HIDE_STEPPE_BIG:
                case HarvestableType.DEADRAT:
                    return "pelego";
                case HarvestableType.ORE:
                case HarvestableType.ORE_BIG:
                case HarvestableType.ORE_CRITTER_GREEN:
                case HarvestableType.ORE_CRITTER_RED:
                case HarvestableType.ORE_CRITTER_DEAD:
                case HarvestableType.ORE_GUARDIAN_RED:
                case HarvestableType.ORE_MINIGUARDIAN_RED:
                    return "minerio";
                case HarvestableType.SILVERCOINS_NODE:
                case HarvestableType.SILVERCOINS_NODE_RICH:
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
                case HarvestableType.SILVERCOINS_RD_STANDARD_TRASH:
                case HarvestableType.SILVERCOINS_RD_STANDARD:
                case HarvestableType.SILVERCOINS_RD_STANDARD_STANDARD:
                case HarvestableType.SILVERCOINS_RD_STANDARD_UNCOMMON:
                case HarvestableType.SILVERCOINS_RD_STANDARD_RARE:
                case HarvestableType.SILVERCOINS_RD_STANDARD_LEGENDARY:
                case HarvestableType.SILVERCOINS_RD_VETERAN_TRASH:
                case HarvestableType.SILVERCOINS_RD_VETERAN:
                case HarvestableType.SILVERCOINS_RD_VETERAN_STANDARD:
                case HarvestableType.SILVERCOINS_RD_VETERAN_UNCOMMON:
                case HarvestableType.SILVERCOINS_RD_VETERAN_RARE:
                case HarvestableType.SILVERCOINS_RD_VETERAN_LEGENDARY:
                case HarvestableType.SILVERCOINS_RD_ELITE_TRASH:
                case HarvestableType.SILVERCOINS_RD_ELITE:
                case HarvestableType.SILVERCOINS_RD_ELITE_STANDARD:
                case HarvestableType.SILVERCOINS_RD_ELITE_UNCOMMON:
                case HarvestableType.SILVERCOINS_RD_ELITE_RARE:
                case HarvestableType.SILVERCOINS_RD_ELITE_LEGENDARY:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_STANDARD:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_STANDARD_TRASH:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_VETERAN:
                case HarvestableType.SILVERCOINS_LOOT_CHEST_DEMON:
                case HarvestableType.CHEST_EXP_SILVERCOINS_LOOT_STANDARD:
                case HarvestableType.CHEST_EXP_SILVERCOINS_LOOT_VETERAN:
                case HarvestableType.SILVERCOINS_LOOT_SARCOPHAGUS_STANDARD_MINIBOSS:
                    return "silver";
                default:
                    return "ERR";
            }
        }
    }
}

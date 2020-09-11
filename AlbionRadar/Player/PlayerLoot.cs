using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
{
    class PlayerLoot
    {
        public static ConcurrentDictionary<int, PlayerLoot> listLoot = new ConcurrentDictionary<int, PlayerLoot>();
        public static int id = 0;
        public static bool canAdd = false;

        string user;
        string item;
        int amount;

        PlayerLoot(string user, string item, int amount)
        {
            this.user = user;
            this.item = item;
            this.amount = amount;
        }

        public string User { get => user; }
        public string Item { get => item; }
        public int Amount { get => amount; }

        public static void addLog(string user, string item, int amount)
        {
            listLoot.TryAdd(id++, new PlayerLoot(user, item, amount));
        }
    }
}

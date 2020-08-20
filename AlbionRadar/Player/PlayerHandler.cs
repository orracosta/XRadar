using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
{
    public class PlayerHandler
    {
        private ConcurrentDictionary<int, Player> playersInRange;
        private ConcurrentDictionary<int, int> mountsInRange;
        private Player localPlayer;

        public PlayerHandler()
        {
            playersInRange = new ConcurrentDictionary<int, Player>();
            mountsInRange = new ConcurrentDictionary<int, int>();
            localPlayer = new Player();
        }
        public void AddPlayer(Single posX, Single posY, String nickname, String guild, String alliance, int id, short[] items, short[] skills, int faction)
        {
            if (!playersInRange.Any(x => x.Key == id))
            {
                Player p = new Player(posX, posY, nickname, guild, alliance, id, items, skills, faction);
                playersInRange.TryAdd(id, p);
            }

            if(!isAllyRoyal(faction))
                Settings.needBeepSound(guild, alliance);
        }
        public void updateLocalPlayer(Single posX, Single posY, String nickname, String guild, String alliance, int faction)
        {
            localPlayer.PosX = posX;
            localPlayer.PosY = posY;
            localPlayer.Nickname = nickname;
            localPlayer.Guild = guild;
            localPlayer.Alliance = alliance;
            localPlayer.Faction = faction;
        }
        internal void UpdatePlayerEquipment(int id, short[] items, short[] skills)
        {
            if (!playersInRange.Any(x => x.Key == id))
                return;

            playersInRange[id].Items = items;
            playersInRange[id].Skills = skills;
        }
        public void AddMount(int id)
        {
            if (!mountsInRange.Any(x => x.Key == id))
                mountsInRange.TryAdd(id, id);
        }
        public bool RemovePlayer(int id)
        {
            return playersInRange.TryRemove(id, out _);
        }
        public bool RemoveMount(int id)
        {
            return mountsInRange.TryRemove(id, out _);
        }
        internal ConcurrentDictionary<int, Player> PlayersInRange
        {
            get { return playersInRange; }
        }
        internal Player LocalPlayer
        {
            get { return LocalPlayer; }
        }

        internal ConcurrentDictionary<int, int> MountsInRange 
        {
            get { return mountsInRange; }
        }

        public void UpdateLocalPlayerPosition(Single posX, Single posY)
        {
            localPlayer.PosX = posX;
            localPlayer.PosY = posY;
        }
        public void UpdatePlayerMount(int id, bool mount)
        {
            if (mount)
                AddMount(id);
            else
                RemoveMount(id);
        }
        internal bool UpdatePlayerPosition(int id, float posX, float posY)
        {
            if (!playersInRange.Any(x => x.Key == id))
                return false;

            playersInRange[id].PosX = posX;
            playersInRange[id].PosY = posY;

            return true;
        }
        public Single localPlayerPosX()
        {
            return localPlayer.PosX;
        }
        public Single localPlayerPosY()
        {
            return localPlayer.PosY;
        }
        public Player getLocalPlayer()
        {
            return localPlayer;
        }
        public bool PlayerIsMounted(int id)
        {
            return mountsInRange.Any(x => x.Key == id);
        }
        public bool isAllyRoyal(int faction)
        {
            var localFaction = localPlayer.Faction;

            if (faction == 0 || (faction == localFaction && faction != 255) || (localFaction == 0 && faction != 255))
                return true;
            else
                return false;
        }
    }
}
